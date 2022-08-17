using System;

namespace Retake_Exam_Reload
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Decode")
            {
                switch (input[0])
                {
                    case "Insert":
                        {
                            message = message.Insert(int.Parse(input[1]), input[2]);
                            break;
                        }

                    case "Move":
                        {
                            var lettersToMoveBack = message.Substring(int.Parse(input[1]));
                            var lettersF = message.Substring(0, int.Parse(input[1]));

                            message = lettersToMoveBack + lettersF;

                            break;
                        }

                    case "ChangeAll":
                        {
                            message = message.Replace(input[1], input[2]);
                            break;
                        }
                }
                input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
