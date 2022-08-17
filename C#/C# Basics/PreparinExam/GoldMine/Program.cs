using System;

namespace GoldMine
{
    class Program
    {
        static void Main(string[] args)
        {
            int locations = int.Parse(Console.ReadLine());

            for (int i = 1; i <= locations; i++)
            {
                double sum = 0.0;

                double averageGold = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());

                for (int p = 1; p <= days; p++)
                {
                    double daylyGold = double.Parse(Console.ReadLine());
                    sum += daylyGold;
                }

                if (sum / days >= averageGold)
                {
                    Console.WriteLine($"Good job! Average gold per day: {(sum / days):F2}.");
                }
                else
                {
                    Console.WriteLine($"You need {(averageGold - sum / days):F2} gold.");
                }
            }
        }
    }
}
