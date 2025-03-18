using DatabaseFirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwindDbContext context = new NorthwindDbContext();

            int count = 3;
            var res = context.Categories.FromSqlRaw("select top(3)*\r\nfrom Categories");
            var categories = context.Categories.FromSqlInterpolated($"select top({count})*\r\nfrom Categories");

            var catID = 1;
            context.Database.ExecuteSqlInterpolated($"update Categories\r\nset CategoryName = 'TestCat'\r\nwhere CategoryID = {catID}");

        }
    }
}
