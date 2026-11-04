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
            if(delete != null)
            employees.Remove(delete);
        }

        public List<Employee> Edit(string current,Employee employee)
        {
            var edit = employees.FirstOrDefault(x=> x.EmployeeName == current);
            if(edit != null)
            {
                edit.EmployeeName = employee.EmployeeName;
                edit.Email = employee.Email;
                edit.Department = employee.Department;
            }

            return employees;
        }

        
    }
}