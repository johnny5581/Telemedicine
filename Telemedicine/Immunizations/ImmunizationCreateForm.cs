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

namespace Telemedicine.Immunizations
{
    public partial class ImmunizationCreateForm : FormBase
    {
        private MedicationAdministrationController _ctrlMedAdm;
        private MedicationRequestController _ctrlMedReq;
        private PatientController _ctrlPat;
        public ImmunizationCreateForm()
        {
            InitializeComponent();
            
            _ctrlMedReq = new MedicationRequestController(this);
            _ctrlPat = new PatientController(this);
            _ctrlMedAdm = new MedicationAdministrationController(this);
        }

        

        private void buttonPat_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new Patients.PatientListForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var pat = d.SelectedPatient;
                        textPatId.Text = pat.Id;
                        textPatName.Text = PatientController.GetName(pat);
                        textPatSex.Text = pat.Gender.ToString(false);
                        textPatBrithDate.Text = pat.BirthDate;
                    }
                }
            });
        }
        private void buttonMedReq_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                
                MsgBoxHelper.Info("建立完成");

            });
        }
        
        

    }
}
