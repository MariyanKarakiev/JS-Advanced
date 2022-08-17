using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Dictionary<string, int> products = new Dictionary<string, int>();
            int sold = 0;

            while (input[0] != "Complete")
            {
                switch (input[0])
                {
                    case "Receive":
                        {
                            if (products.ContainsKey(input[2]))
                            {
                                if (int.Parse(input[1]) <= 0)
                                {
                                    break;
                                }

                                else
                                {
                                    products[input[2]] += int.Parse(input[1]);
                                }
                            }
                            else
                            {
                                if (int.Parse(input[1]) <= 0)
                                {
                                    break;
                                }

                                else
                                {
                                    products.Add(input[2], int.Parse(input[1]));
                                }
                            }
                            break;
                        }

                    case "Sell":
                        {
                            if (products.ContainsKey(input[2]))
                            {
                                if (int.Parse(input[1]) > products[input[2]])
                                {
                                    Console.WriteLine($"There aren't enough {products[input[2]]}. You sold the last {products[input[1]]} of them");
                                    sold += products[input[2]];
                                    products.Remove(input[2]);
                                }

                                else
                                {
                                    products[input[2]] -= int.Parse(input[1]);
                                    sold += int.Parse(input[1]);
                                    Console.WriteLine($"You sold {input[1]} {input[2]}.");

                                    if (products[input[2]] == 0)
                                    {

                                        products.Remove(input[2]);
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine($"You do not have any {input[2]}.");
                            }
                            break;
                        }
                }
                input = Console.ReadLine().Split(' ');
            }

            Dictionary<string, int> sorted = products
               .OrderByDescending(n => n.Value)
               .ThenBy(n => n.Key)
               .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine($"All sold: {sold} goods");

        }
    }
}
