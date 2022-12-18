using NLog;
using ONBASE_DIP_Preprocessor.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ONBASE_DIP_Preprocessor.Services
{
    internal class DocumentService
    {
        private Document Doc;

        string outPutFilePath;
        public DocumentService(Document document,string filePath) {
            Doc = document;
            outPutFilePath = filePath;
        }
        private string formatLine(Invoice invoice)
        {
            var logger = LogManager.GetCurrentClassLogger();
            if(invoice == null) {
                logger.Error("invoice empty");
            }
            string docType = addDelimiter(Doc.BasicInfo.DocumentType);
            string filePath = addDelimiter(String.Format("{0}\\{1}", Doc.BasicInfo.DocumentRootFolder, invoice.Filename));
            string number = addDelimiter(invoice.Number);
            string vendorCode = addDelimiter(invoice.VendorCode);
            string issueDate = addDelimiter(invoice.IssueDate);
            string grossAmount = addDelimiter(invoice.GrossAmount);

            string line = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}", Properties.Settings.Default.Separator, docType, filePath, number, vendorCode, issueDate, grossAmount);
                return line;
        }

        private string addDelimiter(string value)
        {
            return String.Format("{0}{1}{0}", Properties.Settings.Default.Delimiter, value);
        }

        private List<string> getLines()
        {
            List<string> lines = new List<string>();
            foreach (Invoice invoice in Doc.Invoices)
            {
                lines.Add(formatLine(invoice));
            }
            return lines;
        }

        public void processDocument()
        {
            List<string> lines = getLines();
            createTXTFile(lines);
        }
        private void createTXTFile(List<string> lines)
        {
            File.WriteAllLines(outPutFilePath, lines);
        }

    }
}
