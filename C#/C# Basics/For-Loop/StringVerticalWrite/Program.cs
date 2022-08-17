using System;

namespace StringVerticalWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            string Input = Console.ReadLine();
            for (int i = 0; i < Input.Length; i++)
            {
                Console.WriteLine(Input[i]);
            }

            Console.ReadKey();
        }
    }
}
