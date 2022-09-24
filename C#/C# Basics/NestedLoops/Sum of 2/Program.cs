using System;

namespace Sum_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = int.Parse(Console.ReadLine());
            int finalNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combinations = 0;
            bool isFound = false;
            for (int i = startingNumber; i <= finalNumber; i++)
            {
                for (int p = startingNumber; p <= finalNumber; p++)
                {
                    combinations++;
                    if (i + p == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combinations} ({i} + {p} = {magicNumber})");
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
            }
        }
    }
}