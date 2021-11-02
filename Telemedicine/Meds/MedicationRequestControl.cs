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

namespace Telemedicine.Meds
{
    public partial class MedicationRequestControl : UserControlBase
    {
        public MedicationRequestControl()
        {
            InitializeComponent();

            comboMedTiming.AddItemRange(MedTiming.Timings, r => r.ToString(), r => r.Code);
            comboMedRoute.AddItemRange(MedRoute.Routes, r => r.ToString(), r => r.Code);
            comboUnit.AddItemRange(MedUnit.Units, r => r.ToString(), r => r.Code);
        }

        public MedTiming Timing
        {
            get { return (MedTiming)comboMedTiming.SelectedItem; }
            set
            {
                if (value == null)
                    comboMedTiming.SelectedIndex = -1;
                else
                    comboMedTiming.SelectItem<MedTiming>(r => r.Code == value.Code);
            }
        }

        public MedRoute Route
        {
            get { return (MedRoute)comboMedRoute.SelectedItem; }
            set
            {
                if (value == null)
                    comboMedRoute.SelectedIndex = -1;
                else
                    comboMedRoute.SelectItem<MedRoute>(r => r.Code == value.Code);
            }
        }
        public MedUnit Unit
        {
            get { return (MedUnit)comboUnit.SelectedItem; }
            set
            {
                if (value == null)
                    comboUnit.SelectedIndex = -1;
                else
                    comboUnit.SelectItem<MedUnit>(r => r.Code == value.Code);
            }
        }
        public string Instruction
        {
            get { return textInstruction.Text; }
            set { textInstruction.Text = value; }
        }
        public DateTime DateBegin
        {
            get { return dateBegin.Value; }
            set { dateBegin.Value = value; }
        }
        public DateTime DateEnd
        {
            get { return dateEnd.Value; }
            set { dateEnd.Value = value; }
        }
    }
}
