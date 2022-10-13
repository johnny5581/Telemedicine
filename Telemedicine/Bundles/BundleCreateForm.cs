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

namespace Telemedicine.Bundles
{
    public partial class BundleCreateForm : FormBase
    {
        private PractitionerController _ctrlPrac;
        private CompositionController _ctrlComposition;
        public BundleCreateForm()
        {
            InitializeComponent();
            _ctrlPrac = new PractitionerController(this);
            _ctrlComposition = new CompositionController(this);
        }

        private void buttonPatPicker_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new Patients.PatientListForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var pat = d.SelectedPatient;
                        textPatId.Text = pat.Id;
                        textPatId.Tag = pat;
                    }
                }
            });
        }

        private void buttonOrgPicker_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new Orgs.OrgListForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var org = d.Selected;
                        textOrgId.Text = org.Id;
                        textOrgId.Tag = org;
                    }
                }
            });
        }
        private void buttonUserPicker_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new Practitioners.PracListForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var user = d.Selected;
                        textUserId.Text = user.Id;
                        textUserId.Tag = user;
                    }
                }
            });
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {                
                // create composition
                var composition = new Composition();
                composition.Status = CompositionStatus.Final;
                composition.Type = new CodeableConcept("http://loinc.org", "82593-5", "Immunization summary report", null);
                composition.Subject = new ResourceReference("Patient/" + textPatId.Text);
                composition.Date = FhirDateTime.Now().Value;
                composition.Author.Add(new ResourceReference("Practitioner/" + textUserId.Text));
                composition.Title = "COVID-19 Vaccine";                
                var section = new Composition.SectionComponent();
                section.Entry.Add(new ResourceReference("Organization/" + textOrgId.Text));
                section.Entry.Add(new ResourceReference("Patient/" + textPatId.Text));
                section.Entry.Add(new ResourceReference("Practitioner/" + textUserId.Text));
                composition.Section.Add(section);

                var comId = _ctrlComposition.Create(composition);
                var com = _ctrlComposition.Read("Composition/" + comId);

                MsgBoxHelper.Info("建立composition完成");

                // create bundle document
                var bundle = new Bundle();
                bundle.Type = Bundle.BundleType.Document;
                bundle.Timestamp = DateTimeOffset.Now;
                var pat = textPatId.Tag as Patient;
                var org = textOrgId.Tag as Organization;
                var prac = textUserId.Tag as Practitioner;
                bundle.Identifier = new Identifier(textIdSys.Text, textIdVal.Text);
                bundle.Identifier.Period = new Period(new FhirDateTime(textPeriodFrom.Text), new FhirDateTime(textPeriodTo.Text));
                bundle.Timestamp = FhirDateTime.Now().ToDateTimeOffset(TimeSpan.FromHours(8));
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = com, FullUrl = com.ResourceBase + "Composition/" + com.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = org, FullUrl = org.ResourceBase + "Organization/" + org.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = pat, FullUrl = pat.ResourceBase + "Patient/" + pat.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = prac, FullUrl = prac.ResourceBase + "Practitioner/" + prac.Id });
                var document = _ctrlComposition.GetClient().Create(bundle);


                MsgBoxHelper.Info("建立完成");
            });
        }

        private void cgIconButton1_Click(object sender, EventArgs e)
        {
            textIdVal.Text = Guid.NewGuid().ToString();
        }
    }
}
