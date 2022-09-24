using System;
using System.Collections.Generic;
using System.Linq;

namespace Manipulations_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToList();

            bool changed = false;


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                else
                {
                    string[] token = input.Split();

                    switch (token[0])
                    {
                        case "Add":
                            changed = true;
                            numbers.Add(int.Parse(token[1]));
                            break;

                        case "Remove":
                            changed = true;
                            numbers.Remove(int.Parse(token[1]));
                            break;

                        case "RemoveAt":
                            changed = true;

                            numbers.RemoveAt(int.Parse(token[1]));
                            break;

                        case "Insert":
                            changed = true;
                            numbers.Insert(int.Parse(token[2]), int.Parse(token[1]));
                            break;


                        case "Contains":

                            if (numbers.Contains(int.Parse(token[1])))
                            {
                                Console.WriteLine("Yes");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such number");
                                break;
                            }


                        case "PrintEven":

                            Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                            break;


                        case "PrintOdd":

                            Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                            break;


                        case "GetSum":

                            int sum = 0;

                            foreach (var item in numbers)
                            {
                                sum += item;
                            }

                            Console.WriteLine(sum);

                            break;


                        case "Filter":
                            {
                                switch (token[1])
                                {
                                    case "<":
                                        Console.WriteLine(string.Join(" ", numbers.Where(n => n < int.Parse(token[2]))));
                                        break;

                                    case ">":
                                        Console.WriteLine(string.Join(" ", numbers.Where(n => n > int.Parse(token[2]))));
                                        break;

                                    case ">=":
                                        Console.WriteLine(string.Join(" ", numbers.Where(n => n >= int.Parse(token[2]))));
                                        break;

                                    case "<=":
                                        Console.WriteLine(string.Join(" ", numbers.Where(n => n <= int.Parse(token[3]))));
                                        break;
                                }
                                break;
                            }
                    }
                }
            }
            if (changed)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
