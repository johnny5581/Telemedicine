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
using Telemedicine.Meds;

namespace Telemedicine.Vaccs
{
    [DomainControl(typeof(Observation))]
    public partial class VaccListForm2 : ListForm
    {
        public VaccListForm2()
        {
            InitializeComponent();
        }
        public Controller<Observation> Controller { get; set; }
        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
        }
        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            //AddCriteria(criterias, "subject", textSubject.Text);
            //AddCriteria(criterias, "subject.identifier", textPatIdentifier.Text);
            //AddCriteria(criterias, "status", Convert.ToString(comboStatus.SelectedValue));
            //AddCriteria(criterias, "medication.code", textMedId.Text);
            //AddCriteria(criterias, "subject.organization", Convert.ToString(comboPatOrg.SelectedValue));
            //AddCriteria(criterias, "request", textMedReq.Text, r => "MedicationRequest/" + r);

            return Controller.Search(criterias);
        }

        protected override bool ActionDelete(object item)
        {
            if (MsgBoxHelper.YesNo("是否要刪除 #" + DomainControl.GetResourceId(item)))
            {
                Controller.Delete(item as Observation);
                return true;
            }
            return base.ActionDelete(item);
        }
    }
}
