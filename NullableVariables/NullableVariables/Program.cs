using System;

namespace NullableVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            int? favouriteNumber = null;

            Console.WriteLine("Favourite number: " + (favouriteNumber.HasValue ? favouriteNumber.Value.ToString() : ""));
        }
    }
}
