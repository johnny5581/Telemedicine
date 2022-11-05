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
            Execute(() => FindView<Observations.ObservationCreateForm2>());
        }

        private void menuObservationSearch_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Observations.ObservationListForm2>());
        }

        private void menuPatientFind_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Patients.PatientListForm2>());
        }
        private void menuPatientCreate_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Patients.CreatePatientForm2>());
        }

        private void 傳輸監控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                var d = AppDomain.CurrentDomain.GetData("Monitor") as TransactionMonitorDialog;
                if (d == null)
                {
                    d = new TransactionMonitorDialog();
                    AppDomain.CurrentDomain.SetData("Monitor", d);
                }
                d.Show(this);
            });
        }


        private void menuMedReqCreate_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Meds.MedRequestCreateForm>());

        }

        private void menuMedReqSearch_Click(object sender, EventArgs e)
        {

            Execute(() => FindView<Meds.MedRequestListForm>());
        }

        private void menuMedAdmCreate_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Meds.MedAdminCreateForm>());
        }

        private void menuMedAdmSearch_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Meds.MedAdminListForm>());
        }

        private void 建立ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Immunizations.ImmunizationCreateForm>());
        }

        private void 查詢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Immunizations.ImmunizationListForm>());
        }

        private void 建立ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Vaccs.VaccCreateForm>());
        }

        private void 查詢ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Vaccs.VaccListForm>());
        }

        private void 查詢ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Bundles.BundleListForm2>());
        }
        private void 建立ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Bundles.BundleCreateForm>());
        }
        private void 建立ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Orgs.OrgCreateForm>());
        }

        private void 查詢ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Orgs.OrgListForm>());
        }

        private void 建立ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Practitioners.PracCreateForm>());
        }

        private void 查詢ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<Practitioners.PracListForm>());
        }
    }
}
