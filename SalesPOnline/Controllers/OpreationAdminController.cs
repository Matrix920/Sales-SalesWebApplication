using SalesPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesPersons.Controllers
{
    public class OpreationAdminController : Controller
    {
        DBAMWEntities con = new DBAMWEntities();
        // GET: OpreationAdmin
        public ActionResult AddSalesPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSalesPerson(string number, string username, string password,
                                           DateTime register, string region, HttpPostedFileBase file1)
        {
           // var newRaw;
            int number1 = Int32.Parse(number);
            int region1 = Int32.Parse(region);


            var num = con.salesPerson.Where(NPerson => NPerson.personNumber.Equals(number1)).SingleOrDefault();
           if(num == null)
            {
                string filePathInDB="";
                if (file1 != null && file1.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(file1.FileName);
                    string filePath = "~/ProjectFile/" + fileName;
                    filePathInDB = "ProjectFile/" + fileName;
                    file1.SaveAs(Server.MapPath(filePath));
                    Response.Write("00"+ filePathInDB);
                }
                var newRaw = new salesPerson {
                    personNumber =number1,
                    personName =username,
                    personPassword=password,
                    image=filePathInDB ,
                    registrationDate=register ,
                       personRegionId = region1};

                con.salesPerson.Add(newRaw);
                con.SaveChanges();
                return RedirectToAction("AllSalesPerson", "OpreationAdmin");

            }
           else
            {
                ViewBag.error = "error";

            }

          
            return View();
        }

        public ActionResult EditSalesPerson(int salespersonNumper)

        {
            Response.Write(salespersonNumper);
            var num = con.salesPerson.Where(NPerson => NPerson.personNumber.Equals(salespersonNumper)).SingleOrDefault();

            return View(num);
        }

        [HttpPost]
        public ActionResult EditSalesPerson(string number, string username, string password,
                                        string region, HttpPostedFileBase file1)
        {
            
            int number1 = Int32.Parse(number);
            var num = con.salesPerson.Where(NPerson => NPerson.personNumber.Equals(number1)).SingleOrDefault();

            num.personName = username;
            num.personPassword = password;
          
            int intRegion = Int32.Parse(region);
            num.personRegionId = intRegion;
            if (file1 != null && file1.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(file1.FileName);
                string filePath = "~/ProjectFile/" + fileName;
                string filePathInDB = "ProjectFile/" + fileName;
                file1.SaveAs(Server.MapPath(filePath));
                num.image = filePathInDB;
            }
            con.SaveChanges();

            return RedirectToAction("AllSalesPerson","OpreationAdmin");
        }


        public ActionResult DeleteSalesPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSalesPerson(string salesPersonNumber)
        {
            int number1 = Int32.Parse(salesPersonNumber);
            var num = con.salesPerson.Where(NPerson => NPerson.personNumber==number1).SingleOrDefault();
            if(num != null)
            {
                var com = con.commission.Where(c => c.personId == num.personId).ToList();
                if (com != null)
                {
                    con.commission.RemoveRange(com);
                    con.SaveChanges();
                }

                    con.salesPerson.Remove(num);
                con.SaveChanges();
                ViewBag.delet = true;
               
            }
            else
            {
                ViewBag.delet = false;
            }


            return RedirectToAction("AllSalesPerson", "OpreationAdmin");
        }
        public ActionResult AllSalesPerson()
        {
            var listPerson = con.salesPerson.ToList();

            return View(listPerson);
        }
        [HttpPost]
        public ActionResult AllSalesPerson(string salesPersonNumber)
        {

            int salesPersonNumber1 = Int32.Parse(salesPersonNumber);
            var num = con.salesPerson.Where(NPerson => NPerson.personNumber.Equals(salesPersonNumber1)).SingleOrDefault();
            if(num != null)
            {
                int number = num.personNumber;
                 return RedirectToAction("EditSalesPerson", new { salespersonNumper= number });
               
            }
            else
            {
                ViewBag.error = true;
            }
            var listPerson = con.salesPerson.ToList();
            return View(listPerson);
        }

        public ActionResult SearchSalesPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchSalesPerson(string name,string month,string year)
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
                    ViewBag.error = "Ther isn't any result";
                    return View(com);
                      }
                      else
                      {
                ViewBag.error = "Ther isn't any commision";
                      }

            }
            else
            {
                ViewBag.error = "Ther isn't any result";
            }
            ViewBag.error = "Ther isn't any result";
            return View();
            
        }

    }
}