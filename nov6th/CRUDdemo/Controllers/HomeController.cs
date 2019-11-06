using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDdemo.Models;
namespace CRUDdemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DBfirstDemoEntities context = new DBfirstDemoEntities();
            
            return View(context.DemotblEmployees.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            DBfirstDemoEntities con = new DBfirstDemoEntities();
            DemotblEmployee emp = con.DemotblEmployees.FirstOrDefault(x => x.Id == id);

            return View(emp);

        }
        public ActionResult Delete(int id)
        {
            DBfirstDemoEntities con = new DBfirstDemoEntities();
            DemotblEmployee emp = con.DemotblEmployees.Where(s => s.Id == id).FirstOrDefault();
          
            
            return View(emp);
        }

        [HttpPost]
        public ActionResult Create(DemotblEmployee emp)
        {
            DBfirstDemoEntities con = new DBfirstDemoEntities();
            con.DemotblEmployees.Add(emp);
            con.SaveChanges();
            
            return( RedirectToAction("Index"));
        }

        public ActionResult Details(int id)
        {
            DBfirstDemoEntities con = new DBfirstDemoEntities();
            DemotblEmployee selectedEmployee = (DemotblEmployee)con.DemotblEmployees.FirstOrDefault(x=>x.Id== id);
            return View(selectedEmployee);
        }
        [HttpPost]
        public ActionResult Edit(DemotblEmployee demoemp)
        {
            DBfirstDemoEntities con = new DBfirstDemoEntities();
            //DemotblEmployee emp = con.DemotblEmployees.FirstOrDefault(x => x.Id.Equals(demoemp.Id));
            //emp.FullName = demoemp.FullName;
            //emp.Gender = demoemp.Gender;
            //emp.Age = demoemp.Age;
            //emp.EmailAddress = demoemp.EmailAddress;
            //emp.HireDate = demoemp.HireDate;
            //emp.PersonalWebSite = demoemp.PersonalWebSite;
            //emp.Salary = demoemp.Salary;
            
            con.Entry(demoemp).State = System.Data.Entity.EntityState.Modified;
            con.SaveChanges();
            return (RedirectToAction("Index"));
        }
     [HttpPost]
        public ActionResult Delete(DemotblEmployee demoemp)
        {
            DBfirstDemoEntities con = new DBfirstDemoEntities();
            //DemotblEmployee emp = con.DemotblEmployees.FirstOrDefault(x => x.Id.Equals(demoemp.Id));
            //con.DemotblEmployees.Remove(emp);
            con.Entry(demoemp).State = System.Data.Entity.EntityState.Deleted;
            con.SaveChanges();
            return View();
        }
    }
}