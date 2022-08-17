using System;
using System.Linq;

namespace Functional_Programming___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList()
                  .Min(n => n));
        }
    }
}



