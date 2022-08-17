using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n < 100)
            {
                Console.WriteLine(0);              
                Console.WriteLine(0);              
            }
            else
            {
                long extracted = 0;
                int counter = 0;
                while (n >= 100)
                {
                    extracted += n - 26;
                    n -= 10;
                    counter++;
                }
                extracted -= 26;
                Console.WriteLine(counter);
                Console.WriteLine(extracted);
            }
        }
    }
}
