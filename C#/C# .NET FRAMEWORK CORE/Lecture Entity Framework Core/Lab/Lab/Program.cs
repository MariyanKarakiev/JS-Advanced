using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                var employees = dbContext.Employees
                    .Where(e => e.Department.Name == "Marketing")
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Department = e.Department.Name
                    })
                  .ToQueryString();

                Console.WriteLine(employees);
                foreach (var item in employees)
                {
                   // Console.WriteLine($"{item.Name}, {item.Department}");
                }

            }
        }
    }
}

