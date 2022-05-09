using SalesPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesPersons.Controllers
{
    public class LogInOutController : Controller
    {
        DBAMWEntities con = new DBAMWEntities();
        // GET: LogInOut
        public ActionResult Login()
        {

            Session["admin"] = false;
            Session["user"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {

                Session["admin"] = true;
                return RedirectToAction("IfAdmin", "IfAdminOrPerson");
            }
            else
            {
                var user = con.salesPerson.Where(x => x.personName.Equals(username) && x.personPassword.Equals(password)).SingleOrDefault();
                if (user != null)
                {
                    Session["admin"] = false;
                    Session["user"] = user;
                    return RedirectToAction("IfPerson", "IfAdminOrPerson");
                }

                return View();
            }
        }
    }






    
}