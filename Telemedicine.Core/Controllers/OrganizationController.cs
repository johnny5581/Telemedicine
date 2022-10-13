using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class OrganizationController : ControllerBase<Organization>
    {
        public OrganizationController()
        {
        }

        public OrganizationController(IInteractive interactive) : base(interactive)
        {
        }
    }
}
