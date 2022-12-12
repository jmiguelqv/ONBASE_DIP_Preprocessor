using System;
using System.IO;
using System.Xml;

namespace ONBASE_DIP_Preprocessor
{
    internal class FileProcessor
    {
        public string[] processXMLFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            XmlDataDocument xmldoc = new XmlDataDocument();
            xmldoc.Load(fs);
            XmlNodeList invoiceNode= xmldoc.GetElementsByTagName("Invoice");
            string docType = elementValue(xmldoc, "DocumentType");
            string rootFolder  = elementValue(xmldoc, "DocumentRootFolder");
            String[] lines = getLines(invoiceNode, docType, rootFolder);
            return lines;
        }
        private string elementValue(XmlDataDocument xmldoc,string tagName)
        {
            XmlNodeList documentTypeNode = xmldoc.GetElementsByTagName(tagName);
            string value = documentTypeNode[0].InnerText.Trim();
            return value;
        }
        private string[] getLines(XmlNodeList invoiceNode, string docType, string rootFolder)
        {
            String[] lines = new String[invoiceNode.Count];
            for (int i = 0; i <= invoiceNode.Count - 1; i++)
            {
                lines[i] = formatLine(docType, rootFolder, invoiceNode[i]);
            }
            return lines;
        }
        private string formatLine(string docType, string rootFolder,XmlNode invoiceNode)
        {
            return "\"" + docType + "\",\"" + rootFolder + invoiceNode.ChildNodes.Item(4).InnerText.Trim() + "\",\"" + invoiceNode.ChildNodes.Item(0).InnerText.Trim() + "\",\"" + invoiceNode.ChildNodes.Item(1).InnerText.Trim() + "\",\"" + invoiceNode.ChildNodes.Item(2).InnerText.Trim() + "\",\"" + invoiceNode.ChildNodes.Item(3).InnerText.Trim() + "\"";
        }

        public void createTXTFile(string filePath, string[] lines)
        {
            File.WriteAllLines(filePath, lines);
        }
    }
}
