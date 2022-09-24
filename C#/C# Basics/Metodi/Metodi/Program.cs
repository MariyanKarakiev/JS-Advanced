using System;

namespace Metodi
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstMonth = int.Parse(Console.ReadLine());
            int secondMonth = int.Parse(Console.ReadLine());
            Console.WriteLine(Razlika(firstMonth, secondMonth));

        }
        static int Razlika(int firstMonth, int secondMonth)
        {
            return Math.Max(firstMonth, secondMonth) - Math.Min(firstMonth, secondMonth);
        }
        public class Status
        {
            public Status() { }
            public string Name(int l)
            {
                switch (l)
                {
                    case 1:
                        return "January";
                    case 2:
                        return "February";
                    case 3:
                        return "March";
                    case 4:
                        return "April";
                    case 5:
                        return "May";
                    case 6:
                        return "June";
                    case 7:
                        return "Jule";
                    case 8:
                        return "August";
                    case 9:
                        return "Need More Info";
                    case 10:
                        return "Need More Info";
                    case 11:
                        return "Need More Info";
                    case 12:
                        return "Need More Info";
                    default:
                        return ("Unknown");
                }
            }

        }
    }
}
