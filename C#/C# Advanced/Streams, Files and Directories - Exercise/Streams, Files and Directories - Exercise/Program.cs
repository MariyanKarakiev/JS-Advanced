using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Streams__Files_and_Directories___Exercise
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int counter = 1;
                string line = await reader.ReadLineAsync();

                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            line.Replace('?', '@');
                            line.Replace('!', '@');
                            line.Replace('.', '@');
                            line.Replace('-', '@');
                            line.Replace(',', '@');
                            line.Reverse();
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

