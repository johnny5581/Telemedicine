using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public FhirClient GetClient()
        {
            var endpoint = ConfigurationManager.GetConfiguration("server.endpoint");
            if (endpoint.IsNullOrEmpty())
                throw new NullReferenceException("endpoint can not be null");
            var setting = new FhirClientSettings
            {
                PreferredFormat = ResourceFormat.Json,
            };
            HttpClientRequester.Token = ConfigurationManager.GetConfiguration("server.token");
            return new FhirClient(endpoint, setting);
        }


        public T ExecuteClient<T>(Func<FhirClient, T> action)
        {
            var client = GetClient();
            return action(client);
        }
        public void ExecuteClient(Action<FhirClient> action)
        {
            var client = GetClient();
            action(client);
        }
        protected bool TryExecuteClient(Action<FhirClient> action)
        {
            Exception exception;
            return TryExecuteClient(action, out exception);
        }
        protected bool TryExecuteClient(Action<FhirClient> action, out Exception exception)
        {
            try
            {
                ExecuteClient(action);
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
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

        public Bundle CreateBundle(Bundle bundle)
        {
            return ExecuteClient(client => client.Create(bundle));
        }
    }
    public abstract class ControllerBase<T> : ControllerBase
        where T : Resource, new()
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

        public void Delete(T model)
        {
            ExecuteClient(client =>
            {
                client.Delete(model);
            });
        }

        public bool TryDelete(T model)
        {
            return TryExecuteClient(client => client.Delete(model));
        }
        public bool TryDelete(T model, out Exception exception)
        {
            return TryExecuteClient(client => client.Delete(model), out exception);
        }

        public IList<T> Search(params KeyValuePair<string, string>[] searchParams)
        {
            var criteria = searchParams.Select(r => string.Format("{0}={1}", r.Key, r.Value)).ToArray();
            return Search(criteria);
        }
        public IList<T> Search(IEnumerable<KeyValuePair<string, string>> searchParams)
        {
            var criteria = searchParams.Select(r => string.Format("{0}={1}", r.Key, r.Value)).ToArray();
            return Search(criteria);
        }
        public IList<T> Search(IEnumerable<string> criteria)
        {
            return Search(criteria.ToArray());
        }
        public IList<T> SearchPost(IEnumerable<string> criteria)
        {
            return SearchPost(criteria.ToArray());
        }
        public IList<T> Search(bool throwOnNoCriteria, params string[] criteria)
        {
            if (criteria.Length == 0 && throwOnNoCriteria)
                throw new InvalidOperationException("no search criteria");
            //criteria = criteria.Concat(new string[] { "_count=100" }).ToArray();
            var bundle = ExecuteClient(client => client.Search<T>(criteria, pageSize: 100));
            var list = new List<T>();
            if (bundle.Entry.Count > 0)
            {
                foreach (var entry in bundle.Entry)
                {
                    var item = (T)entry.Resource;
                    list.Add(item);
                }
            }
            return list;
        }
        public IList<T> SearchPost(bool throwOnNoCriteria, params string[] criteria)
        {
            if (criteria.Length == 0 && throwOnNoCriteria)
                throw new InvalidOperationException("no search criteria");
            //criteria = criteria.Concat(new string[] { "_count=100" }).ToArray();
            var bundle = ExecuteClient(client => client.SearchUsingPost<T>(criteria, pageSize: 100));
            var list = new List<T>();
            if (bundle.Entry.Count > 0)
            {
                foreach (var entry in bundle.Entry)
                {
                    var item = (T)entry.Resource;
                    list.Add(item);
                }
            }
            return list;
        }
        public IList<T> Search(params string[] criteria)
        {
            return Search(true, criteria);
        }
        public IList<T> SearchPost(params string[] criteria)
        {
            return SearchPost(true, criteria);
        }
        public IList<T> SearchAll()
        {
            return Search(false);
        }
        public IList<T> SearchPostAll()
        {
            return Search(false);
        }
    }
}
