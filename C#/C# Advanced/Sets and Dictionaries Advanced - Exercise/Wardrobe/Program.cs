using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> colors = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = input[0];

                if (!colors.ContainsKey(color))
                {
                    colors.Add(color, new Dictionary<string, int>());
                }

                for (int p = 1; p < input.Length; p++)
                {
                    if (!colors[color].ContainsKey(input[p]))
                    {
                        colors[color].Add(input[p], 0);
                    }


                    colors[color][input[p]]++;

                }
            }
            string[] searchFor = Console.ReadLine().Split();

            foreach (var kvp1 in colors)
            {
                Console.WriteLine($"{kvp1.Key} clothes:");

                foreach (var kvp2 in kvp1.Value)
                {
                    if (kvp1.Key == searchFor[0] && kvp2.Key == searchFor[1])
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp2.Key} - {kvp2.Value}");
                    }
                }
            }
        }
    }
}
