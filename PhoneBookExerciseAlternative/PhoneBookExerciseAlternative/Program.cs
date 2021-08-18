using System;

namespace PhoneBookExerciseAlternative
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from the PhoneBook app");

            Console.WriteLine("1 Add contact");
            Console.WriteLine("2 Display contact by number");
            Console.WriteLine("3 Display all contacts");
            Console.WriteLine("4 Search contacts");
            Console.WriteLine("5 Remove contact");
            Console.WriteLine("To exit insert 'x'");

            var userInput = Console.ReadLine();

            var phoneBook = new PhoneBook();

            var minNameLength = 3;
            var minNumberLength = 9;

            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Insert number");
                        var number = ParseInputNumber(ValidateInput(Console.ReadLine(), minNumberLength));
                        Console.WriteLine("Insert name");
                        var name = ValidateInput(Console.ReadLine(), minNameLength);

                        var newContact = new Contact(name, number);

                        phoneBook.AddContact(newContact);

                        break;
                    case "2":
                        Console.WriteLine("Insert number");
                        var numberToSearch = ParseInputNumber(ValidateInput(Console.ReadLine(), minNumberLength));

                        phoneBook.DisplayContact(numberToSearch);

                        break;
                    case "3":
                        phoneBook.DisplayAllContacts();
                        break;
                    case "4":
                        Console.WriteLine("Insert search phrase");
                        var searchPhrase = Console.ReadLine();

                        phoneBook.DisplayMatchingContacts(searchPhrase);
                        break;
                    case "5":
                        Console.WriteLine("Insert number");
                        var removeNumber = ParseInputNumber(ValidateInput(Console.ReadLine(), minNumberLength));

                        phoneBook.RemoveContact(removeNumber);

                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }

                Console.WriteLine("Select operation");
                userInput = Console.ReadLine();
            }
        }

        static string ValidateInput(string input, int length)
        {
            if (input.Length >= length)
            {
                return input;
            }
            else
            {
                do
                {
                    Console.WriteLine($"Please, enter at least {length} characters");
                    input = Console.ReadLine();
                }
                while (input.Length < length);

                return input;
            }
        }

        static string ParseInputNumber(string input)
        {
            bool isNumeric;
            do
            {
                if (isNumeric = int.TryParse(input, out int intInput))
                {
                    return intInput.ToString();
                }
                else
                {
                    Console.WriteLine("Wrong format, only numbers are allowed.");
                    input = ValidateInput(Console.ReadLine(), input.Length);
                }
            }
            while (!isNumeric);

            throw new ArgumentException("A loop hole found in ParseInputNumber", nameof(input));
        }
    }
}
