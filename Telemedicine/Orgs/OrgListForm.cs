using Hl7.Fhir.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine.Orgs
{
    [DomainControl(typeof(Organization))]
    public partial class OrgListForm : ListForm
    {        
        public OrgListForm()
        {
            InitializeComponent();            
        }

        public Controller<Organization> Controller { get; set; }

        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AddTextColumn<Organization>(r => r.Name);
            dgvData.AddTextColumn<Organization>(r => r.Alias, formatter: StringsFormatter);
        }

        

        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "name", textOrgName.Text);
            AddCriteria(criterias, "identifier", textOrgId.Text);
            return Controller.Search(criterias);            
        }

        protected override bool ActionDelete(object item)
        {
            if (MsgBoxHelper.YesNo("是否要刪除 #" + DomainControl.GetResourceId(item)))
            {
                Controller.Delete(item as Organization);
                return true;
            }
            return base.ActionDelete(item);
        }



    }
}
