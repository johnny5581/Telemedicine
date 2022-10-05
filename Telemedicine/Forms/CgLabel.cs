using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgLabel : Label
    {
        private bool _autoFontSize;
        private FontCache _fontCache;
        private IFitFontSizeProvider _fontProvider;
        private FontMode _fontMode;
        public CgLabel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            _fontCache = new FontCache();
            _fontProvider = BfprtFontEngine.Default;

            AutoSize = false;
        }
        public bool AutoFontSize
        {
            get { return _autoFontSize; }
            set
            {
                _autoFontSize = value;
                Invalidate();
            }
        }
        public FontMode AutoFontMode
        {
            get { return _fontMode; }
            set
            {
                _fontMode = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (_autoFontSize)
            {
                OnPaintBackground(e);
                var rect = e.ClipRectangle.ApplyPadding(Padding);
                // 繪製文字
                var font = MeasureFitFont(rect);
                TextFormatFlags flag = TextFormatFlags.Default;
                if (_fontMode != FontMode.None)
                    flag |= TextFormatFlags.EndEllipsis;
                switch (TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        flag |= TextFormatFlags.Top | TextFormatFlags.Left;
                        break;
                    case ContentAlignment.TopCenter:
                        flag |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                        break;
                    case ContentAlignment.TopRight:
                        flag |= TextFormatFlags.Top | TextFormatFlags.Right;
                        break;
                    case ContentAlignment.MiddleLeft:
                        flag |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                        break;
                    case ContentAlignment.MiddleCenter:
                        flag |= TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                        break;
                    case ContentAlignment.MiddleRight:
                        flag |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                        break;
                    case ContentAlignment.BottomLeft:
                        flag |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                        break;
                    case ContentAlignment.BottomCenter:
                        flag |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                        break;
                    case ContentAlignment.BottomRight:
                        flag |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                        break;
                }
                TextRenderer.DrawText(e.Graphics, Text, font, rect, ForeColor, flag);
            }
            else
                base.OnPaint(e);
        }
        private Font MeasureFitFont(Rectangle rect)
        {
            var fitSize = _fontProvider.GetFitSize(3f, 300f, FontValidator, new object[] { rect });
            return _fontCache.GetFont(fitSize);
        }
        private bool FontValidator(float size, object[] args)
        {
            var measureSize = TextRenderer.MeasureText(Text, _fontCache.GetFont(size));
            var rect = (Rectangle)args[0];            
            switch (_fontMode)
            {
                case FontMode.Horizontal:
                    return rect.Size.Width > measureSize.Width;
                case FontMode.Vertical:
                    return rect.Size.Height > measureSize.Height;
                case FontMode.None:
                default:
                    return rect.Size.Contains(measureSize);
            }
        }
        private void OnBaseFontChanged(Font newFont)
        {
            if (_fontCache.FontFamily != newFont.FontFamily)
                _fontCache = new FontCache(newFont);
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            OnBaseFontChanged(Font);
        }
        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            OnBaseFontChanged(Font);
        }

        public enum FontMode
        {
            None, Horizontal, Vertical
        }

    }
}

