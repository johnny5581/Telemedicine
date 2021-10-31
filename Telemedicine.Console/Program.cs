using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using Telemedicine.Controllers;

namespace Telemedicine
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var controller = new PatientController();
            var pat = controller.Search("500");
            Console.WriteLine("Hello World!");
        }
    }
}
