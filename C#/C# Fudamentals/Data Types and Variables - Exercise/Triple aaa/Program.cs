using System;

namespace ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());


            for (int i = 0; i <= start - 1; i++)
            {
                for (int p = 0; p <= start - 1; p++)
                {
                    for (int k = 0; k <= start - 1; k++)
                    {

                        Console.WriteLine($"{(char)(i + 97)}{(char)(p + 97)}{(char)(k + 97)}");
                    }
                }

            }

        }
    }
}
