using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FileManager
{
    class FileReader : IDisposable
    {
        private readonly string filePath;
        private readonly StreamReader streamReader;
        public FileReader(string filePath)
        {
            this.filePath = filePath;
            if (!File.Exists(filePath))
            {
                throw new Exception("file not found");
            }
            this.streamReader = new StreamReader(this.filePath);

        }
        public async Task<string> ReadFromFileAsync()
        {
            string content = await streamReader.ReadToEndAsync();
            return content;
        }
        public async Task<string> ReadLinesAsync(int lineNumber)
        {
            string lines;
            int count = 0;
            var text = new StringBuilder();
            while (count < lineNumber && (lines = await streamReader.ReadLineAsync()) != null)
            {
                text.AppendLine(lines);
                count++;
            }
            return text.ToString();
        }


        public void Dispose()
        {
            streamReader.Dispose();
        }

    }
}
