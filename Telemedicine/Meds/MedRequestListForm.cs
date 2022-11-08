using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using System;
using System.Collections;
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
using Telemedicine.Patients;

namespace Telemedicine.Meds
{
    [DomainControl(typeof(MedicationRequest))]
    public partial class MedRequestListForm : ListForm
    {
        public MedRequestListForm()
        {
            InitializeComponent();

            comboPatOrg.BindOrganizations("全部");
            comboStatus.Bind<MedicationRequest.medicationrequestStatus>("全部");
        }

        public Controller<MedicationRequest> Controller { get; set; }

        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<MedicationRequest>(r => r.Status);
            dgvData.AddTextColumn<MedicationRequest>(r => r.Intent);
            dgvData.AddTextColumn<MedicationRequest>(r => r.Medication, formatter: MedFormatter);
            dgvData.AddTextColumn<MedicationRequest>(r => r.Subject, formatter: PatientControl.PatFormatter);
            dgvData.AddTextColumn<MedicationRequest>(r => r.AuthoredOn);
            dgvData.AddTextColumn<MedicationRequest>(r => r.DosageInstruction, formatter: MedDosageFormatter);
            dgvData.AddTextColumn<MedicationRequest>(r => r.DispenseRequest, formatter: MedDispenseFormatter);
        }

        private static void MedDispenseFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var dispense = e.Value as MedicationRequest.DispenseRequestComponent;
            if (dispense != null)
            {
                e.Value = $"{dispense.Quantity?.Value}{dispense.Quantity?.Unit}, {dispense.ExpectedSupplyDuration?.Value}{dispense.ExpectedSupplyDuration?.Unit}";
            }
        }

        public static void MedDosageFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var dosages = e.Value as List<Dosage>;
            if (dosages != null)
            {
                e.Value = dosages.ToString(",", r => GetInstruction(r));
            }
        }

        public static string GetInstruction(Dosage dosage)
        {
            var timing = dosage.Timing.Code.Text ?? dosage.Timing.Code.Coding.ToString("+", r => r.Display ?? r.Code);
            var routes = dosage.Route.Text ?? dosage.Route.Coding.ToString("+", r => r.Display ?? r.Code);
            if (dosage.Text.IsNotNullOrEmpty())
                return $"{timing}, {routes} ({dosage.Text})";
            return $"{timing}, {routes}";
        }



        public static void MedFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var dataType = e.Value as DataType;
            if (dataType != null)
                e.Value = MedControl.GetMedText(dataType);
        }

        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "subject", textSubject.Text);
            AddCriteria(criterias, "subject.identifier", textPatIdentifier.Text);
            AddCriteria(criterias, "status", Convert.ToString(comboStatus.SelectedValue).StrToLower());
            AddCriteria(criterias, "code", textMedId.Text);
            AddCriteria(criterias, "subject.organization", comboPatOrg.SelectedValue as string);

            return Controller.Search(criterias);
        }
        protected override bool ActionDelete(object item)
        {
            if (MsgBoxHelper.YesNo("是否要刪除 #" + DomainControl.GetResourceId(item)))
            {
                Controller.Delete(item as MedicationRequest);
                return true;
            }
            return base.ActionDelete(item);
        }
    }
}
