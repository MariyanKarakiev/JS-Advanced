using System;

namespace Steps2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = 1;
            for (int i = 0; i <= n; i = i + 2)
            {

                Console.WriteLine(p);
                p = p * 2 * 2;
            }
        }
    }
}

