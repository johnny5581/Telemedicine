using Hl7.Fhir.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Telemedicine.Controllers;
using Telemedicine.Forms;
using Telemedicine.Orgs;
using Telemedicine.Patients;
using Telemedicine.Practitioners;

namespace Telemedicine.Bundles
{
    [DomainControl(typeof(Composition))]
    public partial class CompositionListForm : ListForm
    {
        public CompositionListForm()
        {
            InitializeComponent();
        }
        public Controller<Composition> Controller { get; set; }

        protected override void SetupDataGridPanel(CgDataGridPanel dgvData)
        {
            base.SetupDataGridPanel(dgvData);
            dgvData.AutoGenerateColumns = true;
        }

        protected override Tuple<Type, IEnumerable> GetSearchResult(List<string> criterias)
        {
            var resList = GetSearchDomainResult(criterias).OfType<Composition>();
            var resCache = new Dictionary<string, object>();
            var list = resList.Select(r => new ViewModel(r, resCache)).ToList();
            return Tuple.Create<Type, IEnumerable>(typeof(ViewModel), list);
        }

        protected override IEnumerable GetSearchDomainResult(List<string> criterias)
        {
            AddCriteria(criterias, "date", cgLabelDateTimeRange1);
            AddCriteria(criterias, "patient", textPat.Text);
            AddCriteria(criterias, "patient.identifier", textPatIdentifier.Text);
            AddCriteria(criterias, "entry", textOrg.Text, r => "Organization/" + r);

            return Controller.Search(criterias);
        }

        public static void SectionFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var sections = e.Value as List<Composition.SectionComponent>;
            var section = sections.ElementAtOrDefault(0);
            if (section != null)
            {
                var target = e.Arguments.ElementAtOrDefault(0) as string;
                var entry = section.Entry.FirstOrDefault(r => r.Reference.StartsWith(target));
                if (entry != null)
                {
                    switch (target)
                    {
                        case "Organization":
                            var org = ControllerBase.Get<Organization>().Get(entry.Reference);
                            e.Value = $"{org.Name}({DomainControl.GetIdentifier(org.Identifier, OrgControl.OrgSystemId)})";

                            break;
                    }
                }
            }
        }
        public static void AuthorFormatter(object sender, CgDataGridPanel.FormattingCellEventArgs e)
        {
            var resRefs = e.Value as List<ResourceReference>;
            var resRef = resRefs.ElementAtOrDefault(0);
            if (resRef != null)
            {
                var prac = ControllerBase.Get<Practitioner>().Get(resRef.Reference);
                e.Value = DomainControl.GetHumanName(prac.Name);
            }
        }


        public class ViewModel : DataModelBase<Composition>
        {
            public ViewModel(Composition data, Dictionary<string, object> res) : base(data)
            {
                var pat = res.GetOrCreate(data.Subject.Reference ?? "", r => ControllerBase.Get<Patient>().TryRead(r)) as Patient;
                var org = res.GetOrCreate(data.Section?.ElementAtOrDefault(0)?.Entry?.FirstOrDefault(r=>r.Reference.StartsWith("Organization"))?.Reference ?? "", r => ControllerBase.Get<Organization>().TryRead(r)) as Organization;
                var prac = res.GetOrCreate(data.Author?.FirstOrDefault()?.Reference ?? "", r => ControllerBase.Get<Practitioner>().TryRead(r)) as Practitioner;

                Status = Convert.ToString(data.Status);
                if (org != null)
                {
                    OrgId = org.Id;
                    OrgName = org.Name;
                    OrgIdentifier = DomainControl.GetIdentifier(org.Identifier, OrgControl.OrgSystemId);
                }
                if (pat != null)
                {
                    PatId = pat.Id;
                    PatName = DomainControl.GetHumanName(pat.Name);
                    PatChtNo = DomainControl.GetIdentifier(pat.Identifier, PatientControl.SystemIdNo);
                    PatIdNo = DomainControl.GetIdentifier(pat.Identifier, PatientControl.SystemChtNo);
                    PatSex = Convert.ToString(pat.Gender);
                    PatBrithDat = pat.BirthDate;
                }
                if (prac != null)
                {
                    PracId = prac.Id;
                    PracName = DomainControl.GetHumanName(prac.Name);
                }
            }

            public string Id { get; set; }
            public string Status { get; set; }
            public string Date { get; set; }
            public string Title { get; set; }
            public string OrgId { get; set; }
            public string OrgName { get; set; }
            public string OrgIdentifier { get; set; }
            public string PatId { get; set; }
            public string PatName { get; set; }
            public string PatSex { get; set; }
            public string PatBrithDat { get; set; }
            public string PatIdNo { get; set; }
            public string PatChtNo { get; set; }

            public string PracId { get; set; }
            public string PracName { get; set; }


        }
    }
}

