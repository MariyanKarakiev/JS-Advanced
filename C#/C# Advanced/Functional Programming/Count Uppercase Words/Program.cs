using System;
using System.Linq;
namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> checker = str => str[0] == str.ToUpper()[0];

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => checker(w))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
