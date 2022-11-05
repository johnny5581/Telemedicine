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
        
        public BundleCreateForm()
        {
            InitializeComponent();            
        }

        public Controller<Bundle> Controller { get; set; }
        public Controller<Composition> CompositionController { get; set; }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {                
                // create composition
                var composition = new Composition();
                composition.Status = CompositionStatus.Final;
                composition.Type = new CodeableConcept("http://loinc.org", "82593-5", "Immunization summary report", null);
                composition.Subject = patientControl1.GetResourceReference();
                composition.Date = FhirDateTime.Now().Value;
                composition.Author.Add(pracControl1.GetResourceReference());
                composition.Title = "COVID-19 Vaccine";                
                var section = new Composition.SectionComponent();
                section.Entry.Add(orgControl1.GetResourceReference());
                section.Entry.Add(patientControl1.GetResourceReference());
                section.Entry.Add(pracControl1.GetResourceReference());
                composition.Section.Add(section);

                var comId = CompositionController.Create(composition);
                var com = CompositionController.Get(comId);

                MsgBoxHelper.Info("建立composition完成");

                // create bundle document
                var bundle = new Bundle();
                bundle.Type = Bundle.BundleType.Document;
                bundle.Timestamp = DateTimeOffset.Now;

                var pat = patientControl1.GetModel();
                var org = orgControl1.GetModel();
                var prac = pracControl1.GetModel();

                bundle.Identifier = new Identifier(textIdSys.Text, textIdVal.Text);
                bundle.Identifier.Period = new Period(new FhirDateTime(textPeriodFrom.Text), new FhirDateTime(textPeriodTo.Text));
                bundle.Timestamp = FhirDateTime.Now().ToDateTimeOffset(TimeSpan.FromHours(8));
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = com, FullUrl = com.ResourceBase + "Composition/" + com.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = org, FullUrl = org.ResourceBase + "Organization/" + org.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = pat, FullUrl = pat.ResourceBase + "Patient/" + pat.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = prac, FullUrl = prac.ResourceBase + "Practitioner/" + prac.Id });
                var document = Controller.Create(bundle);


                MsgBoxHelper.Info("建立完成");
            });
        }

        private void cgIconButton1_Click(object sender, EventArgs e)
        {
            textIdVal.Text = Guid.NewGuid().ToString();
        }

        private void orgControl1_ItemPicked(object sender, EventArgs e)
        {

        }
    }
}
