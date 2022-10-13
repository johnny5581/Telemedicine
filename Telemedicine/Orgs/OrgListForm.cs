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

namespace Telemedicine.Orgs
{
    public partial class OrgListForm : FormBase
    {
        private OrganizationController _ctrlOrg;

        public Organization Selected { get; private set; }
        public OrgListForm()
        {
            InitializeComponent();
            _ctrlOrg = new OrganizationController(this);
            
            dgvData.AddTextColumn<Organization>(r => r.Id, "#");
            dgvData.AddTextColumn<Organization>(r => r.Name);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private void ActionSearch()
        {
            var id = textId.Text;
            var orgId = textOrgId.Text;
            var name = textOrgName.Text;


            dgvData.ClearSource();

            var criteria = new List<string>();
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            if (name.IsNotNullOrEmpty())
                criteria.Add("name=" + name);
            if (orgId.IsNotNullOrEmpty())
                criteria.Add("identifier=" + orgId);
            var obs = _ctrlOrg.Search(criteria);
            dgvData.SetSource(obs);
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<Organization>(dgvData);
                _ctrlOrg.Delete(item);
                MsgBoxHelper.Info("刪除成功");
                ActionSearch();
            });
        }

        private void dgvData_DataSelected(object sender, CgDataGridPanel.DataSelectedEventArgs e)
        {
            if (MdiParent == null)
            {
                Selected = e.Data as Organization;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
