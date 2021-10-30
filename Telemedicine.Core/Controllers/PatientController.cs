using System;
namespace Telemedicine.Controllers
{
    /// <summary>
    /// 病患控制項
    /// </summary>
    public class PatientController : ControllerBase
    {
        public void NewPatient(NewPatientRequest request)
        {
            
        }



        public class NewPatientRequest
        {
            public string Id { get; set; }
            public string ChtNo { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }   
        }
    }
}
