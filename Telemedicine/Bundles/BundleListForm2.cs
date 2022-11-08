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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Telemedicine.Bundles
{
    [DomainControl(typeof(Bundle))]
    public partial class BundleListForm2 : ListForm
    {
        public BundleListForm2()
        {
            InitializeComponent();
        }
        public Controller<Bundle> Controller { get; set; }
        public Controller<Composition> CompositionController { get; set; }
        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<Bundle>(r => r.Type);
            dgvData.AddTextColumn<Bundle>(r => r.Timestamp);
            dgvData.AddTextColumn<Bundle>(r => r.Entry, "Status", formatter: CompositionFormatter, arguments: new string[] { "Composition", "status" });
            dgvData.AddTextColumn<Bundle>(r => r.Entry, "Title", formatter: CompositionFormatter, arguments: new string[] { "Composition", "title" });
            dgvData.AddTextColumn<Bundle>(r => r.Entry, "Date", formatter: CompositionFormatter, arguments: new string[] { "Composition", "date" });
            dgvData.AddTextColumn<Bundle>(r => r.Entry, "PatientName", formatter: CompositionFormatter, arguments: new string[] { "Patient", "name" });

        }

        private void CompositionFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var entries = e.Value as List<Bundle.EntryComponent>;
            if(entries != null)
            {
                var composition = entries[0].Resource as Composition;
                var componentName = Convert.ToString(e.Arguments.ElementAtOrDefault(0));
                var propertyName = Convert.ToString(e.Arguments.ElementAtOrDefault(1));
                if (componentName == "Composition")
                {                    
                    switch(propertyName)
                    {
                        case "status":
                            e.Value = composition.Status;
                            break;
                        case "title":
                            e.Value = composition.Title;
                            break;
                        case "date":
                            e.Value = composition.Date;
                            break;
                    }
                }
                else if(componentName == "Patient")
                {
                    var pat = entries.FirstOrDefault(r => r.Resource is Patient)?.Resource as Patient;
                    switch(propertyName)
                    {
                        case "name":
                            e.Value = Patients.PatientControl.GetPatientName(pat);
                            break;
                    }
                }
            }
        }

        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "composition.date", cgLabelDateTimeRange1, t => "ge" + t) ;
            AddCriteria(criterias, "composition.patient.identifier", textPatIdentifier.Text);
            AddCriteria(criterias, "composition.organization.identifier", Convert.ToString(comboPatOrg.SelectedValue));

            return Controller.Search(criterias);
        }

        protected override bool ActionDelete(object item)
        {
            if (MsgBoxHelper.YesNo("是否要刪除 #" + DomainControl.GetResourceId(item)))
            {
                Controller.Delete(item as Bundle);
                return true;
            }
            return base.ActionDelete(item);
        }
    }
}
