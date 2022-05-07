using System;

namespace Milko_If_Condition
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            if (grade > 6)
            {
                Console.WriteLine("High grade");
            }
            else if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
            else if (grade >= 4.50)
            {
                Console.WriteLine("Bravo!");
            }
            else if (grade >= 3.50)
            {
                Console.WriteLine("Dobur!");
            }
            else if (grade >= 2.50)
            {
                Console.WriteLine("Sreden!");
            }
            else if (grade < 2)
            {
                Console.WriteLine("Low grade");
            }
            else
            {
                Console.WriteLine("Slab!");
            }
        }
    }
}
