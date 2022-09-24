using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               
               .ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int index1 = 0;
                int index2 = 0;
                switch (tokens[0])
                {
                    case "reverse":
                        {
                            index1 = int.Parse(tokens[2]);
                            index2 = int.Parse(tokens[4]);

                            string[] numbersToSort = new string[index2];

                            for (int i = 0; i < index2; i++)
                            {
                                numbersToSort[i] = numbers[index1 + i];
                            }

                            Array.Reverse(numbersToSort);

                            for (int i = 0; i < index2; i++)
                            {
                                numbers[index1 + i] = numbersToSort[i];
                            }


                            break;
                        }
                    case "sort":
                        {
                            index1 = int.Parse(tokens[2]);
                            index2 = int.Parse(tokens[4]);

                            string[] numbersToSort = new string[index2];

                            for (int i = 0; i < index2; i++)
                            {
                                numbersToSort[i] = numbers[index1 + i];
                            }

                            Array.Sort(numbersToSort);

                            for (int i = 0; i < index2; i++)
                            {
                                numbers[index1 + i] = numbersToSort[i];
                            }


                            break;
                        }
                    case "remove":
                        {
                            index1 = int.Parse(tokens[1]);
                            while (index1 - 1 >= 0)
                            {
                                numbers.RemoveAt(index1 - 1);
                                index1--;
                            }

                            break;
                        }
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
