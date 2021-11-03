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

namespace Telemedicine.Immunizations
{
    public partial class ImmunizationListForm : FormBase
    {
        private MedicationAdministrationController _ctrlMedAdm;
        private PatientController _ctrlPat;
        public ImmunizationListForm()
        {
            InitializeComponent();

            _ctrlMedAdm = new MedicationAdministrationController(this);
            _ctrlPat = new PatientController(this);

            dgvData.AutoGenerateColumns = true;
            comboPatOrg.BindOrganizations("全部");
            comboStatus.AddTextItem("全部", null);
            comboStatus.AddItemRange(Enum.GetNames(typeof(MedicationAdministration.MedicationAdministrationStatusCodes)), r=>r);
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
                criteria.Add("status=" + status);
            if (medId.IsNotNullOrEmpty())
                criteria.Add("code=" + medId);
            if (patOrg.IsNotNullOrEmpty())
                criteria.Add("subject.organization=" + patOrg);
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            var reqs = _ctrlMedAdm.Search(criteria);
            var dataList = reqs.Select(r => new DataModel(r)).ToList();
            dgvData.SetSource(dataList);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private class DataModel : DataModelBase<MedicationAdministration>
        {
            public DataModel(MedicationAdministration data) : base(data)
            {
                PatId = data.Subject.Reference;
                if (data.Medication is ResourceReference)
                    MedId = (data.Medication as ResourceReference).Reference;
                else if (data.Medication is CodeableConcept)
                    MedId = (data.Medication as CodeableConcept).Coding.FirstOrDefault()?.Code;
                Status = data.Status.ToString(false);
                Quantity = data.Dosage.Dose.Value.ToString(false);
                Unit = data.Dosage.Dose.Unit;

                ResetEffective();
            }

            public void ResetEffective()
            {
                if (Data.Effective is Period)
                {
                    var period = Data.Effective as Period;
                    Effective = $"{new FhirDateTime(period.Start).ToDateTime().ToString("yyyy-MM-dd")} - {new FhirDateTime(period.End).ToDateTime().ToString("yyyy-MM-dd")}";
                }
                else if (Data.Effective is FhirDateTime)
                    Effective = $"{(Data.Effective as FhirDateTime).ToDateTime().ToString("yyyy-MM-dd")}";
            }

            [DisplayName("#")]
            public string Id { get; set; }
            public string MedId { get; set; }
            public string PatId { get; set; }
            public string Status { get; set; }
            public string Quantity { get; set; }
            public string Unit { get; set; }
            public string Effective { get; set; }
        }
        private void menuDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<DataModel>(dgvData);
                _ctrlMedAdm.Delete(item.Data);
                MsgBoxHelper.Info("刪除成功");
                ActionSearch();
            });
        }
    }
}
