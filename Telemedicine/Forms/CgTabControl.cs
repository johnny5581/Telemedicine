using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    [ProvideProperty("PageEnabled", typeof(Control))]
    [ProvideProperty("PageColor", typeof(Control))]
    public class CgTabControl : TabControl, IExtenderProvider
    {
        private bool _enableCloseButton;
        private Color _tabColor;
        private Color _selectedTabColor;
        private Color _selectedForeColor;
        private const int Inflact = 1;
        private int _lastMouseOnIndex = -1;
        private bool _horizonalText;
        private bool _suspendResize = false;
        private TabSizeModeEx _sizeMode;
        private bool _forceSelectTabPage = false;
        private int _maxItemVerticalWidth = -1;
        private int _itemVerticalWidth;
        private const int MaxCloseSize = 32;
        private readonly Dictionary<Control, TabMeta> _tabMetas = new Dictionary<Control, TabMeta>();

        public CgTabControl()
        {
            DoubleBuffered = true;
        }
        public event TabClickEventHandler TabClick;
        #region 屬性 Properties        
        [DefaultValue(false)]
        public bool EnableCloseButton
        {
            get { return _enableCloseButton; }
            set
            {
                _enableCloseButton = value;
                OnPaintPropertyChanged();
            }
        }
        public new TabAlignment Alignment
        {
            get { return base.Alignment; }
            set
            {
                base.Alignment = value;
                ReCalculateItemSize();
            }
        }
        [DefaultValue(TabSizeModeEx.Normal)]
        public new TabSizeModeEx SizeMode
        {
            get { return _sizeMode; }
            set
            {
                _sizeMode = value;
                if (value == TabSizeModeEx.Fill)
                    base.SizeMode = TabSizeMode.Fixed;
                else
                    base.SizeMode = (TabSizeMode)(int)value;
                ReCalculateItemSize();
            }
        }
        [DefaultValue(typeof(Color), "")]
        public Color TabColor
        {
            get { return _tabColor; }
            set
            {
                _tabColor = value;
                OnPaintPropertyChanged();
            }
        }
        [DefaultValue(false)]
        public bool HorizonalText
        {
            get { return _horizonalText; }
            set
            {
                _horizonalText = value;
                ReCalculateItemSize();
            }
        }
        [DefaultValue(typeof(Color), "")]
        public Color SelectedTabColor
        {
            get { return _selectedTabColor; }
            set
            {
                _selectedTabColor = value;
                OnPaintPropertyChanged();
            }
        }
        [DefaultValue(typeof(Color), "")]
        public Color SelectedForeColor
        {
            get { return _selectedForeColor; }
            set
            {
                _selectedForeColor = value;
                OnPaintPropertyChanged();
            }
        }
        [DefaultValue(-1)]
        public int MaxItemVerticalWidth
        {
            get { return _maxItemVerticalWidth; }
            set
            {
                _maxItemVerticalWidth = value;
                ReCalculateItemSize();
            }
        }
        [DefaultValue(0)]
        public int ItemVerticalWidth
        {
            get { return _itemVerticalWidth; }
            set
            {
                _itemVerticalWidth = value;
                ReCalculateItemSize();
            }
        }

        #region IExtenderProvider
        bool IExtenderProvider.CanExtend(object extendee)
        {
            if (extendee is Control && extendee != null)
                return (extendee as Control).Parent == this;
            return false;
        }

        [DefaultValue(false)]
        public bool GetPageEnabled(Control control)
        {
            TabMeta meta;
            if (_tabMetas.TryGetValue(control, out meta))
                return meta.EnableFlag;
            return false;
        }

        public void SetPageEnabled(Control control, bool value)
        {
            var meta = _tabMetas[control];
            meta.EnableFlag = value;
            _tabMetas[control] = meta;
            Invalidate();
        }
        [DefaultValue(typeof(Color), "")]
        public Color GetPageColor(Control control)
        {
            TabMeta meta;
            if (_tabMetas.TryGetValue(control, out meta))
                return meta.TabColor;
            return default(Color);
        }

        public void SetPageColor(Control control, Color value)
        {
            var meta = _tabMetas[control];
            meta.TabColor = value;
            _tabMetas[control] = meta;
            Invalidate();
        }

        #endregion
        #endregion
        public int MeasureItemSize()
        {
            if (TabCount == 0) return 0;
            var measureSize = Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom
                                ? Width - Margin.Horizontal : Height - Margin.Vertical;
            return measureSize / TabCount;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!_suspendResize)
                ReCalculateItemSize();
        }
        public void ReCalculateItemSize()
        {
            var alignment = Alignment;
            var rawItemSize = ItemSize;
            var isHorizon = alignment == TabAlignment.Top || alignment == TabAlignment.Bottom;
            _suspendResize = true;
            if (SizeMode == TabSizeModeEx.Fill)
            {
                if (TabCount == 0) // 無Tab，無法計算
                {
                    ItemSize = Size.Empty;
                }
                else
                {
                    var size = isHorizon ? Width : Height;
                    var itemSize = (size - 6) / TabCount;
                    if (itemSize < 0)
                        itemSize = 0;
                    if (isHorizon) // 水平
                    {
                        ItemSize = new Size(itemSize, 0);
                    }
                    else // 垂直
                    {
                        var height = itemSize;
                        if (!_horizonalText) //如果是垂直文字，使用字型高度作為預設寬度
                        {
                            ItemSize = new Size(height, FontHeight + 6);
                        }
                        else //如果是水平文字，計算寬度
                        {
                            int tabWid = 0;
                            if (ItemVerticalWidth != 0)
                                tabWid = ItemVerticalWidth;
                            else
                            {
                                // 取得所有Tab的最大值
                                var sizes = TabPages.OfType<TabPage>()
                                    .Select(page => TextRenderer.MeasureText(page.Text, Font, new Size(ItemVerticalWidth, height),
                                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak));
                                var maxWidth = sizes.Max(r => r.Width);
                                tabWid = maxWidth;
                            }
                            if (_maxItemVerticalWidth != -1 && tabWid > _maxItemVerticalWidth)
                                tabWid = _maxItemVerticalWidth;
                            ItemSize = new Size(itemSize, tabWid);
                        }
                    }
                }
            }
            _suspendResize = false;
        }
        protected virtual void OnPaintPropertyChanged()
        {
            Invalidate();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            var page = e.Control as TabPage;
            if (page != null)
            {
                _tabMetas.Add(page, TabMeta.Create());
                ReCalculateItemSize();
            }
            base.OnControlAdded(e);
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            var page = e.Control as TabPage;
            if (page != null)
            {
                _tabMetas.Remove(page);
                ReCalculateItemSize();
            }
        }
        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            if (!_forceSelectTabPage && e.TabPage != null)
            {
                TabMeta meta;
                if (_tabMetas.TryGetValue(e.TabPage, out meta) && !meta.EnableFlag)
                {
                    e.Cancel = true;
                    return;
                }
            }
            base.OnSelecting(e);
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //base.OnDrawItem(e);
            var page = TabPages[e.Index];
            var isSelected = e.Index == SelectedIndex;
            var tabFont = e.Font;
            var foreColor = e.ForeColor;
            Color backColor = e.BackColor;
            TabMeta meta;
            if (!_tabMetas.TryGetValue(page, out meta))
                return; //找不到就不要畫!

            // 順序: Disable => Selected(U) => Selected(G) => Selected => Normal(U) => Normal(G) => Normal
            var isUserColorDefined = meta.TabColor != default(Color);
            if (!meta.EnableFlag)
                foreColor = Color.Gray;
            else if (isSelected)
            {
                tabFont = new Font(tabFont, FontStyle.Bold);
                if (isUserColorDefined)
                    backColor = ControlPaint.Dark(meta.TabColor);
                if (_selectedTabColor != default(Color))
                    backColor = _selectedTabColor;
                if (_selectedForeColor != default(Color))
                    foreColor = _selectedForeColor;
            }
            else
            {
                if (meta.TabColor != default(Color))
                    backColor = meta.TabColor;
                else if (_tabColor != default(Color))
                    backColor = _tabColor;
            }

            // 畫背景
            OnDrawItemBackground(new DrawTabPageEventArgs(e.Graphics, e.Bounds, page, tabFont, foreColor, backColor));

            // 畫文字            
            var textRect = GetTextRectangle(e.Bounds, Inflact);
            OnDrawItemText(new DrawTabPageEventArgs(e.Graphics, textRect, page, tabFont, foreColor, backColor));

            if (GetEnableCloseButton())
            {
                // 畫按鈕                               
                var closeRect = GetCloseButtonRectangle(e.Bounds, Inflact);
                var drawCloseArgs = new DrawCloseButtonEventArgs(e.Graphics, closeRect, page, tabFont, Color.Red, backColor, meta.CloseFlag);
                OnDrawItemCloseButton(drawCloseArgs);
            }
        }
        protected virtual void OnTabClick(TabClickEventArgs e)
        {
            var handler = TabClick;
            if (handler != null)
                handler(this, e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            int index;
            bool closeButton;
            int invalidateIndex1 = -1, invalidateIndex2 = -1;

            if (_lastMouseOnIndex != -1 && TryValidateTab(e.Location, _lastMouseOnIndex, out closeButton))
            {
                var page = TabPages[_lastMouseOnIndex];
                TabMeta meta;
                if (_tabMetas.TryGetValue(page, out meta) && closeButton != meta.CloseFlag)
                {
                    meta.CloseFlag = closeButton;
                    _tabMetas[page] = meta;
                    invalidateIndex1 = _lastMouseOnIndex;
                }
            }
            else if (TryValidateTab(e.Location, out index, out closeButton))
            {
                invalidateIndex1 = _lastMouseOnIndex;
                _lastMouseOnIndex = index;
                var page = TabPages[index];
                TabMeta meta;
                if (_tabMetas.TryGetValue(page, out meta) && closeButton != meta.CloseFlag)
                {
                    meta.CloseFlag = closeButton;
                    _tabMetas[page] = meta;
                    invalidateIndex2 = index;
                }
            }
            else
            {
                invalidateIndex1 = _lastMouseOnIndex;
            }

            if (invalidateIndex1 != -1 && TabPages.Count > invalidateIndex1)
                Invalidate(GetTabRect(invalidateIndex1));
            if (invalidateIndex2 != -1 && TabPages.Count > invalidateIndex2)
                Invalidate(GetTabRect(invalidateIndex2));

            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int index;
            bool closeButton;
            if (TryValidateTab(e.Location, out index, out closeButton))
            {
                var page = TabPages[index];
                OnTabClick(new TabClickEventArgs(page));
            }
            base.OnMouseDown(e);
        }
        private bool TryValidateCloseButton(int index, Point location)
        {
            if (index < TabCount)
            {
                var tabRect = GetTabRect(index);
                if (tabRect.Contains(location))
                {
                    var page = TabPages[index];
                    var closeRect = GetCloseButtonRectangle(tabRect, Inflact);
                    var mouseOn = IsMouseOnCloseButton(location, closeRect);
                    TabMeta meta;
                    if (_tabMetas.TryGetValue(page, out meta) && mouseOn != meta.CloseFlag)
                    {
                        closeRect.Inflate(3, 3);
                        Invalidate(closeRect);
                        meta.CloseFlag = mouseOn;
                        _tabMetas[page] = meta;
                    }
                    return true;
                }
            }
            return false;
        }
        private bool TryValidateTab(Point location, out int index, out bool closeButton)
        {
            index = -1;
            closeButton = false;
            for (var i = 0; i < TabCount; i++)
            {
                if (TryValidateTab(location, i, out closeButton))
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
        private bool TryValidateTab(Point location, int index, out bool closeButton)
        {
            closeButton = false;
            try
            {
                var tabRect = GetTabRect(index);
                if (tabRect.Contains(location))
                {
                    var closeRect = GetCloseButtonRectangle(tabRect, Inflact);
                    closeButton = IsMouseOnCloseButton(location, closeRect);
                    return true;
                }
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        private bool TryInvokeCloseButton(int index, Point location)
        {
            if (_enableCloseButton)
            {
                if (index < TabCount)
                {
                    var tabRect = GetTabRect(index);
                    if (tabRect.Contains(location))
                    {
                        var closeRect = GetCloseButtonRectangle(tabRect, Inflact);
                        var mouseOn = IsMouseOnCloseButton(location, closeRect);
                        if (mouseOn)
                        {
                            var page = TabPages[index];
                            page.Dispose();
                            TabPages.Remove(page);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #region 繪製 Drawing
        private Rectangle GetCloseButtonRectangle(Rectangle tabRect, int inflact)
        {
            var size = tabRect.Height - inflact * 2;
            if (size > MaxCloseSize)
                size = MaxCloseSize;
            return new Rectangle(
                tabRect.Right - size - inflact,
                (tabRect.Height / 2) - (size / 2) + 3,
                size,
                size
            );
        }
        private Rectangle GetTextRectangle(Rectangle tabRect, int inflact)
        {
            var closeWidth = GetEnableCloseButton() ? GetCloseButtonRectangle(tabRect, inflact).Width : 0;
            return new Rectangle(
                tabRect.X + inflact,
                tabRect.Y + inflact,
                tabRect.Width - inflact * 2 - closeWidth,
                tabRect.Height - inflact * 2
            );
        }
        private bool GetEnableCloseButton()
        {
            var alignment = Alignment;
            return _enableCloseButton && (alignment == TabAlignment.Top || alignment == TabAlignment.Bottom);
        }

        protected virtual void OnDrawItemBackground(DrawTabPageEventArgs e)
        {
            using (var brush = new SolidBrush(e.BackColor))
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }

        protected virtual void OnDrawItemText(DrawTabPageEventArgs e)
        {
            var state = e.Graphics.Save();
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var alignment = Alignment;
            switch (alignment)
            {
                case TabAlignment.Left:
                case TabAlignment.Right:
                    if (_horizonalText)
                        TextRenderer.DrawText(e.Graphics, e.Page.Text, e.Font, e.ClipRectangle, e.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
                    else
                    {
                        using (var brush = new SolidBrush(e.ForeColor))
                        using (var sf = new StringFormat(StringFormat.GenericDefault))
                        {
                            sf.LineAlignment = StringAlignment.Center;
                            sf.Alignment = StringAlignment.Center;
                            var rect = e.ClipRectangle;
                            var rotated = false;
                            if (TabAlignment.Left == alignment) // 左旋
                            {
                                e.Graphics.TranslateTransform(0, 0);
                                e.Graphics.RotateTransform(270);
                                rect = new Rectangle(new Point(-rect.Y - rect.Size.Height, rect.X), rect.Size.Rotate90());
                                rotated = true;
                            }
                            e.Graphics.DrawString(e.Page.Text, e.Font, brush, rect, sf);

                            if (rotated)
                                e.Graphics.ResetTransform();
                        }
                    }
                    break;
                default:
                    TextRenderer.DrawText(e.Graphics, e.Page.Text, e.Font, e.ClipRectangle, e.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    break;
            }
            e.Graphics.Restore(state);
        }


        protected virtual void OnDrawItemCloseButton(DrawCloseButtonEventArgs e)
        {
            if (e.IsMouseOn)
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, e.ClipRectangle); // 畫個背景...
            Icons.IconPack.RenderIconGraphic(e.Graphics, Icons.FontAwesomeIcon.Times, e.ClipRectangle, 0f, e.ForeColor);
        }
        #endregion

        private static bool IsMouseOnCloseButton(Point mouseLocationOnTab, Rectangle closeRectangle)
        {
            return closeRectangle.Contains(mouseLocationOnTab);
        }


        #region 參考類別 Class
        private struct TabMeta
        {
            public Color TabColor;
            public bool CloseFlag;
            public bool EnableFlag;

            public static TabMeta Create()
            {
                return new TabMeta
                {
                    EnableFlag = true
                };
            }
        }

        public class DrawTabPageEventArgs : PaintEventArgs
        {
            private readonly TabPage _page;
            private Font _font;
            private Color _backColor;
            private Color _foreColor;

            public DrawTabPageEventArgs(Graphics graphics, Rectangle clipRect, TabPage page, Font font, Color foreColor, Color backColor) : base(graphics, clipRect)
            {
                _page = page;
                _font = font;
                _backColor = backColor;
                _foreColor = foreColor;
            }

            public Color ForeColor
            {
                get { return _foreColor; }
                set { _foreColor = value; }
            }

            public Color BackColor
            {
                get { return _backColor; }
            }

            public Font Font
            {
                get { return _font; }
            }

            public TabPage Page
            {
                get { return _page; }
            }
        }
        public class DrawCloseButtonEventArgs : DrawTabPageEventArgs
        {
            private readonly bool _isMouseOn;

            public DrawCloseButtonEventArgs(Graphics graphics, Rectangle clipRect, TabPage page, Font font, Color foreColor, Color backColor, bool isMouseOn) : base(graphics, clipRect, page, font, foreColor, backColor)
            {
                _isMouseOn = isMouseOn;
            }

            public DrawCloseButtonEventArgs(DrawTabPageEventArgs e, bool isMouseOn) : this(e.Graphics, e.ClipRectangle, e.Page, e.Font, e.ForeColor, e.BackColor, isMouseOn)
            {
            }


            public bool IsMouseOn
            {
                get { return _isMouseOn; }
            }
        }
        public delegate void TabClickEventHandler(object sender, TabClickEventArgs e);
        public class TabClickEventArgs : EventArgs
        {
            public TabClickEventArgs(TabPage page)
            {
                Page = page;
            }

            public TabPage Page { get; private set; }
        }
        public enum TabSizeModeEx
        {
            Normal = 0,
            FillToRight = 1,
            Fixed = 2,
            Fill = 3, //填滿整個容器
        }
        #endregion
    }
}

