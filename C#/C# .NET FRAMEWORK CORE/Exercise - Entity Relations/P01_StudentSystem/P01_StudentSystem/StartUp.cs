using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new StudentSystemContext();

            dbContext.Database.EnsureCreated();

            Console.WriteLine("Delete?");
            if (Console.ReadLine() == "y")
            {
                dbContext.Database.EnsureDeleted();
                Console.WriteLine("DELETED");
            }
        }
    }
}
