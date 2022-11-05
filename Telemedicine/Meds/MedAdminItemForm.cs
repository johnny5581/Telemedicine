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

namespace Telemedicine.Meds
{
    public partial class MedAdminItemForm : DialogBase
    {
        public MedAdminItemForm()
        {
            InitializeComponent();
        }
        public Controller<Medication> Controller { get; set; }

        public decimal? Quantity
        {
            get
            {
                return textQuantity.Text.ToNullable<decimal>();
            }
            set
            {
                textQuantity.Text = Convert.ToString(value);
            }
        }

        public DataType Effective
        {
            get
            {
                return dateRange.GetEffective();                
            }
            set
            {
                if (value is FhirDateTime)
                {
                    dateRange.EndTimeAvaliable = false;
                    var dt = (value as FhirDateTime).ToDateTime();
                    if (dt != null)
                        dateRange.From = dt.Value;
                }
                else if (value is Period)
                {
                    var period = value as Period;
                    var f = new FhirDateTime(period.Start).ToDateTime();
                    var e = new FhirDateTime(period.End).ToDateTime();
                    if (f != null && e != null)
                    {
                        dateRange.From = f.Value;
                        dateRange.To = e.Value;
                    }
                }
            }
        }
        public void SetMedicationAdministration(MedicationAdministration medAdm)
        {
            if (medAdm.Medication is ResourceReference)
            {
                var med = Controller.Read((medAdm.Medication as ResourceReference).Reference);
                medControl1.SetModel(med);
            }
            else if (medAdm.Medication is CodeableConcept)
            {
                var code = (medAdm.Medication as CodeableConcept)?.Coding?.FirstOrDefault()?.Code;
                medControl1.Set(code);
            }

            textUnit.Text = medAdm.Dosage.Dose.Unit;
            Quantity = medAdm.Dosage.Dose.Value;
            Effective = medAdm.Effective;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                if (Quantity == null)
                    throw new Exception("請輸入數量");
                DialogResult = DialogResult.OK;
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
