using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgTableLayoutPanel : TableLayoutPanel
    {
        private Color _borderColor;
        private bool _outBorder = true;
        public CgTableLayoutPanel()
        {
            DoubleBuffered = true;
        }
        [DefaultValue(typeof(Color), "")]
        public Color CellBorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                OnPaintPropertyChanged();
            }
        }
        [DefaultValue(true)]
        public bool OutBorder
        {
            get { return _outBorder; }
            set
            {
                _outBorder = value;
                OnPaintPropertyChanged();
            }
        }

        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            base.OnCellPaint(e);
            if (!CellBorderColor.IsEmpty)
            {
                var state = e.Graphics.Save();
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                var rect = e.CellBounds;
                using (var pen = new Pen(CellBorderColor))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (e.Row == (RowCount - 1))
                        rect.Height -= 1; // 最後一格要內縮1
                    if (e.Column == (ColumnCount - 1))
                        rect.Width -= 1; // 最後一格要內縮1
                    if (OutBorder)
                        e.Graphics.DrawRectangle(pen, rect);
                    else
                    {
                        if (e.Row != 0)
                            e.Graphics.DrawLine(pen, rect.X, rect.Y, rect.X + rect.Width, rect.Y); // Top
                        if (e.Column != 0)
                            e.Graphics.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Y + rect.Height); // Left
                        if (e.Row != RowCount - 1)
                            e.Graphics.DrawLine(pen, rect.X, rect.Y + rect.Height, rect.X + rect.Width, rect.Y + rect.Height); // Bottom
                        if (e.Column != ColumnCount - 1)
                            e.Graphics.DrawLine(pen, rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height); // Right
                    }
                }
                e.Graphics.Restore(state);
            }
        }
        protected void OnPaintPropertyChanged()
        {
            Invalidate();
        }
    }
}

