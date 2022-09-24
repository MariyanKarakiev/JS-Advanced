using System;
using System.IO;
using System.Threading.Tasks;

namespace Slice_file
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int parts = 4;
            byte[] buffer = new byte[4096];
            int totalBytes = 0;

            using (FileStream reader = new FileStream("sliceMe.txt", FileMode.Open, FileAccess.Read))
            {
                int sizetxt = (int)Math.Ceiling((decimal)reader.Length / parts);
               
                for (int i = 1; i <= parts; i++)
                {
                    int readBytes = 0;

                    using (FileStream writer = new FileStream(($"Text-{i}.txt"), FileMode.Create, FileAccess.Write))
                    {
                        while (readBytes < sizetxt && totalBytes < reader.Length)
                        {
                            int bytesToRead = Math.Min(buffer.Length, sizetxt - readBytes);
                            int bytes = await reader.ReadAsync(buffer, 0, bytesToRead);
                            await writer.WriteAsync(buffer, 0, bytes);
                            readBytes += bytes;
                            totalBytes += bytes;
                        }
                    }
                }
            }
        }
    }
}
