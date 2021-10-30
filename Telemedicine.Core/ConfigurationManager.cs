using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemedicine.Logging;

namespace Telemedicine
{
    public class ConfigurationManager
    {
        private static readonly ILogger logger
            = Logger.CreateInstance("ConfigurationManager");
        public static System.Collections.Specialized.NameValueCollection AppSettings
        {
            get { return System.Configuration.ConfigurationManager.AppSettings; }
        }
        public ConfigurationManager(string prefix)
        {
            Prefix = prefix;
        }


        public string Prefix { get; private set; }
        public string Get(string name)
        {
            var key = GetConfigKey(name);
            return GetConfiguration(key);
        }

        private string GetConfigKey(string name)
        {
            if (!string.IsNullOrEmpty(Prefix))
                name = Prefix + ":" + name;
            return name;
        }


        public static string GetConfiguration(string key)
        {
            var value = AppSettings[key];
            logger.Debug("read configuration=" + key + ", value=" + value);
            return value;
        }
    }
}
