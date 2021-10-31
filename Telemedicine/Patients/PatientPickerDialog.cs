using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Controllers;
using Telemedicine.Forms;

namespace Telemedicine.Patients
{
    public class PatientPickerDialog : CgBaseDialogForm
    {
        private CgDataGridPanel dgvData;
        public Patient SelectedPatient { get; private set; }
        protected override Control GetMainComponent()
        {
            dgvData = new CgDataGridPanel();
            dgvData.Size = new System.Drawing.Size(300, 300);
            dgvData.AddTextColumn<Patient>(r => r.Id);
            dgvData.AddTextColumn<Patient>(r => r.Name, formatter: NameFormatter);
            dgvData.AddTextColumn<Patient>(r => r.BirthDate);
            dgvData.AddTextColumn<Patient>(r => r.Gender);
            return dgvData;
        }

        private void NameFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            e.Value = PatientController.GetName(e.Value as List<HumanName>) ?? "";
            e.FormattingApplied = true;
        }

        public void LoadPatients(IEnumerable<Patient> pats)
        {
            dgvData.SetSource(pats);
        }

        protected override void OnPositiveClicking(CancelEventArgs e)
        {
            var item = dgvData.GetSelectedItem();
            if (item == null)
            {
                MsgBoxHelper.Warning("請選擇資料");
                e.Cancel = true;
                return;
            }
            SelectedPatient = item as Patient;
            base.OnPositiveClicking(e);            
        }
    }
}
