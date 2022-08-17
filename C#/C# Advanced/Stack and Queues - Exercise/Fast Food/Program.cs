using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] order = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(order);

            var max = orders.Max();

            while (orders.Count > 0)
            {
                if (food >= orders.Peek())
                {
                    food -= orders.Peek();
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (orders.Count == 0)
            {
                Console.WriteLine(max);
                Console.WriteLine($"Orders complete");
            }
            else
            {
                Console.WriteLine(max);
                Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
            }
        }
    }
}
