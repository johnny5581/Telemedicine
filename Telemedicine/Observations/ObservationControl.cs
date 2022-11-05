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
using Telemedicine.Meds;
using Telemedicine.Observations;
using Telemedicine.Patients;

namespace Telemedicine.Observations
{
    [DomainControl(typeof(Observation))]
    public partial class ObservationControl : DomainControl
    {
        public ObservationControl()
        {
            InitializeComponent();
        }
        public override Type ListFormType => typeof(ObservationListForm);
        public override string[] ExtraArguments => new string[] {
            "category=Laboratory Data"
        };
        protected override void ActionItemPicked(object item)
        {
            base.ActionItemPicked(item);
            //var obs = item as Observation;            
        }

    }
}
