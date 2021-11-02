using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Forms;

namespace Telemedicine.Meds
{
    public class MedicationRequestDialog : CgBaseDialogForm
    {
        private MedicationRequestControl control;
        
        public new MedicationRequestControl MainComponent
        {
            get { return (MedicationRequestControl)base.MainComponent; }
        }
        
        protected override Control GetMainComponent()
        {
            control = new MedicationRequestControl();
            control.Size = new System.Drawing.Size(300, 200);
            return control;
        }

        
    }
}
