using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Forms;

namespace Telemedicine.Immunizations
{
    public class ImmunizationDialog : CgBaseDialogForm
    {
        private ImmunizationControl control;
        private decimal _quantity;
        public new ImmunizationControl MainComponent
        {
            get { return (ImmunizationControl)base.MainComponent; }
        }

        public decimal Quantity
        {
            get { return _quantity; }
        }
        
        protected override Control GetMainComponent()
        {
            control = new ImmunizationControl();
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
