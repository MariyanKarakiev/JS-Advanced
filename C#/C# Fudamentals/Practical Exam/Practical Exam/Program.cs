using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Practical_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] command = Console.ReadLine().Split(' ');
            StringBuilder sb = new StringBuilder();

            sb.Append(input);

            while (command[0] != "Complete")
            {
                switch (command[0])
                {
                    case "Make":
                        {
                            int index = int.Parse(command[2]);

                            if (command[1] == "Upper")
                            {
                                char upper = char.ToUpper(sb[index]);
                                sb.Replace(sb[index], upper);
                                Console.WriteLine(sb);
                            }

                            else if (command[1] == "Lower")
                            {
                                char upper = char.ToLower(sb[index]);
                                sb.Replace(sb[index], upper);
                                Console.WriteLine(sb);
                            }
                            break;
                        }

                    case "Insert":
                        {
                            sb.Insert(int.Parse(command[1]), command[2]);
                            Console.WriteLine(sb);
                            break;
                        }

                    case "Replace":
                        {
                            int number = char.Parse(command[1]) - '0';
                            int sum = (number + int.Parse(command[2])) + '0';
                            string newchar = Convert.ToChar(sum).ToString();

                            sb.Replace(command[1], newchar);
                            Console.WriteLine(sb);
                            break;
                        }
                    default:
                        break;
                        
                    case "Validation":
                        {
                            Regex validation1 = new Regex(@"\w+\*");
                            Regex validation2 = new Regex(@"[0-9]");
                            Regex validation3 = new Regex(@"[A-Z]");
                            Regex validation4 = new Regex(@"[a-z]");

                            if (sb.Length <= 8)
                            {
                                Console.WriteLine("Password must be at least 8 characters long!");
                            }
                            if (validation1.IsMatch(sb.ToString()))
                            {
                                Console.WriteLine("Password must consist only of letters, digits and _!");
                            }
                            if (!validation3.IsMatch(sb.ToString()))
                            {
                                Console.WriteLine("Password must consist at least one uppercase letter!");
                            }
                            if (!validation4.IsMatch(sb.ToString()))
                            {
                                Console.WriteLine("Password must consist at least one lowercase letter!");
                            }
                            if (!validation2.IsMatch(sb.ToString()))
                            {
                                Console.WriteLine("Password must consist at least one digit!");
                            }



                            break;
                        }
                }

                command = Console.ReadLine().Split(' ');
            }
            
        }
    }
}
