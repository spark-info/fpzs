using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fpzs.bl
{
    public class Document
    {
        public string No { get; set; }
        public string BuyerName { get; set; }
        public string BuyerTaxCode { get; set; }
        public string BuyerAddressTel { get; set; }
        public string BuyerBankAccountNo { get; set; }
        public string Memo { get; set; }
        public string Kpr { get; set; }
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

        public string SellerName { get; set; }
        public string SellerTaxCode { get; set; }
        public string SellerAddressTel { get; set; }
        public string SellerBankAccountNo { get; set; }
        public string OriginalInvoiceCode { get; set; }
        public string OriginalInvoiceNo { get; set; }

        public decimal TotalValue()
        {
            decimal value = 0;
            foreach(DocumentItem m in _items)
            {
                value += m.Value;
            }
            return value;
        }

        public decimal TotalTax()
        {
            decimal tax = 0;
            foreach(DocumentItem m in _items)
            {
                tax += m.Tax;
            }
            return tax;
        }
    }
}
