using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{    
    public class CgForm : Form, ICgComponent
    {
        private static Lazy<Icon> _lazyIcon
            = new Lazy<Icon>(GetResourceIcon);
        public const int CS_BYTEALIGNCLIENT = 0x1000;
        public const int CS_BYTEALIGNWINDOW = 0x2000;
        public const int CS_CLASSDC = 0x0040;
        public const int CS_DBLCLKS = 0x0008;
        public const int CS_DROPSHADOW = 0x20000;
        public const int CS_GLOBALCLASS = 0x4000;
        public const int CS_HREDRAW = 0x0002;
        public const int CS_NOCLOSE = 0x0200;
        public const int CS_OWNDC = 0x0020;
        public const int CS_PARENTDC = 0x0080;
        public const int CS_SAVEBITS = 0x0800;
        public const int CS_VREDRAW = 0x0001;
        protected bool _shown;
        public CgForm()
        {
            DoubleBuffered = true;
            Icon = GetIcon();
        }
        public bool IsShown
        {
            get { return _shown; }
        }
        /// <summary>
        /// 是否在Runtime環境下
        /// </summary>
        public bool IsRuntime
        {
            get { return Commons.IsRuntime(); }
        }
        /// <summary>
        /// 取得視窗圖示
        /// </summary>        
        protected virtual Icon GetIcon()
        {
            return _lazyIcon.Value;
        }

        protected static Icon GetResourceIcon()
        {
            var icon = FmResManager.GetResourceIcon("favicon.ico", false, true);            
            return icon;
        }

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            var isRuntime = IsRuntime;
            if (isRuntime)
                OnLoadAtRuntime();
            base.OnLoad(e);
            if (isRuntime)
                OnLoadedAtRuntime();
            _shown = true;
        }

        protected virtual void OnLoadAtRuntime()
        {

        }
        protected virtual void OnLoadedAtRuntime()
        {

        }
        #endregion

        #region OnShown
        protected override void OnShown(EventArgs e)
        {
            var isRuntime = IsRuntime;
            if (isRuntime)
                OnShowAtRuntime();
            base.OnShown(e);
            if (isRuntime)
                OnShownAtRuntime();
        }
        protected virtual void OnShowAtRuntime()
        {
        }
        protected virtual void OnShownAtRuntime()
        {
            // 觸發Bootstrap動作
            OnRuntimeBootstrap();
        }
        #endregion
        void ICgComponent.RuntimeBootstrap()
        {
            OnRuntimeBootstrap();
        }
        protected virtual void OnRuntimeBootstrap()
        {
            foreach (Control c in Controls)
                Commons.Boostrap(c);
        }        
        
    }

    public class CgBorderlessForm : CgForm
    {
        private bool _sdwParams = true;
        public CgBorderlessForm()
        {
            FormBorderStyle = FormBorderStyle.None;
        }

        public bool ParamsShadow
        {
            get { return _sdwParams; }
            set
            {
                _sdwParams = value;
                Invalidate();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                if (_sdwParams)
                    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
    }

    public interface IDialog : IDisposable
    {
        bool IsShown { get; }
        DialogResult ShowDialog(object parentObject);
        void Show(object parentObject);
        void Close();
        object Invoke(Delegate method);
        object Invoke(Delegate method, object[] args);                
    }
    public class CgDialogForm : CgForm, IDialog
    {
        public CgDialogForm()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }
        public virtual DialogResult ShowDialog(object parentObject)
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
        public virtual void Show(object parentObject)
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
    }

    public interface IMessageDialog : IDialog
    {
        string Caption { get; set; }
        string Message { get; set; }
        string SubMessage { get; set; }
        string PositiveText { get; set; }
        string NegativeText { get; set; }
        DialogResult PositiveResult { get; set; }
        DialogResult NegativeResult { get; set; }


        void ChangeIcon(object icon, int size);
        void ChangeMessageStyle(Font font, Color? foreColor, bool changeSub);
        void ChangeSubMessageStyle(Font font, Color? foreColor);
    }
    
}

