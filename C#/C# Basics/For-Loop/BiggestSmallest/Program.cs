using System;

namespace BiggestSmallest
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int MaxNum = 0;
            int MinNum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= MaxNum)
                {
                    MaxNum=num;
                }
                else if(num<MinNum)
                {
                    MinNum=num;
                }
            }
            Console.WriteLine($"Max number: {MaxNum}");
            Console.WriteLine($"Min number: {MinNum}");
        }
    }
}
