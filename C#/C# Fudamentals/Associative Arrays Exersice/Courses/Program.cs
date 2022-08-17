using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();
            

            string[] input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end")
            {
                string module = input[0];
                string name = input[1];

                if (courses.ContainsKey(module))
                {
                    courses[module].Add(name);
                }
                else
                {
                    courses.Add(module, new List<string>());
                    courses[module].Add(name);
                }
                input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            Dictionary<string, List<string>> sorted = courses            
                .OrderByDescending(n => n.Value.Count).
                ToDictionary(x => x.Key, x => x.Value);
                

            foreach (var course in sorted)
            {
               course.Value.Sort();
                Console.WriteLine($"{course.Key}: {sorted[course.Key].Count}\n-- {string.Join("\n-- ",sorted[course.Key])}");
            }
        }
    }
}