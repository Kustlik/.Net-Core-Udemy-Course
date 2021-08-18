using System;

namespace NegativeNumberParseExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to check if it's a correct negative value");

            int parsedValue;
            while(!IsNegative(Console.ReadLine(), out parsedValue))
            {
                Console.WriteLine($"Enter negative value");
            }

            Console.WriteLine($"Entered negative value is equal {parsedValue}");
        }

        static bool IsNegative(string userInput, out int parsedValue)
        {
            int valueCheck;
            int.TryParse(userInput, out valueCheck);

            if (valueCheck < 0)
            {
                parsedValue = valueCheck;
                return true;
            }
            else
            {
                parsedValue = default;
                return false;
            }
        }
    }
}
