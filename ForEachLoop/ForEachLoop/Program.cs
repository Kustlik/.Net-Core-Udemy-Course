using System;

namespace ForEachLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = { "Volvo", "BMW", "Mazda" };

            foreach (string car in cars)
            {
                Console.WriteLine(car);
                if(car == "BMW")
                {
                    Console.WriteLine("bye");
                    break;
                }
            }
        }
    }
}
