using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Controllers
{
    public abstract class ControllerBase
    {
        protected FhirClient GetClient()
        {
            var endpoint = ConfigurationManager.GetConfiguration("server.endpoint");
            if (endpoint.IsNullOrEmpty())
                throw new NullReferenceException("endpoint can not be null");
            return new FhirClient(endpoint);
        }

        protected T ExecuteClient<T>(Func<FhirClient, T> action)
        {
            var client = GetClient();
            return action(client);
        }
        protected bool TryExecuteClient<T>(Func<FhirClient, T> action, out T value)
        {
            Exception exception;
            return TryExecuteClient(action, out value, out exception);
        }
        protected bool TryExecuteClient<T>(Func<FhirClient, T> action, out T value, out Exception exception)
        {
            try
            {
                value = ExecuteClient(action);
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                value = default(T);
                exception = ex;
                return false;
            }
        }
    }
    public abstract class ControllerBase<T> : ControllerBase
        where T : Resource
    {
        public string Create(T model)
        {
            return ExecuteClient(client =>
            {
                var m = client.Create(model);
                return m.Id;
            });
        }

        public string Update(T model)
        {
            return ExecuteClient(client =>
            {
                var m = client.Update(model);
                return m.Id;
            });
        }
    }
}
