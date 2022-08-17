using System;
using System.Collections.Generic;
using System.Linq;

namespace Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            List<int> numbers2 = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            List<int> numbersAll = new List<int>();
           
            Merge(numbers1, numbers2, numbersAll);
            
            GetExess(numbers1, numbers2, numbersAll);
            
            Console.WriteLine(string.Join(" ", numbersAll));
        }

        static private void Merge(List<int> numbers1, List<int> numbers2, List<int> numbersAll)
        {
            for (int i = 0; i < Math.Min(numbers1.Count, numbers2.Count); i++)
            {
                if (numbers1.Count > numbers2.Count)
                {
                    numbersAll.Add(numbers1[i]);
                    numbersAll.Add(numbers2[i]);
                }
                else
                {
                    numbersAll.Add(numbers2[i]);
                    numbersAll.Add(numbers1[i]);
                }
            }
        }
       
        static private void GetExess(List<int> longer, List<int> shorter, List<int> numbersAll)
        {
            for (int i = shorter.Count; i < longer.Count; i++)
            {
                numbersAll.Add(longer[i]);
            }
        }
    }
}
