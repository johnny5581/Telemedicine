using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;

namespace Telemedicine.Controllers
{
    /// <summary>
    /// 基礎Controller
    /// </summary>
    public abstract class ControllerBase
    {


    }

    /// <summary>
    /// 帶類別CRUD的Controller
    /// </summary>
    public abstract class ControllerBase<T> : ControllerBase where T : Resource
    {
        private static readonly FhirClient _Client;
        protected FhirClient GetClient()
        {
            if(_Client == null)
            {

            }
            return _Client;
        }
    }




}
