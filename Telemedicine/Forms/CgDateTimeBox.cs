using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Telemedicine.Forms
{
    [Designer(typeof(CgDateTimeBoxDesigner))]
    public class CgDateTimeBox : CgUserControl
    {
        private DateTime? _value;
        private bool _suspendChangeText;
        public CgDateTimeBox()
        {
            InitializeComponent();
            UseWeekBracket = true;
            UseWeekForeColor = true;
            BorderStyle = BorderStyle.FixedSingle;
            if (!DesignMode)
            {
                iconCalendar.Icon = Icons.FontAwesomeIcon.CalendarAlt;
            }
        }
        #region 屬性
        [DefaultValue(null)]
        public DateTime? Value
        {
            get { return _value; }
            set
            {
                _value = value;
                ChangeValueText();
            }
        }
        [DefaultValue("")]
        public string ValueText
        {
            get
            {
                if (_value == null)
                    return "";
                return _value.Value.ToString("yyyyMMdd");
            }
        }
        public new string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        [Editor(typeof(Design.FormControlEditor), typeof(UITypeEditor))]
        [DefaultValue(null)]
        public Control WeekControl { get; set; }
        [DefaultValue(true)]
        public bool UseWeekBracket { get; set; }
        [DefaultValue(true)]
        public bool UseWeekForeColor { get; set; }
        [DefaultValue(false)]
        public bool AllowEmpty { get; set; }
        [DefaultValue(null)]
        public string ValidateFailureMessage { get; set; }
        [DefaultValue(false)]
        public bool UseCalendar
        {
            get { return iconCalendar.Visible; }
            set { iconCalendar.Visible = value; }
        }
        #endregion

        public event ValueChangedEventHandler ValueChanged;
        public event HandledEventHandler ValidateFailure;

        protected void ChangeValue(DateTime? value, bool changeText)
        {
            if (value != _value)
            {
                // 改變值
                _value = value;
                if (changeText)
                {
                    ChangeValueText();
                }

                if (WeekControl != null)
                {
                    string week = null;
                    Color foreColor = Color.Empty;
                    if (_value.HasValue)
                    {
                        week = GetDayOfWeekText(null, _value.Value);
                        if (UseWeekBracket)
                            week = "(" + week + ")";
                        if (UseWeekForeColor)
                            foreColor = _value.Value.DayOfWeek == DayOfWeek.Saturday || _value.Value.DayOfWeek == DayOfWeek.Sunday
                                ? Color.Red
                                : SystemColors.ControlText;
                    }
                    WeekControl.Text = week;
                    if (!foreColor.IsEmpty)
                        WeekControl.ForeColor = foreColor;
                }
                OnValueChanged();
            }
        }

        protected void ChangeValueText()
        {
            _suspendChangeText = true;
            var text = _value.HasValue ? _value.Value.ToString("yyyy/MM/dd") : null;
            textBox.Text = text;
            _suspendChangeText = false;
        }



        protected void PerformAutoSize()
        {
            SetBoundsCore(Left, Top, Width, Height, BoundsSpecified.Size);
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ChangeTextBoxFont();
        }
        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            ChangeTextBoxFont();
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            var h = textBox.Height + 6;
            //base.SetBoundsCore(x, y, width, height, specified);
            iconCalendar.Width = textBox.Height;
            base.SetBoundsCore(x, y, width, h, specified);
        }
        protected virtual void ChangeTextBoxFont()
        {
            PerformAutoSize();
        }

        protected bool TryValidateText(out DateTime? date)
        {
            var text = textBox.Text;
            return TryValidateText(text, out date);
        }
        protected bool TryValidateText(string text, out DateTime? date)
        {
            bool valid = false;
            DateTime d;
            if (DateTime.TryParseExact(text, "yyyy/MM/dd", null, DateTimeStyles.None, out d))
            {
                date = d;
                valid = true;
            }
            else
            {
                date = null;
                if (string.IsNullOrEmpty(text) && AllowEmpty)
                    valid = true;
            }
            return valid;
        }
        protected void ShowValidateFailureMessage()
        {
            if (!string.IsNullOrEmpty(ValidateFailureMessage))
            {
                // 呈現錯誤訊息
                var form = FindForm();
                var caption = form != null ? form.Text : null;
                MsgBoxHelper.Warning(ValidateFailureMessage, caption);
            }
        }
        protected virtual void OnValueChanged()
        {
            var args = _value.HasValue
                    ? new ValueChangedEventArgs(_value.Value)
                    : new ValueChangedEventArgs();
            OnValueChanged(args);
        }
        protected override void OnGotFocus(EventArgs e)
        {
            //base.OnGotFocus(e);
            textBox.Focus();
        }
        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            var handler = ValueChanged;
            if (handler != null)
                handler(this, e);
        }
        protected virtual void OnValidateFailure()
        {
            var args = new HandledEventArgs();
            OnValidateFailure(args);
            if (!args.Handled)
            {
                ShowValidateFailureMessage();
                Focus();
            }
        }

        protected virtual void OnValidateFailure(HandledEventArgs e)
        {
            var handler = ValidateFailure;
            if (handler != null)
                handler(this, e);
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!_suspendChangeText)
            {
                if (textBox.MaskFull)
                {
                    DateTime? date;
                    if (TryValidateText(out date))
                    {
                        ChangeValue(date, false);
                        return;
                    }
                    // 驗證失敗
                    OnValidateFailure();
                }
            }
        }


        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            DateTime? date;
            if (TryValidateText(out date))
                ChangeValue(date, false);
            else
            {
                var args = new HandledEventArgs();
                OnValidateFailure(args);
                if (!args.Handled)
                {
                    ShowValidateFailureMessage();
                    ChangeValue(_value, false);
                    ChangeValueText();
                }
            }
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTime? date;
                if (TryValidateText(out date))
                    ChangeValue(date, false);
                else
                    OnValidateFailure();
            }
        }
        private static string GetDayOfWeekText(CultureInfo culture, DateTime dateTime)
        {
            var formatter = DateTimeFormatInfo.GetInstance(culture ?? CultureInfo.CurrentCulture);
            var dayOfWeek = formatter.GetShortestDayName(dateTime.DayOfWeek);
            return dayOfWeek;
        }
        private void iconCalendar_Click(object sender, EventArgs e)
        {

        }
        #region Designer
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.MaskedTextBox();
            this.iconCalendar = new CgIconControl();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Mask = "0000/00/00";
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(75, 15);
            this.textBox.TabIndex = 0;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Validating);
            // 
            // iconCalendar
            // 
            this.iconCalendar.AutoIconMouseColor = true;
            this.iconCalendar.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconCalendar.Location = new System.Drawing.Point(75, 0);
            this.iconCalendar.Name = "iconCalendar";
            this.iconCalendar.Size = new System.Drawing.Size(75, 150);
            this.iconCalendar.TabIndex = 1;
            this.iconCalendar.Visible = false;
            this.iconCalendar.Click += new System.EventHandler(this.iconCalendar_Click);
            // 
            // CgDateTimeBox
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.iconCalendar);
            this.Name = "CgDateTimeBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private CgIconControl iconCalendar;
        private MaskedTextBox textBox;
        #endregion

        private class CgDateTimeBoxDesigner : ControlDesigner
        {
            CgDateTimeBoxDesigner()
            {
                AutoResizeHandles = true;
            }
            public override SelectionRules SelectionRules
            {
                get { return SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable; }
            }

        }

        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);
        public class ValueChangedEventArgs : EventArgs
        {

            public ValueChangedEventArgs()
            {
                IsEmpty = true;
            }
            public ValueChangedEventArgs(DateTime value)
            {
                Value = value;
            }
            public DateTime Value { get; private set; }
            public bool IsEmpty { get; private set; }
        }


    }
}

