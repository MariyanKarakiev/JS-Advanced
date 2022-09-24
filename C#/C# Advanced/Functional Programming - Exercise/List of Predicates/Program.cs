using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] predicates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();

            Func<int[], int, bool> condition = (preds, number) =>
                  {
                      bool isDivisible = true;

                      for (int i = 0; i < preds.Length; i++)
                      {
                          if (number % preds[i] != 0)
                          {
                              isDivisible = false;
                          }
                      }
                      return isDivisible;
                  };

            Console.WriteLine(string.Join(' ', Enumerable.Range(1, n).Where(p => condition(predicates, p))));


        }
    }
}