using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int row = size[0];
            int col = size[1];

            var garden = Read(row, col);

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Bloom")
            {
                int rowF = int.Parse(input[0]);
                int colF = int.Parse(input[1]);

                if (rowF > row || colF > col)
                {
                    Console.WriteLine("Invalid coordinates.");

                    input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                else
                {
                    var old = garden[rowF, colF] + 1;

                    for (int i = 0; i < row; i++)
                    {
                        for (int p = 0; p < col; p++)
                        {
                            if (i == rowF)
                            {
                                garden[i, p]++;
                            }

                            if (p == colF)
                            {
                                garden[i, p]++;
                            }
                            garden[rowF, colF] = old;
                        }
                    }
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Print(garden, row, col);
        }


        static int[,] Read(int row, int col)
        {
            int[,] garden = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int p = 0; p < col; p++)
                {
                    garden[i, p] = 0;
                }
            }
            return garden;
        }
        static void Print(int[,] garden, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int p = 0; p < col; p++)
                {
                    Console.Write($"{garden[i, p]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
