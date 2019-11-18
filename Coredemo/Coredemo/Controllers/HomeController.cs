using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Coredemo.Controllers;
using Coredemo.Models;

namespace Coredemo.Controllers
{
    
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
       

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            //return _employeeRepository.details(1).Name;
            return View(model);
            //return View("Sample");
        }
      

        public ViewResult Details(int Id)
        {
            var model = _employeeRepository.details(Id);
           
            return View(model);
        }
    }
}