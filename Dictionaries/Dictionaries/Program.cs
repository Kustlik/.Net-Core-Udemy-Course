using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionaries
{
    class Program
    {
        //Program written by using lists
        //static List<Currency> GetCurrencies()
        //{
        //    return new List<Currency>
        //    {
        //        new Currency("usd", "United States, Dollar", 1),
        //        new Currency("eur", "Euro", 0.83975),
        //        new Currency("gbp", "British Pound", 0.74771),
        //        new Currency("cad", "Canadian Dollar", 1.30724),
        //        new Currency("inr", "Indian Rupee", 73.04),
        //        new Currency("mxn", "Mexican Peso", 21.7571)
        //    };
        //}

        //static void Main(string[] args)
        //{
        //    List<Currency> currencies = GetCurrencies();
        //    Console.WriteLine("Check the rate for:");
        //    string userInput = Console.ReadLine();

        //    Currency selectedCurrency = currencies.FirstOrDefault(c => c.Name == userInput);
        //    if (selectedCurrency != null)
        //    {
        //        Console.WriteLine($"Rate for USD to {selectedCurrency.FullName} is {selectedCurrency.Rate}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Currency not found");
        //    }
        //}

        static Dictionary<string, Currency> GetCurrencies()
        {
            return new Dictionary<string, Currency>
            {
                { "usd", new Currency("usd", "United States, Dollar", 1) },
                { "eur", new Currency("eur", "Euro", 0.83975) },
                { "gbp", new Currency("gbp", "British Pound", 0.74771) },
                { "cad", new Currency("cad", "Canadian Dollar", 1.30724) },
                { "inr", new Currency("inr", "Indian Rupee", 73.04) },
                { "mxn", new Currency("mxn", "Mexican Peso", 21.7571) }
            };
        }

        static void Main(string[] args)
        {
            Dictionary<string, Currency> currencies = GetCurrencies();
            Console.WriteLine("Check the rate for:");
            string userInput = Console.ReadLine();

            currencies.Add("pip", new Currency("hipi", "dipi", 1));
            Currency selectedCurrency = null;
            if (currencies.TryGetValue(userInput, out selectedCurrency))
            {
                Console.WriteLine($"Rate for USD to {selectedCurrency.FullName} is {selectedCurrency.Rate}");
            }
            else
            {
                Console.WriteLine("Currency not found");
            }

            currencies.Remove("usd");

        }
    }
}
