using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace fpzs.bl
{
    public enum InvoiceType
    {
        Special, Common, Electric
    }

    class InvoiceTypeWrapper
    {
        public static int GetValue(InvoiceType type)
        {
            switch (type)
            {
                case InvoiceType.Special:
                    return 0;
                case InvoiceType.Common:
                    return 2;
                case InvoiceType.Electric:
                    return 3;
                default:
                    throw new Exception("未定义的发票种类。");
            }
        }

        public static InvoiceType ValueOf(int value)
        {
            switch (value)
            {
                case 0:
                    return InvoiceType.Special;
                case 2:
                    return InvoiceType.Common;
                case 3:
                    return InvoiceType.Electric;
                default:
                    throw new Exception("发票种类的值错误。" + value);
            }
        }

        public static InvoiceType ValueOf(string value)
        {
            if ("0".Equals(value.Trim()))
                return InvoiceType.Special;
            else if ("2".Equals(value.Trim()))
                return InvoiceType.Common;
            else if ("3".Equals(value.Trim()))
                return InvoiceType.Electric;
            else
                throw new Exception("发票种类的值错误。" + value);
        }

        public static string GetText(InvoiceType type)
        {
            switch (type)
            {
                case InvoiceType.Special:
                    return "专用发票";
                case InvoiceType.Common:
                    return "普通发票";
                case InvoiceType.Electric:
                    return "电子发票";
                default:
                    throw new Exception("未定义的发票种类。");
            }
        }

        public static InvoiceType TextOf(string text)
        {
            if (text.Equals("专用发票"))
                return InvoiceType.Special;
            else if (text.Equals("普通发票"))
                return InvoiceType.Common;
            else if (text.Equals("电子发票"))
                return InvoiceType.Electric;
            else
                throw new Exception("发票种类的名称错误。");
        }
    }
}
