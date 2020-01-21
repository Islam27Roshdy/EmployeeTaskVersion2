using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.ManagersClasses;
using DataAccessLayer.Models;

namespace EmployeeTask.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeManager employeeManager;
        private static string FirstName;
        private static DateTime StartDate;
        private static DateTime EndDate;
        public EmployeeController()
        {
            employeeManager = new EmployeeManager();
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employeesList= employeeManager.GetList();
            return View(employeesList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                employeeManager.Add(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        [HttpGet]
        public ActionResult Update(int id)
        {
            Employee employeeToDelete = employeeManager.FindByID(id);

            return View(employeeToDelete);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            try
            {
                employeeManager.Update(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
            }
        }

   

        // Get: Employee/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Employee employeeToDelete = employeeManager.FindByID(id);
                employeeManager.Delete(employeeToDelete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Search(string firstName, DateTime  endDate, DateTime  startDate)
        {
           int page = 1;
           int pageSize = 5;
            StartDate = startDate;
            EndDate = endDate;
            FirstName = firstName;

            List<Employee> employees = employeeManager.Search(FirstName, StartDate, EndDate);
           int startIndex = employeeManager.GetStartIndex(page, pageSize);
           List<EmployeeViewModel> employeesOfOnePage = employeeManager.GetOnePageEmployees(employees,startIndex, pageSize);

           string Pagination = employeeManager.Pagination(employees.Count(), pageSize, page);
           return Json(new  { Result="OK" ,Records = employeesOfOnePage, Pagination = Pagination });
        }
  
        [HttpPost]
        public JsonResult GetNewPage(int page)
        {
            int pageSize = 5;
       
            List<Employee> employees = employeeManager.Search(FirstName, StartDate, EndDate);

            int startIndex = employeeManager.GetStartIndex(page, pageSize);
            List<EmployeeViewModel> employeesOfOnePage = employeeManager.GetOnePageEmployees(employees, startIndex, pageSize);
            return Json(new { Records = employeesOfOnePage, Result = "OK" });
        }
    }
}
