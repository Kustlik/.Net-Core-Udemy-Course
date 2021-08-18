using System;

namespace DoWhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To exit, type 'x'");

            string userInput;

            do
            {
                userInput = Console.ReadLine();
                Console.WriteLine($"Echo: {userInput}");
            } while (userInput != "x");
        }
    }
}
