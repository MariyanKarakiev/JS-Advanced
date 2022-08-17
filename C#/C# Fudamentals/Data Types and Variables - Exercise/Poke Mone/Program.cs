using System;

namespace Poke_Mone
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            sbyte Y = sbyte.Parse(Console.ReadLine());
            int counter = 0;
            long N1 = N;
            while (N >= M)
            {
                counter++;
                N -= M;

                if (N == N1 / 2 && Y > 0)
                {
                    N = N / Y;
                }

            }

            Console.WriteLine(N);
            Console.WriteLine(counter);
        }
    }
}
