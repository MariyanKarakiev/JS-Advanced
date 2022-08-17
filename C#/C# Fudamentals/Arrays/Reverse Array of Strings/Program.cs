using System;
using System.Linq;

namespace Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine().Split(" ").ToArray();

            
            for (int i = 0; i <str.Length/2; i++)
            {
                var old = str[i];
                str[i] = str[str.Length - i-1];
                str[str.Length - 1 - i] = old;
            }
            Console.WriteLine(string.Join(" ", str));
        }
    }
}
