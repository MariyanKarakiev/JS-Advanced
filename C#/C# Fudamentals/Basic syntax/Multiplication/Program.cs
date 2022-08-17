using System;

namespace Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var start = int.Parse(Console.ReadLine());
           
            if (n <= 10)
            {
                for (int i = start; i <= 10; i++)
                {

                    Console.WriteLine($"{n} X {i} = {n * i}");
                }
            }
       else
            {
                Console.WriteLine($"{n} X {start} = {n * start}");
            }
        }
    }
}
