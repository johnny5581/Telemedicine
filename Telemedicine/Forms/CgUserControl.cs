using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgUserControl : UserControl, ICgComponent
    {
        public CgUserControl()
        {
            DoubleBuffered = true;
            AutoScaleMode = AutoScaleMode.Inherit;
        }
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]       
        public bool IsRuntime
        {
            get { return Commons.IsRuntime(); }
        }

        public void RuntimeBootstrap()
        {
            OnRuntimeBootstrap();
        }
        protected virtual void OnRuntimeBootstrap()
        {
            foreach(Control c in Controls)
                Commons.Boostrap(c);
        }
    }

    
}

