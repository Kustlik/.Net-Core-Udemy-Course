using System;
using System.IO;

namespace DisposingFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\Sobala\source\repos\DisposingFiles\DisposingFiles\file.txt";
            var fileContent = File.ReadAllLines(filePath);

            using (var someClass = new SomeClass())
            {
                someClass.Say("Hi");
            }

            using (var readFileStream = new FileStream(filePath, FileMode.Open))
            {
                //readFileStream.Read();
            }

            //...

            var writeFileStream = new FileStream(filePath, FileMode.Open);
            try
            {
                //writeFileStream.Write();
            }
            finally
            {
                ((IDisposable)writeFileStream).Dispose();
            }

            writeFileStream.Close();
        }
    }
}
