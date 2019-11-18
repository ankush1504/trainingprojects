using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coredemo.Models;

namespace Coredemo.Models
{
    public interface IEmployeeRepository
    {
         Employee details(int id);
       IEnumerable<Employee> GetAllEmployees();
        
    }
}
