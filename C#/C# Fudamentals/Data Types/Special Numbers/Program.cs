using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i++)
            {
                int num = i;
                int sum=0;
                bool k = false;
                while (num > 0)
                {
                    sum += num % 10;
                    num = num / 10;
                }
               if(sum==5||sum==7||sum==11)
                {
                    k= true;
                }          
                Console.WriteLine($"{i} -> {k}");
                
            }
           
        }
    }
}
