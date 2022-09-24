using System;
using System.Linq;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];


            for (int i = 0; i < height; i++)
            {
                long[] row = new long[i + 1];
                row[0] = 1;
                row[i] = 1;

                for (int p = 1; p < i; p++)
                {
                    row[p] = triangle[i - 1][p] + triangle[i - 1][p - 1];

                }
                triangle[i] = row;
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}

