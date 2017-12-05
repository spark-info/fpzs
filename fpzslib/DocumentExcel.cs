using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fpzslib
{
    class DocumentExcel
    {
        public string DocumentNo{get;set;}
        public string BuyerName{get;set;}
        public string BuyerTaxCode{get;set;}
        public string BuyerAddressTel{get;set;}
        public string BuyerBankAccountNo { get; set; }
        public string Memo { get; set; }
        public string Payee { get; set; }
        public string Checker { get; set; }
        public string TaxCatalogVersion { get; set; }
        public string ItemName { get; set; }
        public string ItemSpec { get; set; }
        public string ItemUnit { get; set; }
        public decimal ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal ItemValue { get; set; }
        public decimal ItemTaxRate { get; set; }
        public decimal ItemTax { get; set; }
        public string TaxCatalogItemNo { get; set; }
    }
}
