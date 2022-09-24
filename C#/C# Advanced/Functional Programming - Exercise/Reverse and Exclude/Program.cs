using System;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberss = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int nums = int.Parse(Console.ReadLine());
          
            Predicate<int> predicate = num => num % nums != 0;
           
            Console.WriteLine(string.Join(' ', numberss.Where(n => predicate(n)).Reverse()));
        }
    }
}
