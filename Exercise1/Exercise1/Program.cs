using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int amount = 0;
            int? max = null;
            int intInput = 0;

            Console.WriteLine("Welcome, please provide me some values. I'll sum it and i'll give you max value from them. If you want to check results and end the program, please write '0'");

            do
            {
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out intInput) && userInput != "0")
                {
                    amount += intInput;

                    if (intInput > max || max == null)
                    {
                        max = intInput;
                    }
                }
                else
                {
                    if (userInput != "0")
                    {
                        Console.WriteLine("Wrong Input, write only numbers");
                    }
                }
            }
            while (userInput != "0");

            Console.WriteLine("Sum of provided numbers is equal to " + amount);
            if (max == null)
            {
                Console.WriteLine("No values inserted");
            }
            else
            {
                Console.WriteLine("Maximum of provided numbers is equal to " + max);
            }
        }
    }
}
