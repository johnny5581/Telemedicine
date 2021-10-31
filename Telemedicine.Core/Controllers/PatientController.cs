using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class PatientController : ControllerBase<Patient>
    {
        public PatientController() : base()
        {
        }
        public PatientController(IInteractive interactive) : base(interactive)
        {
        }

        /// <summary>
        /// 查詢單一使用者
        /// </summary>
        public Patient SearchSingle(string id)
        {
            var pats = Search(id);
            Patient pat = null;
            if (pats.Count > 1)
                pat = Interactive(ia => ia.SingleSelection(pats, r => GetName(r)));
            else if (pats.Count == 1)
                pat = pats[0];
            return pat;
        }

        /// <summary>
        /// 查詢多個使用者
        /// </summary>        
        public IList<Patient> Search(string id)
        {
            var bundle = GetClient().Search<Patient>(new string[] { "identifier=" + id });
            var list = new List<Patient>();
            if (bundle.Entry.Count > 0)
            {
                foreach (var entry in bundle.Entry)
                {
                    var pat = (Patient)entry.Resource;
                    list.Add(pat);
                }
            }
            return list;
        }
        /// <summary>
        /// 取得名稱
        /// </summary>        
        public static string GetName(Patient pat)
        {
            if (pat == null)
                return null;
            return GetName(pat.Name);
        }
        /// <summary>
        /// 取得名稱
        /// </summary>        
        public static string GetName(List<HumanName> names)
        {
            if (names == null || names.Count == 0)
                return null;
            var n = names[0].Text;
            if (n == null)
                n = names[0].Family + names[0].Given.ElementAtOrDefault(0);
            return n;
        }
    }
}
