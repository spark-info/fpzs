using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fpzs
{
    [AttributeUsage(AttributeTargets.Property)]
    class ChineseNameAttribute : Attribute
    {
        private string _ChineseName;

        public ChineseNameAttribute(string chineseName)
        {
            this._ChineseName = chineseName;
        }

        public string ChineseName
        {
            get
            {
                return _ChineseName;
            }
        }
    }
}
