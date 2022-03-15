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

namespace Telemedicine.Meds
{
    public partial class MedicationRequestListForm : FormBase
    {
        private MedicationRequestController _ctrlMedReq;
        private PatientController _ctrlPat;

        public MedicationRequest SelectedMedicationRequest { get; private set; }

        public MedicationRequestListForm()
        {
            InitializeComponent();

            _ctrlMedReq = new MedicationRequestController(this);
            _ctrlPat = new PatientController(this);

            dgvData.AutoGenerateColumns = true;
            comboPatOrg.BindOrganizations("全部");
            comboStatus.AddTextItem("全部", null);
            comboStatus.AddItemRange(Enum.GetNames(typeof(MedicationRequest.medicationrequestStatus)), r=>r);
        }

        private void ActionSearch()
        {
            dgvData.ClearSource();
            var id = textId.Text;
            var patId = textSubject.Text;
            var patIdentifier = textPatIdentifier.Text;
            var status = comboStatus.SelectedValue as string;
            var medId = textMedId.Text;
            var patOrg = comboPatOrg.SelectedValue as string;
            

            dgvData.ClearSource();
            var criteria = new List<string>();
            if (patId.IsNotNullOrEmpty())
                criteria.Add("subject=" + patId);
            if (patIdentifier.IsNotNullOrEmpty())
                criteria.Add("subject.identifier=" + patIdentifier);
            if (status.IsNotNullOrEmpty())
                criteria.Add("status=" + status.ToLower());
            if (medId.IsNotNullOrEmpty())
                criteria.Add("medication.code=" + medId);
            if (patOrg.IsNotNullOrEmpty())
                criteria.Add("subject.organization=" + patOrg);
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            
            var reqs = _ctrlMedReq.Search(criteria);
            var dataList = reqs.Select(r => new MedicationRequestData(r)).ToList();
            dgvData.SetSource(dataList);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private class MedicationRequestData : DataModelBase<MedicationRequest>
        {
            public MedicationRequestData(MedicationRequest data) : base(data)
            {
                PatId = data.Subject.Reference;
                if (data.Medication is ResourceReference)
                    MedId = (data.Medication as ResourceReference).Reference;
                else if (data.Medication is CodeableConcept)
                    MedId = (data.Medication as CodeableConcept).Coding.FirstOrDefault()?.Code;
                Status = data.Status.ToString(false);
                Intent = data.Intent.ToString(false);
            }

            [DisplayName("#")]
            public string Id { get; set; }
            public string PatId { get; set; }
            public string MedId { get; set; }
            public string Status { get; set; }
            public string Intent { get; set; }
            public string AuthoredOn { get; set; }
        }
        private void menuDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<MedicationRequestData>(dgvData);
                _ctrlMedReq.Delete(item.Data);
                MsgBoxHelper.Info("刪除成功");
                ActionSearch();
            });
        }

        private void dgvData_DataSelected(object sender, CgDataGridPanel.DataSelectedEventArgs e)
        {
            if (MdiParent == null)
            {
                var item = e.Data as MedicationRequestData;
                SelectedMedicationRequest = item.Data;
                DialogResult = DialogResult.OK;
            }
        }

        private void cgLabelTextBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
