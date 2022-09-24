using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int wide = int.Parse(Console.ReadLine());
            int longg = int.Parse(Console.ReadLine());
            int high = int.Parse(Console.ReadLine());
            int S = wide * longg * high;
            string input = Console.ReadLine();
            int box = 0;
            while (input != "Done")
            {
                box = int.Parse(input);
                S -= box;
                if (S < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(S)} Cubic meters more.");
                    
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Done") { Console.WriteLine($"{S} Cubic meters left."); }
        }
    }
}
                    
