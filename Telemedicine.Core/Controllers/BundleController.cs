using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public class BundleController : Controller<Bundle>
    {
        public BundleController()
        {
        }

        public BundleController(IInteractive interactive) : base(interactive)
        {
        }
    }
}
