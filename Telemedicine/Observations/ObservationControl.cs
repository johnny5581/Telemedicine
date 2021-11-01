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
    public partial class ObservationControl : UserControlBase
    {
        private Observation _lastModel;

        public ObservationControl()
        {
            InitializeComponent();
            ResetVitalSigns();
        }


        public void ResetVitalSigns(string notSpecifyText = null)
        {
            comboItem.ComboBox.BindVitalSigns(notSpecifyText);            
        }

        public void ResetEffectiveDateTime()
        {
            var now = DateTime.Now;
            dateDate.Value = now;
            dateTime.Value = now;            
        }
        
        public void Clear()
        {
            ClearControls(textValue, textUnit, comboItem, dateDate, dateTime);
        }

        public void LoadModel(Observation model)
        {
            Clear();
            if(model.Value != null)
            {
                if (model.Value is Quantity)
                {
                    var quantity = model.Value as Quantity;
                    comboItem.ComboBox.SelectItem<VitalSign>(r => r.Code == quantity.Code);
                    textValue.Text = quantity.Value.ToString(false);
                }
                else
                    throw new NotSupportedException("not supported value type:" + model.Value.GetType().FullName);
            }
            
            if(model.Effective != null)
            {
                if(model.Effective is FhirDateTime)
                {
                    var dt = model.Effective as FhirDateTime;
                    var date = dt.ToDateTime();
                    if(date.HasValue)
                    {
                        dateDate.Value = date.Value;
                        dateTime.Value = date.Value;
                    }
                    else                    
                        ResetEffectiveDateTime();                    
                }
                else
                    throw new NotSupportedException("not supported effective type:" + model.Effective.GetType().FullName);
            }

            _lastModel = model;
        }

        public Observation GetModel()
        {
            var vs = GetVitalSign();
            var model = _lastModel;
            if(model == null)
            {
                model = new Observation();                
            }

            model.Value = GetValueQuantity();
            
            


            return model;
        }

        public Quantity GetValueQuantity(bool throwOnError = true)
        {
            var vs = GetVitalSign();
            var valueText = textValue.Text;
            var value = valueText.ToNullable<decimal>();
            if (value == null && throwOnError)
                throw new FormatException("can't convert value to decimal: " + valueText);
            var quantity = new Quantity(value.Value, vs.Unit, vs.UnitSystem);
            return quantity;
        }

        public DateTime GetEffectiveDateTime()
        {
            var date = dateDate.Value;
            var time = dateTime.Value;
            return date.Date + time.TimeOfDay;
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
            if(comboItem.SelectedIndex != -1)
            {
                var vs = comboItem.SelectedItem as VitalSign;
                if(vs != null)                
                    textUnit.Text = vs.Unit;                
            }
        }
    }
}
