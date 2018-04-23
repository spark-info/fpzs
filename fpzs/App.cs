using fpzs.bl;
using fpzs.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fpzs
{
    sealed class App
    {
        public static readonly App Instance = new App();

        public const string KEY_CERT_PASSWORD = "CERT_PASSWORD";
        public const string KEY_DB_PATH = "DB_PATH";
        public const string KEY_DB_PASSWORD = "DB_PASSWORD";

        public const string DB_NAME_DEFAULT = "fpzs.db";
        public const string DB_PASSWORD_DEFAULT = "";

        private Configuration config;
        private SqliteHelper sqliteHelper;
        private App(){}

        public void Initialize()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string dbPath = GetConfigValue(App.KEY_DB_PATH);
            if(string.IsNullOrEmpty(dbPath))
            {
                dbPath = Application.StartupPath + "\\" + DB_NAME_DEFAULT;
            }

            string dbPassword = GetConfigValue(App.KEY_DB_PASSWORD);
            if(string.IsNullOrEmpty(dbPassword))
            {
                dbPassword = DB_PASSWORD_DEFAULT;
            }
            sqliteHelper = new SqliteHelper(dbPath, dbPassword);
        }

        public SqliteHelper GetSqliteHelper()
        {
            return sqliteHelper;
        }
        public string GetConfigValue(string keyName)
        {
            AppSettingsSection section = config.AppSettings;
            if (section == null)
                return "";
            KeyValueConfigurationElement element = section.Settings[keyName];
            if (element == null)
                return "";
            return element.Value == null ? "" : element.Value;
        }

        public void SetConfigValue(string keyName, string keyValue)
        {
            if (!AppSettingsKeyExists(keyName))
            {
                config.AppSettings.Settings.Add(keyName, "");
            }
            config.AppSettings.Settings[keyName].Value = keyValue;
            config.Save(ConfigurationSaveMode.Modified);
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
