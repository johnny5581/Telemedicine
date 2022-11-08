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
using Telemedicine.Patients;

namespace Telemedicine.Orgs
{
    [DomainControl(typeof(Organization))]
    public partial class OrgControl : DomainControl
    {
        public static string[] Organizations
            = new string[]
            {
                "MITW.ForIdentifier",
                "MITW.ForContact",
                "MITW.ForPHR",
                "MITW.ForEMS",
            };
        public const string OrgSystemId = "http://twcore.mohw.gov.tw/fhir/CodeSystem/organization-identifier-tw";
        public OrgControl()
        {
            InitializeComponent();
            comboPredefined.AddItemRange(Organizations, r => r);
        }

        public override Type ListFormType => typeof(OrgListForm);
        protected override bool RequireShowPickerDialog()
        {
            var predefined = comboPredefined.SelectedValue as string;
            if(predefined != null)
            {
                IdValue = predefined;
                comboPredefined.SelectedIndex = -1;
                return false;
            }
            return base.RequireShowPickerDialog();
        }
    }
}

