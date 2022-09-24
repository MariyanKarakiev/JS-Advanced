using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Merge_Files
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader reader1 = new StreamReader("FileOne.txt"))
            {
                int[] numbers1 = (await reader1.ReadToEndAsync()).Split("\n").Select(int.Parse).ToArray();

                using (StreamReader reader2 = new StreamReader("FileTwo.txt"))
                {
                    int[] numbers2 = (await reader2.ReadToEndAsync()).Split("\n").Select(int.Parse).ToArray();

                    using (StreamWriter writer = new StreamWriter("output.txt"))
                    {
                        for (int i = 0; i < (numbers2.Length > numbers1.Length ? numbers2.Length : numbers1.Length); i++)
                        {
                            if (i < numbers1.Length)
                            {
                                await writer.WriteLineAsync($"{numbers1[i]}");
                            }

                            if (i < numbers2.Length)
                            {
                                await writer.WriteLineAsync($"{numbers2[i]}");
                            }
                        }
                    }
                }
            }
        }
    }
}
