using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Word_Count
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, int> wordsN = new Dictionary<string, int>();

            using (StreamReader wordsReader = new StreamReader("words.txt"))
            {
                string[] words = (await wordsReader.ReadToEndAsync()).Split().ToArray();

                using (StreamReader textReader = new StreamReader("text.txt"))
                {
                    string[] text = (await textReader.ReadToEndAsync())
                        .Split(new string[]
                        { ", ", " ", "-","!","?",".", "…", "\r\n", }
                        , StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    for (int i = 0; i < text.Length; i++)
                    {
                        string wordFromText = text[i].ToLower();
                        if (wordFromText == words[0] || wordFromText == words[1] || wordFromText == words[2])
                        {
                            if (!wordsN.ContainsKey(wordFromText))
                            {
                                wordsN.Add(wordFromText, 0);
                            }
                            wordsN[wordFromText]++;
                        }
                    }
                }
            }

            var orderedWords = wordsN.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in orderedWords)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
