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
using Telemedicine.Controllers;
using Telemedicine.Patients;

namespace Telemedicine.Meds
{
    [DomainControl(typeof(MedicationRequest))]
    public partial class MedRequestControl : DomainControl
    {
        public MedRequestControl()
        {
            InitializeComponent();
        }
        public override Type ListFormType => typeof(MedRequestListForm);
        protected override void ActionItemPicked(object item)
        {
            base.ActionItemPicked(item);
            var medReq = item as MedicationRequest;
            var pat = ControllerBase.Get<Patient>().Read(medReq.Subject.Reference);
            textPatName.Text = PatientControl.GetPatientName(pat);
            textPatName.Tag = pat;
            textMed.Text = MedControl.GetMedText(medReq.Medication);
        }

        
    }
}
