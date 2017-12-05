using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace fpzslib
{
    public class Utility
    {
        public static string GetEnumDescription(Enum obj)
        {
            FieldInfo fi = obj.GetType().GetField(obj.ToString());
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if(arrDesc.Length>0)
            {
                return arrDesc[0].Description;
            }
            else
            {
                return "";
            }
        }
    }
}
