using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class ObservationController : ControllerBase<Observation>
    {
        public ObservationController() : base()
        {
        }
        public ObservationController(IInteractive interactive) : base(interactive)
        {
        }

        public List<Observation> SearchByPatient(string id, string code = null)
        {
            var searchParams = new List<string> { "subject=" + id };
            if (code.IsNotNullOrEmpty())
                searchParams.Add("code=" + code);
            var bundle = ExecuteClient(client => client.Search<Observation>(searchParams.ToArray()));
            var list = new List<Observation>();
            if (bundle.Entry.Count > 0)
            {
                foreach (var entry in bundle.Entry)
                {
                    var obs = (Observation)entry.Resource;
                    list.Add(obs);
                }
            }
            return list;
        }
    }
}
