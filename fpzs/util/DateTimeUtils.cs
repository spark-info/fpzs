using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace fpzs.util
{
    class DateTimeUtils
    {
        public static DateTime ConvertToDateTime(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return DateTime.MinValue;
            }
            else
            {
                DateTime dt = DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                return dt;
            }
        }
    }
}
