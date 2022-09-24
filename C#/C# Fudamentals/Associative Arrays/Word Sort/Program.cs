using System;
using System.Linq;

namespace Word_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .Where(n => n.Length % 2 == 0)
                  .ToList()
                  .ForEach(n => Console.WriteLine(n));
        }
    }
}
