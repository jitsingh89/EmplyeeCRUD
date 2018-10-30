using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Models
{
    public class EmployeeModel
    {
        public int EmpCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public decimal? Salary { get; set; }
    }
}