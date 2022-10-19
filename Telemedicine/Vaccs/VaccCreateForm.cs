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

namespace Telemedicine.Vaccs
{
    public partial class VaccCreateForm : FormBase
    {
        private CompositionController _ctrlComposition;
        private ObservationController _ctrlObs;
        private PatientController _ctrlPat;
        private EncounterController _ctrlEnc;
        public VaccCreateForm()
        {
            InitializeComponent();
            
            _ctrlPat = new PatientController(this);
            _ctrlObs = new ObservationController(this);
            _ctrlComposition = new CompositionController(this);
            _ctrlEnc=new EncounterController(this);
        }

        

        private void buttonPat_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                using (var d = new Patients.PatientListForm())
                {
                    if (d.ShowDialog() == DialogResult.OK)
                    {
                        var pat = d.SelectedPatient;
                        textPatId.Text = pat.Id;
                        textPatName.Text = PatientController.GetName(pat);
                        textPatSex.Text = pat.Gender.ToString(false);
                        textPatBrithDate.Text = pat.BirthDate;
                        textPatId.Tag = pat;
                    }
                }
            });
        }
        private void buttonOrg_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                // create obs first
                var obs = new Observation();
                obs.Status = ObservationStatus.Final;
                obs.Code = new CodeableConcept(textVacSystem.Text,
                    textVacId.Text, textVacName.Text, textVacName.Text);
                obs.Effective = new Period(
                    new FhirDateTime(textRcvdat.Text), new FhirDateTime(textRptdat.Text));
                obs.Issued = new FhirDateTime(textRptdat.Text).ToDateTimeOffset(TimeSpan.FromHours(8));
                obs.Value = new FhirString("Positive");
                var obsId = _ctrlObs.Create(obs);
                obs = _ctrlObs.Read("Observation/" + obsId);
                MsgBoxHelper.Info("建立Observation完成");


                // careat eencounter
                var enc = new Encounter();
                enc.Status = Encounter.EncounterStatus.Finished;
                enc.Class = new Coding("http://terminology.hl7.org/CodeSystem/v3-ActCode", "OBSENC", "observation encounter");
                var encId = _ctrlEnc.Create(enc);
                enc = _ctrlEnc.Read("Encounter/" + encId);
                MsgBoxHelper.Info("建立Encounter完成");

                var prac = textUserId.Tag as Practitioner;
                var org = _ctrlObs.GetClient().Read<Organization>("Organization/" + textOrgId.Text);

                // create composition
                var composition = new Composition();
                composition.Status = CompositionStatus.Final;
                composition.Type = new CodeableConcept("http://loinc.org", "82593-5", "Immunization summary report", null);
                composition.Subject = new ResourceReference("Patient/" + textPatId.Text);
                composition.Date = FhirDateTime.Now().Value;
                composition.Author.Add(new ResourceReference("Organization/" + textOrgId.Text));
                composition.Title = "COVID-19 Vaccine";
                var section = new Composition.SectionComponent();
                section.Entry.Add(new ResourceReference("Organization/" + textOrgId.Text));
                section.Entry.Add(new ResourceReference("Patient/" + textPatId.Text));
                section.Entry.Add(new ResourceReference("Practitioner/" + textUserId.Text));
                section.Entry.Add(new ResourceReference("Encounter/" + encId));
                section.Entry.Add(new ResourceReference("Observation/" + obsId));
                composition.Section.Add(section);

                var comId = _ctrlComposition.Create(composition);
                var com = _ctrlComposition.Read("Composition/" + comId);

                MsgBoxHelper.Info("建立composition完成");

                // create bundle document
                var bundle = new Bundle();
                bundle.Type = Bundle.BundleType.Document;
                var pat = textPatId.Tag as Patient;
                pat.Meta = null;
                bundle.Identifier = new Identifier("http://www.cgmh.org.tw", $"TW.{textOrgId.Text}.2021110109012300.0001");
                bundle.Identifier.Period = new Period(new FhirDateTime("2021-11-01"), new FhirDateTime("2099-12-31"));
                bundle.Timestamp = FhirDateTime.Now().ToDateTimeOffset(TimeSpan.FromHours(8));
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = com, FullUrl = com.ResourceBase + "Composition/" + com.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = org, FullUrl = org.ResourceBase + "Organization/" + org.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = pat , FullUrl = pat.ResourceBase + "Patient/" + pat.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = prac, FullUrl = pat.ResourceBase + "Practitioner/" + prac.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = enc, FullUrl = pat.ResourceBase + "Encounter/" + enc.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = obs, FullUrl = obs.ResourceBase + "Observation/" + obs.Id });
                var document = _ctrlObs.GetClient().Create(bundle);


                MsgBoxHelper.Info("建立完成");

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
                        var prac = d.Selected;
                        textUserId.Text = prac.Id;
                        textUserId.Tag = prac;
                    }
                }
            });
        }
    }
}
