using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<(string, int), int, bool> younger = (person, age) => person.Item2 < age;
            Func<(string, int), int, bool> older = (person, age) => person.Item2 >= age;

            int n = int.Parse(Console.ReadLine());

            List<(string, int)> people = new List<(string, int)>();

            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = token[0];
                int age = int.Parse(token[1]);

                people.Add((name, age));
            }
            string condition = Console.ReadLine();
            int ageToBorder = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();



            switch (condition)
            {
                case "younger":

                    people.Where(p => younger(p, ageToBorder))
                        .ToList()
                        .ForEach(p => Print(format, p.Item1, p.Item2));
                    break;
                case "older":

                    people.Where(p => older(p, ageToBorder))
                        .ToList()
                        .ForEach(p => Print(format, p.Item1, p.Item2));
                    break;
            }
        }
        static void Print(string format, string name, int age)
        {
            switch (format)
            {
                case "age":
                    Console.WriteLine(age);
                    break;
                case "name age":
                    Console.WriteLine($"{name} - {age}");
                    break;
                case "name":
                    Console.WriteLine(name);
                    break;
            }
        }

    }
}
