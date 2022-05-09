using SalesPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesPersons.Controllers
{
    public class LoginOutAndroidController : Controller
    {
        DBAMWEntities con = new DBAMWEntities();
        // GET: LoginOutAndroid
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {

                var adminLogin = new
                {
                    login = true,
                    admin = true,
                    person = false
                };

                return Json(adminLogin, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var user = con.salesPerson.Where(x => x.personName.Equals(username) && x.personPassword.Equals(password)).SingleOrDefault();
                if (user != null)
                {
                    var personLogin = new
                    {
                        login = true,
                        person = true,
                        admin = false,
                        personId=user.personId,
                        personNumber = user.personNumber,
                        personName = user.personName,
                        regionName = user.region.regionName,
                        personRegionId = user.personRegionId,
                        registerationDate =Convert.ToString(user.registrationDate),
                        image = user.image
                    };
                
                    return Json(personLogin, JsonRequestBehavior.AllowGet);

                }

                var noLogin = new
                {
                    login = false,
                    person = false,
                    admin = false
                };

                return Json(noLogin, JsonRequestBehavior.AllowGet);
            }
        }
    }
}