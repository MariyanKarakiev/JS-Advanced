using System;
using System.Collections.Generic;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var goldQuantity = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (goldQuantity.ContainsKey(input))
                {
                    goldQuantity[input] += quantity;
                }
                else
                {
                    goldQuantity.Add(input, quantity);
                }
                input = Console.ReadLine();
            }
            foreach (var kvp in goldQuantity)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
