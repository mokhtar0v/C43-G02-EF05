using CompanyG02.Data;
using CompanyG02.Data.DataSeed;
using CompanyG02.Data.Models;


//using CompanyG02.Data.Models;
//using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyG02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (CompanyDBContext companyDBContext = new CompanyDBContext())
            {

                #region Add
                //Employee emp01 = new Employee() { Name = "Nada", Age = 26, Salary = 9_000, Email = "Nada@gmail.com" };
                //Employee emp02 = new Employee() {Id=1,  Name = "Rana", Age = 26, Salary = 8_000, Email = "Rana@gmail.com" };

                //Console.WriteLine(companyDBContext.Entry(emp01).State);//Detached
                //Console.WriteLine(companyDBContext.Entry(emp02).State);//Detached

                //companyDBContext.ChangeTracker.QueryTrackingBehavior=QueryTrackingBehavior.TrackAll;//Default Behaviour

                //Employee emp04 = new Employee() { Id = 3, Name = "Omar", Age = 26, Salary = 8_000, Email = "Rana@gmail.com" };

                //companyDBContext.Set<Employee>().Add(emp04); // .toTable instead of dbSet
                // companyDBContext.Employees.Add(emp01); //as Local Sequence 
                // companyDBContext.Add(emp02);
                //companyDBContext.Entry(emp01).State=EntityState.Added;

                #endregion
                #region Get And Update
                //var emp = (from e in companyDBContext.Employees
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //if(emp is not null)
                //{
                //    Console.WriteLine(companyDBContext.Entry(emp).State);
                //    Console.WriteLine(emp.Name);
                //    Console.WriteLine(emp.Email);
                //    emp.Salary = 10_000;
                //    Console.WriteLine(companyDBContext.Entry(emp).State);

                //}
                #endregion

                #region Part03

                //var emp = (from e in companyDBContext.Employees.Include(e=>e.Department).ThenInclude(d=>d.Employees)
                //           where e.Id == 3
                //           select e).FirstOrDefault();

                //companyDBContext.Entry(emp).Reference(nameof(Employee.Department)).Load();

                //if (emp is not null)
                //{
                //    Console.WriteLine($"Employee: {emp.Name}, Department: {emp.Department?.Name ?? "Not Found"}");
                //}

                //var dept = (from d in companyDBContext.Departments.Include(d=>d.Employees)
                //            where d.DepartmentId == 1
                //            select d).FirstOrDefault();

                //if(dept is not null)
                //{
                //    Console.WriteLine($"Department :{dept.DepartmentId}, Name : {dept.Name}");
                //    foreach(var item in dept.Employees)
                //    {
                //        Console.WriteLine($"Employee : {item.Name}");
                //    }
                //}
                #endregion

                #region Part04

                #endregion

                #region LazyLoading
                var emp = (from e in companyDBContext.Employees.Include(e => e.Department).ThenInclude(d => d.Employees)
                           where e.Id == 3
                           select e).FirstOrDefault();

                if (emp is not null)
                {
                    Console.WriteLine($"Employee: {emp.Name}, Department: {emp.Department?.Name ?? "Not Found"}");
                }

                #endregion

                //CompanyDBContextSeed.Seed(companyDBContext);

                #region left_outer_join..cross_join
                //var leftoutjoinres = companyDBContext.Departments.GroupJoin(companyDBContext.Employees,
                //    d => d.DepartmentId,
                //    e => e.DepartmentId,
                //    (department, employees) => new
                //    {
                //        department,
                //        employees = employees.DefaultIfEmpty()
                //    }).SelectMany(gColl => gColl.employees, (gColl, emp) => new 
                //    {
                //        emp,
                //        gColl.department
                //    });

                //foreach(var item in leftoutjoinres)
                //{
                //    Console.WriteLine($"{item.department.Name} : {item.emp?.Name??"No Emp"}");
                //}

                var crossJoinRes = from d in companyDBContext.Departments
                                   from e in companyDBContext.Employees
                                   select new
                                   {
                                       e,
                                       d
                                   };
                foreach(var item in crossJoinRes)
                {
                    Console.WriteLine($"{item.d.Name} : {item.e.Name}");
                }
                #endregion
            }
        }
    }
}
