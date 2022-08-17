using System;
using System.IO;
using System.Threading.Tasks;

namespace Streams__Files_and_Directories
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader text = new StreamReader("Input.txt"))
            {     
                string line = await text.ReadLineAsync();
                var counter = 1;

                using (StreamWriter output = new StreamWriter("Output.txt"))
                {
                    while (line!=null)
                    {
                       await output.WriteLineAsync($"{counter}. {line}");
                        counter++;
                        line = await text.ReadLineAsync();
                    }
                }
            }

        }
    }
}
