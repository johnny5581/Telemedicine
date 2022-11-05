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

namespace Telemedicine.Observations
{
    public partial class ObservationControl2 : UserControlBase
    {
        private Observation _lastModel;

        public ObservationControl2()
        {
            InitializeComponent();
            ResetVitalSigns();
        }


        public void ResetVitalSigns(string notSpecifyText = null)
        {
            comboItem.ComboBox.BindVitalSigns(notSpecifyText);
        }

        public void Clear()
        {
            ClearControls(textValue, textUnit, comboItem);
        }

        public void LoadModel(Observation model)
        {

            Clear();
            _lastModel = model;
            var code = model.Code;
            var quantity = model.Value as Quantity;
            var valueCode = code.Coding.FirstOrDefault()?.Code;
            if (valueCode != VitalSign.BloodPressurePanel.Code)
            {
                comboItem.SelectItem<VitalSign>(r => r.Code == valueCode);
                textValue.Text = quantity.Value.ToString(false);
            }
            else
            {
                comboItem.SelectItem<VitalSign>(r => r.Code == VitalSign.BloodPressurePanel.Code);
                var sbp = model.Component.FirstOrDefault(r => r.Code.Coding[0].Code == VitalSign.SystolicBloodPressure.Code);
                var dbp = model.Component.FirstOrDefault(r => r.Code.Coding[0].Code == VitalSign.DistolicBloodPressure.Code);
                textValue.Text = (sbp.Value as Quantity).Value.ToString(false);
                textValue2.Text = (dbp.Value as Quantity).Value.ToString(false);
            }
        }

        public Observation GetModel()
        {
            var vs = GetVitalSign();
            var observation = _lastModel ?? new Observation();
            observation.Status = ObservationStatus.Final;
            observation.Category.Add(new CodeableConcept(vs.CategorySystem, vs.Category, vs.CategoryDisplay, vs.CategoryDisplay));
            observation.Code = new CodeableConcept(vs.CodeSystem, vs.Code, vs.Item, vs.ItemDisplay);
            observation.Effective = new FhirDateTime(dateDate.Value.Date + dateTime.Value.TimeOfDay);
            if (vs.Code == VitalSign.Femoral.Code)
            {
                observation.BodySite = new CodeableConcept { };
                foreach (var item in vs.BodySite)
                {                    
                    observation.BodySite.Coding.Add(item.GetCode());
                    //observation.BodySite.Coding
                }
                observation.BodySite.Text = vs.ItemDisplay;
            }
            if (vs.Code == VitalSign.BloodPressurePanel.Code)
            {
                var sbp = new Observation.ComponentComponent();
                sbp.Code = new CodeableConcept(VitalSign.SystolicBloodPressure.CodeSystem,
                    VitalSign.SystolicBloodPressure.Code,
                    VitalSign.SystolicBloodPressure.Item,
                    VitalSign.SystolicBloodPressure.ItemDisplay);
                sbp.Value = GetValueQuantity(textValue.Text, VitalSign.SystolicBloodPressure);
                observation.Component.Add(sbp);

                var dbp = new Observation.ComponentComponent();
                dbp.Code = new CodeableConcept(VitalSign.DistolicBloodPressure.CodeSystem,
                    VitalSign.DistolicBloodPressure.Code,
                    VitalSign.DistolicBloodPressure.Item,
                    VitalSign.DistolicBloodPressure.ItemDisplay);
                dbp.Value = GetValueQuantity(textValue2.Text, VitalSign.DistolicBloodPressure);
                observation.Component.Add(dbp);
            }
            else
            {
                observation.Value = GetValueQuantity(textValue.Text, vs);
            }

            
            return observation;
        }

        public Quantity GetValueQuantity(string valueText, VitalSign vs, bool throwOnError = true)
        {
            var value = valueText.ToNullable<decimal>();
            if (value == null && throwOnError)
                throw new FormatException("can't convert value to decimal: " + valueText);
            var quantity = new Quantity(value.Value, vs.Unit, vs.UnitSystem);
            return quantity;
        }

        public VitalSign GetVitalSign(bool throwOnError = true)
        {
            var vs = comboItem.SelectedItem as VitalSign;
            if (vs == null && throwOnError)
                throw new NullReferenceException("no vital sign selected");
            return vs;
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls(textUnit);
            if (comboItem.SelectedIndex != -1)
            {
                var vs = comboItem.SelectedItem as VitalSign;
                if (vs != null)
                    textUnit.Text = vs.Unit;
                textValue2.Visible = vs.Code == VitalSign.BloodPressurePanel.Code;
            }
        }
    }
}
