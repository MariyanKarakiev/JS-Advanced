using System;
using System.Linq;

namespace Jaggered_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());

            int[][] jaggered = new int[d][];

            for (int row = 0; row < jaggered.Length; row++)
            {
                int[] colElements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                jaggered[row] = colElements;
            }
            string[] input = Console.ReadLine().Split(" ").ToArray();
            while (input[0] != "END")
            {
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row >= d || row < 0 || col < 0 || col > jaggered[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (input[0] == "Add")
                    {
                        jaggered[row][col] += value;
                    }
                    else if (input[0] == "Subtract")
                    {
                        jaggered[row][col] -= value;
                    }
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }
            foreach (var row in jaggered)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

