using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    /// <summary>
    /// 擴充的Margin / Padding 
    /// </summary>
    public struct MarginPadding
    {
        private double _top;
        private double _bottom;
        private double _left;
        private double _right;
        private bool _nonEmpty;
        public static readonly MarginPadding Empty
            = new MarginPadding();

        public MarginPadding(double left, double top, double right, double bottom)
        {
            _top = top;
            _left = left;
            _bottom = bottom;
            _right = right;
            _nonEmpty = true;
        }
        public MarginPadding(double h, double v)
            : this(h, v, h, v)
        {
        }
        public MarginPadding(double all)
            : this(all, all)
        {
        }
        public double Top
        {
            get { return _top; }
            set { _top = value; }
        }
        public double Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public double Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }
        public double Right
        {
            get { return _right; }
            set { _right = value; }
        }
        public double Horizonal
        {
            get { return _left + _right; }
        }
        public double Vertial
        {
            get { return _top + _bottom; }
        }
        public bool IsEmpty
        {
            get { return !_nonEmpty; }
        }
        public Padding ToPadding()
        {
            return new Padding((int)Left, (int)Top, (int)Right, (int)Bottom);
        }
        public Margins ToMargins()
        {
            return new Margins((int)Left, (int)Top, (int)Right, (int)Bottom);
        }


        public static explicit operator MarginPadding(Padding padding)
        {
            return new MarginPadding(padding.Top, padding.Left, padding.Bottom, padding.Right);
        }
        public static explicit operator MarginPadding(Margins margins)
        {
            return new MarginPadding(margins.Top, margins.Left, margins.Bottom, margins.Right);
        }
    }
    public class MarginPaddingConverter : TypeConverter
    {
        private static readonly Dictionary<string, double> _convertMap
            = new Dictionary<string, double>
            {
                { "cm", 37.795275591 },
                { "mm", 3.7795275591 },
                { "in", 96 },
                { "inch", 96 }
            };
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var sourceText = value as string;
            if (string.IsNullOrEmpty(sourceText))
                return MarginPadding.Empty;

            var texts = sourceText.Split(',').Select(r => r.Trim()).ToArray();
            var values = new double[texts.Length];
            for (var i = 0; i < texts.Length; i++)
            {
                bool flg = false;
                var text = texts[i];
                foreach (var unit in _convertMap.Keys)
                {
                    if (text.EndsWith(unit, StringComparison.OrdinalIgnoreCase))
                    {
                        text = text.Substring(0, text.Length - unit.Length);
                        values[i] = Convert.ToDouble(text) * _convertMap[unit];
                        flg = true;
                        break;
                    }
                }
                if (!flg)
                {
                    double v;
                    if (!double.TryParse(text, out v))
                        throw new InvalidOperationException("invalid value: " + text);
                    values[i] = v;
                }
            }


            switch(texts.Length)
            {
                case 1:
                    return new MarginPadding(values[0]);
                case 2:
                    return new MarginPadding(values[0], values[1]);
                case 4:
                    return new MarginPadding(values[0], values[1], values[2], values[3]);
                default:
                    throw new InvalidOperationException("invalid values length: " + texts.Length);                    
            }            
        }


    }
}


