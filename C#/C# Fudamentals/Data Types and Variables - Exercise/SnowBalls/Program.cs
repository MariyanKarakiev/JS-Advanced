using System;
using System.Numerics;

namespace SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            BigInteger snowballValue = 0;
            string result="";

            if (n >= 0)
            {
                for (int i = 0; i < n; i++)
                {
                    short snowballSnow = short.Parse(Console.ReadLine());
                    short snowballTime = short.Parse(Console.ReadLine());
                    sbyte snowballQuality = sbyte.Parse(Console.ReadLine());

                    if (BigInteger.Pow((snowballSnow / snowballTime), snowballQuality) > snowballValue)
                    {
                        snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                        result = ($"{snowballSnow} : {snowballTime} = {snowballValue:F0} ({snowballQuality})");
                    }

                }

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}
