using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telemedicine.Forms
{
    public class CgUserControl : UserControl
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
    }
}

