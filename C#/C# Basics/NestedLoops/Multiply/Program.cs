using System;

namespace Multiply
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int p = 1; p <= 10; p++)
                {
                    Console.WriteLine($"{i} * {p} = {i * p}");
                }
            }
        }
    }
}
