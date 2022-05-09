using SalesPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesPersons.Controllers
{
    public class OperationAdminAndroidController : Controller
    {
        DBAMWEntities con = new DBAMWEntities();

  

        [HttpPost]
        public ActionResult AddSalesPerson(string personName, string personNumber, string password,
                                           String registerationDate, string personRegionId)
        {

            // var newRaw;
            int number1 = Int32.Parse(personNumber);
            int region1 = Int32.Parse(personRegionId);


            var num = con.salesPerson.Where(NPerson => NPerson.personNumber==number1).SingleOrDefault();
            if (num == null)
            {
                
                var newRaw = new salesPerson
                {
                    personNumber = number1,
                    personName = personName,
                    personPassword = password,
                    registrationDate = Convert.ToDateTime(registerationDate),
                    image="",
                    personRegionId = region1
                };

                con.salesPerson.Add(newRaw);
                con.SaveChanges();

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false,message="another person with person number" }, JsonRequestBehavior.AllowGet);
            }
        }

      
        [HttpPost]
        public ActionResult EditSalesPerson(string personName, string personNumber, string password,
                                           String registerationDate, string personRegionId)
        {

            int number1 = Int32.Parse(personNumber);
            var num = con.salesPerson.Where(NPerson => NPerson.personNumber.Equals(number1)).SingleOrDefault();

            num.personName = personName;
            num.personPassword = password;
            if (registerationDate != null) { num.registrationDate = Convert.ToDateTime(registerationDate); }
            int intRegion = Int32.Parse(personRegionId);
            num.personRegionId = intRegion;
            
            con.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteSalesPerson(string salesPersonNumber)
        {
            int number1 = Int32.Parse(salesPersonNumber);
            var num = con.salesPerson.Where(NPerson => NPerson.personNumber.Equals(number1)).SingleOrDefault();
            if (num != null)
            {
                con.salesPerson.Remove(num);
                con.SaveChanges();

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }
      

        [HttpPost]
        public ActionResult AllSalesPerson()
        {

            var listPerson = (from user in con.salesPerson.AsEnumerable()
                              select new
                              {
                                  personId = user.personId,
                                  personNumber = user.personNumber,
                                  personName = user.personName,
                                  personPassword = user.personPassword,
                                  regionName = user.region.regionName,
                                  personRegionId = user.personRegionId,
                                  registerationDate = Convert.ToString(user.registrationDate),
                                  image = user.image
                              }).ToList();

            return Json(listPerson, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult SearchSalesPerson(string name, string month, string year)
        {
            int m = Int32.Parse(month);
            int y = Int32.Parse(year);
            var namm = con.salesPerson.Where(sp => sp.personName.Equals(name)).SingleOrDefault();
            bool s = false;
            if (namm != null) s = true;
            if (s)
            {
                var com = con.commission.Where(NCom => NCom.personId == namm.personId && NCom.month == m && NCom.year == y).ToList();
                if (com != null)
                {
                    var result = com.Select(x => new
                    {
                        commissionId = x.commissionId,
                        personId = x.personId,
                        southern = x.southern,
                        costal = x.coastal,
                        northern = x.northern_,
                        eastern = x.eastern,
                        lebanon = x.Lebanon,
                        commission = x.commission1,
                        month = x.month,
                        year = x.year
                    }).ToList();
                    return Json(result, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }
    }
}