using System;

namespace GlasniBukvi
{
    class Program
    {
        static void Main(string[] args)
        {

            int sum = 0;
            string input = Console.ReadLine();
            for (int p = 0; p < input.Length; p++)
            {

                switch (input[p])
                {
                    case 'a':
                        {
                            sum += 1;
                        }
                        break;
                    case 'e':
                        {
                            sum += 2;
                        }
                        break;

                    case 'u':
                        {
                            sum += 5;
                        }
                        break;
                    case 'i':
                        {
                            sum += 3;
                        }
                        break;
                    case 'o':
                        {
                            sum += 4;
                        }
                        break;

                }
            }
            Console.WriteLine(sum);
        }
    }
}
 