using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte n1 = sbyte.Parse(Console.ReadLine());
            sbyte n2 = sbyte.Parse(Console.ReadLine());
            sbyte n3 = sbyte.Parse(Console.ReadLine());
            short students = short.Parse(Console.ReadLine());

            short efficiency = (short)(n1 + n2 + n3);
            int time = (int)Math.Ceiling((students /(double)efficiency));
            time += time / 4;
           
            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
