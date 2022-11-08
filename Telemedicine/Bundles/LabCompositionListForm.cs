using Hl7.Fhir.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemedicine.Controllers;

namespace Telemedicine.Bundles
{
    public class LabCompositionListForm : CompositionListForm
    {
        public LabCompositionListForm()
        {
            PredefinedCriterias.Add("title=檢驗報告");
        }
        protected override Tuple<Type, IEnumerable> GetSearchResult(List<string> criterias)
        {
            var resList = GetSearchDomainResult(criterias).OfType<Composition>();
            var resCache = new Dictionary<string, object>();
            var list = resList.Select(r => new ViewModelEx(r, resCache)).ToList();
            return Tuple.Create<Type, IEnumerable>(typeof(ViewModelEx), list);
        }

        public class ViewModelEx : ViewModel
        {
            public ViewModelEx(Composition data, Dictionary<string, object> res) : base(data, res)
            {
                var enc = res.GetOrCreate(data.Section?.FirstOrDefault()?.Entry?.FirstOrDefault(r => r.Reference.StartsWith(typeof(Encounter).Name))?.Reference ?? "", r => ControllerBase.Get<Encounter>().TryRead(r)) as Encounter;
                var obs = res.GetOrCreate(data.Section?.FirstOrDefault()?.Entry?.FirstOrDefault(r => r.Reference.StartsWith(typeof(Observation).Name))?.Reference ?? "", r => ControllerBase.Get<Observation>().TryRead(r)) as Observation;

                if (enc != null)
                {
                    EncId = enc.Id;
                    EncStatus = Convert.ToString(enc.Status);
                    EncClass = enc.Class?.Code;
                }

                if (obs != null)
                {
                    ObsId = obs.Id;
                    ObsStatus = Convert.ToString(obs.Status);
                    LabId = obs.Identifier?.FirstOrDefault()?.Value;
                    LabSrc = DomainControl.GetCodeableConcept(obs.BodySite);
                    LabCat = DomainControl.GetCodeableConcept(obs.Category.FirstOrDefault());
                    var period = obs.Effective as Period;
                    if (period != null)
                    {
                        LabDat = period.Start;
                        RcvDat = period.End;
                    }
                    if (obs.Issued != null)
                        RptDat = obs.Issued.Value.ToString("yyyy-MM-dd");
                    var q = obs.Value as Quantity;
                    if (q != null)
                        LabValue = DomainControl.GetQuantity(q);
                }
            }
            public string EncId { get; set; }
            public string EncStatus { get; set; }
            public string EncClass { get; set; }
            public string ObsId { get; set; }
            public string ObsStatus { get; set; }
            public string LabId { get; set; }
            public string LabSrc { get; set; }
            public string LabCat { get; set; }
            public string LabDat { get; set; }
            public string RcvDat { get; set; }
            public string RptDat { get; set; }
            public string LabValue { get; set; }
        }
    }
}
