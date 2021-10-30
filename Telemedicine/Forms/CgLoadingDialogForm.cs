using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgLoadingDialogForm : CgBaseDialogForm, ILoadingDialog
    {
        private CgProgressBar progress;

        public CgLoadingDialogForm()
        {            
            ControlBox = false;
            ButtonPanelEnabled = false;
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

        protected override Control GetMainComponent()
        {                
            progress = new CgProgressBar();
            return progress;
        }

        protected override int GetMainComponentHeight()
        {
            return WinMonitor.GetPrimaryScaled(50);
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
    }
}

