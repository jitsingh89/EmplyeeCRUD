﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeUI.Models
{
    public class EmployeeModel
    {
        [Display(Name = "EmployeeCode")]
        public int EmpCode { get; set; }

        [Display(Name = "FirstName")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Display(Name = "Salary")]
        public decimal? Salary { get; set; }
    }
}