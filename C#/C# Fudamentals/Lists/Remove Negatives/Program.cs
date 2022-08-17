using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Negatives
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .Where(n => n > 0)
              .ToList();
           
            numbers.Reverse();
            
            Console.WriteLine(string.Join(" " , numbers));
        }
    }
}
