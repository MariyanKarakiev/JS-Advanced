using System;

namespace _30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            var hour = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            minutes += 30;

            if (minutes > 59)
            {
                minutes -= 60;
                hour++;
            }
            if (hour > 23)
            {
                hour = 0;
            }
            Console.WriteLine($"{hour}:{minutes:D2}");
        }
    }
}
