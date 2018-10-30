using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Get All Employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllEmployees()
        {
            IList<EmployeeModel> employees = null;

            using (var ctx = new EmployeeDBEntities())
            {
                employees = ctx.Employees
                            .Select(e => new EmployeeModel()
                            {
                                EmpCode = e.EmpCode,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Salary = e.Salary,
                                Designation = e.Designation
                            }).ToList<EmployeeModel>();
            }

            if (employees.Count == 0)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        /// <summary>
        /// Get Employee by employee code
        /// </summary>
        /// <param name="empCode">Employee Code</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetEmployeeByCode(int empCode)
        {
            EmployeeModel model = new EmployeeModel();
            using (var ctx = new EmployeeDBEntities())
            {
              
                var employee = ctx.Employees.Where(e => e.EmpCode == empCode)
                                                    .FirstOrDefault<Employee>();

                if (employee != null)
                {
                    model.EmpCode = employee.EmpCode;
                    model.FirstName = employee.FirstName;
                    model.LastName = employee.LastName;
                    model.Designation = employee.Designation;
                    model.Salary = employee.Salary;
                }
            }
            
            return Ok(model);
        }

        /// <summary>
        /// Save Employee details
        /// </summary>
        /// <param name="model">employee details</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SaveEmployee(EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid employee model !!");

            using (var ctx = new EmployeeDBEntities())
            {
                ctx.Employees.Add(new Employee()
                {
                    EmpCode = model.EmpCode,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Designation = model.Designation,
                    Salary = model.Salary
                });
                ctx.SaveChanges();

            }
            return Ok();
        }


        /// <summary>
        /// Update Employee details
        /// </summary>
        /// <param name="model">employee details</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateEmployee(EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid employee model !!");

            using (var ctx = new EmployeeDBEntities())
            {
                if (model != null)
                {
                    var employee = ctx.Employees.Where(e => e.EmpCode == model.EmpCode)
                                                  .FirstOrDefault<Employee>();

                    if (employee != null)
                    {
                        employee.FirstName = model.FirstName;
                        employee.LastName = model.LastName;
                        employee.Designation = model.Designation;
                        employee.Salary = model.Salary;
                        ctx.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            return Ok();
        }

        /// <summary>
        /// Get Employee
        /// </summary>
        /// <param name="empCode">Employee Code</param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteEmployeeByEmpCode(int empCode)
        {
            if (empCode <= 0)
                return BadRequest("employee code is not valid.");

            using (var ctx = new EmployeeDBEntities())
            {
                var employee = ctx.Employees
                  .Where(s => s.EmpCode == empCode)
                  .FirstOrDefault();

                ctx.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }

    }
}
