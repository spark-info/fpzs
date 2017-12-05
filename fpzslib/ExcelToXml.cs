using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace fpzslib
{
    public class ExcelToXml
    {
        /// <summary>
        /// 将EXCEL格式的开票数据转换为XML格式的开票数据
        /// </summary>
        /// <param name="excelFilepath"></param>
        /// <param name="xmlFilepath"></param>
        public InvokeResult ConvertExcelToXml(string excelFilepath, string xmlFilepath){
            try
            {
                FileStream source = new FileStream(excelFilepath, FileMode.Open, FileAccess.Read);
                Dictionary<string, List<DocumentExcel>> excelDocs = ReadFromExcel(excelFilepath);
                List<Document> docs = BuildDocument(excelDocs);
                BuildXml(docs, xmlFilepath);
            }catch(Exception ex)
            {
                return InvokeResult.Fail(ex.Message);
            }
            return InvokeResult.SUCCESS;
        }

        private Dictionary<string,List<DocumentExcel>> ReadFromExcel(string excelFilepath)
        {
            Dictionary<string,List<DocumentExcel>> result = new Dictionary<string,List<DocumentExcel>>();
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
                    if(cell.CellType == CellType.Numeric)
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

                    if(!result.ContainsKey(excelDoc.DocumentNo))
                    {
                        result.Add(excelDoc.DocumentNo, new List<DocumentExcel>());
                    }
                    result[excelDoc.DocumentNo].Add(excelDoc);
                }
            }
            return result;
        }
    
        private List<Document> BuildDocument(Dictionary<string,List<DocumentExcel>> excelDocs)
        {
            List<Document> result = new List<Document>();

            foreach(KeyValuePair<string,List<DocumentExcel>> kv in excelDocs)
            {
                Document doc = new Document();
                DocumentExcel excelDocFirst = kv.Value[0];

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
                foreach(DocumentExcel excelDoc in kv.Value)
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

        private void BuildXml(List<Document> docs, string xmlFilepath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using(XmlWriter writer = XmlWriter.Create(xmlFilepath, settings))
            {
                writer.WriteStartElement("Kp");
                XmlWriteElement(writer, "Version", "2.0");

                writer.WriteStartElement("Fpxx");
                XmlWriteElement(writer, "Zsl", Convert.ToString(docs.Count));

                writer.WriteStartElement("Fpsj");
                foreach(Document doc in docs)
                {
                    writer.WriteStartElement("Fp");
                    XmlWriteElement(writer, "Djh", doc.No);
                    XmlWriteElement(writer, "Gfmc", doc.BuyerName);
                    XmlWriteElement(writer, "Gfsh", doc.BuyerTaxCode);
                    XmlWriteElement(writer, "Gfyhzh", doc.BuyerBankAccountNo);
                    XmlWriteElement(writer, "Gfdzdh", doc.BuyerAddressTel);
                    XmlWriteElement(writer, "Bz", doc.Memo);
                    XmlWriteElement(writer, "Fhr", doc.Checker);
                    XmlWriteElement(writer, "Skr", doc.Payee);
                    XmlWriteElement(writer, "Spbmbbh", doc.TaxCatalogVersion);
                    XmlWriteElement(writer, "Hsbz", doc.IsIncludeTax ? "1" : "0");

                    writer.WriteStartElement("Spxx");
                    int n = 1;
                    foreach(DocumentItem item in doc.Items)
                    {
                        writer.WriteStartElement("Sph");
                        XmlWriteElement(writer, "Xh", Convert.ToString(n++));
                        XmlWriteElement(writer, "Spmc", item.Name);
                        XmlWriteElement(writer, "Ggxh", item.Spec);
                        XmlWriteElement(writer, "Jldw", item.Unit);
                        XmlWriteElement(writer, "Spbm", item.TaxCatalogItemNo.PadRight(19,'0'));
                        XmlWriteElement(writer, "Qyspbm", item.ItemNo);
                        XmlWriteElement(writer, "Syyhzcbz", item.IsFreeTax ? "1" : "");
                        XmlWriteElement(writer, "Lslbz", Utility.GetEnumDescription(item.ZeroTax));
                        XmlWriteElement(writer, "Yhzcsm", item.FreeTaxName);
                        string strPrice, strQuantity;
                        if(item.Price == 0)
                        {
                            strPrice = "";
                            strQuantity = "";
                        }
                        else
                        {
                            strPrice = Convert.ToString(item.Price);
                            strQuantity = Convert.ToString(item.Quantity);
                        }
                        XmlWriteElement(writer, "Dj", strPrice);
                        XmlWriteElement(writer, "Sl", strQuantity);
                        XmlWriteElement(writer, "Je", Convert.ToString(item.Value));
                        XmlWriteElement(writer, "Slv", Convert.ToString(item.TaxRate));
                        XmlWriteElement(writer, "Kce", "");
                        writer.WriteEndElement();//Sph
                    }
                    writer.WriteEndElement();//Spxx
                    writer.WriteEndElement();//Fp
                }
                writer.WriteEndElement();//Fpsj
                writer.WriteEndElement();//Kp
            }
        }

        private void XmlWriteElement(XmlWriter writer, string localName, string text)
        {
            writer.WriteStartElement(localName);
            writer.WriteString(text);
            writer.WriteEndElement();
        }
    }
}
