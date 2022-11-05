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
    [DomainControl(typeof(MedicationAdministration))]
    public partial class MedAdminListForm : ListForm
    {
        public MedAdminListForm()
        {
            InitializeComponent();

            comboPatOrg.BindOrganizations("全部");
            comboStatus.Bind<MedicationAdministration.MedicationAdministrationStatusCodes>("全部");
        }
        public Controller<MedicationAdministration> Controller { get; set; }
        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<MedicationAdministration>(r => r.Medication, formatter: MedRequestListForm.MedFormatter);
            dgvData.AddTextColumn<MedicationAdministration>(r => r.Subject, formatter: PatientControl.PatFormatter);
            dgvData.AddTextColumn<MedicationAdministration>(r => r.Status);
            dgvData.AddTextColumn<MedicationAdministration>(r => r.Effective, formatter: PeriodFormatter);
            dgvData.AddTextColumn<MedicationAdministration>(r => r.Request, formatter: ResourceReferenceFormatter);
            dgvData.AddTextColumn<MedicationAdministration>(r => r.Dosage, formatter: DosageFormatter);
        }

        private void DosageFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var dosage = e.Value as MedicationAdministration.DosageComponent;
            if(dosage != null)
            {
                e.Value = $"{dosage.Dose.Value}{dosage.Dose.Unit} ({dosage.Text})";
            }
        }

        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "subject", textSubject.Text);
            AddCriteria(criterias, "subject.identifier", textPatIdentifier.Text);
            AddCriteria(criterias, "status", Convert.ToString(comboStatus.SelectedValue));
            AddCriteria(criterias, "medication.code", textMedId.Text);
            AddCriteria(criterias, "subject.organization", Convert.ToString(comboPatOrg.SelectedValue));
            AddCriteria(criterias, "request", textMedReq.Text, r => "MedicationRequest/" + r);

            return Controller.Search(criterias);
        }

        protected override bool ActionDelete(object item)
        {
            if (MsgBoxHelper.YesNo("是否要刪除 #" + DomainControl.GetResourceId(item)))
            {
                Controller.Delete(item as MedicationAdministration);
                return true;
            }
            return base.ActionDelete(item);
        }
    }
}
