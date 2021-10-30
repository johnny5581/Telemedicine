using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemedicine.Forms.Icons
{
    /// <summary>
    /// 圖示包屬性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]

    public class IconPackInfoAttribute : Attribute
    {
        public IconPackInfoAttribute(string id, Type iconEnumType)
        {
            Id = id;
            IconEnumType = iconEnumType;
        }
        /// <summary>
        /// 識別代碼
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// 列舉的型別
        /// </summary>
        public Type IconEnumType { get; private set; }
    }
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false, Inherited = true)]
    public class IconInfoAttribute : Attribute
    {
        private string _packId;

        public IconInfoAttribute(string packId)
        {
            _packId = packId;
        }
        /// <summary>
        /// 圖示包的識別碼
        /// </summary>
        public string PackId
        {
            get { return _packId; }
        }

        public static string GetPackId(Type type)
        {
            var attrs = type.GetCustomAttributes(typeof(IconInfoAttribute), false);
            return attrs.Length > 0 ? (attrs[0] as IconInfoAttribute).PackId : null;
        }
    }
    /// <summary>
    /// 圖示縮圖集合
    /// </summary>
    public class Thumbnail
    {
        private readonly ImageList _imageList = new ImageList();
        private readonly object _locker = new object();

        public ImageList ImageList
        {
            get { return _imageList; }
        }

        public Image this[string key]
        {
            get { return _imageList.Images[key]; }
        }

        public int Count
        {
            get { return _imageList.Images.Count; }
        }

        public void Add(string key, Image image)
        {
            lock (_locker)
            {
                _imageList.Images.Add(key, image);
            }
        }


        public static implicit operator ImageList(Thumbnail thumbnail)
        {
            return thumbnail.ImageList;
        }
    }
    public class ThumbnailCollection
    {
        private readonly Thumbnail[] _thunbnails;
        private string[] _names;
        public ThumbnailCollection(int capacity)
        {
            _thunbnails = new Thumbnail[capacity];
            _names = new string[capacity];
            for (var i = 0; i < capacity; i++)
                _thunbnails[i] = new Thumbnail();
        }

        public int Count
        {
            get { return _thunbnails.Length; }
        }
        public Thumbnail this[int index]
        {
            get { return _thunbnails[index]; }
        }

        public string GetName(int index)
        {
            return _names[index];
        }
        public void SetName(int index, string name)
        {
            _names[index] = name;
        }

        public void Add(string key, Image image)
        {
            Add(0, key, image);
        }
        public void Add(int index, string key, Image image)
        {
            _thunbnails[index].Add(key, image);
        }
    }
    /// <summary>
    /// 圖示包
    /// </summary>
    public abstract class IconPack
    {
        private IconPackInfoAttribute _info;

        public IconPack()
        {
            var infos = GetType().GetCustomAttributes(typeof(IconPackInfoAttribute), true);
            Info = infos.FirstOrDefault() as IconPackInfoAttribute;
        }

        /// <summary>
        /// 識別名稱
        /// </summary>        
        public string Id
        {
            get { return _info.Id; }
        }
        public IconPackInfoAttribute Info
        {
            get { return _info; }
            set
            {
                if (value == null)
                    throw new NullReferenceException("IconPack info cannot be empty");
                _info = value;
            }
        }
        /// <summary>
        /// 縮圖
        /// </summary>
        public abstract ThumbnailCollection Thumbnails { get; }
        /// <summary>
        /// 圖庫數量
        /// </summary>
        public abstract int IconCount { get; }
        [Browsable(false)]
        public abstract bool IsReady { get; }
        public virtual void RenderGraphic(Graphics g, object icon, RectangleF rect, ref float size, Color foreColor, object meta)
        {
            using (var brush = new SolidBrush(foreColor))
                RenderGraphic(g, icon, rect, ref size, brush, meta);
        }
        public abstract void RenderGraphic(Graphics g, object icon, RectangleF rect, ref float size, Brush foreBrush, object meta);

        public override string ToString()
        {
            return "FontPack@" + Id;
        }



        #region 靜態 Static
        private static readonly ConcurrentDictionary<string, IconPack> _iconPacks
            = new ConcurrentDictionary<string, IconPack>(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<Type, string> _packIndexByType
            = new Dictionary<Type, string>();
        private static readonly Dictionary<string, string> _packIndexByName
            = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        static IconPack()
        {
            // TODO: 列出所有Icon            
            var iconPackTypes = new Type[] { typeof(FontAwesomeIconPack), typeof(MaterialIconPack) };
            foreach (var iconPackType in iconPackTypes)
            {
                var iconPack = (IconPack)Activator.CreateInstance(iconPackType);
                _iconPacks.AddOrUpdate(iconPack.Id, id => iconPack, (id, pack) => iconPack);
                _packIndexByType.Add(iconPack.Info.IconEnumType, iconPack.Id);
                _packIndexByName.Add(iconPack.Info.IconEnumType.Name, iconPack.Id);
            }
        }

        /// <summary>
        /// 圖示包集合
        /// </summary>
        public static ICollection<IconPack> Packs
        {
            get { return _iconPacks.Values; }
        }
        public static IconPack GetIconPackById(string id)
        {
            IconPack pack;
            if (_iconPacks.TryGetValue(id, out pack))
                return pack;
            return null;
        }
        public static IconPack GetIconPack(object icon)
        {
            IconPack pack;
            string packId;
            if (icon is string)
            {
                var name = icon as string;
                var match = Regex.Match(name, @"([A-Za-z0-9_]+)\.([A-Za-z0-9_]+)");
                if (match.Success)
                    name = match.Groups[1].Value;
                if (!_packIndexByName.TryGetValue(name, out packId) && _iconPacks.TryGetValue(name, out pack))
                    return pack;
            }
            else
            {
                Type iconType = icon.GetType();
                _packIndexByType.TryGetValue(iconType, out packId);
            }

            if (packId != null && _iconPacks.TryGetValue(packId, out pack))
                return pack;
            return null;
        }
        public static void RenderIconGraphic(Graphics g, object icon, RectangleF rect, float size, Color foreColor, object meta = null)
        {
            var iconPack = GetIconPack(icon);
            if (iconPack != null)
                iconPack.RenderGraphic(g, icon, rect, ref size, foreColor, meta);
        }
        public static void RenderIconGraphic(Graphics g, object icon, RectangleF rect, float size, Brush foreBrush, object meta = null)
        {
            var iconPack = GetIconPack(icon);
            if (iconPack != null)
                iconPack.RenderGraphic(g, icon, rect, ref size, foreBrush, meta);
        }
        public static void RenderIconGraphic(Graphics g, object icon, RectangleF rect, ref float size, Color foreColor, object meta = null)
        {
            var iconPack = GetIconPack(icon);
            if (iconPack != null)
                iconPack.RenderGraphic(g, icon, rect, ref size, foreColor, meta);
        }
        public static void RenderIconGraphic(Graphics g, object icon, RectangleF rect, ref float size, Brush foreBrush, object meta = null)
        {
            var iconPack = GetIconPack(icon);
            if (iconPack != null)
                iconPack.RenderGraphic(g, icon, rect, ref size, foreBrush, meta);
        }
        public static Image CreateImage(object icon, Size size, Color foreColor, Color backColor = default(Color), object meta = null)
        {
            var image = new Bitmap(size.Width, size.Height);
            if (backColor == Color.Transparent)
            {
                image.MakeTransparent();
            }
            using (var g = Graphics.FromImage(image))
            {
                if (!backColor.IsEmpty && backColor != Color.Transparent)
                {
                    using (var brush = new SolidBrush(backColor))
                        g.FillRectangle(brush, 0, 0, size.Width, size.Height);
                }

                RenderIconGraphic(g, icon, new RectangleF(new PointF(0, 0), size), 0f, foreColor, meta);
            }
            return image;
        }
        #endregion
    }

    /// <summary>
    /// 使用字型的圖示包
    /// </summary>
    public abstract class FontIconPack : IconPack
    {
        private static readonly PrivateFontCollection _privateFonts
            = new PrivateFontCollection();



        private IFitFontSizeProvider _fitFontSizeProvider;
        private FontCache _fontCache;
        private FontCache _fitFontCache;
        private Font _font;
        internal FontIconPack(string resource)
        {
            using (var stream = FmResManager.GetResourceStream(resource))
            {
                var fontFamily = AddResourceFont(stream);
                Initialize(fontFamily);
            }
        }
        public FontIconPack(byte[] fontBytes)
        {
            var fontFamily = AddByteArrayFont(fontBytes);
            Initialize(fontFamily);
        }
        /// <summary>
        /// 圖示參考字型
        /// </summary>
        public Font ReferenceFont
        {
            get { return _font; }
        }
        /// <summary>
        /// 字型快取
        /// </summary>
        public FontCache FontCache
        {
            get { return _fontCache; }
        }
        public override bool IsReady
        {
            get { return _font != null; }
        }
        /// <summary>
        /// 最適字型大小介面
        /// </summary>
        public IFitFontSizeProvider FitFontSizeProvider
        {
            get { return _fitFontSizeProvider ?? BfprtFontEngine.Default; }
            set { _fitFontSizeProvider = value; }
        }

        protected void Initialize(FontFamily fontFamily)
        {
            _font = fontFamily == null
                ? SystemFonts.DefaultFont
                : new Font(fontFamily, 9f, FontStyle.Regular, GraphicsUnit.Point);
            _fontCache = new FontCache(_font);
            _fitFontCache = new FontCache(_font);
        }
        public override void RenderGraphic(Graphics g, object icon, RectangleF rect, ref float size, Brush foreBrush, object meta)
        {
            var text = GetTextCore(icon, meta);
            RenderGraphic(g, text, rect, ref size, foreBrush, meta);
        }
        protected virtual void RenderGraphic(Graphics g, string text, RectangleF rect, ref float size, Brush foreBrush, object meta)
        {
            // 沒有字就不畫
            if (string.IsNullOrEmpty(text))
                return;

            var state = g.Save();
            using (var sf = new StringFormat(StringFormat.GenericDefault))
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                if (size == 0f)
                {
                    // 自動處理font size
                    size = FitFontSizeProvider.GetFitSize(0f, 0f, r =>
                    {
                        var f = _fitFontCache.GetFont(r);
                        var s = g.MeasureString(text, f);
                        return rect.Size.Contains(s);
                    });
                }
                var font = FontCache.GetFont(size);
                g.DrawString(text, font, foreBrush, rect, sf);
            }
            g.Restore(state);
        }
        protected abstract string GetTextCore(object icon, object meta);
        protected abstract object GetIconCore(string text);






        public static FontFamily AddResourceFont(Stream stream)
        {
            byte[] data = null;
            if (stream != null && stream.Length != 0)
            {
                var length = (int)stream.Length;
                data = new byte[length];
                stream.Read(data, 0, length);
            }
            return AddByteArrayFont(data);
        }
        public static FontFamily AddByteArrayFont(byte[] bytes)
        {
            FontFamily font = null;
            if (bytes != null && bytes.Length > 0)
            {
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    ptr = Marshal.AllocCoTaskMem(bytes.Length);
                    Marshal.Copy(bytes, 0, ptr, bytes.Length);
                    _privateFonts.AddMemoryFont(ptr, bytes.Length);
                    font = _privateFonts.Families[_privateFonts.Families.Length - 1];
                }
                finally
                {
                    if (ptr != IntPtr.Zero)
                        Marshal.FreeCoTaskMem(ptr);
                }
            }
            return font;
        }
        public static Font GetFontFromPrivateFonts(string name)
        {
            foreach (var fontFamily in _privateFonts.Families)
            {
                if (string.Equals(fontFamily.Name, name, StringComparison.OrdinalIgnoreCase))
                    return new Font(fontFamily, 9f);
            }
            return null;
        }
    }

    public abstract class FontIconPack<T> : FontIconPack where T : struct
    {
        private Lazy<ThumbnailCollection> _thumbnails;
        internal FontIconPack(string resource) : base(resource)
        {
            _thumbnails = new Lazy<ThumbnailCollection>(() => CreateThumbnails(16));
        }
        public FontIconPack(byte[] fontBytes) : base(fontBytes)
        {
            _thumbnails = new Lazy<ThumbnailCollection>(() => CreateThumbnails(16));
        }


        public override ThumbnailCollection Thumbnails
        {
            get { return _thumbnails.Value; }
        }

        public override int IconCount
        {
            get { return _thumbnails.Value.Count; }
        }
        protected abstract T GetIcon(int code);
        protected abstract string GetText(T icon);

        protected override string GetTextCore(object icon, object meta)
        {
            if (icon is T)
                return GetText((T)icon);
            else if (icon is string)
            {
                var name = (icon as string).Split('.')[1];
                var value = (T)Enum.Parse(typeof(T), name, true);
                return GetText(value);
            }
            throw new ArgumentException("icon is not '" + typeof(T).Name + "'");
        }
        protected virtual string ConvertText(int code)
        {
            return char.ConvertFromUtf32(code);
        }
        protected override object GetIconCore(string text)
        {
            int code;
            if (text.Length > 1 && int.TryParse(text, out code))
                return GetIcon(code);
            code = char.ConvertToUtf32(text, 0);
            try
            {
                return GetIcon(code);
            }
            catch
            {
                return null;
            }
        }
        protected virtual ThumbnailCollection CreateThumbnails(int size)
        {
            var thumbnails = new ThumbnailCollection(1);
            thumbnails.SetName(0, ReferenceFont.FontFamily.Name);
            var values = Enum.GetValues(typeof(T));
            var names = Enum.GetNames(typeof(T));
            var rect = new RectangleF(new Point(0, 0), new Size(size, size));

            // first to measure font size
            var fontSize = 0f;
            RenderThumbnail(thumbnails, size, ref fontSize, rect, names[0], values.GetValue(0));

            Parallel.ForEach(Enumerable.Range(1, names.Length - 1), index =>
              {
                  //if (index == 1)
                  //    System.Diagnostics.Debugger.Break();
                  RenderThumbnail(thumbnails, size, ref fontSize, rect, names[index], values.GetValue(index));
              });


            return thumbnails;
        }

        private void RenderThumbnail(ThumbnailCollection thumbnails, int size, ref float fontSize, RectangleF rect, string name, object icon)
        {
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
                RenderGraphic(g, icon, rect, ref fontSize, Brushes.Black, null);
            thumbnails.Add(name, bmp);
        }
    }
}

