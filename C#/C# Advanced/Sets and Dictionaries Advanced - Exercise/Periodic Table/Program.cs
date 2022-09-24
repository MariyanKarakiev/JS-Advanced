using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chems = new SortedSet<string>();
           
            for (int i = 0; i < n; i++)
            {
                string[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
              
                for (int p = 0; p < array.Length; p++)
                {
                    chems.Add(array[p]);
                }
            }

            foreach (var item in chems)
            {
                Console.Write($"{item} ");
            }

        }
    }
}
