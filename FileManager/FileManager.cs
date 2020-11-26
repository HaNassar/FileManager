using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager
{
    class FileManager : IDisposable
    {
        private readonly string filePath;
        private readonly string copiedFilePath;
        private readonly StreamReader streamReader;
        //private readonly StreamWriter streamWriter;
        private readonly StreamWriter streamCopy;
        private readonly bool boolAppend = true;


        public FileManager(string filePath, string destinationPath)
        {
            this.filePath = filePath;
            this.copiedFilePath = destinationPath;
            if (!File.Exists(filePath) || !File.Exists(destinationPath))
            {
                throw new Exception("file not found");
            }
            //this.streamWriter = new StreamWriter(this.filePath, boolAppend);
            this.streamReader = new StreamReader(this.filePath);
            this.streamCopy = new StreamWriter(this.copiedFilePath, boolAppend);
        }
        public string ReadFromFile()
        {
            //using (StreamReader sr = new StreamReader(filePath))
            //{
            string content = streamReader.ReadToEnd();
            return content;
            //}
        }
        public string readLines(int lineNumber)
        {
            string lines;
            var text = new StringBuilder();
            for (int i = 0; i < lineNumber; i++)
            {
                if ((lines = streamReader.ReadLine()) != null)
                {
                    text.AppendLine(lines);
                }
            }
            return text.ToString();
        }
        //public void WriteToFile(string content)
        //{
        //     streamWriter.WriteLine(content);
        //    //System.IO.File.AppendAllText(filePath, content);
        //}
        public void Copy()
        {
            string copiedcontent = ReadFromFile();

            streamCopy.WriteLine();
            streamCopy.WriteLine();
            DateTime updateTime = DateTime.Now;
            string time = "Updated at:" + updateTime.ToString();
            streamCopy.WriteLine(time);
            streamCopy.WriteLine("__________________________________");
            streamCopy.WriteLine(copiedcontent);
            //System.IO.File.AppendAllText(destinationPath, copiedcontent);

        }
        public void Dispose()
        {
            streamCopy.Dispose();
            streamReader.Dispose();
            //streamWriter.Dispose();


        }

    }
}
