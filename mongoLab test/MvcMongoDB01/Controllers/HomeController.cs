using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using MvcMongoDB01.Models;
using MvcMongoDB01.Properties;

namespace MvcMongoDB01.Controllers
{
    public class HomeController : Controller
    {
        //public MongoDatabase MongoDatabase;
        public EmployeeRepository Context = new EmployeeRepository();

        /*public HomeController()
        {
            var mongoClient = new MongoClient(Settings.Default.EmployeesConnectionString);
            var server = mongoClient.GetServer();
            MongoDatabase = server.GetDatabase(Settings.Default.DB);
        }*/

        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            //return View();
            
            //MongoDatabase.GetStats();
            //return Json(MongoDatabase.Server.BuildInfo, JsonRequestBehavior.AllowGet);
            var tmp = Context.GetAllEmployees();
            return View("Index", Context.GetAllEmployees().ToList());
        }

        public ActionResult Add()
        {
            return View();
        }


       /* [HttpPost]
        public ActionResult Add(Employee employee)
        {
            var result = Context.Add(employee);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(string Id)
        {
            var employee = Context.GetEmployeeById(Id);

            return View(Context.GetEmployeeById(Id));
        }


        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (employee == null) return RedirectToAction("Index");

            //Context.Update(employee.Id, employee);

            return RedirectToAction("Index");
        }


        /*public ActionResult Delete(string Id)
        {
            Context.Delete(Id);
            return RedirectToAction("Index");
        }*/

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
