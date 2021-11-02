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

namespace Telemedicine.Patients
{
    public partial class PatientListForm : FormBase
    {
        private PatientController _ctrlPat;
        public PatientListForm()
        {
            InitializeComponent();

            _ctrlPat = new PatientController(this);

            dgvData.AddTextColumn<Patient>(r => r.Id, "#");
            dgvData.AddTextColumn<Patient>(r => r.Name, formatter: NameFormatter);
            dgvData.AddTextColumn<Patient>(r => r.BirthDate);
            dgvData.AddTextColumn<Patient>(r => r.Gender);

            comboOrg.BindOrganizations("全部");
        }

        private void NameFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            e.Value = PatientController.GetName(e.Value as List<HumanName>) ?? "";
            e.FormattingApplied = true;
        }

        private void PatientFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var value = e.Value as ResourceReference;
            if (value != null)
            {
                e.Value = value.Reference ?? "";
                e.FormattingApplied = true;
            }
        }


        private void ActionClearScreen()
        {
            ClearControls(textId, textName, textIdentifier, comboOrg);

            dgvData.ClearSource();
        }

        private void ActionSearch()
        {
            var id = textId.Text;
            var identifier = textIdentifier.Text;
            var name = textName.Text;
            var org = comboOrg.SelectedValue as string;

            dgvData.ClearSource();

            var criteria = new List<string>();
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            if (identifier.IsNotNullOrEmpty())
                criteria.Add("identifier=" + identifier);
            if (name.IsNotNullOrEmpty())
                criteria.Add("name=" + name);
            if (org.IsNotNullOrEmpty())
                criteria.Add("organization=" + org);
            var obs = _ctrlPat.Search(criteria);
            dgvData.SetSource(obs);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<Patient>(dgvData);
                var d = new CreatePatientForm();
                d.LoadPatient(item);
                d.Show();
            });
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<Patient>(dgvData);
                _ctrlPat.Delete(item);
            });
        }
    }
}
