using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace fpzs.util
{
    class VisualProperty
    {
        public string Name { get; set; }
        public string ChineseName { get; set; }
        public object Value { get; set; }

        public static List<VisualProperty> GetChineseName(Type t)
        {
            List<VisualProperty> list = new List<VisualProperty>();
            PropertyInfo[] propertyInfo = t.GetProperties();

            foreach (PropertyInfo property in propertyInfo)
            {
                Attribute[] attrs = Attribute.GetCustomAttributes(property);
                foreach (Attribute attr in attrs)
                {
                    if (attr is ChineseNameAttribute)
                    {
                        ChineseNameAttribute descAttr = (ChineseNameAttribute)attr;
                        VisualProperty vp = new VisualProperty();
                        vp.Name = property.Name;
                        vp.ChineseName = descAttr.ChineseName;
                        list.Add(vp);
                    }
                }
            }

            return list;
        }

        public static List<VisualProperty> GetValueWithChineseName(object instance)
        {
            List<VisualProperty> list = new List<VisualProperty>();
            PropertyInfo[] info = instance.GetType().GetProperties();
            foreach (PropertyInfo property in info)
            {
                Attribute[] attrs = Attribute.GetCustomAttributes(property);
                foreach (Attribute attr in attrs)
                {
                    if (attr is ChineseNameAttribute)
                    {
                        VisualProperty vp = new VisualProperty();
                        vp.Name = property.Name;
                        vp.Value = property.GetValue(instance, null);
                        list.Add(vp);
                    }
                }
            }
            return list;
        }
    }
}
