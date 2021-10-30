using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgBaseDialogForm : CgDialogForm, IMessageDialog
    {
        private DialogResult _positiveResult = DialogResult.OK;
        private DialogResult _negativeResult = DialogResult.Cancel;
        public CgBaseDialogForm()
        {
            InitializeComponent();
            InitializeCustomizeComponents();
        }

        [DefaultValue("&OK")]
        public string PositiveText
        {
            get { return buttonOK.Text; }
            set { buttonOK.Text = value; }
        }
        [DefaultValue(DialogResult.OK)]
        public DialogResult PositiveResult
        {
            get { return _positiveResult; }
            set { _positiveResult = value; }
        }
        [DefaultValue("&Cancel")]
        public string NegativeText
        {
            get { return buttonCancel.Text; }
            set { buttonCancel.Text = value; }
        }
        [DefaultValue(DialogResult.Cancel)]
        public DialogResult NegativeResult
        {
            get { return _negativeResult; }
            set { _negativeResult = value; }
        }

        [DefaultValue(true)]
        public bool ButtonPanelEnabled
        {
            get { return panelControl.Visible; }
            set { panelControl.Visible = value; }
        }
        [DefaultValue("")]
        public string Caption
        {
            get { return Text; }
            set { Text = value; }
        }
        [DefaultValue("")]
        public string Message
        {
            get { return textMessage.Text; }
            set { textMessage.Text = value; }
        }
        [DefaultValue("")]
        public string SubMessage
        {
            get { return textMessage2.Text; }
            set { textMessage2.Text = value; }
        }


        public void ChangeIcon(object icon, int size)
        {
            ChangeIcon(icon);
            ChangeIconSize(size);
        }
        public void ChangeIcon(object icon)
        {
            if (icon == null)
            {
                // 清除圖示
                imageIcon.Image = null;
                imageIcon.Visible = false;
                return;
            }
            var iconType = icon.GetType();
            if (typeof(Image).IsAssignableFrom(iconType))
            {
                imageIcon.Image = (Image)icon;
            }
            else if (typeof(Icon).IsAssignableFrom(iconType))
            {
                imageIcon.Image = ((Icon)icon).ToBitmap();
            }
            else if (typeof(string) == iconType || iconType.GetCustomAttributes(typeof(Icons.IconInfoAttribute), false).Length > 0)
            {
                var image = new Bitmap(imageIcon.Width, imageIcon.Height);
                using (var g = Graphics.FromImage(image))
                    Icons.IconPack.RenderIconGraphic(g, icon, new RectangleF(0, 0, imageIcon.Width, imageIcon.Height), 0f, ForeColor);
                imageIcon.Image = image;
            }
            imageIcon.Visible = true;
        }
        public void ChangeIconSize(int size)
        {
            if (size != 0)
                imageIcon.Width = size;
        }

        public void ChangeMessageStyle(Font font, Color? foreColor, bool changeSub)
        {
            if (font != null)
                textMessage.Font = font;
            if (foreColor != null)
                textMessage.ForeColor = foreColor.Value;
            if (changeSub)
                ChangeSubMessageStyle(font, foreColor);
        }

        public void ChangeSubMessageStyle(Font font, Color? foreColor)
        {
            if (font != null)
                textMessage2.Font = font;
            if (foreColor != null)
                textMessage2.ForeColor = foreColor.Value;            
        }



        protected virtual void OnPositiveClicking(CancelEventArgs e)
        {

        }

        protected virtual void OnNegativeClicking(CancelEventArgs e)
        {

        }



        protected virtual Control GetMainComponent()
        {
            return null;
        }
        protected virtual int GetMainComponentHeight()
        {
            return 0;
        }
        protected virtual void ResetMainComponentHeight()
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var args = new CancelEventArgs();
            OnPositiveClicking(args);
            if (args.Cancel)
                return;
            DialogResult = _positiveResult;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var args = new CancelEventArgs();
            OnNegativeClicking(args);
            if (args.Cancel)
                return;
            DialogResult = _negativeResult;
        }

        #region Designer
        protected System.Windows.Forms.TableLayoutPanel panelLayout;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;

        private void InitializeComponent()
        {
            this.panelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelText = new System.Windows.Forms.Panel();
            this.textMessage = new System.Windows.Forms.Label();
            this.textMessage2 = new System.Windows.Forms.Label();
            this.imageIcon = new System.Windows.Forms.PictureBox();
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageIcon)).BeginInit();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLayout
            // 
            this.panelLayout.ColumnCount = 1;
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelLayout.Controls.Add(this.panel1, 0, 0);
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayout.Location = new System.Drawing.Point(0, 0);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.RowCount = 3;
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelLayout.Size = new System.Drawing.Size(434, 65);
            this.panelLayout.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelText);
            this.panel1.Controls.Add(this.imageIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 58);
            this.panel1.TabIndex = 4;
            // 
            // panelText
            // 
            this.panelText.Controls.Add(this.textMessage);
            this.panelText.Controls.Add(this.textMessage2);
            this.panelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelText.Location = new System.Drawing.Point(58, 0);
            this.panelText.Name = "panelText";
            this.panelText.Padding = new System.Windows.Forms.Padding(3);
            this.panelText.Size = new System.Drawing.Size(370, 58);
            this.panelText.TabIndex = 3;
            // 
            // textMessage
            // 
            this.textMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMessage.Location = new System.Drawing.Point(3, 3);
            this.textMessage.Margin = new System.Windows.Forms.Padding(3);
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(364, 31);
            this.textMessage.TabIndex = 3;
            this.textMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textMessage2
            // 
            this.textMessage2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textMessage2.Location = new System.Drawing.Point(3, 34);
            this.textMessage2.Margin = new System.Windows.Forms.Padding(3);
            this.textMessage2.Name = "textMessage2";
            this.textMessage2.Size = new System.Drawing.Size(364, 21);
            this.textMessage2.TabIndex = 2;
            this.textMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageIcon
            // 
            this.imageIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.imageIcon.Location = new System.Drawing.Point(0, 0);
            this.imageIcon.Name = "imageIcon";
            this.imageIcon.Size = new System.Drawing.Size(58, 58);
            this.imageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageIcon.TabIndex = 1;
            this.imageIcon.TabStop = false;
            this.imageIcon.Visible = false;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.buttonOK);
            this.panelControl.Controls.Add(this.buttonCancel);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 65);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(434, 36);
            this.panelControl.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(266, 7);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(347, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CgBaseDialogForm
            // 
            this.AcceptButton = this.buttonOK;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(434, 101);
            this.Controls.Add(this.panelLayout);
            this.Controls.Add(this.panelControl);
            this.Name = "CgBaseDialogForm";
            this.panelLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageIcon)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private void InitializeCustomizeComponents()
        {
            var control = GetMainComponent();
            if (control != null)
            {
                var height = GetMainComponentHeight();
                if (height == 0)
                {
                    // 使用元件本身的高度
                    height = control.Height;
                }
                Height += height;
                panelLayout.SuspendLayout();
                control.Dock = DockStyle.Fill;
                panelLayout.Controls.Add(control);
                panelLayout.SetRow(control, 1);
                panelLayout.SetColumn(control, 1);
                panelLayout.ResumeLayout(false);
            }
        }

        private Panel panel1;
        private PictureBox imageIcon;
        private Panel panelText;
        private Label textMessage;
        private Label textMessage2;
        #endregion
    }
}

