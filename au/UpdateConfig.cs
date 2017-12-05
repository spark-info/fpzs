using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au
{
    class UpdateConfig
    {
        public const string KEY_LOCAL_APP_DIRECTORY = "LOCAL_APP_DIRECTORY";
        public const string KEY_LOCAL_UPDATE_DIRECTORY = "LOCAL_UPDATE_DIRECTORY";
        public const string KEY_SERVER_UPDATE_URL = "SERVER_UPDATE_URL";
        public const string VERSION_FILE_NAME = "version.txt";

        private string m_LocalAppDirectory;
        public string LocalAppDirectory 
        {
            get
            {
                return m_LocalAppDirectory;
            } 
            set
            {
                m_LocalAppDirectory = AppendSlash(value);
            }
        }
        private string m_LocalUpdateDirectory;
        public string LocalUpdateDirectory 
        { 
            get
            {
                return m_LocalUpdateDirectory;
            }
            set
            {
                m_LocalUpdateDirectory = AppendSlash(value);
            }
        }
        private string m_ServerUpdateUrl;
        public string ServerUpdateUrl
        {
            get
            {
                return m_ServerUpdateUrl;
            }
            set
            {
                m_ServerUpdateUrl = AppendSlash(value);
            }
        }
        private string AppendSlash(string path)
        {
            if (!string.Equals("\\", path.Substring(path.Length - 1, 1)))
            {
                path += "\\";
            }
            return path;
        }
    }
}
