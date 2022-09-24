using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToList();


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
                        case "Delete":
                            numbers.Remove(int.Parse(token[1]));
                            break;

                        case "Insert":
                            numbers.Insert(int.Parse(token[2]), int.Parse(token[1]));
                            break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
