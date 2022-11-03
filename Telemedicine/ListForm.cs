using Hl7.Fhir.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine
{
    public partial class ListForm : FormBase
    {
        private bool _flgDialog;
        public ListForm()
        {
            InitializeComponent();
            SetupDataGridPanel(dgvData);
        }
        protected override void OnShownAtRuntime()
        {
            base.OnShownAtRuntime();
            if (splitContainer2.Panel2.Controls.Count == 0)
                splitContainer2.Panel2Collapsed = true;
        }
        public object Selected { get; set; }

        public T GetSelected<T>()
            where T : Resource
        {
            return (T)Selected;
        }
        protected virtual void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            dgvData.AddTextColumn("Id", "#");
        }
        protected void ActionSearch()
        {
            dgvData.ClearSource();
            var criterias = new List<string>();
            if (textId.Text.IsNotNullOrEmpty())
                criterias.Add("_id=" + textId.Text);

            var tupleRes = GetSearchResult(criterias);
            if (tupleRes != null)
                dgvData.SetSource(tupleRes.Item2, tupleRes.Item1);
        }
        protected virtual bool ActionDelete(object item)
        {
            return false;
        }
        protected virtual Tuple<Type, IEnumerable> GetSearchResult(List<string> criterias)
        {
            var domains = GetSearchDomainResult(criterias);
            if (domains != null)
                return Tuple.Create(DomainControl.GetDomainType(GetType()), domains);
            return null;
        }
        protected virtual IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            return null;
        }
        protected virtual void ActionDataSelected(object item)
        {
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {                                
                if (ActionDelete(GetSelectedItem(dgvData)))
                    MsgBoxHelper.Info("刪除成功");
            });
            Execute(ActionSearch);
        }

        private void dgvData_DataSelected(object sender, CgDataGridPanel.DataSelectedEventArgs e)
        {
            Execute(() =>
            {
                Selected = e.Data;
                ActionDataSelected(e.Data);
                if (_flgDialog)
                    DialogResult = DialogResult.OK;
            });
        }

        protected void StringsFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var strings = e.Value as IEnumerable<string>;
            if (strings != null)
            {
                e.Value = strings.ToString(",");
            }
        }
        protected void HumanNamesFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var names = e.Value as IEnumerable<HumanName>;
            if (names != null)
            {
                var name = names.FirstOrDefault();
                e.Value = name?.Text;
            }
        }
        protected void IdentifierFormatter(CgDataGridPanel.FormattingCellEventArgs e, string system)
        {
            var identifiers = e.Value as List<Identifier>;
            if (identifiers != null)
            {
                var identifier = identifiers.FirstOrDefault(r => r.System == system);
                e.Value = identifier?.Value;
            }
        }

        protected void AddCriteria(List<string> criterias, string name, string value, Func<string, string> valueFactory = null)
        {
            if (value.IsNotNullOrEmpty())
            {
                if (valueFactory != null)
                    value = valueFactory(value);
                criterias.Add($"{name}={value}");
            }
        }

        public new DialogResult ShowDialog()
        {
            _flgDialog = true;
            return base.ShowDialog();
        }

    }
}