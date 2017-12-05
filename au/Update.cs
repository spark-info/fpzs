using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace au
{
    class Updater
    {
        
        public UpdateConfig GetUpdateConfig(string appDir)
        {
            UpdateConfig config = new UpdateConfig();
            config.LocalAppDirectory = appDir + ConfigurationManager.AppSettings[UpdateConfig.KEY_LOCAL_APP_DIRECTORY].ToString();
            config.LocalUpdateDirectory = appDir + ConfigurationManager.AppSettings[UpdateConfig.KEY_LOCAL_UPDATE_DIRECTORY].ToString();
            config.ServerUpdateUrl = ConfigurationManager.AppSettings[UpdateConfig.KEY_SERVER_UPDATE_URL].ToString();
            return config;
        }

        public List<FileVersion> ReadServerVersion(string serverUrl)
        {
            string verionFileUrl = serverUrl + UpdateConfig.VERSION_FILE_NAME;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(verionFileUrl);
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.UTF8);
            string json = sr.ReadToEnd();
            sr.Close();
            resStream.Close();

            return parseFileVersionListFromJson(json);
        }

        public List<FileVersion> ReadLocalVersion(string localUpdateDir)
        {
            string versionFilePath = localUpdateDir + UpdateConfig.VERSION_FILE_NAME;
            if (!File.Exists(versionFilePath))
            {
                return new List<FileVersion>();
            }
            string json = File.ReadAllText(versionFilePath,Encoding.UTF8);
            return parseFileVersionListFromJson(json);
        }

        public List<FileVersion> CompareFileVersionList(List<FileVersion> serverList, List<FileVersion> localList)
        {
            List<FileVersion> list = new List<FileVersion>();
            foreach (FileVersion svrFv in serverList)
            {
                bool needUpdate = true;
                foreach (FileVersion locFv in localList)
                {
                    if (svrFv.MajorVersion < locFv.MajorVersion)
                    {
                        needUpdate = false;
                    }
                    else if(svrFv.MajorVersion ==locFv.MajorVersion)
                    {
                        if(svrFv.MinorVersion < locFv.MinorVersion)
                        {
                            needUpdate = false;
                        }
                        else if(svrFv.MinorVersion == locFv.MinorVersion)
                        {
                            if (svrFv.BuildVersion <= locFv.BuildVersion)
                            {
                                needUpdate = false;
                            }
                        }
                    }
                }

                if (needUpdate)
                {
                    list.Add(svrFv);
                }
            }
            return list;
        }

        public void DownloadUpdateList(string serverUrl, string localUpdateDir, List<FileVersion> updateList)
        {
            if(!Directory.Exists(localUpdateDir))
            {
                Directory.CreateDirectory(localUpdateDir);
            }
            foreach (FileVersion fv in updateList)
            {
                HttpWebResponse response;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(serverUrl+fv.Name);
                response = (HttpWebResponse)request.GetResponse();
                Stream sm = response.GetResponseStream();
                FileStream fs = new FileStream(localUpdateDir + fv.Name, FileMode.Create);
                byte[] buffer = new byte[1024];
                int size = sm.Read(buffer,0,buffer.Length);
                while(size>0)
                {
                    fs.Write(buffer, 0, size);
                    size = sm.Read(buffer, 0, buffer.Length);
                }
                fs.Close();
                sm.Close();
            }
        }

        public void CopyFile(string localUpdateDir, string localAppDir,List<FileVersion> list)
        {
            foreach (FileVersion fv in list)
            {
                string src = localUpdateDir + fv.Name;
                string dest = localAppDir + fv.Name;
                if(File.Exists(src))
                {
                    File.Copy(src, dest, true);
                    updateLocalVersion(localUpdateDir, fv);
                }
                else
                {
                    return;
                }
            }
            return;
        }

        private List<FileVersion> parseFileVersionListFromJson(string json)
        {
            Stream mStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(List<FileVersion>));
            List<FileVersion> list = (List<FileVersion>)deserializer.ReadObject(mStream);
            mStream.Close();
            return list;
        }

        private bool updateLocalVersion(string localUpdateDir, FileVersion updateFv)
        {
            List<FileVersion> list = ReadLocalVersion(localUpdateDir);
            bool found = false;
            foreach(FileVersion fv in list){
                if(string.Equals(fv.Name,updateFv.Name)){
                    fv.Version = updateFv.Version;
                    found = true;
                }
            }
            if (!found)
            {
                list.Add(updateFv);
            }

            FileStream fs = new FileStream(localUpdateDir + "version.txt", FileMode.Create, FileAccess.Write);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<FileVersion>));
            serializer.WriteObject(fs, list);
            fs.Flush();
            fs.Close();
            return true;
        }

    }
}
