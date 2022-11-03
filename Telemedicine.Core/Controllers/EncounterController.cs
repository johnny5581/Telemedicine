using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class EncounterController : Controller<Encounter>
    {
        public EncounterController()
        {
        }

        public EncounterController(IInteractive interactive) : base(interactive)
        {
        }
    }
}
