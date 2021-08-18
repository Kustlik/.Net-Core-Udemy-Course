using System;
using System.Threading.Tasks;

namespace AsynchronicException
{
    class Program
    {
        static async Task FooAsync()
        {
            Console.WriteLine("Foo start");

            await Task.Delay(2000);

            throw new Exception();

            Console.WriteLine("Foo end");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Main started");

            try
            {
                await FooAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception");
            }

            Console.ReadLine();
        }
    }
}
