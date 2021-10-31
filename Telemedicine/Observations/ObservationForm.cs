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
    public partial class ObservationForm : FormBase
    {
        private PatientController _ctrlPat;
        private ObservationController _ctrlObs;
        public ObservationForm()
        {
            InitializeComponent();
            comboVs.SelectedIndex = comboVs.AddTextItem("全部", null);
            comboVs.AddItemRange(VitalSign.VitalSigns, r => string.Format("{0} ({1})", r.ItemChn, r.Item), r => r.Code);

            _ctrlPat = new PatientController(this);
            _ctrlObs = new ObservationController(this);

            dgvData.AddTextColumn<Observation>(r => r.Id, "#");
            dgvData.AddTextColumn<Observation>(r => r.Effective, formatter: DateTimeFormatter);
            dgvData.AddTextColumn("Item", "Item", "Value", ItemFormatter);
            dgvData.AddTextColumn("Code", "Code", "Value", CodeFormatter);
            dgvData.AddTextColumn("Value", "Value", "Value", ValueFormatter);
            dgvData.AddTextColumn("Unit", "Unit", "Value", UnitFormatter);
        }

        private void DateTimeFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var value = e.Value as FhirDateTime;
            if(value != null)
            {
                e.Value = value.ToDateTime().ToString("yyyy-MM-dd HH:mm:ss");
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
            ClearControls(textId, textName, textBrithDate, textSex);
            dgvData.ClearSource();
        }
        private void ActionSearch()
        {
            var text = textSearch.Text;
            ActionClearScreen();
            if (text.IsNotNullOrEmpty())
            {
                var pat = _ctrlPat.SearchSingle(text);
                if (pat != null)
                {
                    textId.Text = pat.Id;
                    textName.Text = PatientController.GetName(pat);
                    textBrithDate.Text = pat.BirthDate;
                    textSex.Text = pat.Gender.ToString(false);
                }
                else
                    throw new Exception("找不到病患");

                var code = comboVs.SelectedValue as string;
                var obs = _ctrlObs.SearchByPatient(pat.Id, code);
                if (obs == null || obs.Count == 0)
                    throw new Exception("no data found");
                dgvData.SetSource(obs);
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Execute(ActionSearch);
        }


    }
}
