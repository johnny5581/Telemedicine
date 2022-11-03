using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Telemedicine.Forms
{
    [Designer(typeof(CgLabelControlDesigner))]
    public abstract class CgLabelControlBase : CgUserControl
    {
        private TableLayoutPanel panelLayout;
        private Label labelHeader;
        private HorizontalAlignment _headerAlign;
        private Control _control;
        private bool _grouping;
        private Label labelColon;
        private string _symbolColon;
        private int _componentHeight;

        public CgLabelControlBase()
        {
            InitializeComponent();
            _grouping = true;
            _control = GetMainComponent();
            if (_control != null)
            {
                _control.Dock = DockStyle.Fill;
                Controls.Add(_control);
                Controls.SetChildIndex(_control, 0);
            }
        }
        [DefaultValue(false)]
        public bool IsColon
        {
            get { return labelColon.Visible; }
            set
            {
                labelColon.Visible = value;
                ResetHeaderColon();
            }
        }
        [DefaultValue(null)]
        public string ColonSymbol
        {
            get { return _symbolColon; }
            set
            {
                _symbolColon = value;
                ResetHeaderColon();
            }
        }
        [DefaultValue(true)]
        public bool IsGrouping
        {
            get { return _grouping; }
            set
            {
                _grouping = value;
                SyncOthersHeaderWidth();
            }
        }
        [DefaultValue("")]
        public string Header
        {
            get { return labelHeader.Text; }
            set
            {
                labelHeader.Text = value;
                SyncOthersHeaderWidth();
            }
        }
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment HeaderAlign
        {
            get { return _headerAlign; }
            set
            {
                _headerAlign = value;
                switch (_headerAlign)
                {
                    case HorizontalAlignment.Center:
                        panelLayout.ColumnStyles[0].Width = 50f;
                        panelLayout.ColumnStyles[3].Width = 50f;
                        break;
                    case HorizontalAlignment.Left:
                        panelLayout.ColumnStyles[0].Width = 0f;
                        panelLayout.ColumnStyles[3].Width = 100f;
                        break;
                    case HorizontalAlignment.Right:
                        panelLayout.ColumnStyles[0].Width = 100f;
                        panelLayout.ColumnStyles[3].Width = 0f;
                        break;
                }
            }
        }
        [Browsable(false)]
        protected Control Control
        {
            get { return _control; }
        }
        [DefaultValue("")]
        [Bindable(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get
            {
                return _control.Text;
            }

            set
            {
                _control.Text = value;
            }
        }

        internal int LabelWidth
        {
            get { return labelHeader.Width + labelHeader.Margin.Horizontal + labelColon.Width + labelColon.Margin.Horizontal; }
        }
        internal int HeaderWidth
        {
            get { return panelLayout.Width; }
        }
        [DefaultValue(0)]
        public int ComponentHeight
        {
            get { return _componentHeight; }
            set
            {
                _componentHeight = value;
                PerformAutoSize();
            }
        }
        [DefaultValue(typeof(Padding), "1,1,1,1")]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        internal void SetHeaderWidth(int width)
        {
            panelLayout.Width = width;
            PerformLayout();
            Refresh();
        }
        protected void ResetHeaderColon()
        {
            labelColon.Text = _symbolColon == null || _symbolColon.Length == 0 ? ":" : _symbolColon;
            SyncOthersHeaderWidth();
        }
        protected void SyncOthersHeaderWidth()
        {
            // 跟同一區的做比較
            var parent = Parent;
            var labelWidth = LabelWidth;
            if (parent != null)
            {
                var refCtrls = parent.Controls.OfType<CgLabelControlBase>().Where(r => r != this && r.IsGrouping);
                if (refCtrls.Count() > 0) // 如果有其他人
                {
                    var maximize = IsGrouping ? labelWidth : 0;
                    foreach (var ctrl in refCtrls)
                        maximize = Math.Max(maximize, ctrl.LabelWidth);
                    foreach (var ctrl in refCtrls)
                        ctrl.SetHeaderWidth(maximize);
                    if (IsGrouping)
                        labelWidth = maximize;
                }
            }
            SetHeaderWidth(labelWidth);
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            SyncOthersHeaderWidth();
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            PerformAutoSize();
            SyncOthersHeaderWidth();
            Invalidate();
        }
        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            PerformAutoSize();
            SyncOthersHeaderWidth();
            Invalidate();
        }

        protected void PerformAutoSize()
        {
            SetBoundsCore(Left, Top, Width, Height, BoundsSpecified.Size);
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (_control != null)
            {
                var h = IsMainComponentAutoHeight() ? _control.Height : ComponentHeight == 0 ? Font.Height : ComponentHeight;
                height = h + Padding.Vertical + _control.Margin.Vertical;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected virtual Control GetMainComponent()
        {
            return null;
        }
        protected virtual bool IsMainComponentAutoHeight()
        {
            return false;
        }
        #region designer
        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelColon = new System.Windows.Forms.Label();
            this.panelLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Location = new System.Drawing.Point(3, 6);
            this.labelHeader.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(0, 12);
            this.labelHeader.TabIndex = 0;
            // 
            // panelLayout
            // 
            this.panelLayout.ColumnCount = 4;
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLayout.Controls.Add(this.labelColon, 2, 1);
            this.panelLayout.Controls.Add(this.labelHeader, 1, 1);
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLayout.Location = new System.Drawing.Point(1, 1);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.RowCount = 3;
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelLayout.Size = new System.Drawing.Size(60, 25);
            this.panelLayout.TabIndex = 2;
            // 
            // labelColon
            // 
            this.labelColon.AutoSize = true;
            this.labelColon.Location = new System.Drawing.Point(3, 6);
            this.labelColon.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labelColon.Name = "labelColon";
            this.labelColon.Size = new System.Drawing.Size(0, 12);
            this.labelColon.TabIndex = 1;
            this.labelColon.Visible = false;
            // 
            // CgLabelControlBase
            // 
            this.Controls.Add(this.panelLayout);
            this.Name = "CgLabelControlBase";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(150, 27);
            this.panelLayout.ResumeLayout(false);
            this.panelLayout.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private class CgLabelControlDesigner : ControlDesigner
        {
            CgLabelControlDesigner()
            {
                AutoResizeHandles = true;
            }
            public override SelectionRules SelectionRules
            {
                get { return SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable; }
            }
        }
    }
    public class CgLabelControl : CgLabelControlBase
    {
        private Label label;
        protected override Control GetMainComponent()
        {
            label = new Label { AutoSize = true };
            return label;
        }
        public Label Label
        {
            get { return (Label)Control; }
        }
        protected override bool IsMainComponentAutoHeight()
        {
            return true;
        }
    }
    public class CgLabelTextBox : CgLabelControlBase, ICgTextBox
    {
        private CgTextBox textBox;
        protected override Control GetMainComponent()
        {
            textBox = new CgTextBox();
            return textBox;
        }
        public CgTextBox TextBox
        {
            get { return (CgTextBox)Control; }
        }

        [DefaultValue(null)]
        public string WatermarkText
        {
            get
            {
                return ((ICgTextBox)textBox).WatermarkText;
            }

            set
            {
                ((ICgTextBox)textBox).WatermarkText = value;
            }
        }
        [DefaultValue(CharacterCasing.Normal)]
        public CharacterCasing CharacterCasing
        {
            get
            {
                return ((ICgTextBox)textBox).CharacterCasing;
            }

            set
            {
                ((ICgTextBox)textBox).CharacterCasing = value;
            }
        }
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return ((ICgTextBox)textBox).TextAlign;
            }

            set
            {
                ((ICgTextBox)textBox).TextAlign = value;
            }
        }
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get
            {
                return ((ICgTextBox)textBox).ReadOnly;
            }

            set
            {
                ((ICgTextBox)textBox).ReadOnly = value;
            }
        }

        [Browsable(true)]
        public new event EventHandler TextChanged
        {
            add { textBox.TextChanged += value; }
            remove { textBox.TextChanged -= value; }
        }
        public new event KeyEventHandler KeyDown
        {
            add { textBox.KeyDown += value; }
            remove { textBox.KeyDown -= value; }
        }
        public new event KeyPressEventHandler KeyPress
        {
            add { textBox.KeyPress += value; }
            remove { textBox.KeyPress -= value; }
        }
        protected override bool IsMainComponentAutoHeight()
        {
            return true;
        }
    }
    public class CgLabelComboBox : CgLabelControlBase, ICgComboBox
    {
        private CgComboBox comboBox;

        public event CgComboBox.DrawItemStyleEventHandler DrawItemStyle
        {
            add
            {
                ((ICgComboBox)comboBox).DrawItemStyle += value;
            }

            remove
            {
                ((ICgComboBox)comboBox).DrawItemStyle -= value;
            }
        }

        public event EventHandler SelectedIndexChanged
        {
            add
            {
                ((ICgComboBox)comboBox).SelectedIndexChanged += value;
            }

            remove
            {
                ((ICgComboBox)comboBox).SelectedIndexChanged -= value;
            }
        }

        protected override Control GetMainComponent()
        {
            comboBox = new CgComboBox();
            return comboBox;
        }

        public int AddItem(CgComboBox.ComboBoxItem cbItem)
        {
            return ((ICgComboBox)comboBox).AddItem(cbItem);
        }

        public int AddItem(object item)
        {
            return ((ICgComboBox)comboBox).AddItem(item);
        }

        public int AddItem(object item, string text, object value)
        {
            return ((ICgComboBox)comboBox).AddItem(item, text, value);
        }

        public int AddItem<T, V>(T item, Func<T, string> textResolver, Func<T, V> valueResolver)
        {
            return ((ICgComboBox)comboBox).AddItem(item, textResolver, valueResolver);
        }

        public int AddItem<T>(T item, Func<T, string> textResolver)
        {
            return ((ICgComboBox)comboBox).AddItem(item, textResolver);
        }

        public void AddItemRange<T, V>(IEnumerable<T> items, Func<T, string> textResolver, Func<T, V> valueResolver, Action<T, CgComboBox.ComboBoxItem> configure = null)
        {
            ((ICgComboBox)comboBox).AddItemRange(items, textResolver, valueResolver, configure);
        }

        public void AddItemRange<T>(IEnumerable<T> items, Func<T, string> textResolver, Action<T, CgComboBox.ComboBoxItem> configure = null)
        {
            ((ICgComboBox)comboBox).AddItemRange(items, textResolver, configure);
        }

        public int AddTextItem(string text)
        {
            return ((ICgComboBox)comboBox).AddTextItem(text);
        }

        public int AddTextItem(string text, object value)
        {
            return ((ICgComboBox)comboBox).AddTextItem(text, value);
        }

        public void AddTextItemRange(string[] texts, object[] values)
        {
            ((ICgComboBox)comboBox).AddTextItemRange(texts, values);
        }

        public CgComboBox.ComboBoxItem GetComboBoxItem(int index)
        {
            return ((ICgComboBox)comboBox).GetComboBoxItem(index);
        }

        public int GetIndexOfItem<T>(T item, IEqualityComparer<T> comparer = null, Func<object, T> converter = null)
        {
            return ((ICgComboBox)comboBox).GetIndexOfItem(item, comparer, converter);
        }

        public int GetIndexOfItemText(string text, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return ((ICgComboBox)comboBox).GetIndexOfItemText(text, comparison);
        }

        public int GetIndexOfItemValue<T>(T value, IEqualityComparer<T> comparer = null, Func<object, T> converter = null)
        {
            return ((ICgComboBox)comboBox).GetIndexOfItemValue(value, comparer, converter);
        }

        public void PerformSelectedIndexChanged()
        {
            ((ICgComboBox)comboBox).PerformSelectedIndexChanged();
        }

        public int SelectItem(Func<CgComboBox.ComboBoxItem, bool> selector)
        {
            return ((ICgComboBox)comboBox).SelectItem(selector);
        }

        public int SelectItem<T>(Func<T, bool> itemSelector, Func<object, T> converter = null)
        {
            return ((ICgComboBox)comboBox).SelectItem(itemSelector, converter);
        }

        public int SelectItem<T>(T item, IEqualityComparer<T> comparer = null, Func<object, T> converter = null)
        {
            return ((ICgComboBox)comboBox).SelectItem(item, comparer, converter);
        }

        public int SelectValue<T>(Func<T, bool> itemSelector, Func<object, T> converter = null)
        {
            return ((ICgComboBox)comboBox).SelectValue(itemSelector, converter);
        }

        public int SelectValue<T>(T value, IEqualityComparer<T> comparer = null, Func<object, T> converter = null)
        {
            return ((ICgComboBox)comboBox).SelectValue(value, comparer, converter);
        }

        public CgComboBox ComboBox
        {
            get { return (CgComboBox)Control; }
        }
        public int ItemCount
        {
            get
            {
                return ((ICgComboBox)comboBox).ItemCount;
            }
        }

        public CgComboBox.ComboBoxItem SelectedComboItem
        {
            get
            {
                return ((ICgComboBox)comboBox).SelectedComboItem;
            }
        }

        public object SelectedItem
        {
            get
            {
                return ((ICgComboBox)comboBox).SelectedItem;
            }
        }
        [DefaultValue(null)]
        public object SelectedValue
        {
            get { return ((ICgComboBox)comboBox).SelectedValue; }
            set
            {
                ((ICgComboBox)comboBox).SelectedValue = value;
            }
        }
        [DefaultValue(-1)]
        public int SelectedIndex
        {
            get
            {
                return ((ICgComboBox)comboBox).SelectedIndex;
            }

            set
            {
                ((ICgComboBox)comboBox).SelectedIndex = value;
            }
        }
        [DefaultValue("")]
        public string SelectedText
        {
            get { return ((ICgComboBox)comboBox).SelectedText; }
            set
            {
                ((ICgComboBox)comboBox).SelectedText = value;
            }
        }
        [DefaultValue(ComboBoxStyle.DropDown)]
        public ComboBoxStyle DropDownStyle
        {
            get { return ((ICgComboBox)comboBox).DropDownStyle; }
            set
            {
                ((ICgComboBox)comboBox).DropDownStyle = value;
            }
        }

        public ComboBox.ObjectCollection Items
        {
            get
            {
                return ((ICgComboBox)comboBox).Items;
            }
        }
        protected override bool IsMainComponentAutoHeight()
        {
            return true;
        }

        public void AddItemRange<T>(Func<T, string> textResolver) where T : struct
        {
            ((ICgComboBox)comboBox).AddItemRange(textResolver);
        }
    }

    public class CgLabelDateTimePicker : CgLabelControlBase
    {
        private DateTimePicker dateTimePicker;
        protected override Control GetMainComponent()
        {
            dateTimePicker = new DateTimePicker();
            dateTimePicker.Value = DateTime.Now;
            return dateTimePicker;
        }
        public DateTimePicker DateTimePicker
        {
            get { return (DateTimePicker)Control; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Value
        {
            get { return dateTimePicker.Value; }
            set { dateTimePicker.Value = value; }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DefaultValue(null)]
        public new string Text { get; set; }
        protected override bool IsMainComponentAutoHeight()
        {
            return true;
        }
    }

    public class CgLabelCustomControl : CgLabelControlBase
    {
        private CgLayoutPanel panel;
        public CgLayoutPanel LayoutPanel
        {
            get { return (CgLayoutPanel)Control; }
        }
        protected override Control GetMainComponent()
        {
            panel = new CgLayoutPanel();
            panel.Size = new Size(23, Font.Height);
            return panel;
        }
    }


}

