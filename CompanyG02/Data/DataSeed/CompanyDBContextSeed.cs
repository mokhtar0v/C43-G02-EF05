using CompanyG02.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompanyG02.Data.DataSeed
{
    internal static class CompanyDBContextSeed
    {
        public static void Seed(CompanyDBContext dBContext)
        {

            if (!dBContext.Departments.Any())
            {
                var departmentsData = File.ReadAllText("E:\\Temp\\ASP.NET\\C#\\Entity Framework\\Session4 EF\\CompanyG02Solution\\CompanyG02\\Data\\DataSeed\\departments.json");
                var departments = JsonSerializer.Deserialize<List<Department>>(departmentsData);
                if (departments?.Count > 0)
                {
                    foreach (var department in departments)
                    {
                        dBContext.Departments.Add(department);
                    }
                    dBContext.SaveChanges();
                }
            }
            if (!dBContext.Employees.Any())
            {
                var employeesData = File.ReadAllText("E:\\Temp\\ASP.NET\\C#\\Entity Framework\\Session4 EF\\CompanyG02Solution\\CompanyG02\\Data\\DataSeed\\employees.json");
                var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData);
                if (employees?.Count > 0)
                {
                    foreach (var employee in employees)
                    {
                        dBContext.Employees.Add(employee);
                    }
                    dBContext.SaveChanges();
                }
            }

        }
    }
}
