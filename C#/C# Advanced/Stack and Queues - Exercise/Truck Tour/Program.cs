using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());



            Queue<long[]> values = new Queue<long[]>();

            for (int i = 0; i < n; i++)
            {
                long[] tank = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                values.Enqueue(tank);
            }

            var index = 0;

            while (true)
            {
                long total = 0;

                foreach (var tank in values)
                {
                    total += tank[0] - tank[1];
                    if (total < 0)
                    {
                        index++;
                        values.Enqueue(values.Dequeue());
                        break;
                    }
                }

                if (total >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}
