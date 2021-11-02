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

namespace Telemedicine.Observations
{
    public partial class ObservationListForm : FormBase
    {
        private PatientController _ctrlPat;
        private ObservationController _ctrlObs;
        private DateTimePicker dateBeginDate;
        private DateTimePicker dateBeginTime;
        private DateTimePicker dateEndDate;
        private DateTimePicker dateEndTime;
        public ObservationListForm()
        {
            InitializeComponent();

            _ctrlPat = new PatientController(this);
            _ctrlObs = new ObservationController(this);

            dgvData.AddTextColumn<ObservationData>(r => r.Id);
            dgvData.AddTextColumn<ObservationData>(r => r.PatId);
            dgvData.AddTextColumn<ObservationData>(r => r.MedId);
            dgvData.AddTextColumn<ObservationData>(r => r.Effecitve);

            dgvData.AddTextColumn<ObservationData>(r => r.Category);
            dgvData.AddTextColumn<ObservationData>(r => r.Item);
            dgvData.AddTextColumn<ObservationData>(r => r.Code);
            dgvData.AddTextColumn<ObservationData>(r => r.Value);
            dgvData.AddTextColumn<ObservationData>(r => r.Unit);


            comboVitalSign.SelectedIndex = comboVitalSign.AddTextItem("全部", null);
            //comboVitalSign.AddItemRange(VitalSign.VitalSigns, r => r.ToString(false), r => r.Code);
            comboVitalSign.BindVitalSigns("全部");
            comboPatOrg.BindOrganizations("全部");

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


        private void ActionClearScreen()
        {
            ClearControls(textId, comboVitalSign, textSubject, textPatIdentifier);

            dgvData.ClearSource();
        }

        private void ActionSearch()
        {
            var id = textId.Text;
            var patId = textSubject.Text;
            var patIdentifier = textPatIdentifier.Text;
            var patName = textPatName.Text;
            var patOrg = comboPatOrg.SelectedValue as string;
            var vsCode = comboVitalSign.SelectedValue as string;
            var dateBegin = dateBeginDate.Value.Date + dateBeginTime.Value.TimeOfDay;
            var dateEnd = dateEndDate.Value.Date + dateEndTime.Value.TimeOfDay;

            dgvData.ClearSource();
            if (patId.IsNullOrEmpty())
            {
                // 先找看看使用者
                var patCriteria = new List<string>();
                if (patIdentifier.IsNotNullOrEmpty())
                    patCriteria.Add("identifier=" + patIdentifier);
                if (patName.IsNotNullOrEmpty())
                    patCriteria.Add("name=" + patName);
                if (patOrg.IsNotNullOrEmpty())
                    patCriteria.Add("organization=" + patOrg);
                if (patCriteria.Count > 0)
                {
                    var pat = _ctrlPat.SearchSingle(patCriteria);
                    if (pat == null) // 沒有找到病人
                        return;
                    patId = pat.Id;
                }
            }
            var criteria = new List<string>();
            if (patId.IsNotNullOrEmpty())
                criteria.Add("subject=" + patId);
            if (vsCode.IsNotNullOrEmpty())
                criteria.Add("code=" + vsCode);
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            if (checkDateRange.Checked)
            {
                var begin = dateBeginDate.Value.Date + dateBeginTime.Value.TimeOfDay;
                var end = dateEndDate.Value.Date + dateEndTime.Value.TimeOfDay;
                var datBegin = begin.ToString("yyyy-MM-dd");
                var datEnd = end.ToString("yyyy-MM-dd");
                criteria.Add("date=gt" + datBegin);
                criteria.Add("date=lt" + datEnd);
            }
            var obs = _ctrlObs.SearchPost(criteria);
            var dataList = obs.Select(r => new ObservationData(r)).ToList();
            dgvData.SetSource(dataList);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }

        private void menuEdit_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<ObservationData>(dgvData);
                using (var d = new ObservationDialog())
                {
                    d.MainComponent.LoadModel(item.Data);
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var newItem = d.MainComponent.GetModel();
                        _ctrlObs.Update(newItem);
                        MsgBoxHelper.Info("更新成功");
                        ActionSearch();
                    }
                }
            });
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var item = GetSelectedItem<ObservationData>(dgvData);
                _ctrlObs.Delete(item.Data);
                MsgBoxHelper.Info("刪除成功");
                ActionSearch();

            });
        }

        private class ObservationData : DataModelBase<Observation>
        {
            public ObservationData(Observation data) : base(data, false)
            {
                Id = data.Id;
                PatId = data.Subject?.Reference;
                MedId = data.BasedOn.FirstOrDefault()?.Reference;
                Category = data.Category.ToString(", ", r => r.Text);
                Item = data.Code.Coding.ToString(", ", r => r.Display);
                Code = data.Code.Coding.ToString(", ", r => r.Code);
                var quantity = data.Value as Quantity;
                if (data.Code.Coding[0].Code == VitalSign.BloodPressurePanel.Code)
                {
                    var sbp = data.Component.FirstOrDefault(r => r.Code.Coding.FirstOrDefault()?.Code == VitalSign.SystolicBloodPressure.Code);
                    var dbp = data.Component.FirstOrDefault(r => r.Code.Coding.FirstOrDefault()?.Code == VitalSign.DistolicBloodPressure.Code);
                    var qsbp = sbp?.Value as Quantity;
                    var qdbp = dbp?.Value as Quantity;
                    Value = $"SBP:{qsbp?.Value}, DBP: {qdbp?.Value}";
                    Unit = $"{qsbp?.Unit}, {qdbp?.Unit}";
                }
                else
                {
                    Value = quantity?.Value.ToString(false);
                    Unit = quantity?.Unit;
                }
                Effecitve = (data.Effective as FhirDateTime).ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
            }
            [DisplayName("#")]
            public string Id { get; set; }
            [DisplayName("病患")]
            public string PatId { get; set; }
            public string MedId { get; set; }
            public string Category { get; set; }
            public string Item { get; set; }
            public string Code { get; set; }
            public string Value { get; set; }
            public string Unit { get; set; }
            public string Effecitve { get; set; }
        }
    }
}
