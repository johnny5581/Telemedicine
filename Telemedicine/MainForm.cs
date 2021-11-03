using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telemedicine
{
    public partial class MainForm : FormBase
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form FindView(Type viewType, bool createIfEmpty = true)
        {
            Form form = null;
            foreach (var f in MdiChildren)
            {
                if (f.GetType() == viewType)
                {
                    form = f;
                    break;
                }
            }

            if (form != null)
            {
                form.BringToFront();
            }
            else if (createIfEmpty)
            {
                form = (Form)Activator.CreateInstance(viewType);
                var f = form as FormBase;
                if (f != null)
                    f.Show(this);
                else
                    f.Show();
            }
            return form;
        }
        private T FindView<T>(bool createIfEmpty = true) where T : Form
        {
            return (T)FindView(typeof(T), createIfEmpty);
        }

        private void menuObservationPersonal_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Observations.ObservationCreateForm>());
        }

        private void menuObservationSearch_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Observations.ObservationListForm>());
        }

        private void menuPatientFind_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Patients.PatientListForm>());
        }
        private void menuPatientCreate_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Patients.CreatePatientForm>());
        }

        private void 傳輸監控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var d = AppRuntime.Current.GetData("Monitor") as TransactionMonitorDialog;
                if (d == null)
                {
                    d = new TransactionMonitorDialog();
                    AppRuntime.Current.SetData("Monitor", d);
                }
                d.Show(this);
            });
        }


        private void menuMedReqCreate_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Meds.MedicationRequestCreateForm>());

        }

        private void menuMedReqSearch_Click(object sender, EventArgs e)
        {

            Execute(() => FindView<Meds.MedicationRequestListForm>());
        }

        private void menuMedAdmCreate_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Meds.MedicationAdminCreateForm>());
        }

        private void menuMedAdmSearch_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Meds.MedicationAdminListForm>());
        }

        private void 建立ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Immunizations.ImmunizationCreateForm>());
        }

        private void 查詢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Immunizations.ImmunizationListForm>());
        }
    }
}
