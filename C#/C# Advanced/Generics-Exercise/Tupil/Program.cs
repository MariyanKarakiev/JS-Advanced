using System;

namespace Tupil
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split();
            string fullName = $"{info[0]} {info[1]}";
            string street = info[2];
            string city = info[3];

            var info2 = Console.ReadLine().Split();
            string Name = info2[0];
            int liters = int.Parse(info2[1]);
            string drunkOrNot = info2[2];
            bool drunk = drunkOrNot == "drunk" ? true : false;

            var info3 = Console.ReadLine().Split();
            string name = info3[0];
            double doubleNum = double.Parse(info3[1]);
            string sth = info3[2];


            var tuple1 = new Tuple<string, string, string>(fullName,street, city);
            var tuple2 = new Tuple<string, int, bool>(Name, liters, drunk);
            var tuple3 = new Tuple<string, double, string>(name, doubleNum, sth);

            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2} -> {tuple1.Item3}");
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2} -> {tuple2.Item3}");
            Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2} -> {tuple3.Item3}");
        }
    }
}
