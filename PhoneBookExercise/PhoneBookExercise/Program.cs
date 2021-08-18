using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookExercise
{
    class Program
    {
        static Dictionary<int, string> MyContactList = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            Dictionary<int, string> myContacts = new Dictionary<int, string>();

            Console.WriteLine("Welcome to Phone Book, write the number given below to continue.");

            int parsedUserInput = 0;
            do
            {
                Console.WriteLine("1 - Add a contact.");
                Console.WriteLine("2 - Display contact based by number.");
                Console.WriteLine("3 - Display all contacts.");
                Console.WriteLine("4 - Search for a contact by name.");
                Console.WriteLine("5 - Remove a contact");
                Console.WriteLine("q - Exit.");

                string userInput = Console.ReadLine();
                int.TryParse(userInput, out parsedUserInput);

                if (userInput == "q")
                {
                    return;
                }

                switch (parsedUserInput)
                {
                    case 1:
                        Console.WriteLine();
                        AddContact();
                        break;
                    case 2:
                        Console.WriteLine();
                        DisplayByNumber();
                        break;
                    case 3:
                        Console.WriteLine();
                        DisplayAll();
                        break;
                    case 4:
                        Console.WriteLine();
                        SearchByName();
                        break;
                    case 5:
                        Console.WriteLine();
                        RemoveContact();
                        break;
                    default:
                        Console.WriteLine("Sorry, you've typed a wrong option. Please choose again.");
                        break;
                }
                parsedUserInput = 0;
            }
            while (parsedUserInput < 1 || 5 < parsedUserInput);
        }

        static int CheckForValidNumber()
        {
            int telephoneNumber;

            do
            {
                int.TryParse(Console.ReadLine(), out telephoneNumber);

                if (telephoneNumber < 100000000 || 999999999 < telephoneNumber)
                {
                    Console.WriteLine("Wrong number.");
                }
            }
            while (telephoneNumber < 100000000 || 999999999 < telephoneNumber);

            return telephoneNumber;
        }

        static string CheckForValidName()
        {
            string name = null;
            Console.WriteLine("Type name of your contact.");
            do
            {
                name = Console.ReadLine();

                if (name.Length < 2)
                {
                    Console.WriteLine("Name is too short.");
                }
            }
            while (name.Length < 2);

            return name;
        }

        static void AddContact()
        {
            Console.WriteLine("Type number of your contact (9 numbers).");

            int telephoneNumber = CheckForValidNumber();
            string name = CheckForValidName();

            try
            {
                MyContactList.Add(telephoneNumber, name);
            }
            catch(ArgumentException)
            {
                Console.WriteLine($"Number '{telephoneNumber}' is already on your contact list.");
            }
        }

        static void DisplayByNumber()
        {
            Console.WriteLine("Type contact number.");

            int userInput = CheckForValidNumber();
            string userSearched = null;

            if (MyContactList.TryGetValue(userInput, out userSearched) == true)
            {
                Console.WriteLine($"Contact number {userInput} belongs to {userSearched}.");
            }
            else
            {
                Console.WriteLine($"Contact number {userInput} has no owner.");
            }
        }

        static void DisplayAll()
        {
            foreach(KeyValuePair<int, string> contact in MyContactList)
            {
                Console.WriteLine($"Contact Name: {contact.Value} - {contact.Key}");
            }
        }

        static void SearchByName()
        {
            Console.WriteLine("Type contact name.");

            string userInput = Console.ReadLine();
            foreach (KeyValuePair<int, string> contact in MyContactList)
            {
                if (contact.Value == userInput)
                {
                    Console.WriteLine($"Contact Name: {contact.Value} - {contact.Key}");
                    return;
                }
            }

            Console.WriteLine($"There isn't any contact named '{userInput}'.");
        }

        static void RemoveContact()
        {
            Console.WriteLine("Type number of contact you want to delete.");

            int number = CheckForValidNumber();
            if (MyContactList.ContainsKey(number))
            {
                Console.WriteLine($"Contact removed - Name: {MyContactList[number]} - {number}");
                MyContactList.Remove(number);
            }
            else
            {
                Console.WriteLine($"Specified number '{number}' not found.");
            }
        }
    }
}
