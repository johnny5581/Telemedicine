using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Forms;

namespace Telemedicine
{
    public class CgLabelHumanName : CgLabelCustomControl
    {
        private CgTextBox textFamily;
        private CgTextBox textGiven;

        protected override Control GetMainComponent()
        {
            var panel = base.GetMainComponent() as CgLayoutPanel;
            panel.ChangeLayout(2, 1);
            textFamily = new CgTextBox();
            textGiven = new CgTextBox();

            panel.AddControlToPosition(textFamily, 0, 0);
            panel.AddControlToPosition(textGiven, 1, 0);

            textFamily.Dock = DockStyle.Fill;
            textGiven.Dock = DockStyle.Fill;
            return panel;
        }

        [DefaultValue("")]
        public string FamilyName
        {
            get { return textFamily.Text; }
            set { textFamily.Text = value; }
        }
        [DefaultValue("")]
        public string GivenName
        {
            get { return textGiven.Text; }
            set { textGiven.Text = value; }
        }
        public HumanName GetHumanName(HumanName.NameUse use = HumanName.NameUse.Official)
        {
            var name = new HumanName().WithGiven(textGiven.Text).AndFamily(textFamily.Text);
            name.Text = textFamily.Text + textGiven.Text;
            name.Use = use;
            return name;
        }

        public void SetHumanName(HumanName name)
        {
            textFamily.Text = name?.Family;
            textGiven.Text = name?.Given?.FirstOrDefault();
        }
    }

    public class CgLabelDateTimeRange : CgLabelCustomControl
    {
        private DateTimePicker dateFromDate;
        private DateTimePicker dateFromTime;
        private DateTimePicker dateToDate;
        private DateTimePicker dateToTime;
        private CheckBox checkBoxEnable;
        private CheckBox checkBoxEndDate;
        protected override Control GetMainComponent()
        {
            var panel = base.GetMainComponent() as CgLayoutPanel;
            panel.ChangeLayout(new ColumnStyle[] {
                new ColumnStyle(SizeType.Absolute, 30),
                new ColumnStyle(SizeType.Absolute, 40),                
                new ColumnStyle(SizeType.Percent, 55f),
                new ColumnStyle(SizeType.Percent, 45f),
            }, new RowStyle[] {
                new RowStyle(SizeType.Percent, 55f),
                new RowStyle(SizeType.Percent, 45f),
            });
            dateFromDate = new DateTimePicker();
            dateFromDate.CustomFormat = "yyyy-MM-dd";
            dateFromDate.Format = DateTimePickerFormat.Custom;
            dateFromDate.Dock = DockStyle.Fill;
            dateFromTime = new DateTimePicker();
            dateFromTime.CustomFormat = "HH:mm:ss";
            dateFromTime.Format = DateTimePickerFormat.Custom;
            dateFromTime.ShowUpDown = true;
            dateFromTime.Dock = DockStyle.Fill;
            dateToDate = new DateTimePicker();
            dateToDate.CustomFormat = "yyyy-MM-dd";
            dateToDate.Format = DateTimePickerFormat.Custom;
            dateToDate.Dock = DockStyle.Fill;
            dateToTime = new DateTimePicker();
            dateToTime.CustomFormat = "HH:mm:ss";
            dateToTime.Format = DateTimePickerFormat.Custom;
            dateToTime.ShowUpDown = true;
            dateToTime.Dock = DockStyle.Fill;
            panel.AddControlToPosition(new Label { Dock = DockStyle.Fill, Text = "起", TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 1, 0);
            panel.AddControlToPosition(dateFromDate, 2, 0);
            panel.AddControlToPosition(dateFromTime, 3, 0);
            panel.AddControlToPosition(new Label { Dock = DockStyle.Fill, Text = "迄", TextAlign = System.Drawing.ContentAlignment.MiddleCenter }, 1, 1);
            panel.AddControlToPosition(dateToDate, 2, 1);
            panel.AddControlToPosition(dateToTime, 3, 1);
            checkBoxEnable = new CheckBox { Checked = true };
            checkBoxEndDate = new CheckBox { Checked = true };

            //var panelLayout = new CgLayoutPanel { Dock = DockStyle.Fill };
            //panelLayout.ChangeLayout(new ColumnStyle[] { new ColumnStyle(SizeType.Percent, 100f) }, new RowStyle[]
            //{
            //    new RowStyle(SizeType.Percent, 50f), new RowStyle(SizeType.AutoSize), new RowStyle(SizeType.Percent, 50f)
            //});
            //panelLayout.AddControlToPosition(checkBox, 0, 1);
            //panel.AddControlToPosition(panelLayout, 0, 0);
            //panel.SetRowSpan(panelLayout, 2);

            panel.AddControlToPosition(checkBoxEnable, 0, 0);
            panel.AddControlToPosition(checkBoxEndDate, 0, 1);
            checkBoxEnable.CheckedChanged += CheckBox_CheckedChanged;
            checkBoxEndDate.CheckedChanged += CheckBoxEndDate_CheckedChanged;
            return panel;
        }

        private void CheckBoxEndDate_CheckedChanged(object sender, EventArgs e)
        {
            var @checked = (sender as CheckBox).Checked;
            dateToDate.Enabled
                = dateToTime.Enabled
                = @checked;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var @checked = (sender as CheckBox).Checked;
            dateFromDate.Enabled
                = dateFromTime.Enabled
                = dateToDate.Enabled
                = dateToTime.Enabled
                = checkBoxEndDate.Enabled
                = @checked;
        }

        [DefaultValue(true)]
        public bool EnableTime
        {
            get { return dateFromTime.Visible; }
            set
            {
                dateFromTime.Visible
                    = dateToTime.Visible
                    = value;
            }
        }

        [DefaultValue(true)]
        public bool Avaliable
        {
            get { return checkBoxEnable.Checked; }
            set { checkBoxEnable.Checked = value; }
        }

        [DefaultValue(true)]
        public bool EndTimeAvaliable
        {
            get { return checkBoxEndDate.Checked; }
            set { checkBoxEndDate.Checked = value; }
        }


        public DateTime From
        {
            get
            {
                return dateFromDate.Value.Date + dateFromTime.Value.TimeOfDay;
            }
            set
            {
                dateFromDate.Value
                    = dateFromTime.Value
                    = value;
            }
        }
        public DateTime To
        {
            get
            {
                return dateToDate.Value.Date + dateToTime.Value.TimeOfDay;
            }
            set
            {
                dateToDate.Value
                    = dateToTime.Value
                    = value;
            }
        }
    }
}