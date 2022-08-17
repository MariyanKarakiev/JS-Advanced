using System;
using System.Collections.Generic;
using System.Linq;

namespace Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> count = new Dictionary<string, int>();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            foreach (var word in input)
            {
                string wordLower = word.ToLower();

                if (count.ContainsKey(wordLower))
                {
                    count[wordLower]++;
                }
                else
                {
                    count.Add(wordLower, 1);
                }
            }
            foreach (var word in count)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}
