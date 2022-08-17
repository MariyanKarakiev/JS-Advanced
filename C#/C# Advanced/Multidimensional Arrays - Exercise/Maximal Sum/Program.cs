using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            FindSquare(ReadMatrix(rows, cols));
        }
        static void FindSquare(int[,] matrix)
        {
            int sum = 0;
            int cCol = 0;
            int cRow = 0;

            for (int row = 1; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 1; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentsum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col - 1] +
                        matrix[row - 1, col] + matrix[row - 1, col + 1] + matrix[row - 1, col - 1] +
                         matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col - 1];

                    if (currentsum > sum)
                    {
                        cRow = row;
                        cCol = col;
                        sum = currentsum;
                    }
                }
            }
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"{matrix[cRow - 1, cCol - 1]} {matrix[cRow - 1, cCol]} {matrix[cRow - 1, cCol + 1]}");
            Console.WriteLine($"{matrix[cRow, cCol - 1]} {matrix[cRow, cCol]} {matrix[cRow, cCol + 1]}");
            Console.WriteLine($"{matrix[cRow + 1, cCol - 1]} {matrix[cRow + 1, cCol]} {matrix[cRow + 1, cCol + 1]}");
        }
        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }
            return matrix;
        }
    }
}
