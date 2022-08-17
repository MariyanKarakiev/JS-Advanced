using System;
using System.Text.Json;

namespace Lecture____JSON_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                FirstName = "petur",
                LastName = "petrov",
                DateOfBirth = new DateTime(1998, 11, 11),
                Age = 23
            };

            string serializedPerson = JsonSerializer.Serialize(person);

            Console.WriteLine(serializedPerson);

            var anotherPerson = JsonSerializer.Deserialize<Person>(serializedPerson);
            Console.WriteLine(anotherPerson);

        }
    }
}
