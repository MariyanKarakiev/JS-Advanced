using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = ConsoleParse();
            }

            double[][] matrixProccessed = ProccessedMatrix(matrix, rows);

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                double value = double.Parse(input[3]);

                if ((row >= 0 && row < matrix.Length) && (col >= 0 && col < matrix[row].Length))
                {
                    switch (input[0])
                    {
                        case "Add":
                            {
                                matrixProccessed[row][col] += value;
                                break;
                            }
                        case "Subtract":
                            {
                                matrixProccessed[row][col] -= value;
                                break;
                            }
                    }
                }
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var row in matrixProccessed)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
        static double[] ConsoleParse() =>
           Console.ReadLine()
           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(double.Parse)
           .ToArray();

        static double[][] ProccessedMatrix(double[][] matrix, int rows)
        {
            for (int row = 0; row < rows - 1; row++)
            {

                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                }

                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }
            return matrix;
        }
    }
}