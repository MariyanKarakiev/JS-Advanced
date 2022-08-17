using System;

namespace PreparinExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int VideoPrice = int.Parse(Console.ReadLine());
            int AdapterPrice = int.Parse(Console.ReadLine());
            double TokPrice = double.Parse(Console.ReadLine());
            double Profit = double.Parse(Console.ReadLine());                  
            Console.WriteLine((VideoPrice * 13) + (AdapterPrice * 13) + 1000);
            Console.WriteLine(Math.Ceiling(((VideoPrice * 13) + (AdapterPrice * 13) + 1000) / ((Profit - TokPrice) * 13)));
        }
    }
}
