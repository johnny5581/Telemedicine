using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class PractitionerController : Controller<Practitioner>
    {
        public PractitionerController()
        {
        }

        public PractitionerController(IInteractive interactive) : base(interactive)
        {
        }
    }
}
