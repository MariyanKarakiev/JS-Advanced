using System;
using System.Collections.Generic;
using System.Linq;

namespace Snale_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            Snaking(rows, cols);
        }
        static void Snaking(int rows, int cols)
        {
            int counter = 0;
            string input = Console.ReadLine();

            char[] snake = input.ToCharArray();
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 1)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (counter < 0 || counter > snake.Length - 1)
                        {
                            counter = 0;
                            matrix[row, col] = snake[counter].ToString();
                        }

                        else
                        {
                            matrix[row, col] = snake[counter].ToString();
                        }
                        counter++;
                    }
                }

                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (counter < 0 || counter > snake.Length - 1)
                        {
                            counter = 0;
                            matrix[row, col] = snake[counter].ToString();
                        }

                        else
                        {
                            matrix[row, col] = snake[counter].ToString();
                        }
                        counter++;
                    }
                }
            }
            PrintMatrix(matrix);
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    Console.Write(matrix[i, p]);
                }
                Console.WriteLine();
            }
        }
    }
}
