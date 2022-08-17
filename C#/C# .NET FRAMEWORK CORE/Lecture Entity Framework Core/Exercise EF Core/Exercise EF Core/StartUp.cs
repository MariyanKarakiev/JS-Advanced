using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var dbContext = new SoftUniContext())
            {
                var output = RemoveTown(dbContext);
                Console.WriteLine(output);
            }
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Employees
                  .OrderBy(e => e.EmployeeId)
                  .Select(e => new
                  {
                      Info = $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}"
                  })
                  .ToList()
                  .ForEach(e => sb.AppendLine(e.Info));

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    Info = $"{e.FirstName} - {e.Salary:F2}"
                })
                .ToList()
                .ForEach(e => sb.AppendLine(e.Info));

            return sb.ToString();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList()
                .ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}"));

            return sb.ToString();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var address = new Address
            {
                TownId = 4,
                AddressText = "Vitoshka 15"
            };

            context.Addresses.Add(address);

            var nakovEmployee = context.Employees
                                       .First(e => e.LastName == "Nakov");

            nakovEmployee.Address = address;

            context.SaveChanges();

            context.Employees
                   .OrderByDescending(e => e.AddressId)
                   .Select(e => e.Address.AddressText)
                   .Take(10)
                   .ToList()
                   .ForEach(e => sb.AppendLine(e));

            return sb.ToString();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                {
                    EmployeeName = $"{e.FirstName} {e.LastName}",
                    ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                                .Select(ep => new
                                {
                                    ProjectName = ep.Project.Name,
                                    StartDate = ep.Project.StartDate,
                                    EndDate = ep.Project.EndDate
                                })
                                .Where(ep => ep.StartDate.Year >= 2001 && ep.StartDate.Year <= 2003)
                })
                .Where(e => e.Projects.Count() != 0)
                .Take(10)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.EmployeeName} - Manager: {e.ManagerName}");

                foreach (var project in e.Projects)
                {
                    string EndDate;
                    if (project.EndDate == null)
                    {
                        EndDate = "not finished";
                    }
                    else
                    {
                        EndDate = project.EndDate.ToString();
                    }
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {EndDate}");
                }
            }
            return sb.ToString();
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Addresses
                  .OrderByDescending(a => a.Employees.Count)
                   .ThenBy(a => a.Town.Name)
                   .ThenBy(a => a.AddressText)
                 .Select(a => new
                 {
                     EmployeesCount = a.Employees.Count,
                     a.AddressText,
                     a.Town.Name
                 })
                .Take(10)
                   .ToList()
                   .ForEach(a => sb.AppendLine($"{a.AddressText}, {a.Name} - {a.EmployeesCount} employees"));

            return sb.ToString();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                    .OrderBy(ep => ep.Project.Name)
                    .Select(ep => new
                    {
                        ep.Project.Name
                    })
                })
                .ToList();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var project in e.Projects)
                {
                    sb.AppendLine(project.Name);
                }
            }

            return sb.ToString().Trim();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => new
                    {
                        d.Name,
                        d.Manager.FirstName,
                        d.Manager.LastName,
                        Employees = d.Employees
                                     .OrderBy(e => e.FirstName)
                                     .ThenBy(e => e.LastName)
                                     .Select(e => new
                                     {
                                         e.FirstName,
                                         e.LastName,
                                         e.JobTitle
                                     })
                    })
                    .ToArray();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.FirstName} {d.LastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                   .OrderByDescending(p => p.StartDate)
                   .Take(10)
                    .OrderBy(p => p.Name)
                   .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString());
            }



            return sb.ToString().Trim();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Salary = e.Salary + e.Salary * 0.12M
                })
               .OrderBy(e => e.FirstName)
               .ThenBy(e => e.LastName)
               .ToList()
               .ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})"));

            return sb.ToString();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
               .OrderBy(e => e.FirstName)
               .ThenBy(e => e.LastName)
               .ToList()
               .ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));

            return sb.ToString();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeeProject = context.EmployeesProjects
                             .Where(e => e.ProjectId == 2)
                             .ToList();

            var project = context.Projects
                             .First(e => e.ProjectId == 2);

            foreach (var ep in employeeProject)
            {
                context.EmployeesProjects.Remove(ep);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            context.Projects
                   .Take(10)
                   .ToList()
                   .ForEach(p => sb.AppendLine(p.Name));

            return sb.ToString();
        }
        public static string RemoveTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
          
            Address[] addressesInSeattle = context.Addresses
                                        .Where(a => a.Town.Name == "Seattle")
                                        .ToArray();

            var countOfRemovedAddresses = addressesInSeattle.Length;

            var employeesInSeattle = context.Employees
                .ToArray()
                .Where(e => addressesInSeattle.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (var employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }

            var town = context.Towns
                        .First(t => t.Name == "Seattle");

            context.RemoveRange(addressesInSeattle);
            context.Remove(town);
            context.SaveChanges();

            return $"{countOfRemovedAddresses} addresses in Seattle were deleted";
        }
    }
}

