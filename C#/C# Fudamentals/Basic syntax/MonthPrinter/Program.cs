using System;

namespace MonthPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            switch (country)
            {
                case "England":
                case "USA":
                    Console.WriteLine("English");
                    return;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    return;
                default:
                    Console.WriteLine("unknown");
                    return;
            }
        }
    }
}
