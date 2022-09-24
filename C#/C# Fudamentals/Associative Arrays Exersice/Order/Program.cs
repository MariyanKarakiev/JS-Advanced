using System;
using System.Collections.Generic;
using System.Linq;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Dictionary<string, List<double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0]=="buy")
                {
                    break;
                }
              
                string product = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (order.ContainsKey(product))
                {
                    order[product][0] = price;
                    order[product][1] += quantity;
                }
                else
                {
                    order.Add(product, new List<double>());
                    order[product].Add(price);
                    order[product].Add(quantity);
                }
            }
            double sum = 1.2d;
            foreach (var item in order)
            {
                sum =order[item.Key][0] * order[item.Key][1];
                Console.WriteLine($"{item.Key} -> {sum:F2}");
            }
        }
    }
}
