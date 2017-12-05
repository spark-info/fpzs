using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fpzslib;
using System.IO;
using System.Text;

namespace fpzslibtest
{
    [TestClass]
    public class TestExcelToXml
    {
        [TestMethod]
        public void ConvertExcelToXml()
        {
            string xmlFilepathExpected = @"testdata\开票数据模板-V1.0.xml";
            string excelFilepath = @"testdata\开票数据模板-V1.0.xlsx";
            string xmlFilepath = @"testdata\开票数据模板-V1.0-tmp.xml";

            if(File.Exists(xmlFilepath))
            {
                File.Delete(xmlFilepath);
            }

            ExcelToXml excelToXml = new ExcelToXml();
            excelToXml.ConvertExcelToXml(excelFilepath, xmlFilepath);

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
                if(!str1.Substring(i,1).Equals(str2.Substring(i,1)))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}
