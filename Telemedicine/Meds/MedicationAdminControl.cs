using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemedicine.Meds
{
    public partial class MedicationAdminControl : UserControlBase
    {
        public MedicationAdminControl()
        {
            InitializeComponent();
        }

        public string Quantity
        {
            get { return textQuantity.Text; }
            set { textQuantity.Text = value; }
        }
        public string Unit
        {
            get { return textUnit.Text; }
            set { textUnit.Text = value; }
        }
        public DateTime DateBegin
        {
            get { return dateBegin.Value; }
            set { dateBegin.Value = value; }
        }
        public DateTime DateEnd
        {
            get { return dateEnd.Value; }
            set { dateEnd.Value = value; }
        }
        public bool DateEndEnabled
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dateEnd.Enabled = checkBox1.Checked;
        }
    }
}
