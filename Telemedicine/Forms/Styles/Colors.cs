using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Telemedicine.Forms.Styles
{
    /// <summary>
    /// 色票
    /// </summary>
    public struct Colors
    {
        private Color _color1;      // 主色     
        private Color _color2;      // 副色
        private SolidBrush _brush;
        private Pen _pen;

        public Colors(Color color1)
        {
            _color1 = color1;
            _color2 = default(Color);
            _brush = null;
            _pen = null;
        }

        public Colors(Color color1, Color color2)
        {
            _color1 = color1;
            _color2 = color2;
            _brush = null;
            _pen = null;
        }
        public Colors(string color1)
        {
            _color1 = Convert(color1);
            _color2 = default(Color);
            _brush = null;
            _pen = null;
        }

        public Colors(string color1, string color2)
        {
            _color1 = Convert(color1);
            _color2 = Convert(color2);
            _brush = null;
            _pen = null;
        }

        public Color Color1
        {
            get { return _color1; }
            set { _color1 = value; }
        }
        public Color Color2
        {
            get { return _color2; }
            set { _color2 = value; }
        }


        public string Color1Hex
        {
            get { return ColorTranslator.ToHtml(_color1); }
            set { _color1 = Convert(value); }
        }
        public string Color2Hex
        {
            get { return ColorTranslator.ToHtml(_color2); }
            set { _color2 = Convert(value); }
        }

        public Brush GetBrush(RectangleF? rect = null, float angle = 90f)
        {
            if (_color2.IsEmpty) // 單色才可以用暫存
            {
                if (_brush == null || _brush.Color != _color1)
                {
                    if (_brush != null)
                    {
                        _brush.Dispose();
                        _brush = null;
                    }
                    _brush = new SolidBrush(_color1);
                }
                return _brush;
            }

            if (rect == null)
                throw new InvalidOperationException("linear gradient must has rectangle info");
            var linearBrush = new LinearGradientBrush(rect.Value, _color1, _color2, angle);
            return linearBrush;
        }

        public Pen GetPen(float width = 1f)
        {
            if (_pen == null || _pen.Color != _color1 || _pen.Width != width)
            {
                if (_pen != null)
                {
                    _pen.Dispose();
                    _pen = null;
                }
                _pen = new Pen(_color1, width);
            }
            return _pen;
        }
        private static Color Convert(string value)
        {
            if (value == null)
                return default(Color);
            else if (value.StartsWith("#"))
                return ColorTranslator.FromHtml(value);
            else
                return Color.FromName(value);
        }
        public static implicit operator Color(Colors colors)
        {
            return colors.Color1;
        }
        public static implicit operator Colors(Color color)
        {
            return new Colors(color);
        }
    }
}

