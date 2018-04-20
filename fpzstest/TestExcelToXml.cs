using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fpzs;
using System.IO;
using System.Text;
using fpzs.bl;

namespace fpzslibtest
{
    [TestClass]
    public class TestExcelToXml
    {
        [TestMethod]
        public void ConvertExcelToXmlElectric()
        {
            string xmlFilepathExpected = @"testdata\开票数据模板-电子-V1.0.xml";
            string excelFilepath = @"testdata\开票数据模板-电子-V1.0.xlsx";
            string xmlFilepath = @"testdata\开票数据模板-电子-V1.0-tmp.xml";

            if(File.Exists(xmlFilepath))
            {
                File.Delete(xmlFilepath);
            }

            ExcelToXml excelToXml = new ExcelToXml();
            excelToXml.ConvertExcelToXml(excelFilepath, xmlFilepath, InvoiceType.Electric);

            string strXmlExpected = ReadTextFromFile(xmlFilepathExpected);
            string strXml = ReadTextFromFile(xmlFilepath);
            int pos = Diff(strXmlExpected, strXml);
            Assert.AreEqual(strXmlExpected, strXml);
        }

        [TestMethod]
        public void ConvertExcelToXmlSpecialAndCommon()
        {
            string xmlFilepathExpected = @"testdata\开票数据模板-增专增普-V1.0.xml";
            string excelFilepath = @"testdata\开票数据模板-增专增普-V1.0.xlsx";
            string xmlFilepath = @"testdata\开票数据模板-增专增普-V1.0-tmp.xml";

            if (File.Exists(xmlFilepath))
            {
                File.Delete(xmlFilepath);
            }

            ExcelToXml excelToXml = new ExcelToXml();
            excelToXml.ConvertExcelToXml(excelFilepath, xmlFilepath, InvoiceType.Special);

            string strXmlExpected = ReadTextFromFile(xmlFilepathExpected);
            string strXml = ReadTextFromFile(xmlFilepath);
            //int pos = Diff(strXmlExpected, strXml);
            Assert.AreEqual(strXmlExpected, strXml);
        }

        private string ReadTextFromFile(string filepath)
        {
            StringBuilder sb = new StringBuilder();
            using(StreamReader sr = new StreamReader(filepath))
            {
                string line;
                while((line=sr.ReadLine())!=null)
                {
                    sb.Append(line.Trim());
                }
            }
            return sb.ToString();
        }

        private int Diff(string str1, string str2)
        {
            int result = 0;
            for(int i=0; i<str1.Length; i++)
            {
                string c1 = str1.Substring(i, 1);
                string c2 = str2.Substring(i, 1);
                if(!c1.Equals(c2))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}
