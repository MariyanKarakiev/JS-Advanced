using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            var obj = new Person();
           
            if (age > 15)
            {
                obj = new Person(name, age);
            }
            else
            {
                obj = new Child(name, age);
            }

            Console.WriteLine(obj);
        }
    }
}