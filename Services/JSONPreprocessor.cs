
using Newtonsoft.Json;
using ONBASE_DIP_Preprocessor.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ONBASE_DIP_Preprocessor.Services
{
    public class JSONPreprocessor : FilePreprocessor
    {
        public JSONPreprocessor(string filePath) : base(filePath) { }
        public class JSONSerialized
        {
            public string DocumentType { get; set; }
            public string DocumentRootFolder { get; set; }
            public List<Invoice> Invoices { get; set; }
        }
        public override Document processFile()
        {
            Document document = new Document();
            using (StreamReader file = File.OpenText(FilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                JSONSerialized doc = (JSONSerialized)serializer.Deserialize(file, typeof(JSONSerialized));
                document.BasicInfo.DocumentRootFolder = doc.DocumentRootFolder;
                document.BasicInfo.DocumentType = doc.DocumentType;
                document.Invoices = doc.Invoices;
            }
            return document;
        }
    }
}
