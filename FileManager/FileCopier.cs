using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    class FileCopier : IDisposable
    {
        private readonly string filePath;
        private readonly string copiedFilePath;
        private readonly StreamWriter streamCopy;


        public FileCopier(string filePath, string destinationPath)
        {
            this.filePath = filePath;
            this.copiedFilePath = destinationPath;
            if (!File.Exists(filePath))
            {
                throw new Exception("file not found");
            }
            this.streamCopy = new StreamWriter(this.copiedFilePath, true);
        }

        public void Copy()
        {
            string copiedcontent = System.IO.File.ReadAllText(filePath);
            streamCopy.WriteLine();
            streamCopy.WriteLine();
            DateTime updateTime = DateTime.Now;
            string time = "Updated at:" + updateTime.ToString();
            streamCopy.WriteLine(time);
            streamCopy.WriteLine("__________________________________");
            streamCopy.WriteLine(copiedcontent);
            Console.WriteLine("====================================================");
            Console.WriteLine("File updated successfully at: " + updateTime.ToString());
            Console.WriteLine("====================================================");
        }
        public void Dispose()
        {
            streamCopy.Dispose();
            streamCopy.Dispose();
        }
    }
}
