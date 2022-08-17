using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_and_Dictionaries_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();



            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (grades.ContainsKey(input[0]))
                {
                    grades[input[0]].Add(double.Parse(input[1]));
                }
                else
                {
                    grades.Add(input[0], new List<double>() { double.Parse(input[1]) });
                }
            }

            foreach (var KVP in grades)
            {
                Console.WriteLine($"{KVP.Key} -> {string.Join(' ', KVP.Value.Select(v=>v.ToString("F2")))} (avg: {(decimal)KVP.Value.Average():F2})");
            }
        }
    }
}
