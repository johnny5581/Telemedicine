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
    public partial class MedicationListForm : DialogBase
    {
        private MedicationController _ctrlMed;
        public MedicationListForm()
        {
            InitializeComponent();

            dgvData.AddTextColumn<MedicationData>(r => r.Id);
            dgvData.AddTextColumn<MedicationData>(r => r.Text);


            _ctrlMed = new MedicationController(this);
            //var meds = _ctrlMed.SearchByActive();
            var meds = _ctrlMed.SearchAll();
            var dataList = meds.Select(r => new MedicationData(r)).ToList();
            dgvData.SetSource(dataList);
        }

        public event EventHandler Insert;

        public Medication GetCurrentMedication()
        {
            var item = GetSelectedItem<MedicationData>(dgvData, false);
            if (item != null)
                return item.Data;
            return null;
        }
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            var handler = Insert;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private class MedicationData : DataModelBase<Medication>
        {
            public MedicationData(Medication data) : base(data, false)
            {
                Id = data.Id;
                Text = data.Code?.Text;
            }

            public string Id { get; set; }
            public string Text { get; set; }
        }


    }
}
