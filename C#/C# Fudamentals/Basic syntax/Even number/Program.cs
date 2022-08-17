using System;

namespace Even_number
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            while (n % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                n = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {Math.Abs(n)}");
        }
    }
}
