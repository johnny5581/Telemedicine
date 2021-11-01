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
    public partial class CreateSingleForm : DialogBase
    {
        private PatientController _ctrlPat;
        private ObservationController _ctrlObs;
        public CreateSingleForm()
        {
            InitializeComponent();

            comboItem.AddTextItem("", null);
            comboItem.AddItemRange(VitalSign.VitalSigns, r => string.Format("{0} ({1})", r.ItemDisplay, r.Item));

            _ctrlPat = new PatientController(this);
            _ctrlObs = new ObservationController(this);
        }

        private void ActionClearScreen()
        {
            ClearControls(textId, textName, textBrithDate, textSex, textUnit, textValue, comboItem);
        }
        private void ActionSearchPatient()
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
            }
        }
        private void ActionUpload()
        {
            var vs = comboItem.ComboBox.SelectedItem as VitalSign;
            var value = textValue.Text;
            var id = textId.Text;
            if (id.IsNullOrEmpty())
                throw new Exception("no patient select");
            var obs = new Observation();
            obs.Status = ObservationStatus.Final;
            obs.Category.Add(new CodeableConcept(vs.CategorySystem, vs.Category, vs.CategoryDisplay));
            obs.Code = new CodeableConcept { };
            obs.Code.Coding.Add(new Coding(vs.CodeSystem, vs.Code, vs.Item));
            obs.Subject = new ResourceReference("Patient/" + id);
            obs.Effective = FhirDateTime.Now();
            var valueQuantity = new Quantity(value.To<decimal>(), vs.Unit, vs.UnitSystem);
            valueQuantity.Code = vs.Code;
            obs.Value = valueQuantity;
            _ctrlObs.Create(obs);
            MsgBoxHelper.Info("上傳成功");
        }
        private void textSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Execute(ActionSearchPatient);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Execute(ActionUpload);
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboItem.SelectedIndex != -1)
            {
                var vs = comboItem.ComboBox.SelectedItem as VitalSign;
                textValue.Text = null;
                textUnit.Text = vs.Unit;
            }
        }
    }
}
