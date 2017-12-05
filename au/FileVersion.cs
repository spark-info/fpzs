using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace au
{
    [DataContract]
    class FileVersion
    {
        [DataMember]
        public string Name{get; set;}
        [DataMember]
        public string Version { get; set; }

        public int MajorVersion
        {
            get
            {
                int startIndex = 0;
                int length = Version.IndexOf(".");
                return Convert.ToInt32(Version.Substring(startIndex,length));
            }
        }

        public int MinorVersion
        {
            get
            {
                int startIndex = Version.IndexOf(".") + 1;
                int length = Version.LastIndexOf(".") - startIndex;
                return Convert.ToInt32(Version.Substring(startIndex, length));
            }
        }

        public int BuildVersion
        {
            get
            {
                int startIndex = Version.LastIndexOf(".") + 1;
                int length = Version.Length - startIndex;
                return Convert.ToInt32(Version.Substring(startIndex, length));
            }
        }
    }
}
