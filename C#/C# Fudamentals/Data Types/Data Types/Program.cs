using System;

namespace Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = int.Parse(Console.ReadLine());
            float km = m / 1000.0f;
            Console.WriteLine($"{km:f2}");
        }
    }
}
