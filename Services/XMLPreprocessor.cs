using ONBASE_DIP_Preprocessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ONBASE_DIP_Preprocessor.Services
{
    public class XMLPreprocessor : FilePreprocessor
    {
        public XMLPreprocessor(string filePath) : base(filePath) {}

        public override  Document processFile()
        {
            Document document= new Document();  
            using (FileStream fs = File.Open(FilePath, FileMode.Open))
            {
                XmlDocument xml = new XmlDocument();
                 xml.Load(fs);
                XmlNodeList xmlInvoiceNodes = xml.SelectNodes("/DocumentBatch/Invoices/Invoice");
                DocumentInfo documentInfo = GetDocumentInfo(xml);
                List<Invoice>  invoices= getXMLInvoices(xmlInvoiceNodes);
                document.Invoices = invoices;
                document.BasicInfo = documentInfo;
            }
            return document;
        }

        private DocumentInfo GetDocumentInfo(XmlDocument xml)
        {
            DocumentInfo documentInfo = new DocumentInfo();
            documentInfo.DocumentType = xml.DocumentElement.SelectSingleNode("/DocumentBatch/DocumentType").InnerText.Trim();
            documentInfo.DocumentRootFolder = xml.DocumentElement.SelectSingleNode("/DocumentBatch/DocumentRootFolder").InnerText.Trim();
            return documentInfo;
        }
        private List<Invoice> getXMLInvoices(XmlNodeList xmlInvoiceNodes)
        {
           
            List<Invoice> invoices = new List<Invoice>();
            foreach (XmlNode xmlInvoiceNode in xmlInvoiceNodes)
            {
                Invoice invoice = new Invoice();
                invoice.Number = xmlInvoiceNode.SelectSingleNode("Number").InnerText;
                invoice.VendorCode = xmlInvoiceNode.SelectSingleNode("VendorCode").InnerText;
                invoice.IssueDate = xmlInvoiceNode.SelectSingleNode("IssueDate").InnerText;
                invoice.GrossAmount = xmlInvoiceNode.SelectSingleNode("GrossAmount").InnerText;
                invoice.Filename = xmlInvoiceNode.SelectSingleNode("Filename").InnerText;
                invoices.Add(invoice);

            }
            return invoices;
        }
    }
}
