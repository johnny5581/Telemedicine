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
        private readonly IInteractive _interactive;
        private static IInteractive _gInteractive;
        public static IInteractive GlobalInteractive
        {
            get { return _gInteractive; }
            set { _gInteractive = value; }
        }
        public ControllerBase()
        {
        }
        public ControllerBase(IInteractive interactive)
        {
            _interactive = interactive;
        }
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

        protected void Interactive(Action<IInteractive> action)
        {
            var interactive = _interactive ?? _gInteractive;
            if (interactive == null)
                throw new NotSupportedException("no interactive instance");
            action(interactive);
        }
        protected T Interactive<T>(Func<IInteractive, T> action)
        {
            var interactive = _interactive ?? _gInteractive;
            if (interactive == null)
                throw new NotSupportedException("no interactive instance");
            return action(interactive);
        }
    }
    public abstract class ControllerBase<T> : ControllerBase
        where T : Resource
    {

        public ControllerBase() : base()
        {
        }
        public ControllerBase(IInteractive interactive) : base(interactive)
        {

        }
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
