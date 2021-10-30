using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;

namespace Telemedicine
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var client = new FhirClient("https://hapi.fhir.tw/fhir/");
            //var result = client.Search<Patient>(new string[] { "identifier=500"});
            var res2 = client.Read<Patient>("Patient/102508");
            Console.WriteLine("Hello World!");
        }
    }
}
