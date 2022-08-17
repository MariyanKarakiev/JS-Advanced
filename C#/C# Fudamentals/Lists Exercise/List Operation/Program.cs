using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                string[] token = input.Split();

                if (input == "End")
                {
                    break;
                }
              
                else
                {
                    
                    if (token[1] == "left")
                    {
                        for (int i = 0; i < int.Parse(token[2]); i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                    }
               
                    else if (token[1] == "right")
                    {
                        for (int i = 0; i < int.Parse(token[2]); i++)
                        {
                            numbers.Insert(0, numbers[numbers.Count - 1]);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                  
                    else
                    {
                        switch (token[0])
                        {
                            case "Add":

                                numbers.Add(int.Parse(token[1]));
                                break;

                            case "Remove":

                                if (IsValid(int.Parse(token[1]), numbers.Count))
                                {
                                    numbers.RemoveAt(int.Parse(token[1]));
                                }

                                else
                                {
                                    Console.WriteLine("Invalid index");
                                }
                                break;


                            case "Insert":

                                if (int.Parse(token[2]) >= 0 && int.Parse(token[2]) < numbers.Count)
                                {
                                    numbers.Insert(int.Parse(token[2]), int.Parse(token[1]));
                                }

                                else
                                {
                                    Console.WriteLine("Invalid index");
                                }
                                break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        static bool IsValid(int token, int numbers)
        {
            if (token >= 0 && token <= numbers)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


