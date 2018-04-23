using fpzs.bl;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace fpzs.dal
{
    public class DocumentDAO
    {
        private SqliteHelper sqlite;
        public DocumentDAO(SqliteHelper sqlite)
        {
            this.sqlite = sqlite;
        }

        public bool Insert(Document doc)
        {
            string sql = "insert into tbl_document " +
                "(IssueInvoiceType,ImportDate,DocumentNo,BuyerName,BuyerTaxCode," +
                "BuyerAddressTel,BuyerBankAccountNo,Memo,Maker,Checker, " +
                "Payee,TaxCatalogVersion,IsIncludeTax,SellerName,SellerTaxCode,"+
                "SellerAddressTel,SellerBankAccountNo,OriginalInvoiceCode,OriginalInvoiceNo) " +
                "values " +
                "(@IssueInvoiceType,@ImportDate,@DocumentNo,@BuyerName,@BuyerTaxCode," +
                "@BuyerAddressTel,@BuyerBankAccountNo,@Memo,@Maker,@Checker, " +
                "@Payee,@TaxCatalogVersion,@IsIncludeTax,@SellerName,@SellerTaxCode,"+
                "@SellerAddressTel,@SellerBankAccountNo,@OriginalInvoiceCode,@OriginalInvoiceNo) ";
            SQLiteParameter[] ps = new SQLiteParameter[]{
                new SQLiteParameter("@IssueInvoiceType",InvoiceTypeWrapper.GetValue(doc.IssueInvoiceType)),
                new SQLiteParameter("@ImportDate",doc.ImportDate),
                new SQLiteParameter("@DocumentNo",doc.No),
                new SQLiteParameter("@BuyerName",doc.BuyerName),
                new SQLiteParameter("@BuyerTaxCode",doc.BuyerTaxCode),
                new SQLiteParameter("@BuyerAddressTel",doc.BuyerAddressTel),
                new SQLiteParameter("@BuyerBankAccountNo",doc.BuyerBankAccountNo),
                new SQLiteParameter("@Memo",doc.Memo),
                new SQLiteParameter("@Maker",doc.Maker),
                new SQLiteParameter("@Checker",doc.Checker),
                new SQLiteParameter("@Payee",doc.Payee),
                new SQLiteParameter("@TaxCatalogVersion",doc.TaxCatalogVersion),
                new SQLiteParameter("@IsIncludeTax",doc.IsIncludeTax),
                new SQLiteParameter("@SellerName",doc.SellerName),
                new SQLiteParameter("@SellerTaxCode",doc.SellerTaxCode),
                new SQLiteParameter("@SellerAddressTel",doc.SellerAddressTel),
                new SQLiteParameter("@SellerBankAccountNo",doc.SellerBankAccountNo),
                new SQLiteParameter("@OriginalInvoiceCode",doc.OriginalInvoiceCode),
                new SQLiteParameter("@OriginalInvoiceNo",doc.OriginalInvoiceNo)
            };

            return sqlite.ExecuteInsert(sql, ps);
        }
    }
}
