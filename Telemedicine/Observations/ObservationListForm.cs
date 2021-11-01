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

            dgvData.AddTextColumn<Observation>(r => r.Id, "#");
            dgvData.AddTextColumn<Observation>(r => r.Effective, formatter: DateTimeFormatter);
            dgvData.AddTextColumn("PatId", "Patient Id", "Subject", PatientFormatter);
            dgvData.AddTextColumn("Item", "Item", "Value", ItemFormatter);
            dgvData.AddTextColumn("Code", "Code", "Value", CodeFormatter);
            dgvData.AddTextColumn("Value", "Value", "Value", ValueFormatter);
            dgvData.AddTextColumn("Unit", "Unit", "Value", UnitFormatter);

            comboVitalSign.SelectedIndex = comboVitalSign.AddTextItem("全部", null);
            comboVitalSign.AddItemRange(VitalSign.VitalSigns, r => r.ToString(false), r => r.Code);

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
                new RowStyle[] { new RowStyle(SizeType.Percent, 100 )});
            labelDateRange.LayoutPanel.AddControlToPosition(dateBeginDate, 0, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateBeginTime, 1, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(new Label { Text = "~", TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill }, 2, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateEndDate, 3, 0);
            labelDateRange.LayoutPanel.AddControlToPosition(dateEndTime, 4, 0);
        }

        private void PatientFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var value = e.Value as ResourceReference;
            if(value != null)
            {
                e.Value = value.Reference ?? "";
                e.FormattingApplied = true;
            }
        }

        private void DateTimeFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var value = e.Value as FhirDateTime;
            if(value != null)
            {
                e.Value = value.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
                e.FormattingApplied = true;
            }
        }

        private void UnitFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var value = e.Value as Quantity;
            if (value != null)
            {
                e.Value = value.Unit;
                e.FormattingApplied = true;
            }
        }

        private void ValueFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var value = e.Value as Quantity;
            if (value != null)
            {
                e.Value = value.Value.ToString(false);
                e.FormattingApplied = true;
            }
        }

        private void CodeFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var value = e.Value as Quantity;
            if (value != null)
            {
                e.Value = value.Code;
                e.FormattingApplied = true;
            }
        }

        private void ItemFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var value = e.Value as Quantity;
            if (value != null)
            {
                var obs = e.Row.DataBoundItem as Observation;
                var coding = obs.Code.Coding.FirstOrDefault(r => r.Code == value.Code);
                if (coding != null)
                {
                    e.Value = coding.Display;
                    e.FormattingApplied = true;
                }
            }
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
            var vsCode = comboVitalSign.SelectedValue as string;
            var dateBegin = dateBeginDate.Value.Date + dateBeginTime.Value.TimeOfDay;
            var dateEnd = dateEndDate.Value.Date + dateEndTime.Value.TimeOfDay;
            if (patId.IsNullOrEmpty() && patIdentifier.IsNotNullOrEmpty())
            {
                // 先找看看使用者
                var pat = _ctrlPat.SearchByIdentifierSingle(patIdentifier);
                if (pat != null)
                    patId = pat.Id;
            }
            dgvData.ClearSource();
            var criteria = new List<string>();
            if (patId.IsNotNullOrEmpty())
                criteria.Add("subject=" + patId);
            if (vsCode.IsNotNullOrEmpty())
                criteria.Add("code=" + vsCode);
            if (id.IsNotNullOrEmpty())
                criteria.Add("_id=" + id);
            var obs = _ctrlObs.Search(criteria);
            dgvData.SetSource(obs);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }
    }
}
