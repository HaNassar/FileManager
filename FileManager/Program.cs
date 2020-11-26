using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path = @"file.txt";
            string path2 = @"copied-version.txt";

            //using (FileManager f1 = new FileManager(path, path2))
            //{
            //    Console.WriteLine(f1.ReadFromFile());
            //}
            using (FileManager f1 = new FileManager(path, path2))
            {
                Console.WriteLine(f1.readLines(10));
            }
            //f1.Dispose();
            //string s = "hannna nassat";
            //System.IO.File.WriteAllText(path, s);

        }
    }
}
