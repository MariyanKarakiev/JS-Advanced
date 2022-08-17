using System;

namespace Sign_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberType(int.Parse(Console.ReadLine()));
        }
        public static void NumberType(int number)
        {
            if (number<0)
            {
                Console.WriteLine($"The number - {number} is negative.");
            }
            else if (number == 0)
            {
                Console.WriteLine($"The number - {number} is zero.");
            }
            else
            {
                Console.WriteLine($"The number - {number} is positive");
            }
        }
    }
}
