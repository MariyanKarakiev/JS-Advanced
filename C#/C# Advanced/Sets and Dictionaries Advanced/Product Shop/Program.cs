using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> stores = new SortedDictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0] != "Revision")
            {
                if (!stores.ContainsKey(input[0]))
                {
                    stores[input[0]] = new Dictionary<string, double>();
                }

                stores[input[0]].Add(input[1], double.Parse(input[2]));

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var KVP in stores)
            {
                Console.WriteLine($"{KVP.Key}->");

                foreach (var KVP2 in KVP.Value)
                {
                    Console.WriteLine($"Product: {KVP2.Key}, Price: {KVP2.Value}");
                }
            }
        }
    }
}
