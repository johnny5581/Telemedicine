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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Telemedicine.Forms;

namespace Telemedicine.Practitioners
{
    public partial class PracListForm : FormBase
    {
        private PractitionerController _ctrlPrac;
        public PracListForm()
        {
            InitializeComponent();
            _ctrlPrac = new PractitionerController(this);

            dgvData.AddTextColumn<Practitioner>(r => r.Id, "#");
            dgvData.AddTextColumn<Practitioner>(r => r.Name, formatter: NameFormatter);
        }

        private void NameFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var names = e.Value as List<HumanName>;
            if(names != null && names.Count > 0)
            {
                var name = names.ElementAt(0);
                e.Value = name.Text;
                e.FormattingApplied = true;
            }
        }

        public Practitioner Selected { get; private set; }
        private void ActionSearch()
        {
            var id = textId.Text;
            var userno = textUserNo.Text;
            var name = textUserName.Text;


            dgvData.ClearSource();

            var criteria = new List<string>();
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            if (name.IsNotNullOrEmpty())
                criteria.Add("name=" + name);
            if (userno.IsNotNullOrEmpty())
                criteria.Add("identifier=" + userno);
            var list = _ctrlPrac.Search(criteria);
            dgvData.SetSource(list);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }
        private void menuDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<Practitioner>(dgvData);
                _ctrlPrac.Delete(item);
                MsgBoxHelper.Info("刪除成功");
                ActionSearch();
            });
        }

        private void dgvData_DataSelected(object sender, CgDataGridPanel.DataSelectedEventArgs e)
        {
            if (MdiParent == null)
            {
                Selected = e.Data as Practitioner;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
