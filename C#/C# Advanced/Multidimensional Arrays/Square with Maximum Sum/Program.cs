using System;
using System.Linq;

namespace Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }


            int sum = int.MinValue;
            int sqrow = 0;
            int sqcol = 0;

            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    var NewSquareSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (sum < NewSquareSum)
                    {
                        sum = NewSquareSum;
                        sqrow = row;
                        sqcol = col;
                    }
                }
            }


            Console.WriteLine($"{matrix[sqrow, sqcol]} {matrix[sqrow, sqcol + 1]}");
            Console.WriteLine($"{matrix[sqrow + 1, sqcol]} {matrix[sqrow + 1, sqcol + 1]}");
            Console.WriteLine(sum);

        }
    }
}
