using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgBaseDialogForm : CgDialogForm
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
       
        /// <summary>
        /// 主要元件
        /// </summary>
        public Control MainComponent { get; private set; }



        



        protected virtual void OnPositiveClicking(CancelEventArgs e)
        {

        }

        protected virtual void OnNegativeClicking(CancelEventArgs e)
        {

        }


        #region MainComponent
        protected virtual Control GetMainComponent()
        {
            return null;
        }
        protected virtual int GetMainComponentHeight()
        {
            return 0;
        }
        #endregion

        #region MessageComponent
        protected virtual Control GetTextComponent()
        {
            return null;
        }

        protected virtual int GetTextComponentHeight()
        {
            return 0;
        }
        #endregion

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
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLayout
            // 
            this.panelLayout.ColumnCount = 1;
            this.panelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayout.Location = new System.Drawing.Point(0, 0);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.RowCount = 3;
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelLayout.Size = new System.Drawing.Size(434, 2);
            this.panelLayout.TabIndex = 1;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.buttonOK);
            this.panelControl.Controls.Add(this.buttonCancel);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 2);
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
            this.ClientSize = new System.Drawing.Size(434, 38);
            this.Controls.Add(this.panelLayout);
            this.Controls.Add(this.panelControl);
            this.Name = "CgBaseDialogForm";
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private void InitializeCustomizeComponents()
        {
            var textComponent = GetTextComponent();
            if(textComponent != null)
            {
                var tHeight = GetTextComponentHeight();
                if (tHeight == 0)
                    tHeight = textComponent.Height;
                Height += tHeight;
                panelLayout.SuspendLayout();
                panelLayout.RowStyles[0].Height = tHeight;
                panelLayout.Controls.Add(textComponent, 0, 0);
                panelLayout.ResumeLayout(false);
            }

            MainComponent = GetMainComponent();
            if (MainComponent != null)
            {
                var height = GetMainComponentHeight();
                if (height == 0)
                {
                    // 使用元件本身的高度
                    height = MainComponent.Height;
                }
                Height += height;
                panelLayout.SuspendLayout();
                MainComponent.Dock = DockStyle.Fill;
                panelLayout.Controls.Add(MainComponent, 0, 1);
                panelLayout.ResumeLayout(false);
            }
        }
        #endregion
    }

    public class CgBaseMessageDialogForm : CgBaseDialogForm, IMessageDialog
    {
        private Panel panelMessage;
        private Label textMessage;
        private Label textMessage2;
        private PictureBox imageIcon;
        private Panel panelText;

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

        protected override Control GetTextComponent()
        {
            panelMessage = new Panel();
            panelText = new Panel();
            textMessage = new Label();
            textMessage2 = new Label();
            imageIcon = new PictureBox();

            panelMessage.SuspendLayout();
            panelText.SuspendLayout();

            panelMessage.Controls.Add(panelText);
            panelMessage.Controls.Add(imageIcon);

            panelText.Dock = DockStyle.Fill;
            panelText.Controls.Add(textMessage);
            panelText.Controls.Add(textMessage2);

            textMessage.Dock = DockStyle.Fill;
            textMessage.Margin = new Padding(3);
            textMessage.TextAlign = ContentAlignment.MiddleLeft;
            textMessage.TabStop = false;
            textMessage.Visible = false;

            textMessage2.Dock = DockStyle.Bottom;
            textMessage2.Size = new Size(0, 24);
            textMessage2.Margin = new Padding(3);
            textMessage2.TextAlign = ContentAlignment.MiddleLeft;
            textMessage2.TabStop = false;
            textMessage2.Visible = false;

            imageIcon.Size = new Size(58, 58);
            imageIcon.Dock = DockStyle.Left;
            imageIcon.SizeMode = PictureBoxSizeMode.Zoom;
            imageIcon.TabStop = false;
            imageIcon.Visible = false;

            panelText.ResumeLayout(false);
            panelMessage.ResumeLayout(false);

            return panelMessage;
        }
        protected override int GetTextComponentHeight()
        {
            return imageIcon.Height;
        }
    }
}

