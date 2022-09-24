using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int i = 1;
            double average =0.0;
            int excluded = 0;
            while (i <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                average += grade;
                if (grade < 4.00)
                {
                    excluded += 1;

                    if (excluded > 1)
                    {
                        Console.WriteLine($"{input} has been excluded at {i} grade");
                        break;
                    }
               
                }
                else 
                {
                    if (i < 12)
                    {
                        i++;
                        continue;
                    }
                    else if (i == 12)
                    {
                        Console.WriteLine($"{input} graduated. Average grade: {average / 12:F2}");
                        break;
                    }
                }         
           
            }
       
        }
    }
}
