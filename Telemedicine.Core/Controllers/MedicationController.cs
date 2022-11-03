using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class MedicationController : Controller<Medication>
    {
        public MedicationController() : base()
        {
        }
        public MedicationController(IInteractive interactive) : base(interactive)
        {
        }

        public IList<Medication> SearchByActive()
        {
            return Search("status=active");
        }
    }
}
