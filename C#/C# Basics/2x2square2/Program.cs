using System;
using System.Linq;


namespace _2x2square
{
    class Program
    {
        static void Main(string[] args)
        {

            int sum = 0;
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int p = 0; p < matrix.GetLength(1); p++)
                    matrix[i, p] = elements[p];
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var newsquaresum = matrix[row, col] +
                        matrix[row + 1, col] +
                        matrix[row, col + 1] +
                        matrix[row + 1, col + 1];
                    if (newsquaresum > sum)
                    {
                        sum = newsquaresum;

                    }
                }
            }
        }
    }
}
                
 

