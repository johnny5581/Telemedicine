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

namespace Telemedicine.Bundles
{
    public partial class BundleListForm : FormBase
    {
        private BundleController _ctrlBundle;
        private DateTimePicker dateBeginDate;
        private DateTimePicker dateBeginTime;
        private DateTimePicker dateEndDate;
        private DateTimePicker dateEndTime;
        public BundleListForm()
        {
            InitializeComponent();

            _ctrlBundle = new BundleController(this);

            dateBeginDate = new DateTimePicker();
            dateBeginDate.CustomFormat = "yyyy-MM-dd";
            dateBeginDate.Format = DateTimePickerFormat.Custom;
            dateBeginDate.Dock = DockStyle.Fill;
            dateBeginTime = new DateTimePicker();
            dateBeginTime.CustomFormat = "HH:mm:ss";
            dateBeginTime.Format = DateTimePickerFormat.Custom;
            dateBeginTime.ShowUpDown = true;
            dateBeginTime.Dock = DockStyle.Fill;
            dateEndDate = new DateTimePicker();
            dateEndDate.CustomFormat = "yyyy-MM-dd";
            dateEndDate.Format = DateTimePickerFormat.Custom;
            dateEndDate.Dock = DockStyle.Fill;
            dateEndTime = new DateTimePicker();
            dateEndTime.CustomFormat = "HH:mm:ss";
            dateEndTime.Format = DateTimePickerFormat.Custom;
            dateEndTime.ShowUpDown = true;
            dateEndTime.Dock = DockStyle.Fill;
            labelDateRange.LayoutPanel.ChangeLayout(
                new ColumnStyle[] { new ColumnStyle(SizeType.Percent, 30), new ColumnStyle(SizeType.Percent, 20), new ColumnStyle(SizeType.Absolute, 20), new ColumnStyle(SizeType.Percent, 30), new ColumnStyle(SizeType.Percent, 20) },
                new RowStyle[] { new RowStyle(SizeType.Percent, 100) });
            labelDateRange.LayoutPanel.AddControlToPosition(dateBeginDate, 0, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateBeginTime, 1, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(new Label { Text = "~", TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 2, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateEndDate, 3, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateEndTime, 4, 0);

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private void ActionSearch()
        {
            dgvData.ClearSource();

            var id = textId.Text;            
            var patIdentifier = textPatIdentifier.Text;
            var patOrg = comboPatOrg.SelectedValue as string;

            dgvData.ClearSource();

            var criteria = new List<string>();
            if (patIdentifier.IsNotNullOrEmpty())
                criteria.Add("composition.patient.identifier=" + patIdentifier);
            if (patOrg.IsNotNullOrEmpty())
                criteria.Add("composition.organization.identifier=" + patOrg);
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            if (checkDateRange.Checked)
            {
                var begin = dateBeginDate.Value.Date + dateBeginTime.Value.TimeOfDay;
                var end = dateEndDate.Value.Date + dateEndTime.Value.TimeOfDay;
                var datBegin = begin.ToString("yyyy-MM-dd");
                var datEnd = end.ToString("yyyy-MM-dd");
                criteria.Add("composition.date=gt" + datBegin);
                criteria.Add("composition.date=lt" + datEnd);
            }
            var list = _ctrlBundle.Search(criteria);
            var ctrl = ControllerBase.Create<Composition>(this);
            var dataList = list.Select(r => new DataModel(r, ctrl)).ToList();
            dgvData.SetSource(dataList);
        }
        private class DataModel : DataModelBase<Bundle>
        {
            public DataModel(Bundle data, Controller<Composition> controller) : base(data)
            {                
                var composition = controller.Read(data.Entry[0].FullUrl);
                var resOfPat = composition.Section[0].Entry.Find(resRef => resRef.TypeName == "Patient");
                var pat = data.FindEntry(resOfPat) as Patient;
                PatientId = pat.Identifier.Find(id => id.System == "https://www.cgmh.org.tw")?.Value;
                PatientName = pat.Name[0].Text;
                var resOfOrg = composition.Section[0].Entry.Find(resRef => resRef.TypeName == "Organization");
                var org = data.FindEntry(resOfOrg) as Organization;
                OrgName = org.Name;
            }

            [DisplayName("#")]
            public string Id { get; set; }

            [DisplayName("病歷號")]
            public string PatientId { get; set; }
            [DisplayName("病患姓名")]
            public string PatientName { get; set; }
            [DisplayName("組織")]
            public string OrgName { get; set; }
        }
    }
}
