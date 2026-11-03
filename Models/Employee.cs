using System.ComponentModel.DataAnnotations;

namespace EmployeeMgmSystem.Models
{
    public class Employee
    {
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Department { get; set; }
    }
}
