using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkAssessment.Models
{
    public class DepartmentEmployee
    {
        public int ind1 { set; get; }
      public IEnumerable<Employee> emp1 { get; set; }

        public IEnumerable<Department> dep1 { get; set; }


    }
}