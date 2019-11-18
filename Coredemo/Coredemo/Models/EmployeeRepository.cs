using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coredemo.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        List<Employee> employeeslist;
        public EmployeeRepository()
        {
            employeeslist = new List<Employee>()
            {
                new Employee{Id=1,Name="john",Email="john@mail.com",Department="IT"},
                new Employee{Id=2,Name="steve",Email="steve@mail.com",Department="HR"},
                new Employee{Id=3,Name="smith",Email="smith@mail.com",Department="Sales"}
            };

        }
        public Employee details(int id)
        {
            Employee employee = employeeslist.FirstOrDefault(e => e.Id == id);
            return employee;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeslist;
        }
    }
}
