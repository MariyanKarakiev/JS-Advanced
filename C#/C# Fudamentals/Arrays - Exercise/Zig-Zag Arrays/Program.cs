using System;
using System.Linq;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] input1 = new int[n];
            int[] input2 = new int[n];

            for (int p = 0; p < n; p++)
            {
                int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                if (p % 2 == 0)
                {
                    input1[p] = numbers[0];
                    input2[p] = numbers[1];
                }
                else
                {
                    input1[p] = numbers[1];
                    input2[p] = numbers[0];
                }
            }
        
        Console.WriteLine(string.Join(" ", input1));
        Console.WriteLine(string.Join(" ", input2));
        }
}
}
