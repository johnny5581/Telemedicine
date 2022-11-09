using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
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
using System.Web.SessionState;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine
{
    public partial class ListForm : FormBase
    {
        private bool _flgDialog;
        private readonly BindingList<string> _bindingList;
        public ListForm()
        {
            InitializeComponent();
            SetupDataGridPanel(dgvData);
            _bindingList = new BindingList<string>();
            _bindingList.ListChanged += BindingList_ListChanged;
        }


        protected void AppendContextMenu(string text, EventHandler click)
        {
            var item = contextMenuStrip.Items.Add(text);
            item.Click += click;
        }
        public IList<string> PredefinedCriterias
        {
            get { return _bindingList; }
        }

        protected override void OnShownAtRuntime()
        {
            base.OnShownAtRuntime();
            if (splitContainer2.Panel2.Controls.Count == 0)
                splitContainer2.Panel2Collapsed = true;
        }
        public object Selected { get; set; }

        public bool IsEditable
        {
            get { return menuEdit.Visible; }
            set { menuEdit.Visible = value; }
        }

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
          //  criterias.Add("active=true");
            if (textId.Text.IsNotNullOrEmpty())
                criterias.Add("_id=" + textId.Text);

            if (PredefinedCriterias.Count > 0)
                criterias.AddRange(PredefinedCriterias);

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
                var item = e.Data;
                var model = item as DataModelBase;
                if (model != null)
                    item = model.Raw;
                Selected = item;
                ActionDataSelected(item);
                if (_flgDialog)
                    DialogResult = DialogResult.OK;
            });
        }
        private void meduEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                if (ActionEdit(GetSelectedItem(dgvData)))
                    MsgBoxHelper.Info("修改成功");
            });
            Execute(ActionSearch);
        }

        protected virtual bool ActionEdit(object item)
        {
            return false;
        }

        public static void PeriodFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var dataType = e.Value as DataType;
            if (dataType != null)
                e.Value = DomainControl.GetPeriod(dataType);
        }

        public static void GenericFormatter<T>(CgDataGridPanel.FormattingCellEventArgs e, Func<T, string> selector)
            where T : class
        {
            var item = e.Value as T;
            if (item != null)
                e.Value = selector(item);
            else
            {
                var list = e.Value as IEnumerable<T>;
                if (list != null)
                    e.Value = list.ToString(", ", r => selector(r));
            }
        }


        public static void ResourceReferenceFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            GenericFormatter<ResourceReference>(e, r => r.Reference);
        }

        public static void StringsFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var strings = e.Value as IEnumerable<string>;
            if (strings != null)
            {
                e.Value = strings.ToString(",");
            }
        }
        public static void HumanNamesFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var names = e.Value as IEnumerable<HumanName>;
            if (names != null)
            {
                var name = names.FirstOrDefault();
                e.Value = name?.Text;
            }
        }

        public static void IdentifierFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var system = Convert.ToString(e.Arguments.ElementAtOrDefault(0));
            var identifiers = e.Value as List<Identifier>;
            if (identifiers != null)
            {
                var identifier = identifiers.FirstOrDefault(r => r.System == system);
                e.Value = identifier?.Value;
            }
        }
        protected void AddCriteria<T>(List<string> criterias, string name, object value, Func<string, string> valueFactory = null)
        {
            if (value != null)
            {
                var enumMembers = typeof(T).GetMember(Convert.ToString(value));
                var enumMember = enumMembers.FirstOrDefault(r => r.DeclaringType == typeof(T));
                if (enumMember != null && enumMember.TryGetCustomAttribute(false, out EnumLiteralAttribute attr))
                {
                    var text = attr.Literal;
                    if (valueFactory != null)
                        text = valueFactory(text);
                    criterias.Add($"{name}={text}");
                }
            }
        }
        protected void AddCriteria(List<string> criterias, string name, object value, Func<string, string> valueFactory = null)
        {
            var text = Convert.ToString(value);
            if (text.IsNotNullOrEmpty())
            {
                if (valueFactory != null)
                    text = valueFactory(text);
                criterias.Add($"{name}={text}");
            }
        }
        protected void AddCriteria(List<string> criterias, string name, CgLabelDateTimeRange range, Func<string, string> valueFactory = null)
        {
            if (range.Avaliable)
            {
                string from, to;
                if (range.EnableTime)
                {
                    from = range.From.ToString("yyyy-MM-ddTHH:mm:ss");
                    to = range.To.ToString("yyyy-MM-ddTHH:mm:ss");
                }
                else
                {
                    from = range.From.ToString("yyyy-MM-dd");
                    to = range.To.ToString("yyyy-MM-dd");
                }

                if (range.EndTimeAvaliable)
                {
                    criterias.Add($"{name}=gt{from}");
                    criterias.Add($"{name}=lt{to}");
                }
                else
                {
                    if (valueFactory != null)
                        from = valueFactory(from);
                    criterias.Add($"{name}={from}");
                }
            }
        }
        public new DialogResult ShowDialog()
        {
            _flgDialog = true;
            return base.ShowDialog();
        }
        private void BindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            panelExtraCriteria.Controls.Clear();
            foreach (var criteria in _bindingList)
            {
                var label = new Label { AutoSize = false, Text = criteria };
                panelExtraCriteria.Controls.Add(label);
            }
        }


    }
}