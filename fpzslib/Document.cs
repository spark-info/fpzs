using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fpzslib
{
    public class Document
    {
        public string No { get; set; }
        public string BuyerName { get; set; }
        public string BuyerTaxCode { get; set; }
        public string BuyerAddressTel { get; set; }
        public string BuyerBankAccountNo { get; set; }
        public string Memo { get; set; }
        public string Checker { get; set; }
        public string Payee { get; set; }
        public string TaxCatalogVersion { get; set; }
        public bool IsIncludeTax { get; set; }

        private List<DocumentItem> _items = new List<DocumentItem>();
        public List<DocumentItem> Items
        { 
            get
            {
                return _items;
            }
        }
    }
}
