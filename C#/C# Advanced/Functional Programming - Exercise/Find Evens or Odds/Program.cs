using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string query = Console.ReadLine();

            List<int> numbers = new List<int>();
            Predicate<int> OddOrEven = query == "odd" ? number => number % 2 != 0 : new Predicate<int>( (number) => number % 2 == 0);

            for (int i = n[0]; i <= n[1]; i++)
            {
                if (OddOrEven(i))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
            
        }
    }
}
