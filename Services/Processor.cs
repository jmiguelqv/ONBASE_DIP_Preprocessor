using NLog;
using ONBASE_DIP_Preprocessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONBASE_DIP_Preprocessor.Services
{
    public class Processor
    {
        private string[] args;
        public Processor(string[] args) {
            this.args = args;
        }


        public void process() {
            var logger = LogManager.GetCurrentClassLogger();
            if(args.Length >= 2)
            {
                PreprocessorService preprocessor = new PreprocessorService(args[0]);
                Document document = preprocessor.getDocument();
                DocumentService documentService = new DocumentService(document, args[1]);
                documentService.processDocument();
            }
            else
            {
                logger.Error("No arguments detected");
            }
           
        }
    }
}
