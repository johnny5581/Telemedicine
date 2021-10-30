using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgSplashForm : CgBorderlessForm, ILoadingDialog
    {
        private DialogResult _positiveResult = DialogResult.OK;
        private CgGradientPanel panelContent;
        private Panel panelTitle;
        private DialogResult _negativeResult = DialogResult.Cancel;
        public CgSplashForm()
        {
            InitializeComponent();
            InitializeCustomComponent();
            ResetTitleFont();
        }


        public int ProgressValue
        {
            get { return GetProgressProperty(p => p.ProgressValue); }
            set { SetProgressProperty(p => p.ProgressValue = value); }
        }
        public int ProgressMaximum
        {
            get { return GetProgressProperty(p => p.ProgressMaximum); }
            set { SetProgressProperty(p => p.ProgressMaximum = value); }
        }

        public string ProgressMessage
        {
            get { return GetProgressProperty(p => p.ProgressMessage); }
            set { SetProgressProperty(p => p.ProgressMessage = value); }
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
            get { return textTitle.Text; }
            set { textTitle.Text = value; }
        }
        [DefaultValue("")]
        public string SubMessage
        {
            get { return textSubTitle.Text; }
            set { textSubTitle.Text = value; }
        }

        [DefaultValue(DialogResult.OK)]
        public DialogResult PositiveResult
        {
            get { return _positiveResult; }
            set { _positiveResult = value; }
        }
        [DefaultValue(DialogResult.Cancel)]
        public DialogResult NegativeResult
        {
            get { return _negativeResult; }
            set { _negativeResult = value; }
        }

        public void SetBackground(Image image, ImageLayout layout)
        {
            ClearBackground();
            panelContent.BackgroundImage = image;
            panelContent.BackgroundImageLayout = layout;
        }

        public void SetBackground(Color backColor)
        {
            ClearBackground();
            panelContent.BackColor = backColor;
        }
        public void SetBackground(Color backColor1, Color backColor2)
        {
            ClearBackground();
            panelContent.BackColor = backColor1;
            panelContent.BackColor2 = backColor2;
        }

        private void ClearBackground()
        {
            panelContent.BackgroundImage = null;
            panelContent.BackColor = SystemColors.Control;
            panelContent.BackColor2 = Color.Empty;
        }


        public void Show(object parentObject)
        {
            var win32window = parentObject as IWin32Window;
            if (win32window != null)
            {
                StartPosition = FormStartPosition.CenterParent;
                base.Show(win32window);
            }
            else
            {
                StartPosition = FormStartPosition.CenterScreen;
                Show();
            }
        }

        public DialogResult ShowDialog(object parentObject)
        {
            var win32window = parentObject as IWin32Window;
            if (win32window != null)
            {
                StartPosition = FormStartPosition.CenterParent;
                return base.ShowDialog(win32window);
            }
            else
            {
                StartPosition = FormStartPosition.CenterScreen;
                return ShowDialog();
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            ResetTitleFont();
        }

        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            ResetTitleFont();
        }
        private void ResetTitleFont()
        {
            textTitle.Font = new Font(Font.FontFamily, 26f, FontStyle.Bold);
            textSubTitle.Font = new Font(Font.FontFamily, 18f);
        }
        protected T GetProperty<T, TCtrl>(TCtrl ctrl, Func<TCtrl, T> @delegate)
        {
            if (InvokeRequired)
                return (T)Invoke(@delegate, ctrl);
            return @delegate(ctrl);
        }
        protected void SetProperty<TCtrl>(TCtrl ctrl, Action<TCtrl> @delegate)
        {
            if (InvokeRequired)
                Invoke(@delegate, ctrl);
            else
                @delegate(ctrl);
        }
        protected T GetProgressProperty<T>(Func<CgProgressBar, T> @delegate)
        {
            return GetProperty(progress, @delegate);
        }
        protected void SetProgressProperty(Action<CgProgressBar> @delegate)
        {
            SetProperty(progress, @delegate);
        }
        #region unused 
        string IMessageDialog.PositiveText { get; set; }
        string IMessageDialog.NegativeText { get; set; }
        void IMessageDialog.ChangeIcon(object icon, int size)
        {
            // do nothing
        }
        void IMessageDialog.ChangeMessageStyle(Font font, Color? foreColor, bool changeSub)
        {
            // do nothing
        }

        void IMessageDialog.ChangeSubMessageStyle(Font font, Color? foreColor)
        {
            // do nothing
        }
        #endregion

        #region designer
        private void InitializeComponent()
        {
            this.textTitle = new System.Windows.Forms.Label();
            this.textSubTitle = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // textTitle
            // 
            this.textTitle.BackColor = System.Drawing.Color.Transparent;
            this.textTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textTitle.Location = new System.Drawing.Point(20, 20);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(440, 237);
            this.textTitle.TabIndex = 1;
            this.textTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textSubTitle
            // 
            this.textSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.textSubTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textSubTitle.Location = new System.Drawing.Point(20, 257);
            this.textSubTitle.Name = "textSubTitle";
            this.textSubTitle.Size = new System.Drawing.Size(440, 43);
            this.textSubTitle.TabIndex = 2;
            this.textSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.Controls.Add(this.textTitle);
            this.panelTitle.Controls.Add(this.textSubTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Padding = new System.Windows.Forms.Padding(9);
            this.panelTitle.Size = new System.Drawing.Size(480, 320);
            this.panelTitle.TabIndex = 3;
            // 
            // CgSplashForm
            // 
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(this.panelTitle);
            this.Name = "CgSplashForm";
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private void InitializeCustomComponent()
        {
            progress = new CgProgressBar();
            panelContent = new CgGradientPanel();
            panelContent.SuspendLayout();
            SuspendLayout();

            progress.BackColor = Color.Transparent;
            progress.Location = new Point(12, 266);
            progress.Name = "progress";
            progress.ProgressFont = new Font("Consolas", 9F);
            progress.Dock = DockStyle.Bottom;

            panelContent.BackColor = Color.White;
            panelContent.BackColor2 = Color.FromArgb(120, 211, 255);
            panelContent.Controls.Add(this.progress);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Name = "panelContent";
            panelContent.Controls.Add(progress);
            panelContent.Controls.Add(panelTitle);

            var padding = panelTitle.Padding;
            panelContent.Padding = padding;
            panelTitle.Padding = new Padding(0, padding.Top, 0, padding.Bottom);

            Controls.Add(panelContent);

            panelContent.ResumeLayout(false);
            ResumeLayout(false);            
        }

        private CgProgressBar progress;
        private Label textTitle;
        private Label textSubTitle;
        #endregion
    }
}


