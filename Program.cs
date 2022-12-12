using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace ONBASE_DIP_Preprocessor
{
     class Program
    {
        static  int  Main(string[] args)
        {
            try
            {
                FileProcessor fileProcessor = new FileProcessor();
                string[] lines = fileProcessor.processXMLFile(args[0]);
                fileProcessor.createTXTFile(args[1], lines);
                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return 0;
            }
            
        }
    }
}
