using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam eget risus sit amet est commodo\n" +
                             "consequat sed id enim. Vivamus imperdiet mattis sodales. Donec in libero tristique, vestibulum \n" +
                             "ligula quis,auctor risus. Ut venenatis augue a sapien ultrices, non rutrum magna semper.\n" +
                             "Suspendisse eu quam a erat placerat dapibus vitae.\n\n\n";
            string path = @"file.txt";
            string path2 = @"copied-version.txt";
            using (FileManager f1 = new FileManager(path))
            {
                f1.filePath = path;
                f1.WriteToFile(content);
                f1.Copy(path2);
                string result =  f1.ReadFromFile();
                Console.WriteLine(result);
            }

            //f1.Dispose();
            //string s = "hannna nassat";
            //System.IO.File.WriteAllText(path, s);

        }
    }
}
