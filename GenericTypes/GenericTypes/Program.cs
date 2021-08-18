using System;
using System.Collections.Generic;

namespace GenericTypes
{
    class Program
    {
        public delegate void Display(string value);

        public delegate bool GenericPredicate<T>(T value);

        static void Main(string[] args)
        {
            Display display = (string value) => Console.Write(value + ", ");

            display("Test");

            var numbers = new int[] { 10, 30, 50 };
            //DisplayNumbers(number, display);
            var count = Count(numbers, (int value) => value > 35);
            Console.WriteLine(count);

            var strings = new string[] { "Generic", "Delegate", "test" };
            var countString = Count(strings, value => value.Length > 4);
            Console.WriteLine($"countString {countString}");

            //End of delegate excercise

            var restaurants = new List<Restaurant>();

            var result = new PaginatedResult<Restaurant>();

            result.Results = restaurants;

            var users = new List<User>();

            // result.Results = users; // compile error

            // var stringRepository = new Repository<string>();

            // stringRepository.AddElement("some value");

            // string firstElement = stringRepository.GetElement(0);

            var user2Repository = new Repository<User>();

            var userRepository = new Repository<string, User>();

            userRepository.AddElement("Bill", new User() { Name = "Bill" });

            User bill = userRepository.GetElement("Bill");

            int[] intArray = new[] { 1, 3, 5 };

            Utils.Swap(ref intArray[0], ref intArray[2]);

            Console.WriteLine(string.Join(", ", intArray));
        }

        static void DisplayNumbers(IEnumerable<int> numbers, Display display)
        {
            foreach (int number in numbers)
            {
                display(number.ToString());
            }
        }

        static int Count<T>(IEnumerable<T> elements, GenericPredicate<T> predicate)
        {
            int count = 0;
            foreach (T element in elements)
            {
                if (predicate(element))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
