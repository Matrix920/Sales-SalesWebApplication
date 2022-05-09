using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesPersons.Controllers
{
    public class IfAdminOrPersonController : Controller
    {
        // GET: IfAdminOrPerson
        public ActionResult IfAdmin()
        {
            return View();
        }

        // GET: IfAdminOrPerson
        public ActionResult IfPerson()
        {
            return View();
        }
    }
}