using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
          
            FulfillComands(rows, cols, ReadMatrix(rows, cols));
        }

        static void FulfillComands(int rows, int cols, string[,] matrix)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0] != "END")
            {
                if (input.Length == 5 && input[0] == "swap" &&
                    int.Parse(input[1]) < rows &&
                    int.Parse(input[2]) < cols &&
                    int.Parse(input[3]) < rows &&
                    int.Parse(input[4]) < cols)
                {
                    int row1 = int.Parse(input[1]);
                    int col1 = int.Parse(input[2]);
                    int row2 = int.Parse(input[3]);
                    int col2 = int.Parse(input[4]);

                    PrintMatrix(SwappedMatrix(row1, col1, row2, col2, matrix));
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }
        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    Console.Write(matrix[i, p] + " ");
                }
                Console.WriteLine();
            }
        }
        static string[,] SwappedMatrix(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            string valueCell1 = string.Empty;

            valueCell1 = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = valueCell1;

            return matrix;
        }

        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }
            return matrix;
        }
    }
}
