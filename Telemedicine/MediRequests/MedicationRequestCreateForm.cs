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

namespace Telemedicine.MediRequests
{
    public partial class MedicationRequestCreateForm : FormBase
    {
        public MedicationRequestCreateForm()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var request = new MedicationRequest();
                request.Status = MedicationRequest.medicationrequestStatus.Active;
                request.Intent = MedicationRequest.medicationRequestIntent.Order;

            });
        }
    }
}
