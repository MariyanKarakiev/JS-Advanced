using System;

namespace Telephony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');
            var sites = Console.ReadLine().Split(' ');

            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else
                    {
                        Console.WriteLine(smartPhone.Call(number));
                    }
                }
                catch (NumberExeption ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(site));
                }
                catch (URLExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
