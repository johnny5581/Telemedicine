using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgGradientPanel : Panel
    {
        private Color _backColor2;
        private float _gradientAngle;

        public CgGradientPanel()
        {            
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            GradientAngle = 90f;
        }
        [Category(Commons.CategoryAppearance)]
        [DefaultValue(typeof(Color), "")]
        public Color BackColor2
        {
            get { return _backColor2; }
            set
            {
                _backColor2 = value;
                Invalidate();
            }
        }
        [Category(Commons.CategoryAppearance)]
        [DefaultValue(90f)]
        public float GradientAngle
        {
            get { return _gradientAngle; }
            set
            {
                _gradientAngle = value;
                Invalidate();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (BackColor2.IsEmpty || BackColor2 == Color.Transparent || BackColor == Color.Transparent || BackgroundImage != null)
                base.OnPaintBackground(e);
            else
            {
                // 繪製漸層
                var rect = ClientRectangle;
                using (var lgb = new LinearGradientBrush(rect, BackColor, BackColor2, GradientAngle))
                {
                    e.Graphics.FillRectangle(lgb, rect);
                }

            }
        }
    }
}

