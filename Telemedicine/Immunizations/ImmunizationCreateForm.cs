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

namespace Telemedicine.Immunizations
{
    public partial class ImmunizationCreateForm : FormBase
    {
        private MedicationAdministrationController _ctrlMedAdm;
        private MedicationRequestController _ctrlMedReq;
        private PatientController _ctrlPat;
        private ImmunizationController _ctrlImmu;
        public ImmunizationCreateForm()
        {
            InitializeComponent();
            
            _ctrlMedReq = new MedicationRequestController(this);
            _ctrlPat = new PatientController(this);
            _ctrlMedAdm = new MedicationAdministrationController(this);
            _ctrlImmu = new ImmunizationController(this);
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
            using (var d = new Orgs.OrgListForm())
            {
                if (d.ShowDialog() == DialogResult.OK)
                {
                    var org = d.Selected;
                    textOrgId.Text = org.Id;
                    textOrgName.Text = org.Name;
                }
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Execute(() =>
            {
                // create immu first

                var immunization = new Immunization();
                immunization.Status = Immunization.ImmunizationStatusCodes.Completed;
                var protocolApplied = new Immunization.ProtocolAppliedComponent();
                protocolApplied.TargetDisease.Add(new CodeableConcept("http://hl7.org/fhir/sid/icd-10", textICD.Text));
                protocolApplied.DoseNumber = new PositiveInt(textVacDose.Text.ToNullable<int>());
                protocolApplied.SeriesDoses = new PositiveInt(textVacSeries.Text.ToNullable<int>());
                immunization.ProtocolApplied.Add(protocolApplied);
                immunization.Patient = new ResourceReference("Patient/" + textPatId.Text);
                immunization.VaccineCode = new CodeableConcept("http://www.cdc.gov.tw", textVacId.Text, textVacName.Text, textVacName.Text);
                immunization.Manufacturer = new ResourceReference();
                immunization.Manufacturer.Display = textVacMa.Text;
                immunization.LotNumber = textVacIot.Text;
                immunization.Occurrence = new FhirDateTime(textImmuDate.Text);
                var performer = new Immunization.PerformerComponent();
                performer.Actor = new ResourceReference("Organization/" + textOrgId.Text);
                immunization.Performer.Add(performer);
                var meduser = new Immunization.PerformerComponent();
                meduser.Actor = new ResourceReference();
                meduser.Actor.Display = textImmuPerformer.Text;
                immunization.Performer.Add(meduser);

                var immuId = _ctrlImmu.Create(immunization);
                var org = _ctrlImmu.GetClient().Read<Organization>("Organization/" + textOrgId.Text);
                var immu = _ctrlImmu.Read("Immunization/" + immuId);

                MsgBoxHelper.Info("建立Immunization完成");

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
                section.Entry.Add(new ResourceReference("Immunization/" + immuId));
                composition.Section.Add(section);

                var newComposition = _ctrlImmu.GetClient().Create(composition);

                MsgBoxHelper.Info("建立composition完成");
                // create bundle document
                var bundle = new Bundle();
                bundle.Type = Bundle.BundleType.Document;
                var pat = textPatId.Tag as Patient;
                pat.Meta = null;
                bundle.Identifier = new Identifier("http://www.cgmh.org.tw", $"TW.{textOrgId.Text}.2021110109012300.0001");
                bundle.Identifier.Period = new Period(new FhirDateTime("2021-11-01"), new FhirDateTime("2099-12-31"));
                bundle.Timestamp = FhirDateTime.Now().ToDateTimeOffset(TimeSpan.FromHours(8));
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = newComposition, FullUrl = newComposition.ResourceBase + "Composition/" + newComposition.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = org, FullUrl = org.ResourceBase + "Organization/" + org.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = pat , FullUrl = pat.ResourceBase + "Patient/" + pat.Id });
                bundle.Entry.Add(new Bundle.EntryComponent { Resource = immu, FullUrl = immu.ResourceBase + "Immunization/" + immuId });
                var document =  _ctrlImmu.GetClient().Create(bundle);


                MsgBoxHelper.Info("建立完成");

            });
        }
        
        

    }
}
