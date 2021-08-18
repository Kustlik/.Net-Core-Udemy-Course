using System;
using System.Collections.Generic;

namespace IteratorYield
{
    class Program
    {
        public static IEnumerable<int> GetData()
        {
            Console.WriteLine("GetData() Start");

            var result = new List<int>();
            for(int i = 0; i <= 9; i++)
            {
                Console.WriteLine($"GetData() Element: {i}");
                result.Add(i);
            }

            Console.WriteLine("GetData() Stop");

            return result;
        }
        public static IEnumerable<int> GetYieldedData()
        {
            Console.WriteLine("GetYieldedData() Start");

            for(int i=1; i<=9; i++)
            {
                Console.WriteLine($"GetYieldedData() Element: {i}");
                yield return i;
                if (i % 3 == 0)
                {
                    yield break;
                }
            }

            Console.WriteLine("GetYieldedData() Stop"); 
        }

        static void Main(string[] args)
        {
            var yieldedData = GetYieldedData();
            var data = GetData();
            foreach (int element in yieldedData)
            {
                Console.WriteLine($"Main Element: {element}");
                if (element > 5)
                {
                    break;
                }
            }
            Console.WriteLine("");
            foreach(int element in data)
            {
                Console.WriteLine($"Main Element: {element}");
                if (element > 5)
                {
                    break;
                }
            }
        }



        // break - yield break difference
        //public IEnumerable<int> BuildMyCollection()
        //{
        //    for (int i = 0; i < items.Length; i++)
        //    {
        //        if (i >= 2)
        //        {
        //            //yield break;
        //            break;
        //        }
        //        yield return items[i];
        //    }

        //    Console.WriteLine("You used break.");

        //    yield return 10;
        //}
    }
}
