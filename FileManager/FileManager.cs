using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager
{
    class FileManager : IDisposable
    {
        
        public string filePath { get; set; }
        
        public FileManager(string filePath)
        {
        }
        public string ReadFromFile()
        {
            //using (StreamReader sr = new StreamReader(filePath))
            //{
            //    string content = sr.ReadToEnd();
            //    return content;
            //}
            StreamReader sr = new StreamReader(filePath);
            string content = sr.ReadToEnd();
            sr.Dispose();
            return content;

        }
        public void WriteToFile(string content)
        {
            System.IO.File.AppendAllText(filePath, content);
        }
        public void Copy(string destinationPath)
        {
            string copiedcontent = ReadFromFile();
            System.IO.File.AppendAllText(destinationPath, copiedcontent);
           
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //sr.Dispose();
                // free managed resources
            }

            // free native resources if there are any.
        }
    }
}
