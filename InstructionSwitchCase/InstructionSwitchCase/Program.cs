using System;

namespace InstructionSwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("It's a start of the work week");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("It's an end of the work week");
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("It's weekend");
                    break;
                default:
                    Console.WriteLine("It's the middle of the work week");
                    break;
            }
        }
    }

}
