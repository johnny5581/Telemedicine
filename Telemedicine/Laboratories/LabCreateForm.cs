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

namespace Telemedicine.Laboratories
{
    public partial class LabCreateForm : FormBase
    {
        public LabCreateForm()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                // create encounter
                var encounter = new Encounter();
                encounter.Status = Encounter.EncounterStatus.Finished;
                encounter.Class = new Coding("http://terminology.hl7.org/CodeSystem/v3-ActCode", "OBSENC", "observation encounter");
                encounter.Id = ControllerBase.Get<Encounter>().Create(encounter);
                MsgBoxHelper.Info("Encounter: " + encounter.Id);

                // create observation
                var observation = new Observation();
                observation.Status = ObservationStatus.Final;
                var obsIdentifier = new Identifier(DomainControl.SystemId, textLabId.Text);
                obsIdentifier.Type = new CodeableConcept("http://terminology.hl7.org/CodeSystem/v2-0203", "LACSN");
                observation.Identifier.Add(obsIdentifier);
                observation.BodySite = new CodeableConcept("http://snomed.info/set", "442083009", "Anatomical or acquired body structure", "Anatomical or acquired body structure");
                observation.Category.Add(new CodeableConcept("http://terminology.hl7.org/CodeSystem/v3-SpecimenType", textLabCategory.Text, textLabCategoryDesc.Text, textLabCategoryDesc.Text));
                observation.Effective = new Period(new FhirDateTime(textLabDat.Text), new FhirDateTime(textRcvDat.Text));
                observation.Issued = new FhirDateTime(textRptDat.Text).ToDateTimeOffset();
                observation.Subject = patientControl1.GetResourceReference();
                observation.Performer.Add(pracControl1.GetResourceReference());
                observation.Encounter = DomainControl.GetResourceReference(encounter);
                var glu = VitalSign.BloodGlucosePostMeal;
                observation.Code = glu.GetCode();
                //observation.Category.Add(glu.GetCategory());
                observation.Value = new Quantity(100, glu.Unit);
                observation.ReferenceRange.Add(new Observation.ReferenceRangeComponent { Low = new Quantity(80, glu.Unit), High = new Quantity(130, glu.Unit) });
                observation.Id = ControllerBase.Get<Observation>().Create(observation);
                MsgBoxHelper.Info("Observation: " + observation.Id);

                // create composition
                var composition = new Composition();
                composition.Status = CompositionStatus.Final;
                composition.Type = new CodeableConcept("http://loinc.org", textLabItid.Text
                    , textLabItnm.Text, textLabItnm.Text);
                composition.Subject = patientControl1.GetResourceReference();
                composition.Date = new FhirDateTime(DateTimeOffset.Now).ToString();
                composition.Title = textRptTitle.Text;
                composition.Author.Add(pracControl1.GetResourceReference());
                var section = new Composition.SectionComponent();
                section.Entry.Add(orgControl1.GetResourceReference());
                section.Entry.Add(patientControl1.GetResourceReference());
                section.Entry.Add(pracControl1.GetResourceReference());
                section.Entry.Add(DomainControl.GetResourceReference(encounter));
                section.Entry.Add(DomainControl.GetResourceReference(observation));
                composition.Section.Add(section);
                composition.Id = ControllerBase.Get<Composition>().Create(composition);
                MsgBoxHelper.Info("Composition: " + composition.Id);

                var bundle = new Bundle();
                bundle.Identifier = new Identifier(DomainControl.SystemId, Guid.NewGuid().ToString());
                bundle.Identifier.Period = new Period(new FhirDateTime(DateTime.Now), new FhirDateTime(DateTime.Now.AddYears(5)));
                
                bundle.Type = Bundle.BundleType.Document;
                bundle.Timestamp = DateTimeOffset.Now;
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = composition, FullUrl = composition.ResourceBase + DomainControl.GetResourceReference(composition).Reference });

                bundle.Entry.Add(new Bundle.EntryComponent { Resource = orgControl1.GetModel(), FullUrl = composition.ResourceBase + orgControl1.GetResourceReference().Reference });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = patientControl1.GetModel(), FullUrl = composition.ResourceBase + patientControl1.GetResourceReference().Reference });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = pracControl1.GetModel(), FullUrl = composition.ResourceBase + pracControl1.GetResourceReference().Reference });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = encounter, FullUrl = composition.ResourceBase + DomainControl.GetResourceReference(encounter).Reference });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = observation, FullUrl = composition.ResourceBase + DomainControl.GetResourceReference(observation).Reference });
                bundle.Id = ControllerBase.Get<Bundle>().Create(bundle);
                MsgBoxHelper.Info("Bundle: " + bundle.Id);
            });
        }

        private void cgIconButton1_Click(object sender, EventArgs e)
        {
            textLabId.Text = Guid.NewGuid().ToString();
        }
    }
}
