﻿using System;
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
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }

            return form;
        }
        private T FindView<T>(bool createIfEmpty = true) where T : Form
        {
            return (T)FindView(typeof(T), createIfEmpty);
        }

        private void menuPatient_Click(object sender, EventArgs e)
        {
            Execute(() => FindView<PatientForm>());
        }
    }
}
