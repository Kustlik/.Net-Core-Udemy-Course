using System;

namespace WhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = { "volvo", "BMW", "Mazda" };

            int i = 0;
            while(i < cars.Length)
            {
                Console.WriteLine(cars[i]);

                if(cars[i] == "BMW")
                {
                    Console.WriteLine("bye");
                    break;
                }
                i++;
            }
        }
    }
}
