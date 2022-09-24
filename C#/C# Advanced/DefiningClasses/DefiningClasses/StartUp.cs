using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family member = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                member.AddMember(new Person(tokens[0], int.Parse(tokens[1])));
            }

            // Console.WriteLine(member.GetOldestMember().ToString());

            var olds = member.GetAllPeopleAbove30();

            Console.WriteLine(string.Join(Environment.NewLine, olds));

        }
    }
}
