using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var regex = new Regex("[#|](?<kalor>[a-zA-Z])\\1[#|](?<date>[0-9]+(/[0-9]+)+)[#|](?<num>[0-9]+)[#|*]", RegexOptions.IgnoreCase);         

            MatchCollection matches = regex.Matches(input);
          
            var list =new List<string>();

            foreach (Match match in matches)
            {              
                list.Add(match.Groups["kalor"].Value);
            }


            Console.WriteLine(string.Join(' ', list));
               


        }
    }
}
