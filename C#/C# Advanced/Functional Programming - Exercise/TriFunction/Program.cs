using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Func<string, int, bool> validation = (name, number) =>
                    {
                        return name.ToCharArray().Select(n => (int)n).Sum() >= number;
                    };

            Func<string[], int, Func<string, int, bool>, string> foundName = (nnames, number, func) =>
            {
                return nnames.FirstOrDefault(n => validation(n, number));
            };

            Console.WriteLine(foundName(names, n, validation));
        }
    }
}
