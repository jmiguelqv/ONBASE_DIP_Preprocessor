using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONBASE_DIP_Preprocessor.Models
{
    public class Document
    {
        public Document() {
            BasicInfo = new DocumentInfo();
            Invoices = new List<Invoice>();
        }
        public DocumentInfo BasicInfo { get; set; }
        public List<Invoice>  Invoices { get; set; }
    }
}
