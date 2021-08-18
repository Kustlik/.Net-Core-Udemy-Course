using System;
using System.Globalization;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo enUS = new CultureInfo("en-US");

            DateTime userBirthDate;
            bool validDateFormat = false;
            string userInput;
            ValidateEnteredDateFormat(enUS, out userBirthDate, validDateFormat, out userInput);
        }

        private static bool ValidateEnteredDateFormat(CultureInfo enUS, out DateTime userBirthDate, bool validDateFormat, out string userInput)
        {
            do
            {
                Console.WriteLine("Hello, please enter you Birth date, using format dd/mm/yyyy");
                userInput = Console.ReadLine();

                if (DateTime.TryParseExact(userInput, "dd/MM/yyyy", enUS, DateTimeStyles.None, out userBirthDate))
                {
                    PassResultsToConsole(userBirthDate, ref validDateFormat);
                }
                else
                {
                    Console.WriteLine("unable to parse {0}.", userInput);
                }
            } while (!validDateFormat);
            return validDateFormat;
        }

        private static TimeSpan PassResultsToConsole(DateTime userBirthDate, ref bool validDateFormat)
        {
            TimeSpan howManyDaysPassed = DateTime.Now.Date - userBirthDate;
            if (howManyDaysPassed.Days <= 0)
            {
                Console.WriteLine("You cannot pass time from the future, please enter you date again");
            }
            else
            {
                Console.WriteLine("{0} days have passed since your bithday", howManyDaysPassed.Days);
                validDateFormat = true;
            }

            return howManyDaysPassed;
        }
    }
}
