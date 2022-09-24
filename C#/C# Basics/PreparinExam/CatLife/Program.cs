using System;

namespace CatLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string cat = Console.ReadLine();
            string sex = Console.ReadLine();

            switch (cat)
            {
                case "British Shorthair":
                    if (sex == "m")
                    {
                        Console.WriteLine($"{(13 * 12) / 6} cat months");
                    }
                    if (sex == "f")
                    {
                        Console.WriteLine($"{(14 * 12) / 6} cat months");
                    }
                    break;
                case "Siamese":
                    if (sex == "m")
                    {
                        Console.WriteLine($"{(15 * 12) / 6} cat months");
                    }
                    if (sex == "f")
                    {
                        Console.WriteLine($"{(16 * 12) / 6} cat months");
                    }
                    break;
                case "Persian":
                    if (sex == "m")
                    {
                        Console.WriteLine($"{(14 * 12) / 6} cat months");
                    }
                    if (sex == "f")
                    {
                        Console.WriteLine($"{(15 * 12) / 6} cat months");
                    }
                    break;
                case "Ragdoll":
                    if (sex == "m")
                    {
                        Console.WriteLine($"{(16 * 12) / 6} cat months");
                    }
                    if (sex == "f")
                    {
                        Console.WriteLine($"{(17 * 12) / 6} cat months");
                    }
                    break;
                case "American Shorthair":
                    if (sex == "m")
                    {
                        Console.WriteLine($"{(12 * 12) / 6} cat months");
                    }
                    if (sex == "f")
                    {
                        Console.WriteLine($"{ (13 * 12) / 6} cat months");
                    }
                    break;
                case "Siberian":
                    if (sex == "m")
                    {
                        Console.WriteLine($"{(11 * 12) / 6} cat months");
                    }
                    if (sex == "f")
                    {
                        Console.WriteLine($"{(12 * 12) / 6} cat months");
                    }
                    break;
                default:
                    Console.WriteLine($"{cat} is invalid cat!");
                    break;
            }
        }
    }
}