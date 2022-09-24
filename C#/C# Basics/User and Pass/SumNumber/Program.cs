using System;

namespace SumNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int s = 1;
            while (s<=n)
            {
                Console.WriteLine(s);
                s = s * 2 + 1;
            }

        }
    }
}
