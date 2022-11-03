using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Forms;

namespace Telemedicine.Meds
{
    public class MedicationAdminDialog : CgBaseDialogForm
    {
        private MedicationAdminControl control;
        private decimal _quantity;
        public new MedicationAdminControl MainComponent
        {
            get { return (MedicationAdminControl)base.MainComponent; }
        }

        public decimal Quantity
        {
            get { return _quantity; }
        }
        
        protected override Control GetMainComponent()
        {
            control = new MedicationAdminControl();
            control.Size = new System.Drawing.Size(300, 200);
            return control;
        }
        protected override void OnPositiveClicking(CancelEventArgs e)
        {            
            var q = control.Quantity.ToNullable<decimal>();
            if(q == null)
            {
                e.Cancel = true;
                MsgBoxHelper.Warning("輸入數量錯誤: " + control.Quantity);
                return;
            }
            _quantity = q.Value;
            base.OnPositiveClicking(e);
        }

    }
}
