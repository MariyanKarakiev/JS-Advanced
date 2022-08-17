using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var farmed = new Dictionary<string, int>
            {
                { "motes", 0},
                { "shards", 0},
                { "fragments", 0}
            };
            var junk = new Dictionary<string, int>();

            bool isEarned = false;

            string earned = " ";
            while (!isEarned)
            {

                string[] input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int value = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();
                    if (farmed.ContainsKey(material))
                    {
                        farmed[material] += value;

                        if (farmed[material] >= 250)
                        {
                            farmed[material] -= 250;

                            earned = material;
                            isEarned = true;
                            break;
                        }
                    }

                    else if (junk.ContainsKey(material))
                    {
                        junk[material] += value;
                    }

                    else
                    {
                        junk.Add(material, value);
                    }
                }
            }


            Dictionary<string, int> sorted = farmed
                 .OrderByDescending(n => n.Value)
                 .ThenBy(n => n.Key)
                 .ToDictionary(x => x.Key, x => x.Value);

            Dictionary<string, int> sorted2 = junk
                .OrderBy(n => n.Key)

                .ToDictionary(x => x.Key, x => x.Value);

            switch (earned)
            {

                case "motes":
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        break;
                    }

                case "fragments":
                    {
                        Console.WriteLine("Valanyr obtained!");
                        break;
                    }

                case "shards":
                    {
                        Console.WriteLine("Shadowmourne obtained!");
                        break;
                    }
            }
            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in sorted2)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}