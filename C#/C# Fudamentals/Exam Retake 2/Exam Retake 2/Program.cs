using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Exam_Retake_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            //char[] pass = password.Split().Select(char.Parse).ToArray();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Complete")
            {
                switch (input[0])
                {
                    case "Make":
                        {
                            int index = int.Parse(input[2]);

                            if (input[1] == "Upper")
                            {
                                password = password.Substring(0, index) + password.Substring(index, 1).ToUpper() + password.Substring(index + 1);
                                Console.WriteLine(password);
                            }
                            else if (input[1] == "Lower")
                            {
                                password = password.Substring(0, index) + password.Substring(index, 1).ToLower() + password.Substring(index + 1);
                                Console.WriteLine(password);
                            }
                            break;
                        }

                    case "Insert":
                        {
                            int index = int.Parse(input[1]);

                            if (index > password.Length||index<0)
                            {

                            }
                            else
                            {
                                password = password.Insert(int.Parse(input[1]), input[2]);
                                Console.WriteLine(password);
                            }
                            break;
                        }

                    case "Replace":
                        {
                            if(password.Contains(char.Parse(input[1])))
                            {
                                password = password.Replace(char.Parse(input[1]), (char)(int.Parse(input[2]) + (int)char.Parse(input[1])));
                                Console.WriteLine(password);
                            }
                            break;
                        }
                    case "Validation":
                        {
                            Regex validation1 = new Regex(@"\w+\*");
                            Regex validation2 = new Regex(@"[0-9]");
                            Regex validation3 = new Regex(@"[A-Z]");
                            Regex validation4 = new Regex(@"[a-z]");

                            if (password.Length < 8)
                            {
                                Console.WriteLine("Password must be at least 8 characters long!");
                            }
                            if (validation1.IsMatch(password))
                            {
                                Console.WriteLine("Password must consist only of letters, digits and _!");
                            }
                            if (!validation3.IsMatch(password))
                            {
                                Console.WriteLine("Password must consist at least one uppercase letter!");
                            }
                            if (!validation4.IsMatch(password))
                            {
                                Console.WriteLine("Password must consist at least one lowercase letter!");
                            }
                            if (!validation2.IsMatch(password))
                            {
                                Console.WriteLine("Password must consist at least one digit!");
                            }
                            break;
                        }
                }
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}