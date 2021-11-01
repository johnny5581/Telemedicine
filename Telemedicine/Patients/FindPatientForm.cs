using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine.Patients
{
    public partial class FindPatientForm : FormBase
    {
        private PatientController _ctrlPat;
        public FindPatientForm()
        {
            InitializeComponent();
            _ctrlPat = new PatientController(this);
            dgvData.AddTextColumn<Patient>(r => r.Id);
            dgvData.AddTextColumn<Patient>(r => r.Name, formatter: NameFormatter);
            dgvData.AddTextColumn<Patient>(r => r.BirthDate);
            dgvData.AddTextColumn<Patient>(r => r.Gender);
        }
        private void NameFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            e.Value = PatientController.GetName(e.Value as List<HumanName>) ?? "";
            e.FormattingApplied = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Hl7.Fhir.Model.Patient patient1 = new Hl7.Fhir.Model.Patient
            //{
            //    Id = textBoxID.Text,
            //    Identifier = new List<Hl7.Fhir.Model.Identifier>
            //    {
            //        new Hl7.Fhir.Model.Identifier("https://www.dicom.org.tw/cs/identityCardNumber_tw", textBoxIdentifier.Text),
            //    },
            //    Name = new List<Hl7.Fhir.Model.HumanName> {
            //        new Hl7.Fhir.Model.HumanName { Text = textBoxName.Text } },
            //    ManagingOrganization = new Hl7.Fhir.Model.ResourceReference(textBoxOrg.Text),
            //};
            Execute(() =>
            {
                var criteria = new List<string>();
                if (textBoxID.Text.IsNotNullOrEmpty())
                    criteria.Add("id=" + textBoxID.Text);
                if (textBoxIdentifier.Text.IsNotNullOrEmpty())
                    criteria.Add("identifier=" + HttpUtility.HtmlEncode("https://www.dicom.org.tw/cs/identityCardNumber_tw|" + textBoxIdentifier.Text));
                if (textBoxName.Text.IsNotNullOrEmpty())
                    criteria.Add("name=" + textBoxName.Text);
                if (textBoxOrg.Text.IsNotNullOrEmpty())
                    criteria.Add("managingOrganization=" + textBoxOrg.Text);
                var pats = _ctrlPat.Search(criteria);
                dgvData.SetSource(pats);
            });
        }
    }
}
