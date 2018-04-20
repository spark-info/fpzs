using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace fpzs.bl
{
    public enum ZeroTax
    {
        /// <summary>
        /// 非零税率
        /// </summary>
        [Description("")]
        NonZeroTax, 
        /// <summary>
        /// 出口零税
        /// </summary>
        [Description("0")]
        ExportZeroTax,
        /// <summary>
        /// 免税
        /// </summary>
        [Description("1")]
        TaxFree,
        /// <summary>
        /// 不征税
        /// </summary>
        [Description("2")]
        OutOfTax,
        /// <summary>
        /// 普通零税率
        /// </summary>
        [Description("3")]
        CommonZeroTax
    }
}
