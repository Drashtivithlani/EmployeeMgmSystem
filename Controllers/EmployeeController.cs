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
            if(search != null)
            {
                list = list.Where(x=>x.EmployeeName.ToLower() == search.ToLower()).ToList();

                
            }
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
                TempData["Message"] = "Employee Added";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(string name)
        {
             _employeeService.Delete(name);
            TempData["Message"] = "Employee Deleted";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string name)
        {
            var employee = _employeeService.GetAll().FirstOrDefault(x => x.EmployeeName == name);

            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);

        }

        [HttpPost]
        public IActionResult Edit(string current,Employee employee)
        {
            
            if (ModelState.IsValid)
            {
                _employeeService.Edit(current, employee);

                TempData["Message"] = "Employee Edited";

               return  RedirectToAction("Index");

            }
            return View(employee);

        }
    }
}