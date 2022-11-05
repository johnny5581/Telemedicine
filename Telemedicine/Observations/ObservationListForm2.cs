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

namespace Telemedicine.Observations
{
    [DomainControl(typeof(Observation))]
    public partial class ObservationListForm2 : ListForm
    {
        public ObservationListForm2()
        {
            InitializeComponent();
        }
        public Controller<Observation> Controller { get; set; }

        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<Observation>(r => r.Subject, "病患", formatter: PatientControl.PatFormatter);
            dgvData.AddTextColumn<Observation>(r => r.BasedOn, "醫囑", formatter: ResourceReferenceFormatter);
            dgvData.AddTextColumn<Observation>(r => r.Category, "類型", formatter: (s, ev) => GenericFormatter<CodeableConcept>(ev, r => r.Text));
            dgvData.AddTextColumn<Observation>(r => r.Code, "項目", formatter: (s, ev) => GenericFormatter<CodeableConcept>(ev, r => r.Coding.ToString(", ", m => m.Display)));
            dgvData.AddTextColumn<Observation>(r => r.Code, "代碼", formatter: (s, ev) => GenericFormatter<CodeableConcept>(ev, r => r.Coding.ToString(", ", m => m.Code)));
            dgvData.AddTextColumn<Observation>(r => r.Value, "值", formatter: ObservationValueFormatter);
            dgvData.AddTextColumn<Observation>(r => r.Effective, "日期", formatter: PeriodFormatter);
        }

        public static void ObservationValueFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var obs = e.Row.DataBoundItem as Observation;
            var quantity = e.Value as Quantity;
            if (quantity != null)
            {
                e.Value = DomainControl.GetQuantity(quantity);
            }
            else if (obs.Code.Coding.FirstOrDefault()?.Code == VitalSign.BloodPressurePanel.Code)
            {
                // 血壓有順序
                var components = obs.Component;
                var sbp = components.FirstOrDefault(r => r.Code.Coding.FirstOrDefault()?.Code == VitalSign.SystolicBloodPressure.Code);
                var dbp = components.FirstOrDefault(r => r.Code.Coding.FirstOrDefault()?.Code == VitalSign.DistolicBloodPressure.Code);
                e.Value = $"{DomainControl.GetQuantity(sbp.Value as Quantity)}, {DomainControl.GetQuantity(dbp.Value as Quantity)}";
            }
            else if(obs.Code.Coding.FirstOrDefault()?.Code == VitalSign.ECG.Code)
            {
                e.Value = "(SampledData)";
            }
        }

        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "subject", textSubject.Text);
            AddCriteria(criterias, "code", comboVitalSign.SelectedValue);
            AddCriteria(criterias, "subject.identifier", textPatIdentifier.Text);
            AddCriteria(criterias, "subject.name", textPatName.Text);
            AddCriteria(criterias, "subject.organization", comboPatOrg.SelectedValue);
            AddCriteria(criterias, "date", cgLabelDateTimeRange1);
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
