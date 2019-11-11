using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkAssessment.Models;


namespace EntityFrameworkAssessment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(DepartmentEmployee demp)
        {
            DBfirstDemoEntities con = new DBfirstDemoEntities();
            ViewBag.Departments = new SelectList(con.Departments, "Id", "Name");
            demp.dep1 = con.Departments.ToList();
            demp.emp1 = con.Employees.ToList();
           
            return View(demp);
        }
        [HttpPost]
        public ActionResult Index(DepartmentEmployee demp, FormCollection form)
        {

            DBfirstDemoEntities con = new DBfirstDemoEntities();
            ViewBag.Departments = new SelectList(con.Departments, "Id", "Name");
            var mymodel = new DepartmentEmployee();
            mymodel.dep1 = con.Departments.ToList();
            mymodel.emp1 = con.Employees.ToList();
            

            mymodel.ind1= int.Parse(form["selectedDepartment"]);

            //var deptlist = con.Departments;
            //List<DepartmentEmployee> empnames1 = new List<DepartmentEmployee>();
            //var emplist = con.Employees;


            return View(mymodel);
        }
    
     



    }
}