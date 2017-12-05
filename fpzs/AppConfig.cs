using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace fpzs
{
    sealed class AppConfig
    {
        public static readonly AppConfig Instance = new AppConfig();

        private const string KEY_CERT_PASSWORD = "CERT_PASSWORD";

        private Configuration config;
        private AppConfig()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        
        public string CertPassword
        {
            get
            {
                return config.AppSettings.Settings[KEY_CERT_PASSWORD].Value;
            }
            set
            {
                if (!AppSettingsKeyExists(KEY_CERT_PASSWORD))
                {
                    config.AppSettings.Settings.Add(KEY_CERT_PASSWORD, "");
                }
                config.AppSettings.Settings[KEY_CERT_PASSWORD].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private bool AppSettingsKeyExists(string key)
        {
            bool exists = false;
            foreach (string k in config.AppSettings.Settings.AllKeys)
            {
                if (string.Equals(key, k))
                {
                    exists = true;
                }
            }
            return exists;
        }
    }
}
