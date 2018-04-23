using fpzs.bl;
using fpzs.dal;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fpzs.cl
{
    public class DocumentManager
    {
        private SqliteHelper sqlite;
        private DocumentDAO docDAO;
        public DocumentManager(SqliteHelper sqlite)
        {
            this.sqlite = sqlite;
            docDAO = new DocumentDAO(sqlite);
        }
        public InvokeResult SaveDocument(List<Document> docs)
        {
            sqlite.BeginTransaction();
            try
            {
                foreach(Document d in docs)
                {
                    docDAO.Insert(d);
                }
                sqlite.CommitTransaction();
            }
            catch (Exception ex)
            {
                sqlite.RollbackTransaction();
                return InvokeResult.Fail(ex.Message);
            }
            return InvokeResult.SUCCESS;
        }
        public List<Document> ConvertToDocument(Dictionary<string, List<DocumentExcel>> excelDocs)
        {
            List<Document> result = new List<Document>();

            foreach (KeyValuePair<string, List<DocumentExcel>> kv in excelDocs)
            {
                Document doc = new Document();
                DocumentExcel excelDocFirst = kv.Value[0];

                doc.ImportDate = DateTime.Now;
                doc.No = excelDocFirst.DocumentNo;
                doc.BuyerName = excelDocFirst.BuyerName;
                doc.BuyerTaxCode = excelDocFirst.BuyerTaxCode;
                doc.BuyerAddressTel = excelDocFirst.BuyerAddressTel;
                doc.BuyerBankAccountNo = excelDocFirst.BuyerBankAccountNo;
                doc.Memo = excelDocFirst.Memo;
                doc.Checker = excelDocFirst.Checker;
                doc.Payee = excelDocFirst.Payee;
                doc.TaxCatalogVersion = excelDocFirst.TaxCatalogVersion;
                doc.IsIncludeTax = false;

                int serialNo = 1;
                foreach (DocumentExcel excelDoc in kv.Value)
                {
                    DocumentItem item = new DocumentItem();
                    item.DocumentNo = excelDoc.DocumentNo;
                    item.SerialNo = serialNo++;
                    item.Name = excelDoc.ItemName;
                    item.Spec = excelDoc.ItemSpec;
                    item.Unit = excelDoc.ItemUnit;
                    item.Price = excelDoc.ItemPrice;
                    item.Quantity = excelDoc.ItemQuantity;
                    item.Value = excelDoc.ItemValue;
                    item.TaxRate = excelDoc.ItemTaxRate;
                    item.Tax = excelDoc.ItemTax;
                    item.TaxCatalogItemNo = excelDoc.TaxCatalogItemNo;
                    item.ItemNo = "";
                    item.IsFreeTax = false;
                    item.FreeTaxName = "";
                    item.ZeroTax = ZeroTax.NonZeroTax;
                    doc.Items.Add(item);
                }

                result.Add(doc);
            }
            return result;
        }
        public Dictionary<string, List<DocumentExcel>> ParseExcel(string excelFilepath)
        {
            Dictionary<string, List<DocumentExcel>> result = new Dictionary<string, List<DocumentExcel>>();
            IWorkbook workbook;
            ISheet sheet;

            workbook = new XSSFWorkbook(excelFilepath);
            sheet = workbook.GetSheetAt(0);
            if (sheet != null)
            {
                int rowCount = sheet.LastRowNum;
                for (int i = 2; i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null)
                    {
                        continue;
                    }

                    DocumentExcel excelDoc = new DocumentExcel();
                    ICell cell;

                    cell = row.Cells[0];
                    string strDocumentNo;
                    if (cell.CellType == CellType.Numeric)
                    {
                        strDocumentNo = Convert.ToString(cell.NumericCellValue);
                    }
                    else
                    {
                        strDocumentNo = cell.StringCellValue;
                    }
                    excelDoc.DocumentNo = strDocumentNo;

                    excelDoc.BuyerName = row.Cells[1].StringCellValue;
                    excelDoc.BuyerTaxCode = row.Cells[2].StringCellValue;
                    excelDoc.BuyerAddressTel = row.Cells[3].StringCellValue;
                    excelDoc.BuyerBankAccountNo = row.Cells[4].StringCellValue;
                    excelDoc.Memo = row.Cells[5].StringCellValue;
                    excelDoc.Payee = row.Cells[6].StringCellValue;
                    excelDoc.Checker = row.Cells[7].StringCellValue;
                    excelDoc.TaxCatalogVersion = row.Cells[8].StringCellValue;
                    excelDoc.ItemName = row.Cells[9].StringCellValue;
                    excelDoc.ItemSpec = row.Cells[10].StringCellValue;
                    excelDoc.ItemUnit = row.Cells[11].StringCellValue;
                    excelDoc.ItemQuantity = Convert.ToDecimal(row.Cells[12].NumericCellValue);
                    excelDoc.ItemPrice = Convert.ToDecimal(row.Cells[13].NumericCellValue);
                    excelDoc.ItemValue = Convert.ToDecimal(row.Cells[14].NumericCellValue);
                    excelDoc.ItemTaxRate = Convert.ToDecimal(row.Cells[15].NumericCellValue);
                    excelDoc.ItemTax = Convert.ToDecimal(row.Cells[16].NumericCellValue);
                    excelDoc.TaxCatalogItemNo = row.Cells[17].StringCellValue;

                    if (!result.ContainsKey(excelDoc.DocumentNo))
                    {
                        result.Add(excelDoc.DocumentNo, new List<DocumentExcel>());
                    }
                    result[excelDoc.DocumentNo].Add(excelDoc);
                }
            }
            return result;
        }
    }
}
