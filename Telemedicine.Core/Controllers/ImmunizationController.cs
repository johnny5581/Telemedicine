using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class ImmunizationController : Controller<Immunization>
    {
        public ImmunizationController()
        {
        }

        public ImmunizationController(IInteractive interactive) : base(interactive)
        {
        }
    }
}
