using EmployeeMgmSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMgmSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index(string search)
        {
           
           var list = _employeeService.GetAll();
            return View(list);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var post = _employeeService.Add(employee);
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(string name)
        {
             _employeeService.Delete(name);
            return RedirectToAction("Index");
        }
    }
}