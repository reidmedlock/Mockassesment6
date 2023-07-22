using Microsoft.AspNetCore.Mvc;
using Mockassesment6.Models;
using System.Diagnostics;

namespace Mockassesment6.Controllers;

 

public class HomeController : Controller
    {
        private readonly EmployeeDbContext _dbContext;

        public HomeController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Employees()
        {
            List<Employee> employees = _dbContext.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult RetirementInfo()
        {
            return View(new Retirement());
        }

        [HttpPost]
        public IActionResult RetirementInfo(int id)
        {
            Employee employee = _dbContext.Employees.FirstOrDefault(e => e.Id == id);

            Retirement retirement = new Retirement();
            if (employee != null)
            {
                retirement.CanRetire = employee.Age > 60;
                retirement.Benefits = 0.6f * employee.Salary;
            }

            return View(retirement);
        }
    }
