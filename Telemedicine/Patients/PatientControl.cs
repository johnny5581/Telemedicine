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
using Telemedicine.Practitioners;

namespace Telemedicine.Patients
{
    [DomainControl(typeof(Patient))]
    public partial class PatientControl : DomainControl
    {
        public static readonly string SystemIdNo = "http://www.moi.gov.tw/";
        public const string SystemChtNo = SystemId;
        public PatientControl()
        {
            InitializeComponent();            
        }
        public override Type ListFormType => typeof(PatientListForm2);

        [DefaultValue("")]
        public string PatName
        {
            get { return textName.Text; }
            set { textName.Text = value; }
        }
        [DefaultValue("")]
        public string PatIdNo
        {
            get { return textIdentifier.Text; }
            set { textIdentifier.Text = value; }
        }
        [DefaultValue("")]
        public string PatId
        {
            get { return textChtno.Text; }
            set { textChtno.Text = value; }
        }

        protected override void ActionItemPicked(object item)
        {
            base.ActionItemPicked(item);
            var pat = item as Patient;
            PatName = pat.Name.FirstOrDefault()?.Text;
            PatIdNo = pat.Identifier.FirstOrDefault(r => r.System == SystemIdNo)?.Value;
            PatId = pat.Identifier.FirstOrDefault(r => r.System == SystemChtNo)?.Value;
        }

        public static string GetPatientName(Patient pat)
        {
            return pat?.Name?.FirstOrDefault()?.Text;
        }
        public static void PatFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var resRef = e.Value as ResourceReference;
            if (resRef != null)
            {
                //var pat = ControllerBase.Get<Patient>().Read(resRef.Reference);
                //e.Value = GetPatientName(pat);
                e.Value = resRef.Reference;
            }
        }
    }
}
