using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Meds;
using Telemedicine.Patients;

namespace Telemedicine.Services
{
    [DomainControl(typeof(ServiceRequest))]
    public partial class ServiceRequestControl : DomainControl
    {
        public ServiceRequestControl()
        {
            InitializeComponent();
        }
        
    }
}
