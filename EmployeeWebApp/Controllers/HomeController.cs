using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParserLibrary;
using ParserLibrary.Entities;
using EmployeeWebApp.Models;

namespace EmployeeWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Parser<Employee> parser = new Parser<Employee>();
            List<Employee> employees = parser.ParseCSV("C:\\Users\\Nam\\Code\\Repos\\Lacera\\EmployeeWebApp\\bin\\Employees.csv");

            //clean up, don't show invalid employees
            employees.RemoveAll(x => x.Invalid == true);

            HomeIndexViewModel hiv = new HomeIndexViewModel();
            hiv.Employees = employees.ConvertAll(x => new EmployeeViewModel() { Name = x.Name,
                                                                                Birthdate = x.Birthdate,
                                                                                Salary = x.Salary,
                                                                                DateHired = x.DateHired });
            
            return View(hiv);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}