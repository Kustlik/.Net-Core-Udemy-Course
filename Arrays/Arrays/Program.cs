using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = { "Volvo", "BMW", "Mazda" };
            Console.WriteLine(cars[0]);
            int arrayLength = cars.Length; // 3

            cars[2] = "Tesla";
            Console.WriteLine(cars[cars.Length - 1]);
        }
    }
}
