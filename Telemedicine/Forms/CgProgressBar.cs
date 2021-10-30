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
    [Designer(typeof(CgProgressBarDesigner))]
    public class CgProgressBar : CgUserControl
    {
        private string _progressText;
        private bool _customProgressText;
        private Label textMessage;
        private int _pogressBarHeight;

        public CgProgressBar()
        {
            InitializeComponent();
            textProgress.Font = new Font("Consolas", 9f);
            UpdateProgressText();
        }
        [DefaultValue(null)]
        public string ProgressText
        {
            get { return _progressText; }
            set
            {
                _progressText = value;
                UpdateProgressText();
            }
        }
        [DefaultValue(false)]
        public bool CustomProgressText
        {
            get { return _customProgressText; }
            set
            {
                _customProgressText = value;
                UpdateProgressText();
            }
        }

        [DefaultValue(0)]
        public int ProgressBarHeight
        {
            get { return _pogressBarHeight; }
            set
            {
                _pogressBarHeight = value;
                barProgress.Height = value == 0 ? 23 : value;
                PerformAutoSize();
            }
        }
        
        [DefaultValue(0)]
        public int ProgressValue
        {
            get { return barProgress.Value; }
            set
            {
                barProgress.Value = value;
                OnProgressValueChanged();
            }
        }
        [DefaultValue(100)]
        public int ProgressMaximum
        {
            get { return barProgress.Maximum; }
            set
            {
                barProgress.Maximum = value;
                UpdateProgressText();
            }
        }

        [DefaultValue(0)]
        public int ProgressMinimum
        {
            get { return barProgress.Minimum; }
            set
            {
                barProgress.Minimum = value;
                UpdateProgressText();
            }
        }
        [DefaultValue("")]
        public string ProgressMessage
        {
            get { return textMessage.Text; }
            set
            {
                textMessage.Text = value;
                PerformAutoSize();
            }
        }
        
        [DefaultValue(typeof(Font), "Consolas, 9F")]
        public Font ProgressFont
        {
            get { return textProgress.Font; }
            set { textProgress.Font = value; }
        }
        public event EventHandler ProgressValueChanged;


        public void UpdateProgressText()
        {
            if (_customProgressText)
            {
                textProgress.Text = _progressText;
            }
            else
            {
                var maximumLen = barProgress.Maximum.ToString().Length;
                var format = "{0," + maximumLen + "}/{1}";
                var text = string.Format(format, barProgress.Value, barProgress.Maximum);
                //var width = TextRenderer.MeasureText(text, Font).Width + 6;
                textProgress.Text = text;
            }
        }



        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ChangeProgressTextFont();
        }
        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            ChangeProgressTextFont();
        }

        protected void PerformAutoSize()
        {
            SetBoundsCore(Left, Top, Width, Height, BoundsSpecified.Size);
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            var h = textProgress.Height + textProgress.Margin.Vertical;
            if (textMessage.Visible)            
                h += textMessage.Height + textMessage.Margin.Vertical;            
            h += DefaultMargin.Vertical; 
            //base.SetBoundsCore(x, y, width, height, specified);
            base.SetBoundsCore(x, y, width, h, specified);
        }
        protected virtual void OnProgressValueChanged()
        {
            UpdateProgressText();


            var handler = ProgressValueChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        protected virtual void ChangeProgressTextFont()
        {
            //var newFont = new Font(Font.FontFamily, Font.Size);
            PerformAutoSize();
        }
        private void textMessage_TextChanged(object sender, EventArgs e)
        {
            textMessage.Visible = textMessage.Text.Length != 0;
        }
        #region Designer
        private void InitializeComponent()
        {
            this.barProgress = new System.Windows.Forms.ProgressBar();
            this.textProgress = new System.Windows.Forms.Label();
            this.panelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.textMessage = new System.Windows.Forms.Label();
            this.panelLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // barProgress
            // 
            this.barProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barProgress.Location = new System.Drawing.Point(0, 72);
            this.barProgress.Margin = new System.Windows.Forms.Padding(0);
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(144, 23);
            this.barProgress.TabIndex = 0;
            // 
            // textProgress
            // 
            this.textProgress.AutoSize = true;
            this.textProgress.Dock = System.Windows.Forms.DockStyle.Right;
            this.textProgress.Location = new System.Drawing.Point(148, 72);
            this.textProgress.Name = "textProgress";
            this.textProgress.Size = new System.Drawing.Size(0, 23);
            this.textProgress.TabIndex = 1;
            this.textProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelLayout
            // 
            this.panelLayout.ColumnCount = 2;
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelLayout.Controls.Add(this.barProgress, 0, 2);
            this.panelLayout.Controls.Add(this.textProgress, 1, 2);
            this.panelLayout.Controls.Add(this.textMessage, 0, 1);
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayout.Location = new System.Drawing.Point(0, 0);
            this.panelLayout.Margin = new System.Windows.Forms.Padding(0);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.RowCount = 4;
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelLayout.Size = new System.Drawing.Size(150, 150);
            this.panelLayout.TabIndex = 2;
            // 
            // textMessage
            // 
            this.textMessage.AutoSize = true;
            this.panelLayout.SetColumnSpan(this.textMessage, 2);
            this.textMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMessage.Location = new System.Drawing.Point(3, 57);
            this.textMessage.Margin = new System.Windows.Forms.Padding(3);
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(144, 12);
            this.textMessage.TabIndex = 2;
            this.textMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.textMessage.Visible = false;
            this.textMessage.TextChanged += new System.EventHandler(this.textMessage_TextChanged);
            // 
            // CgProgressBar
            // 
            this.Controls.Add(this.panelLayout);
            this.Name = "CgProgressBar";
            this.panelLayout.ResumeLayout(false);
            this.panelLayout.PerformLayout();
            this.ResumeLayout(false);

        }
        private ProgressBar barProgress;
        private TableLayoutPanel panelLayout;
        private Label textProgress;
        #endregion

        private class CgProgressBarDesigner : ControlDesigner
        {
            CgProgressBarDesigner()
            {
                AutoResizeHandles = true;
            }
            public override SelectionRules SelectionRules
            {
                get { return SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable; }
            }

        }


    }


}

