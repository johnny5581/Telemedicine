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
using Telemedicine.Forms;
using Telemedicine.Orgs;

namespace Telemedicine.Meds
{
    [DomainControl(typeof(Medication))]
    public partial class MedControl : DomainControl
    {
        public MedControl()
        {
            InitializeComponent();
        }
        protected override void ActionItemPicked(object item)
        {
            base.ActionItemPicked(item);
            var med = item as Medication;
            textCode.Text = med?.Code?.Coding?.FirstOrDefault()?.Display;
            textName.Text = med?.Code?.Text;
        }
        public static string GetMedText(DataType medRes)
        {
            var resRef = medRes as  ResourceReference;
            var resCode = medRes as CodeableConcept;

            if (resRef != null)
            {
                var med = ControllerBase.Get<Medication>().Read(resRef.Reference);
                return med?.Code?.Text;
            }
            else if (resCode != null)
            {
                return resCode.Coding?.FirstOrDefault()?.Code;
            }
            return null;
        }
    }
}
