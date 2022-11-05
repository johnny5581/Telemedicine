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
using Telemedicine.Forms;

namespace Telemedicine.Observations
{
    public partial class ObservationItemForm : FormBase
    {
        public ObservationItemForm()
        {
            InitializeComponent();
            comboItem.BindVitalSigns();
        }
        public event EventHandler Insert;
        
        public bool BatchMode
        {
            get { return buttonInsert.Visible; }
            set
            {
                buttonInsert.Visible = value;
                buttonOk.Visible = !value;
            }
        }

        public void SetObservation(Observation obs)
        {
            buttonInsert.Visible = false;
            comboItem.SelectItem<VitalSign>(r => r.Code == obs.Code?.Coding?.FirstOrDefault()?.Code);
            comboItem.Enabled = false;
            if (obs.BodySite != null)
            {
                comboBodySite.SelectValue(obs.BodySite?.Coding?.FirstOrDefault()?.Code);
            }            
        }

        public decimal?[] GetValues()
        {
            return cgFlowLayoutPanel1.Controls.OfType<CgLabelTextBox>().Select(r => r.Text.ToNullable<decimal>()).ToArray();
        }
        

        public VitalSign VitalSign
        {
            get { return comboItem.SelectedItem as VitalSign; }
            set { comboItem.SelectItem<VitalSign>(r => r.Code == value.Code); }
        }

        public VitalSign.BodySiteObj BodySite
        {
            get { return comboBodySite.Enabled ? comboBodySite.SelectedItem as VitalSign.BodySiteObj : null; }
            set { comboBodySite.SelectValue(value.Code); }
        }
        public DataType Effective
        {
            get { return cgLabelDateTimeRange1.GetEffective(); }
        }

        private CgLabelTextBox ActionAddValue(string header)
        {
            var label = new CgLabelTextBox { Header = header };
            cgFlowLayoutPanel1.Controls.Add(label);
            return label;
        }

        public delegate void ObservationEventHandler(object sender, ObservationEventArgs e);
        public class ObservationEventArgs : EventArgs
        {
            public ObservationEventArgs(Observation observation)
            {
                Observation = observation;
            }

            public Observation Observation { get; }
        }

        private void ResetValueFields(VitalSign.ValueSpec[] valueSpecs)
        {
            var values = valueSpecs?.Length ?? 1;
            if (cgFlowLayoutPanel1.Controls.Count != values)
            {
                cgFlowLayoutPanel1.Controls.Clear();

                if (valueSpecs != null)
                {
                    foreach (var valueSpec in valueSpecs)
                    {
                        var label = new CgLabelTextBox { Header = valueSpec.VitalSign.ItemDisplay };
                        cgFlowLayoutPanel1.Controls.Add(label);
                    }
                }
                else
                {
                    var label = new CgLabelTextBox { Header = "數值" };
                    cgFlowLayoutPanel1.Controls.Add(label);
                }
            }

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                if (GetValues().Any(r => !r.HasValue))
                    throw new Exception("請輸入所有數值");
                if (Insert != null)
                    Insert(this, EventArgs.Empty);
            });
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                if (GetValues().Any(r => !r.HasValue))
                    throw new Exception("請輸入所有數值");
                DialogResult = DialogResult.OK;
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            textUnit.Text = "";
            comboBodySite.Items.Clear();
            comboBodySite.Enabled = false;
            var item = comboItem.SelectedItem as VitalSign;
            if (item != null)
            {
                textUnit.Text = item.Unit;
                if (item.BodySite != null && item.BodySite.Count > 0)
                {
                    comboBodySite.AddItemRange(item.BodySite, r => r.CodeDisplay, r => r.Code);
                    comboBodySite.Enabled = true;
                }
                ResetValueFields(item.ValueSpecs);                
            }

        }
    }
}
