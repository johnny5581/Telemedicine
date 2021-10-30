using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgIconButton : Button
    {
        private object _icon;
        private Color _colorFore;
        private Color _colorBack;
        private int _iconSize;
        private int _iconMargin;

        public CgIconButton()
        {
            TextImageRelation = TextImageRelation.ImageAboveText;
            BackgroundImageLayout = ImageLayout.Zoom;
            DoubleBuffered = true;

        }
        [Category(Commons.CategoryIcon)]
        [Editor(typeof(Icons.Design.IconEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [TypeConverter(typeof(Icons.Design.IconConverter))]
        [DefaultValue(null)]
        public object Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnIconChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(typeof(Color), "")]
        public Color IconForeColor
        {
            get { return _colorFore; }
            set
            {
                _colorFore = value;
                OnIconChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(typeof(Color), "")]
        public Color IconBackColor
        {
            get { return _colorBack; }
            set
            {
                _colorBack = value;
                OnIconChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(0f)]
        public int IconSize
        {
            get { return _iconSize; }
            set
            {
                _iconSize = value;
                OnIconChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(0)]
        public int IconMargin
        {
            get { return _iconMargin; }
            set
            {
                _iconMargin = value;
                OnIconChanged();
            }
        }
        protected virtual void OnIconChanged()
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }
            if (BackgroundImage != null)
            {
                BackgroundImage.Dispose();
                BackgroundImage = null;
            }

            // 產生新的icon圖檔
            if (Icon != null)
            {
                var clientSize = ClientSize.ApplyPadding(IconMargin);
                if (!string.IsNullOrEmpty(Text) && (TextImageRelation == TextImageRelation.ImageAboveText || TextImageRelation == TextImageRelation.TextAboveImage))
                {
                    var measureTextBox = new TextBox()
                    {
                        Multiline = true,
                        BorderStyle = BorderStyle.None,
                        Width = Math.Max(ClientRectangle.Width - 12, 0),
                        Font = Font,
                        Text = Text
                    };
                    int lineCount = measureTextBox.GetLineFromCharIndex(int.MaxValue) + 1;
                    int fontHeight = TextRenderer.MeasureText("X", Font).Height;
                    var height = lineCount * fontHeight;

                    var newHeight = clientSize.Height - height;
                    if (newHeight < 0)
                        newHeight = 0;
                    clientSize.Height = newHeight;
                }

                var imageSize = Math.Min(clientSize.Width, clientSize.Height);
                if (imageSize == 0)
                    imageSize = 1;

                var image = new Bitmap(imageSize, imageSize);
                using (var g = Graphics.FromImage(image))
                {
                    var rect = new Rectangle(new Point(0, 0), image.Size);

                    // 背景
                    if (!IconBackColor.IsEmpty)
                    {
                        using (var b = new SolidBrush(IconBackColor))
                            g.FillRectangle(b, rect);
                    }

                    var colorFore = Commons.GetNonEmptyColor(IconForeColor, ForeColor);
                    Icons.IconPack.RenderIconGraphic(g, Icon, rect, IconSize, colorFore);
                }
                if (string.IsNullOrEmpty(Text))
                    BackgroundImage = image;
                else
                    Image = image;
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            OnIconChanged();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            OnIconChanged();
        }
    }
}

