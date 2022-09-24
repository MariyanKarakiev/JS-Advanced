using System;
using System.Linq;

namespace Multidimensional_Arrays___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] inputLine = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputLine[col];
                }

            }

            int sumD1 = 0;
            int sumD2 = 0;

            for (int row = 0; row < n; row++)
            {
                sumD1 += matrix[row, row];
            }

            for (int row = 0; row < n; row++)
            {
                sumD2 += matrix[row, n - 1 - row];
            }

            Console.WriteLine(Math.Abs(sumD1 - sumD2));
        }
    }
}
