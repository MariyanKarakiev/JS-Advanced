using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            var occur = new Dictionary<char, int>();

            string input = Console.ReadLine();
                

            foreach (char letter in input)
            {
                if (letter==' ')
                {
                    continue;
                }
                if (occur.ContainsKey(letter))
                {
                    occur[letter]++;
                }
                else
                {
                    occur.Add(letter, 1);
                }
            }
            foreach (var kvp in occur)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }      
        }
    }
}
