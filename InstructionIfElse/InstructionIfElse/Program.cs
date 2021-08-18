using System;

namespace FirstProject
{
    #region MainCode

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please tell me your year of birth");
            string userInput = Console.ReadLine();

            int yearOfBirth = int.Parse(userInput);
            bool isUserAgeOver18 = DateTime.Now.Date.Year - yearOfBirth >= 18;

            if (isUserAgeOver18)
            {
                Console.WriteLine("Welcome to the system");
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.Write("Today is Sunday");
            }
            else
            {
                Console.WriteLine("Access denied");
            }

            Console.WriteLine("Have a nice day");
        }
    }

    #endregion
}