using ONBASE_DIP_Preprocessor.Models;


namespace ONBASE_DIP_Preprocessor.Services
{
    public abstract class FilePreprocessor { 
        public string FilePath { get; set; }
    public FilePreprocessor(string filePath) {
            FilePath = filePath;
        }
        public abstract Document processFile();
    }
}
