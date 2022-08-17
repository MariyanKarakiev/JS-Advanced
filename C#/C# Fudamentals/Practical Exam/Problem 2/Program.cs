using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex("([@+]?[#+]?)+([a-z]{3,})([@+]?[#+]?)+(\\w+)?(\\W+)?(\\/+)+(\\d+)(\\/+)+");

            string i = Console.ReadLine();

            var matches = regex.Matches(i);

            Dictionary<int, string> count = new Dictionary<int, string>();

            List<int> numbers = new List<int>();
            List<string> color = new List<string>();
            foreach (Match item in matches)
            {
                Console.WriteLine($"You found {int.Parse(item.Groups[7].ToString())} {item.Groups[2].Value.ToString()} eggs!");

            }
        }
    }
}
