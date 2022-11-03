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
            dgvData.AddTextColumn<Organization>(r => r.Name);
            dgvData.AddTextColumn<Organization>(r => r.Alias, formatter: StringsFormatter);
        }



        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            //AddCriteria(criterias, "name", textOrgName.Text);
            //AddCriteria(criterias, "identifier", textOrgId.Text);
            return Controller.Search(criterias);
        }

    }
}
