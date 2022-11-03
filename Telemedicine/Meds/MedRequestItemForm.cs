using Hl7.Fhir.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemedicine.Meds
{
    public partial class MedRequestItemForm : DialogBase
    {
        public MedRequestItemForm()
        {
            InitializeComponent();

            comboMedTiming.AddItemRange(MedTiming.Timings, r => r.Code);
            comboMedRoute.AddItemRange(MedRoute.Routes, r => r.Code);
            comboUnit.AddItemRange(MedUnit.Units, r => r.Code);
        }
        [DefaultValue(null)]
        public MedTiming Timing
        {
            get { return comboMedTiming.SelectedValue as MedTiming; }
            set { comboMedTiming.SelectItem<MedTiming>(r => r.Code == value?.Code); }
        }
        [DefaultValue(null)]
        public MedRoute Route
        {
            get { return comboMedRoute.SelectedValue as MedRoute; }
            set { comboMedRoute.SelectItem<MedRoute>(r => r.Code == value?.Code); }
        }
        [DefaultValue(null)]
        public MedUnit Unit
        {
            get { return comboUnit.SelectedValue as MedUnit; }
            set { comboUnit.SelectItem<MedUnit>(r => r.Code == value?.Code); }
        }

        public DateTime From
        {
            get { return cgLabelDateTimeRange1.From; }
            set { cgLabelDateTimeRange1.From = value; }
        }
        public DateTime To
        {
            get { return cgLabelDateTimeRange1.To; }
            set { cgLabelDateTimeRange1.To = value; }
        }
        public string Instruction
        {
            get { return textInstruction.Text; }
            set { textInstruction.Text = value; }
        }
        public void SetMedication(Medication med)
        {
            medControl1.SetModel(med);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                if (comboMedTiming.SelectedValue == null)
                    throw new InvalidOperationException("missing Timing");
                if (comboMedRoute.SelectedValue == null)
                    throw new InvalidOperationException("missing Route");
                if (comboUnit.SelectedValue == null)
                    throw new InvalidOperationException("missing Unit");
                DialogResult = DialogResult.OK;
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
