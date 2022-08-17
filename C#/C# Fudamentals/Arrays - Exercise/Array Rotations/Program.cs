using System;
using System.Linq;

namespace Array_Rotations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int oldFirst = numbers[0];
                for (int p = 0; p < numbers.Length-1; p++)
                {
                    numbers[p] = numbers[p+1];
                }
                numbers[numbers.Length - 1] = oldFirst;

            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
