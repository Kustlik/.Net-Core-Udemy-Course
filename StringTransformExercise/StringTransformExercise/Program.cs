using System;
using System.Text;

namespace StringTransformExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            do
            {
                Console.WriteLine("Please enter a word using Camel Case/Kebab Case format to transform respectively to one another. Type 'q' to quit.");

                userInput = Console.ReadLine();

                foreach(char letter in userInput)
                {
                    if (char.IsUpper(letter))
                    {
                        Console.WriteLine(ToKebabCase(userInput));
                        break;
                    }
                    else if (letter == '-')
                    {
                        Console.WriteLine(ToCamelCase(userInput));
                        break;
                    }
                }
            }
            while (userInput != "q");
        }

        static string ToCamelCase(string userInput)
        {
            var userInputSplitted = userInput.Split('-');
            StringBuilder stringBuilder = new StringBuilder(userInputSplitted[0]);

            for (int i = 1; i < userInputSplitted.Length; i++)
            {
                char firstLetter = userInputSplitted[i][0];
                stringBuilder.Append(char.ToUpper(firstLetter));
                stringBuilder.Append(userInputSplitted[i].Substring(1));
            }
            userInput = stringBuilder.ToString();

            return userInput;
        }

        static string ToKebabCase(string userInput)
        {
            for (int i = 0; i < userInput.Length; i++)
            {
                if (char.IsUpper(userInput[i]))
                {
                    userInput = userInput.Replace(userInput[i].ToString(), "-" + char.ToLower(userInput[i]));
                }
            }
            return userInput;
        }
    }
}
