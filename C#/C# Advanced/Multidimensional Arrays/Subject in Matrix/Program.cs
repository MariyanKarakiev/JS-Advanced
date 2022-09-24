using System;
using System.Linq;

namespace Subject_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            int d = int.Parse(Console.ReadLine());

            char[,] matrix = new char[d, d];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colElements = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            char element = char.Parse(Console.ReadLine());
            bool contains = true;



            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!contains)
                    {
                        break;
                    }
                    if (element == matrix[row, col])
                    {

                        Console.WriteLine($"({row}, {col})");
                        contains = false;

                    }
                }
            }


            if (contains)
            {
                Console.WriteLine($"{element} does not occur in the matrix");
            }
        }
    }
}
