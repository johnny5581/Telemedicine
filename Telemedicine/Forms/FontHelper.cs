using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemedicine.Forms
{

    /// <summary>
    /// 字形工具
    /// </summary>
    public static class FontHelper
    {
        /// <summary>
        /// 取得新大小的字型
        /// </summary>        
        public static Font NewFont(this Font baseFont, float newSize)
        {
            return new Font(baseFont.FontFamily, newSize, baseFont.Style, baseFont.Unit, baseFont.GdiCharSet);
        }
        /// <summary>
        /// 取得調整大小的字型
        /// </summary>        
        public static Font AdjestFont(this Font baseFont, float sizeOffset)
        {
            var newSize = baseFont.Size + sizeOffset;
            return NewFont(baseFont, newSize);
        }
    }
    public class FontCache : ConcurrentDictionary<float, Font>
    {
        private Font _font;
        public FontCache(Font referenceFont = null) : base(1, 10)
        {
            _font = referenceFont ?? SystemFonts.DefaultFont;
        }
        public FontCache(FontFamily family)
        {
            _font = new Font(family, 9f);
        }

        public FontFamily FontFamily
        {
            get { return _font.FontFamily; }
        }
        public Font GetFont(float size)
        {
            return GetOrAdd(size, r => _font.NewFont(size));
        }
    }

    /// <summary>
    /// 適應字型大小介面
    /// </summary>
    public interface IFitFontSizeProvider
    {
        float GetFitSize(float min, float max, Func<float, bool> validator);
    }

    public abstract class FontSizeEngineBase : IFitFontSizeProvider
    {
        private const float MaximumFontSize = 300f;
        public float GetFitSize(float min, float max, Func<float, bool> validator)
        {
            if (max == 0f)
                max = MaximumFontSize;
            return CalcFitSize(min, max, validator);
        }

        protected abstract float CalcFitSize(float min, float max, Func<float, bool> validator);
    }


    /// <summary>
    /// TOP-K
    /// </summary>
    public class BfprtFontEngine : FontSizeEngineBase
    {
        public static readonly BfprtFontEngine Default = new BfprtFontEngine();
        private float _accuarcy;
        public BfprtFontEngine(float accuarcy)
        {
            _accuarcy = accuarcy;
        }
        public BfprtFontEngine() : this(0.5f)
        {
        }
        private float Mean(float current, float reference)
        {
            return (current + reference) / 2;
        }

        protected override float CalcFitSize(float min, float max, Func<float, bool> validator)
        {

            var latest = max;
            float value;
            while (true)
            {
                value = Mean(max, min);
                if (Math.Abs(value - latest) <= _accuarcy)
                    break;
                if (validator(value))
                    min = value;
                else
                    max = value;
                latest = value;
            }
            return latest;
        }
    }
    /// <summary>
    /// 線性
    /// </summary>
    public class LinearFontEngine : FontSizeEngineBase
    {
        public static readonly LinearFontEngine Default = new LinearFontEngine();
        private readonly float _step;
        public LinearFontEngine(float step)
        {
            _step = step;
        }
        public LinearFontEngine() : this(1)
        {
        }
        protected override float CalcFitSize(float min, float max, Func<float, bool> validator)
        {
            var value = max;
            while (value > min)
            {
                if (validator(value))
                    return value;
                value -= _step;
            }
            return min;
        }
    }


}

