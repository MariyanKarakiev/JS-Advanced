using System;

namespace Refractor_1
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Length: ");
            var lenght = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            var width = double.Parse(Console.ReadLine());
            Console.Write("Heigth: ");
            var heigth = double.Parse(Console.ReadLine());

            double V = (lenght * width * heigth) / 3;
            Console.WriteLine($"Pyramid Volume: {V:f2}");
        }
    }
}
