using System;
using System.IO;

namespace TextFileHandling
{
    class Program
    {
        static void ScanAndAppend()
        {
            var files = Directory.GetFiles(@"C:\Users\Ikestius\source\repos\TextFileHandling\TextFileHandling\", "*.txt", SearchOption.AllDirectories);
            foreach(string file in files)
            {
                File.AppendAllText(file, "All rights reserved");
            }
        }
        static void ReadFiles()
        {
            var document1 = File.ReadAllText(@"C:\Users\Ikestius\source\repos\TextFileHandling\TextFileHandling\template.txt");
            var document2 = File.ReadAllLines(@"C:\Users\Ikestius\source\repos\TextFileHandling\TextFileHandling\template.txt");

            var document2String = string.Join(Environment.NewLine, document2);

            Console.WriteLine("document1");
            Console.WriteLine(document1);

            Console.WriteLine("document2");
            Console.WriteLine(document2String);
        }
        static void GenerateDocuments()
        {
            Console.WriteLine("Insert name");
            var name = Console.ReadLine();

            Console.WriteLine("Insert orderNumber:");
            var orderNumber = Console.ReadLine();

            var template = File.ReadAllText(@"C:\Users\Ikestius\source\repos\TextFileHandling\TextFileHandling\template.txt");
            var document = template
                .Replace("{name}", name)
                .Replace("{orderNumber}", orderNumber)
                .Replace("{dateTime}", DateTime.Now.ToString());

            File.WriteAllText($@"C:\Users\Ikestius\source\repos\TextFileHandling\TextFileHandling\document-{name}.txt", document);
        }
        static void Main(string[] args)
        {
            ReadFiles();
            GenerateDocuments();
            ScanAndAppend();
        }
        
    }
}
