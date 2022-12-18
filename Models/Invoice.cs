using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONBASE_DIP_Preprocessor.Models
{
    
    public class Invoice
    {
        public string Number { get; set; }
        public string VendorCode { get; set; }
        public string IssueDate   { get; set; }
        public string GrossAmount { get; set; }
        public string Filename { get; set; }

        /*
            Add all invoice information keywords
        */

        public Invoice() { }
        public Invoice (string number,string vendorCode, string issueDate, string grossAmount,string fileName) { 
            Number = number;
            VendorCode = vendorCode;
            IssueDate = issueDate;
            GrossAmount = grossAmount;
            Filename = fileName;
        }
    }
}
