using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lekture
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var employees = new List<Employee>();

            SqlConnection conn = new SqlConnection("Server=localhost, 1433;Database=SoftUni; User Id=sa; Password=Docker21; TrustServerCertificate=True;");
            await conn.OpenAsync();

            using (conn)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE Salary > 50000", conn);

                using (cmd)
                {
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    using (reader)
                    {
                        while (await reader.ReadAsync())
                        {
                            employees.Add(new Employee()
                            {
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Salary = (decimal)reader["Salary"]
                            });
                        }
                    }
                }
            }
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Salary}");
            }
        }
    }
}