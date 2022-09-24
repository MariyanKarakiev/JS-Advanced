using System;

namespace Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggestKeg=0;
            string modelKeg="";
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                if (biggestKeg< Math.PI * radius * radius * height)
                {
                    biggestKeg = Math.PI * radius * radius * height;
                    modelKeg = model;
                }
                
            }
            Console.WriteLine(modelKeg);
        }
    }
}
