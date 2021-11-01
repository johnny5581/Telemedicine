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
        public Patient SearchByIdentifierSingle(string id)
        {
            var pats = SearchByIdentifier(id);
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
        public IList<Patient> SearchByIdentifier(string id)
        {
            return Search(new KeyValuePair<string, string>("identifier", id));
        }
        public IList<Patient> Search(params KeyValuePair<string, string>[] searchParams)
        {
            var criteria = searchParams.Select(r => string.Format("{0}={1}", r.Key, r.Value)).ToArray();
            return Search(criteria);
        }
        public IList<Patient> Search(IEnumerable<KeyValuePair<string, string>> searchParams)
        {
            var criteria = searchParams.Select(r => string.Format("{0}={1}", r.Key, r.Value)).ToArray();
            return Search(criteria);
        }
        public IList<Patient> Search(IEnumerable<string> criteria)
        {
            return Search(criteria.ToArray());
        }
        public IList<Patient> Search(params string[] criteria)
        {
            var bundle = ExecuteClient(client => client.Search<Patient>(criteria));
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
            return GetName(names[0]);
        }
        /// <summary>
        /// 取得名稱
        /// </summary>        
        public static string GetName(HumanName name)
        {
            if (name == null)
                return null;
            var n = name.Text;
            if (n == null)
                n = name.Family + name.Given.ElementAtOrDefault(0);
            return n;
        }

        public static string GetIdentifier(Patient pat)
        {
            if (pat == null)
                return null;
            return GetIdentifier(pat.Identifier);
        }

        public static string GetIdentifier(List<Identifier> identifiers)
        {
            if (identifiers == null || identifiers.Count == 0)
                return null;
            return identifiers[0].Value;
        }

        public static string GetTelecom(Patient pat)
        {
            if (pat == null)
                return null;
            return GetTelecom(pat.Telecom);
        }
        public static string GetTelecom(List<ContactPoint> contactPoints)
        {
            if (contactPoints == null || contactPoints.Count == 0)
                return null;
            return contactPoints[0].Value;
        }
    }
}
