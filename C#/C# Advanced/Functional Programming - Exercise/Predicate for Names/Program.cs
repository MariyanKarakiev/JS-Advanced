using System;
using System.Linq;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Predicate<string> predicate = str => str.Length <= n;
            Action<string[]> print = str => str.Where(n => predicate(n)).ToList().ForEach(n => Console.WriteLine(n));

            print(input);
        }
    }
}