using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> numbers = new HashSet<string>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "IN":
                        {
                            numbers.Add(input[1]);
                            break;
                        }
                    case "OUT":
                        {
                            numbers.Remove(input[1]);
                            break;
                        }
                    default:
                        break;
                }
                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var item in numbers)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
