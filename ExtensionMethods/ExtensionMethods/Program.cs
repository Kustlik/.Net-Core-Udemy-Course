using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            DateTime before = now.Subtract(new TimeSpan(7, 0, 0, 0));
            DateTime after = now.AddDays(7);

            bool isDateBetween = Utils.IsDateBetween(now, before, after);

            bool isDateBetween2 = now.IsBetween(before, after);

            int value = 2;
            value.Squared();
        }
    }
}
