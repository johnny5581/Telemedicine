using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class MedicationAdministrationController : ControllerBase<MedicationAdministration>
    {
        public MedicationAdministrationController() : base()
        {
        }
        public MedicationAdministrationController(IInteractive interactive) : base(interactive)
        {
        }
    }
}
