﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Forms;

namespace Telemedicine.Observations
{
    public class ObservationDialog : CgBaseDialogForm
    {
        private ObservationControl2 control;
        public ObservationDialog()
        {
            // 縮小一點
            Width = 320;
        }
        public new ObservationControl2 MainComponent
        {
            get { return (ObservationControl2)base.MainComponent; }
        }
        protected override Control GetMainComponent()
        {
            control = new ObservationControl2();
            return control;
        }

        protected override int GetMainComponentHeight()
        {
            return 200;
        }
    }
}
