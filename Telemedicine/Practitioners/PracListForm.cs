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

namespace Telemedicine.Practitioners
{
    [DomainControl(typeof(Practitioner))]
    public partial class PracListForm : ListForm
    {
        public PracListForm()
        {
            InitializeComponent();
        }
        public Controller<Practitioner> Controller { get; set; }
        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<Practitioner>(r => r.Name, formatter: HumanNamesFormatter);            
        }
        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "name", textUserName.Text);
            AddCriteria(criterias, "identifier", textUserNo.Text);
            return Controller.Search(criterias);
        }
    }
}
