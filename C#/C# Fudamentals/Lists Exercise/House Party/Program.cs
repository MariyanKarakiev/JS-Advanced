using System;
using System.Collections.Generic;
using System.Linq;

namespace House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> people = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();


                string[] token = input.Split();

                switch (token[2])
                {
                    case "going":

                        if (people.Contains(token[0]))
                        {
                            Console.WriteLine($"{token[0]} is already in the list!");
                            break;
                        }
                        else
                        {
                            people.Add(token[0]);
                            break;
                        }
                   
                    case "not":
                        
                        if (!people.Contains(token[0]))
                        {
                            Console.WriteLine($"{token[0]} is not in the list!");
                            break;
                        }
                       
                        else
                        {
                            people.Remove(token[0]);
                            break;
                        }
                }
            }

            Console.WriteLine(string.Join("\n", people));
        }
    }
}
