using System;

namespace Data_Types_and_Variables___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            long n1 = long.Parse(Console.ReadLine());
            long n2 = long.Parse(Console.ReadLine());
            long n3 = long.Parse(Console.ReadLine());
            long n4 = long.Parse(Console.ReadLine());
          
            Console.WriteLine(((n1+n2)/n3)*n4);
        }
    }
}
