using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace fpzslib
{
    public enum InvoiceType
    {
        [Description("增值税专用发票")]
        Special=0,
        [Description("增值税普通发票")]
        Common=2,
        [Description("增值税电子普通发票")]
        Electric=3
    }
}
