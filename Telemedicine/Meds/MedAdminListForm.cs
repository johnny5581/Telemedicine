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

namespace Telemedicine.Meds
{
    [DomainControl(typeof(MedicationAdministration))]
    public partial class MedAdminListForm : ListForm
    {
        public MedAdminListForm()
        {
            InitializeComponent();
        }
        public Controller<MedicationAdministration> Controller { get; set; }
        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<MedicationAdministration>(r => r.Medication, formatter: MedRequestListForm.MedFormatter);
            dgvData.AddTextColumn<MedicationAdministration>(r => r.Subject, formatter: MedRequestListForm.MedPatFormatter);
        }



        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "subject", textSubject.Text);
            AddCriteria(criterias, "subject.identifier", textPatIdentifier.Text);
            AddCriteria(criterias, "status", comboStatus.SelectedValue as string);
            AddCriteria(criterias, "medication.code", textMedId.Text);
            AddCriteria(criterias, "subject.organization", comboPatOrg.SelectedValue as string);
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
