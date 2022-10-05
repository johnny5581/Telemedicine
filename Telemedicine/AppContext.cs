using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telemedicine.Caching;
using Telemedicine.Forms;
using Telemedicine.IoC;
using Telemedicine.Logging;

namespace Telemedicine
{
    public class AppContext : ApplicationContext, IAppRuntime
    {
        protected static readonly ILogger logger
            = Logger.CreateInstance("AppContext");
        private static readonly string SystemPrefix = "Telemedicine";
        private readonly Dictionary<string, string> _environments
            = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, object> _objects
            = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        private readonly Caching.Providers.AppCacheProvider _appCache
            = new Caching.Providers.AppCacheProvider();
        private IServiceLocator _serviceLocator;
        private readonly string[] _arguments;

        public AppContext(string[] args)
        {
            _arguments = args;
            AppRuntime.Current = this;
            //_serviceLocator = new IoC.Locators.LightInjectServiceLocator(ResManager.GetResourceBytes(typeof(AppContext), "LightInject.dll"));
        }

        #region 屬性
        public string this[string key]
        {
            get { return GetEnvironment(key); }
            set { SetEnvironment(key, value); }
        }
        public ICacheProvider AppCache
        {
            get { return _appCache; }
        }
        public IServiceLocator ServiceLocator
        {
            get { return _serviceLocator ?? IoC.ServiceLocator.Current; }
            set
            {
                if (_serviceLocator != null)
                    throw new InvalidOperationException("duplicate setting service locator");
                _serviceLocator = value;
            }
        }

#if DEBUG
        public virtual string DebugDept
        {
            get { return ""; }
        }
        public virtual string DebugUser
        {
            get { return ""; }
        }
#endif
        public event ValueChangedEventHandler EnvironmentValueChanged;


        public bool Contains(string key)
        {
            return _environments.ContainsKey(key);
        }

        public object GetData(string key)
        {
            return _objects.TryGetValue(key);
        }

        public void SetData(string key, object data)
        {
            _objects.SetOrCreate(key, data);
        }
        public string GetEnvironment(string name)
        {
            return _environments.TryGetValue(name);
        }
        public void SetEnvironment(string name, string value, bool raiseEvent = true)
        {
            var oldValue = _environments.TryGetValue(name);
            _environments.SetOrCreate(name, value);
            logger.Debug("set environment '" + name + "' from '" + oldValue + "' to '" + value + "'");
            if (raiseEvent)
                OnEnvironmentValueChanged(new ValueChangedEventArgs(name, oldValue, value));
        }
        #endregion

        public bool TryLoadSplashScreen(out Exception lastError)
        {
            lastError = null;
            if (!LoadingSplashScreen())
            {
                lastError = new OperationCanceledException("user canceled");
                return false;
            }

            var splash = new SplashDialog()
            {
                Message = "歡迎使用" + ConfigurationManager.GetConfiguration("sys:app.name"),
            };


            var splashForm = new CgSplashForm();
            splashForm.Size = new Size(480, 320);
            splashForm.SetBackground(GetSplashBackgroundImage(), ImageLayout.Stretch);
            var collection = splash.SplashActionItems;
            SetupSplashActions(collection);
            var cache = new SplashDialog.SplashActionCache();
            cache.Add("args", _arguments);
            var result = splash.ShowDialog(splashForm, this, cache);
            switch (result)
            {
                case DialogResult.Yes:
                    if (MainForm == null)
                    {
                        var mainView = GetMainView();
                        var mainForm = mainView as Form;
                        if (mainForm == null)
                            throw new InvalidOperationException("missing main form");
                        SetData("MainView", mainView);
                        MainForm = mainForm;
                    }

                    logger.Debug("==== env variables ====");
                    foreach (var kv in _environments)
                        logger.Debug(kv.Key + "=" + kv.Value);
                    logger.Debug("=======================");

                    return true;
                case DialogResult.No:
                    return false;
                case DialogResult.Cancel:
                case DialogResult.Abort:
                    if (splash.LastError is SplashDialog.SplashException)
                    {
                        var ex = splash.LastError as SplashDialog.SplashException;
                        var message = ex.Text + "失敗";
                        if (ex.InnerException != null)
                            message += ": " + ex.InnerException.Message;
                        lastError = new Exception(message);
                    }
                    else
                        lastError = splash.LastError;
                    return false;
                default:
                    throw new Exception("unhandler result: " + result);
            }
        }
        #region Private / Protected Methods
        protected virtual bool LoadingSplashScreen()
        {
            return true;
        }
        protected virtual void SetupSplashActions(SplashDialog.SplashActionItemCollection collection)
        {
            //TODO 塞入一些動畫看起來很帥，毫無用處的垃圾功能
            collection.Append(new SplashDialog.SplashActionItem("Init", "初始化系統", (dialog, cache) => { System.Threading.Thread.Sleep(2000); }));
            collection.Append(new SplashDialog.SplashActionItem("SetupMonitor", "設定監控視窗", (dialog, cache) =>
            {
                var d = GetData("Monitor") as TransactionMonitorDialog;
                if (d == null)
                {
                    d = new TransactionMonitorDialog();
                    SetData("Monitor", d);
                }
                HttpClientRequester.Transacted += (req, reqBody, resp, respBody) =>
                {
                    Application.DoEvents();
                    d.Clear();
                    Application.DoEvents();
                    d.SetRequest(req, reqBody);
                    Application.DoEvents();
                    if (resp != null)
                        d.SetResponse(resp, respBody);
                    Application.DoEvents();
                };
            }));
        }



        protected virtual Image GetSplashBackgroundImage()
        {
            return FmResManager.GetResourceImage("splash.jpg");
        }


        protected virtual Form GetMainView()
        {
            return new MainForm();
        }
        protected virtual void OnEnvironmentValueChanged(ValueChangedEventArgs e)
        {
            var handler = EnvironmentValueChanged;
            if (handler != null)
                handler(this, e);
        }
        #endregion


        public static AppContext GetContext(string[] args)
        {
            
            // 使用預設的環境
            return new AppContext(args);
        }

        public static bool TryGetContextType(Assembly assembly, string runtimeId, out Type contextType)
        {
            var ctxTypeName = typeof(AppContext).Namespace + "." + runtimeId + ".AppContext";
            logger.Debug("searching ctx=" + ctxTypeName);
            contextType = assembly.GetType(ctxTypeName, false);
            if (contextType == null)
            {
                ctxTypeName = typeof(AppContext).Namespace + ".AppContext_" + runtimeId;
                logger.Debug("searching ctx=" + ctxTypeName);
                contextType = assembly.GetType(ctxTypeName, false);
            }
            return contextType != null;
        }

        public static AppContext LoadEnvironmentLibFile(string file, string id, string[] args)
        {
            var assembly = Assembly.LoadFile(Path.GetFullPath(file));
            logger.Information("use runtime: " + id);
            Type ctxType;
            if (!TryGetContextType(assembly, id, out ctxType))
                throw new InvalidOperationException("no appContext class found in '" + file + "'");
            logger.Information("use class: " + ctxType.FullName);
            return (AppContext)Activator.CreateInstance(ctxType, new object[] { args });
        }
    }
}
