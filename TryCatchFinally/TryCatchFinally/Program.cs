using System;

namespace TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = { "Volvo", "BMW", "Mazda" };

            try
            {
                Console.WriteLine("Inside Try - 1");
                cars[4] = "Tesla"; //throws System.IndexOutOfRangeException
                Console.WriteLine("Inside Try - 2");
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Handling IndexOutOfRangeException exception");
            }
            catch(Exception e)
            {
                Console.WriteLine("Handling any exception");
            }
            finally
            {
                Console.WriteLine("Cleanup");
            }
            Console.WriteLine("Outside of try-catch");
        }
    }
}
