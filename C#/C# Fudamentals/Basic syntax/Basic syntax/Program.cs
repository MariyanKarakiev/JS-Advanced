using System;

namespace Basic_syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var grade = 0.0;

            if (double.TryParse(Console.ReadLine(), out grade))
            {
                Console.WriteLine($"Name: {name}, Age: {age}, Grade: {grade:F2}");
            }
            else
            {
                Console.WriteLine("Enter valid grade!");
            }

        }
    }
}
