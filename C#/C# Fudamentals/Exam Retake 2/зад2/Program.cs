using System;
using System.Collections.Generic;

namespace зад2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, double> sold = new SortedDictionary<string, double>();
            SortedDictionary<string, double> delivered = new SortedDictionary<string, double>();

            double total = 0;

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Deliver":
                        {
                            string name = input[1];
                            double money = double.Parse(input[2]);

                            if (delivered.ContainsKey(name))
                            {
                                delivered[name] += money;
                            }
                            else
                            {
                                delivered.Add(name, money);
                            }


                            break;
                        }

                    case "Return":
                        {
                            string name = input[1];
                            double money = double.Parse(input[2]);

                            if (delivered.ContainsKey(name))
                            {
                                if (delivered[name] < money)
                                {

                                }
                                else
                                {
                                    delivered[name] -= money;
                                    if (delivered[name] <= 0)
                                    {
                                        delivered.Remove(name);
                                    }
                                }
                            }

                            else
                            {

                            }
                            break;
                        }

                    case "Sell":
                        {
                            string name = input[1];
                            double money = double.Parse(input[2]);

                            if (sold.ContainsKey(name))
                            {
                                sold[name] += money;


                            }
                            else
                            {
                                sold.Add(name, money);
                            }
                            total += money;
                            break;
                        }
                }
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var i in sold)
            {
                Console.WriteLine($"{i.Key}: {i.Value:F2}");
            }
            Console.WriteLine("-----------");

            foreach (var i in delivered)
            {
                Console.WriteLine($"{i.Key}: {i.Value:F2}");
            }
            Console.WriteLine("-----------");
            Console.WriteLine($"Total Income: {total:F2}");
        }
    }
}
