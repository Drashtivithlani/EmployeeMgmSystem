namespace EmployeeMgmSystem.Models
{
    public class EmployeeService
    {

        public List<Employee> employees = new List<Employee>();

        public List<Employee> GetAll()
        {
            return employees;
        }

        public List<Employee> Add(Employee employee)
        {
            employees.Add(employee);
            return employees;
        }

        public void Delete(string name)
        {
           var delete = employees.FirstOrDefault(x=>x.EmployeeName == name);
            employees.Remove(delete);
        }
    }
}