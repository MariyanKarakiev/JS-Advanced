using System;
using System.IO;
using System.Threading.Tasks;

namespace Odd_Lines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                int counter = 1;
                string line = await reader.ReadLineAsync();

                using (StreamWriter writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            await writer.WriteLineAsync(line);
                        }
                        counter++;
                        line = await reader.ReadLineAsync();
                    }
                }
            }
        }
    }
}
