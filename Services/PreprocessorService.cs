using NLog;
using ONBASE_DIP_Preprocessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONBASE_DIP_Preprocessor.Services
{
    public class PreprocessorService
    {
        private string FilePath;
        public PreprocessorService(string filePath)
        {
            FilePath = filePath;
        }

        public Document getDocument()
        {
            var logger = LogManager.GetCurrentClassLogger();
            FileInfo fi = new FileInfo(FilePath);
            string extn = fi.Extension;
            Document document = new Document();
            FilePreprocessor fileProcessor = null;
            switch (extn)
            {
                case ".xml":
                    fileProcessor = new XMLPreprocessor(FilePath);
                    break;
                case ".json":
                    fileProcessor = new JSONPreprocessor(FilePath);
                    break;
                default:
                    logger.Error("File extenson no supported");
                    break;
            }
            document = fileProcessor.processFile();
            return document;
        }
    }
}
