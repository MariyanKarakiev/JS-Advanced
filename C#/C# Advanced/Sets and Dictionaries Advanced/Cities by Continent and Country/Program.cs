using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();



            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!continents.ContainsKey(input[0]))
                {
                    continents[input[0]] = new Dictionary<string, List<string>>();
                }
                if (!continents[input[0]].ContainsKey(input[1]))
                {
                    continents[input[0]][input[1]] = new List<string>();
                }
                continents[input[0]][input[1]].Add(input[2]);
            }

            foreach (var KVP in continents)
            {
                Console.WriteLine($"{KVP.Key}:");

                foreach (var KVP2 in KVP.Value)
                {
                    Console.WriteLine($"{KVP2.Key} -> {string.Join(", ", KVP2.Value)}");
                }
            }
        }
    }
}

