using System;

namespace Historgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1Count = 0;
            int p2Count = 0;
            int p3Count = 0;
            int p4Count = 0;
            int p5Count = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    p1Count += 1;
                }
                else if (num <= 399)
                {
                    p2Count += 1;
                }
                else if (num <= 599)
                {
                    p3Count += 1;
                }
                else if (num <= 799)
                {
                    p4Count += 1;
                }
                else if (num >= 800)
                {
                    p5Count += 1;
                }
            }
            Console.WriteLine($"{Math.Round((double)p1Count / n * 100, 2):F2}%");
            Console.WriteLine($"{Math.Round((double)p2Count / n * 100, 2):F2}%");
            Console.WriteLine($"{Math.Round((double)p3Count / n * 100, 2):F2}%");
            Console.WriteLine($"{Math.Round((double)p4Count / n * 100, 2):F2}%");
            Console.WriteLine($"{Math.Round((double)p5Count / n * 100, 2):F2}%");
        }
    }
}
