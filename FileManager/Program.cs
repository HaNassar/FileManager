using System;
using System.Threading.Tasks;

namespace FileManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var repeat = true;
            int lineNumbers;
            string path = @"file.txt";
            string path2 = @"copied-version.txt";
            while (repeat)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine("Welcome to the file manager,choose what you want to do");
                Console.WriteLine("=======================================================");
                Console.WriteLine("Type 1 to read all file");
                Console.WriteLine("Type 2 to read a number of lines");
                Console.WriteLine("Type 3 to update the second file");
                Console.WriteLine("Type 0 to Exit !!");
                int choosenCase = Convert.ToInt32(Console.ReadLine());
                switch (choosenCase)
                {
                    case 1:
                        using (FileReader fileReader = new FileReader(path))
                        {
                            Console.WriteLine(await fileReader.ReadFromFileAsync());
                        }
                        break;
                    case 2:
                        Console.WriteLine("How many lines you want to read ?");
                        lineNumbers = Convert.ToInt32(Console.ReadLine());
                        using (FileReader fileReader = new FileReader(path))
                        {
                            Console.WriteLine("your {0} requested lines", lineNumbers);
                            Console.WriteLine("=============================");
                            Console.WriteLine(await fileReader.ReadLinesAsync(lineNumbers));
                        }
                        break;
                    case 3:
                        using (FileCopier fileCopier = new FileCopier(path, path2))
                        {
                            fileCopier.Copy();
                        }
                        break;
                    case 0:
                        repeat = false;
                        break;
                }
            }

        }
    }
}
