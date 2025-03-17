using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyG02.Data.Models
{
    public class EmployeeDepartments
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string? EmployeeName { get; set; }
        public int? EmployeeID { get; set; }
    }
}
