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
    public class CgIconControl : Control
    {
        private object _icon;
        private Color _colorFore;
        private Color _colorHover;
        private Color _colorClick;
        private Color _colorBack;
        private IconModes _iconMode = IconModes.IconAboveText;
        private Rectangle _rectText;
        private Rectangle _rectIcon;
        private bool _flgRect;
        private int _iconWidthHeight;
        private bool _autoWidth;
        private bool _iconVisible = true;
        private bool _clickable = true;
        private float _iconSize;
        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;
        private ControlBorderStyles _controlBorderStyle = ControlBorderStyles.None;
        private float _controlBorderWidth = 1;
        private PenAlignment _controlBorderAlignment;
        private int _controlBorderRadius = 8;
        private int _iconMargin;
        private bool _textWrap = true;
        private AutoMouseColorType _autoMouseHoverColorType = AutoMouseColorType.Light;
        private AutoMouseColorType _autoMouseClickColorType = AutoMouseColorType.Dark;

        public CgIconControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
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
                OnPaintPropertyChanged();
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
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(typeof(Color), "")]
        public Color IconHoverColor
        {
            get { return _colorHover; }
            set
            {
                _colorHover = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(typeof(Color), "")]
        public Color IconClickColor
        {
            get { return _colorClick; }
            set
            {
                _colorClick = value;
                OnPaintPropertyChanged();
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
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(true)]
        public bool IconClickable
        {
            get { return _clickable; }
            set
            {
                _clickable = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(false)]
        public bool AutoIconMouseColor { get; set; }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(IconModes.IconAboveText)]
        public IconModes IconMode
        {
            get { return _iconMode; }
            set
            {
                _iconMode = value;
                OnLayoutPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(0)]
        public int IconWidthHeight
        {
            get { return _iconWidthHeight; }
            set
            {
                _iconWidthHeight = value;
                OnLayoutPropertyChanged();
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
                OnLayoutPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(false)]
        public bool AutoWidth
        {
            get { return _autoWidth; }
            set
            {
                _autoWidth = value;
                ReCalculateClientSize();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(true)]
        public bool IconVisible
        {
            get { return _iconVisible; }
            set
            {
                _iconVisible = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(0f)]
        public float IconSize
        {
            get { return _iconSize; }
            set
            {
                _iconSize = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(ContentAlignment.MiddleCenter)]
        public ContentAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryAppearance)]
        [DefaultValue(ControlBorderStyles.None)]
        public ControlBorderStyles ControlBorderStyle
        {
            get { return _controlBorderStyle; }
            set
            {
                _controlBorderStyle = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryAppearance)]
        [DefaultValue(1f)]
        public float ControlBorderWidth
        {
            get { return _controlBorderWidth; }
            set
            {
                _controlBorderWidth = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryAppearance)]
        [DefaultValue(PenAlignment.Center)]
        public PenAlignment ControlBorderAlignment
        {
            get { return _controlBorderAlignment; }
            set
            {
                _controlBorderAlignment = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryAppearance)]
        [DefaultValue(8)]
        public int ControlBorderRadius
        {
            get { return _controlBorderRadius; }
            set
            {
                _controlBorderRadius = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryAppearance)]
        [DefaultValue(true)]
        public bool TextWrap
        {
            get { return _textWrap; }
            set
            {
                _textWrap = value;
                OnLayoutPropertyChanged();
            }
        }
        [DefaultValue("")]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                OnLayoutPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(AutoMouseColorType.Light)]
        public AutoMouseColorType AutoMouseHoverColorType
        {
            get { return _autoMouseHoverColorType; }
            set
            {
                _autoMouseHoverColorType = value;
                OnPaintPropertyChanged();
            }
        }
        [Category(Commons.CategoryIcon)]
        [DefaultValue(AutoMouseColorType.Dark)]
        public AutoMouseColorType AutoMouseClickColorType
        {
            get { return _autoMouseClickColorType; }
            set
            {
                _autoMouseClickColorType = value;
                OnPaintPropertyChanged();
            }
        }

        protected Rectangle IconRectangle
        {
            get
            {
                if (!_flgRect)
                    ReCalculateRectangles();
                return _rectIcon;
            }
        }
        protected Rectangle TextRectangle
        {
            get
            {
                if (!_flgRect)
                    ReCalculateRectangles();
                return _rectText;
            }
        }
        #region Public methods
        public void PerformClick()
        {
            InvokeOnClick(this, EventArgs.Empty);
        }
        #endregion

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var clientRect = ClientRectangle;
            // 同時繪製邊框，如果有設定
            switch (ControlBorderStyle)
            {
                case ControlBorderStyles.Circle:
                    using (var pen = CreatePen(ForeColor))
                    using (var brush = CreateBrush(BackColor))
                    {
                        InvokePaintBackground(Parent, e);
                        e.Graphics.FillEllipse(brush, clientRect);
                        e.Graphics.DrawEllipse(pen, clientRect);
                    }
                    break;
                case ControlBorderStyles.Round:
                    using (var pen = CreatePen(ForeColor))
                    using (var brush = CreateBrush(BackColor))
                    using (var path = Commons.CreateRoundGraphicsPath(new Rectangle(clientRect.X, clientRect.Y, clientRect.Width - 1, clientRect.Height - 1), ControlBorderRadius))
                    {
                        InvokePaintBackground(Parent, e);
                        e.Graphics.FillPath(brush, path);
                        e.Graphics.DrawPath(pen, path);
                    }
                    break;
                case ControlBorderStyles.Square:
                    using (var pen = CreatePen(ForeColor))
                    using (var brush = CreateBrush(BackColor))
                    {
                        e.Graphics.FillRectangle(brush, clientRect);
                        e.Graphics.DrawRectangle(pen, clientRect);
                    }
                    break;
                case ControlBorderStyles.None:
                    base.OnPaintBackground(e);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            // 繪製背景
            OnPaintBackground(e);

            var foreColor = Commons.GetNonEmptyColor(_colorFore, ForeColor);
            var backColor = _colorBack;
            // 如果是在設計模式就不要改顏色
            if (!DesignMode)
            {
                // 如果允許點擊才檢查顏色變化
                if (IconClickable)
                {
                    // 檢查滑鼠是否有在元件上                    
                    if (DisplayRectangle.Contains(PointToClient(MousePosition)))
                    {
                        // 沒有點選任何按鍵
                        if (MouseButtons == MouseButtons.None)
                            foreColor = Commons.GetNonEmptyColor(IconHoverColor, GetAutoMouseColor(foreColor, AutoMouseHoverColorType), foreColor);
                        // 點選任何按鍵
                        else
                            foreColor = Commons.GetNonEmptyColor(IconClickColor, GetAutoMouseColor(foreColor, AutoMouseClickColorType), foreColor);
                    }

                }
            }



            // 繪圖            
            switch (IconMode)
            {
                case IconModes.IconOnly:
                    PaintIcon(e.Graphics, foreColor, backColor);
                    break;
                case IconModes.IconOverText:
                    PaintText(e.Graphics);
                    PaintIcon(e.Graphics, foreColor, backColor);
                    break;
                case IconModes.TextOverIcon:
                    PaintIcon(e.Graphics, foreColor, backColor);
                    PaintText(e.Graphics);
                    break;
                default:
                    PaintIcon(e.Graphics, foreColor, backColor);
                    PaintText(e.Graphics);
                    break;
            }

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            OnPaintPropertyChanged();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            OnPaintPropertyChanged();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            OnPaintPropertyChanged();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            OnPaintPropertyChanged();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            OnPaintPropertyChanged();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (IconClickable)
                base.OnMouseClick(e);
            OnPaintPropertyChanged();
        }
        protected override void OnClick(EventArgs e)
        {
            if (IconClickable)
                base.OnClick(e);
            OnPaintPropertyChanged();
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            ReCalculateRectangles();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (_autoWidth)
                ReCalculateClientSize();
            OnPaintPropertyChanged();
        }

        protected Color GetAutoMouseColor(Color baseColor, AutoMouseColorType autoMouseColorType)
        {
            if (!AutoIconMouseColor)
                return Color.Empty;
            switch (autoMouseColorType)
            {
                case AutoMouseColorType.Dark:
                    return ControlPaint.Dark(baseColor);
                case AutoMouseColorType.DarkDark:
                    return ControlPaint.DarkDark(baseColor);
                case AutoMouseColorType.Light:
                    return ControlPaint.Light(baseColor);
                case AutoMouseColorType.LightLight:
                    return ControlPaint.LightLight(baseColor);
            }
            return baseColor;
        }


        protected virtual void OnPaintPropertyChanged()
        {
            Invalidate();
        }
        protected virtual void OnLayoutPropertyChanged()
        {
            PerformLayout();
            OnPaintPropertyChanged();
        }


        protected void PaintIcon(Graphics g, Color foreColor, Color backColor)
        {
            if (_icon != null && IconVisible)
            {
                var state = g.Save();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                var rect = IconRectangle;
                if (!backColor.IsEmpty)
                {
                    using (var brush = new SolidBrush(backColor))
                        g.FillRectangle(brush, rect);
                }
                Icons.IconPack.RenderIconGraphic(g, _icon, rect, IconSize, foreColor);
                g.Restore(state);
            }
        }
        protected virtual void PaintText(Graphics g)
        {
            var text = Text;
            if (!string.IsNullOrEmpty(text))
            {
                var fs = TextFormatFlags.Default | TextFormatFlags.TextBoxControl | TextFormatFlags.EndEllipsis;
                if (TextWrap)
                    fs |= TextFormatFlags.WordBreak;
                switch (_textAlign)
                {
                    case ContentAlignment.TopLeft:
                        fs |= TextFormatFlags.Left;
                        fs |= TextFormatFlags.Top;
                        break;
                    case ContentAlignment.TopCenter:
                        fs |= TextFormatFlags.HorizontalCenter;
                        fs |= TextFormatFlags.Top;
                        break;
                    case ContentAlignment.TopRight:
                        fs |= TextFormatFlags.Right;
                        fs |= TextFormatFlags.Top;
                        break;
                    case ContentAlignment.MiddleLeft:
                        fs |= TextFormatFlags.Left;
                        fs |= TextFormatFlags.VerticalCenter;
                        break;
                    case ContentAlignment.MiddleCenter:
                        fs |= TextFormatFlags.HorizontalCenter;
                        fs |= TextFormatFlags.VerticalCenter;
                        break;
                    case ContentAlignment.MiddleRight:
                        fs |= TextFormatFlags.Right;
                        fs |= TextFormatFlags.VerticalCenter;
                        break;
                    case ContentAlignment.BottomLeft:
                        fs |= TextFormatFlags.Left;
                        fs |= TextFormatFlags.Bottom;
                        break;
                    case ContentAlignment.BottomCenter:
                        fs |= TextFormatFlags.HorizontalCenter;
                        fs |= TextFormatFlags.Bottom;
                        break;
                    case ContentAlignment.BottomRight:
                        fs |= TextFormatFlags.Right;
                        fs |= TextFormatFlags.Bottom;
                        break;

                }
                TextRenderer.DrawText(g, text, Font, TextRectangle, ForeColor, fs);
            }
        }
        private void ReCalculateClientSize()
        {
            if (IconMode == IconModes.IconAfterText || IconMode == IconModes.IconBeforeText)
            {
                ReCalculateRectangles();
                if (string.IsNullOrEmpty(Text))
                {
                    Width = IconRectangle.Width;
                    return;
                }
                var text = Text;
                var font = Font;
                var measureSize = TextRenderer.MeasureText(text, font);
                var widthOffset = measureSize.Width - TextRectangle.Width;
                Width += widthOffset;
                ReCalculateRectangles();
            }
        }
        private void ReCalculateRectangles()
        {
            var size = ClientSize;

            switch (IconMode)
            {
                case IconModes.IconOnly:
                    _rectIcon = ClientRectangle;
                    _rectIcon = _rectIcon.ApplyPadding(IconMargin);
                    _rectText = Rectangle.Empty;
                    break;
                case IconModes.IconOverText:
                case IconModes.TextOverIcon:
                    _rectText = _rectIcon = ClientRectangle;
                    _rectIcon = _rectIcon.ApplyPadding(IconMargin);
                    break;
                case IconModes.IconBeforeText:
                case IconModes.IconAfterText:
                    var w = IconWidthHeight;
                    if (w == 0)
                        w = Math.Min(size.Height, size.Width);
                    if (IconMode == IconModes.IconBeforeText)
                    {
                        _rectIcon = new Rectangle(new Point(0, 0), new Size(w, size.Height));
                        _rectText = new Rectangle(new Point(w, 0), new Size(size.Width - w, size.Height));
                    }
                    else
                    {
                        _rectIcon = new Rectangle(new Point(0, 0), new Size(w, size.Height));
                        _rectText = new Rectangle(new Point(w, 0), new Size(size.Width - w, size.Height));
                    }
                    _rectIcon = _rectIcon.ApplyPadding(IconMargin);
                    break;
                case IconModes.IconAboveText:
                case IconModes.IconUnderText:
                    if (HasText())
                    {
                        // 如果有文字，就先計算文字大小
                        int textHeight = 0;

                        var proposedSize = new Size(size.Width, 0);
                        var fs = TextFormatFlags.Default | TextFormatFlags.TextBoxControl | TextFormatFlags.EndEllipsis;
                        if (TextWrap)
                            fs |= TextFormatFlags.WordBreak;
                        var measureSize = TextRenderer.MeasureText(Text, Font, proposedSize, fs);
                        textHeight = measureSize.Height;
                        if (IconMode == IconModes.IconAboveText)
                        {
                            _rectText = new Rectangle(new Point(0, size.Height - textHeight), new Size(size.Width, textHeight));
                            _rectIcon = new Rectangle(new Point(0, 0), new Size(size.Width, size.Height - textHeight));
                        }
                        else
                        {
                            _rectText = new Rectangle(new Point(0, 0), new Size(size.Width, textHeight));
                            _rectIcon = new Rectangle(new Point(0, textHeight), new Size(size.Width, size.Height - textHeight));
                        }
                    }
                    else
                    {
                        var h = IconWidthHeight;
                        if (h == 0)
                            h = Math.Min(size.Height, size.Width);
                        // 否則文字大小固定為0
                        if (IconMode == IconModes.IconAboveText)
                        {
                            _rectIcon = new Rectangle(new Point(0, 0), new Size(size.Width, h));
                            _rectText = new Rectangle(new Point(0, size.Height), new Size(size.Width, 0));
                        }
                        else
                        {
                            _rectIcon = new Rectangle(new Point(0, size.Height - h), new Size(size.Width, h));
                            _rectText = new Rectangle(new Point(0, 0), new Size(size.Width, 0));
                        }
                    }
                    _rectIcon = _rectIcon.ApplyPadding(IconMargin);
                    break;
            }
            _flgRect = true;
        }
        private bool HasText()
        {
            return !string.IsNullOrEmpty(Text);
        }
        private Pen CreatePen(Color color)
        {
            return new Pen(color, ControlBorderWidth)
            {
                Alignment = ControlBorderAlignment,
            };
        }
        private Brush CreateBrush(Color color)
        {
            return new SolidBrush(color);
        }

        public enum AutoMouseColorType
        {
            Light,
            LightLight,
            Dark,
            DarkDark,
        }

    }

    public enum ControlBorderStyles
    {
        None,
        Circle,
        Round,
        Square,
    }

    /// <summary>
    /// 圖示模式
    /// </summary>
    public enum IconModes
    {
        /// <summary>
        /// 只有圖
        /// </summary>
        IconOnly,
        /// <summary>
        /// 圖重疊於文字上
        /// </summary>
        IconOverText,
        /// <summary>
        /// 字重疊於圖上
        /// </summary>
        TextOverIcon,
        /// <summary>
        /// 先畫圖再畫文字
        /// </summary>
        IconBeforeText,
        /// <summary>
        /// 先畫文字再畫圖
        /// </summary>
        IconAfterText,
        /// <summary>
        /// 圖在上
        /// </summary>
        IconAboveText,
        /// <summary>
        /// 圖在下
        /// </summary>
        IconUnderText,
    }
}

