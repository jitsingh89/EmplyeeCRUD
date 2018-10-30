using EmployeeUI.Models;
using EmployeeUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeUI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeClient empClient = new EmployeeClient();
            ViewData["employees"] = empClient.GetEmployees();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeVM)
        {
            EmployeeClient empClient = new EmployeeClient();
            empClient.SaveEmployee(employeeVM.Employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int empCode)
        {
            EmployeeClient empClient = new EmployeeClient();
            empClient.DeleteEmployeeByEmpCode(empCode);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int empCode)
        {
            EmployeeClient empClient = new EmployeeClient();
            EmployeeViewModel employeeVM = new EmployeeViewModel();
            employeeVM.Employee = empClient.GetEmployeeByEmpCode(empCode);
            return View("Edit", employeeVM);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeVM)
        {
            EmployeeClient empClient = new EmployeeClient();
            empClient.UpdateEmployee(employeeVM.Employee);
            return RedirectToAction("Index");
        }
    }
}