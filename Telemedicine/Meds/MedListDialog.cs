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

namespace Telemedicine.Meds
{
    public partial class MedListDialog : DialogBase
    {
        public MedListDialog()
        {
            InitializeComponent();

            dgvData.AddTextColumn("Id", "#");
            dgvData.AddTextColumn<Medication>(r => r.Code, "Code", formatter: MedCodeIdFormatter, arguments: new string[] { DomainControl.SystemId });
            dgvData.AddTextColumn<Medication>(r => r.Code, "Name", formatter: MedCodeTextFormatter);
        }
        public Controller<Medication> Controller { get; set; }

        public event MedEventHandler Insert;
        protected override void OnLoadedAtRuntime()
        {
            base.OnLoadedAtRuntime();
            var meds = Controller.SearchAll();
            dgvData.SetSource(meds);
        }
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var med = GetSelectedItem<Medication>(dgvData);
                var handler = Insert;
                if (handler != null)
                    handler(this, new MedEventArgs(med));
            });

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public delegate void MedEventHandler(object sender, MedEventArgs e);
        public class MedEventArgs : EventArgs
        {
            public MedEventArgs(Medication med)
            {
                Med = med;
            }
            public Medication Med { get; }
        }
        public static void MedCodeIdFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var medCode = e.Value as CodeableConcept;
            var system = e.Arguments.ElementAtOrDefault(0) as string;
            if (medCode != null && system != null)
                e.Value = medCode.Coding?.FirstOrDefault(r => r.System == system)?.Code;
        }
        public static void MedCodeTextFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var medCode = e.Value as CodeableConcept;
            if (medCode != null)
                e.Value = medCode.Text;
        }

        

    }
}
