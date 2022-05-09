using SalesPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesPersons.Controllers
{
    public class OperationSalesPersonAndroidController : Controller
    {
        DBAMWEntities con = new DBAMWEntities();

        // GET: OpreatiionSalesPerson
        public ActionResult InsertSalesPersonCommission()
        {
            salesPerson salesperson = (salesPerson)Session["user"];
            return View(salesperson);
        }

        [HttpPost]
        public ActionResult InsertSalesPersonCommission(string month, string year, string southern, string coastal,
            string northern, string eastern, string lebanon, string personNumber, string personRegionId)
        {
            int month1 = Int32.Parse(month);
            int year1 = Int32.Parse(year);
            int southern1 = Int32.Parse(southern);
            int coastal1 = Int32.Parse(coastal);
            int northern1 = Int32.Parse(northern);
            int eastern1 = Int32.Parse(eastern);
            int lebanon1 = Int32.Parse(lebanon);
            int personId1 = Int32.Parse(personNumber);

            double[] comms = new double[6];

            var com = con.commission.Where(c => c.personId == personId1 && c.month == month1 && c.year == year1).SingleOrDefault();
            if (com != null)
            {
                return Json(new { Error = true, Message = "you have inserted sales for this month befor" },JsonRequestBehavior.AllowGet);
            }

            switch (personRegionId)
            {
                case "1":
                    if (southern1 > 1000000)
                        comms[1] = ((1000000 * 0.05) + ((southern1 - 1000000) * 0.07));
                    else
                        comms[1] = (southern1 * 0.05);
                    if (coastal1 > 1000000)
                        comms[2] = ((1000000 * 0.03) + ((coastal1 - 1000000) * 0.04));
                    else
                        comms[2] = (coastal1 * 0.03);
                    if (northern1 > 1000000)
                        comms[3] = ((1000000 * 0.03) + ((northern1 - 1000000) * 0.04));
                    else
                        comms[3] = (northern1 * 0.03);
                    if (eastern1 > 1000000)
                        comms[4] = ((1000000 * 0.03) + ((eastern1 - 1000000) * 0.04));
                    else
                        comms[4] = (eastern1 * 0.03);
                    if (lebanon1 > 1000000)
                        comms[5] = ((1000000 * 0.03) + ((lebanon1 - 1000000) * 0.04));
                    else
                        comms[5] = (lebanon1 * 0.03);

                    break;

                case "2":
                    if (southern1 > 1000000)
                        comms[1] = ((1000000 * 0.03) + ((southern1 - 1000000) * 0.04));
                    else
                        comms[1] = (southern1 * 0.03);
                    if (coastal1 > 1000000)
                        comms[2] = ((1000000 * 0.05) + ((coastal1 - 1000000) * 0.07));
                    else
                        comms[2] = (coastal1 * 0.05);
                    if (northern1 > 1000000)
                        comms[3] = ((1000000 * 0.03) + ((northern1 - 1000000) * 0.04));
                    else
                        comms[3] = (northern1 * 0.03);
                    if (eastern1 > 1000000)
                        comms[4] = ((1000000 * 0.03) + ((eastern1 - 1000000) * 0.04));
                    else
                        comms[4] = (eastern1 * 0.03);
                    if (lebanon1 > 1000000)
                        comms[5] = ((1000000 * 0.03) + ((lebanon1 - 1000000) * 0.04));
                    else
                        comms[5] = (lebanon1 * 0.03);

                    break;

                case "3":
                    if (southern1 > 1000000)
                        comms[1] = ((1000000 * 0.03) + ((southern1 - 1000000) * 0.04));
                    else
                        comms[1] = (southern1 * 0.03);
                    if (coastal1 > 1000000)
                        comms[2] = ((1000000 * 0.03) + ((coastal1 - 1000000) * 0.04));
                    else
                        comms[2] = (coastal1 * 0.03);
                    if (northern1 > 1000000)
                        comms[3] = ((1000000 * 0.05) + ((northern1 - 1000000) * 0.07));
                    else
                        comms[3] = (northern1 * 0.05);
                    if (eastern1 > 1000000)
                        comms[4] = ((1000000 * 0.03) + ((eastern1 - 1000000) * 0.04));
                    else
                        comms[4] = (eastern1 * 0.03);
                    if (lebanon1 > 1000000)
                        comms[5] = ((1000000 * 0.03) + ((lebanon1 - 1000000) * 0.04));
                    else
                        comms[5] = (lebanon1 * 0.03);

                    break;

                case "4":
                    if (southern1 > 1000000)
                        comms[1] = ((1000000 * 0.03) + ((southern1 - 1000000) * 0.04));
                    else
                        comms[1] = (southern1 * 0.03);
                    if (coastal1 > 1000000)
                        comms[2] = ((1000000 * 0.03) + ((coastal1 - 1000000) * 0.04));
                    else
                        comms[2] = (coastal1 * 0.03);
                    if (northern1 > 1000000)
                        comms[3] = ((1000000 * 0.03) + ((northern1 - 1000000) * 0.04));
                    else
                        comms[3] = (northern1 * 0.03);
                    if (eastern1 > 1000000)
                        comms[4] = ((1000000 * 0.05) + ((eastern1 - 1000000) * 0.07));
                    else
                        comms[4] = (eastern1 * 0.05);
                    if (lebanon1 > 1000000)
                        comms[5] = ((1000000 * 0.03) + ((lebanon1 - 1000000) * 0.04));
                    else
                        comms[5] = (lebanon1 * 0.03);

                    break;


                case "5":
                    if (southern1 > 1000000)
                        comms[1] = ((1000000 * 0.03) + ((southern1 - 1000000) * 0.04));
                    else
                        comms[1] = (southern1 * 0.03);
                    if (coastal1 > 1000000)
                        comms[2] = ((1000000 * 0.03) + ((coastal1 - 1000000) * 0.04));
                    else
                        comms[2] = (coastal1 * 0.03);
                    if (northern1 > 1000000)
                        comms[3] = ((1000000 * 0.03) + ((northern1 - 1000000) * 0.04));
                    else
                        comms[3] = (northern1 * 0.03);
                    if (eastern1 > 1000000)
                        comms[4] = ((1000000 * 0.03) + ((eastern1 - 1000000) * 0.04));
                    else
                        comms[4] = (eastern1 * 0.03);
                    if (lebanon1 > 1000000)
                        comms[5] = ((1000000 * 0.05) + ((lebanon1 - 1000000) * 0.07));
                    else
                        comms[5] = (lebanon1 * 0.05);

                    break;
            }
            double comm = comms.Sum();
            commission newcomm = new commission();
            newcomm.personId = personId1;

            newcomm.southern = Convert.ToDecimal(comms[1]);
            newcomm.coastal = Convert.ToDecimal(comms[2]);
            newcomm.northern_ = Convert.ToDecimal(comms[3]);
            newcomm.eastern = Convert.ToDecimal(comms[4]);
            newcomm.Lebanon = Convert.ToDecimal(comms[5]);

            newcomm.commission1 = Convert.ToDecimal(comm);

            newcomm.month = month1;
            newcomm.year = year1;

            con.commission.Add(newcomm);
            con.SaveChanges();

            return RedirectToAction("ViewSalesPersonCommission", new { pid = newcomm.commissionId });
        }

        public ActionResult ViewSalesPersonCommission(int pid)
        {

            var co = con.commission.Where(n => n.commissionId==pid).Select(x => new
            {
                costal = x.coastal,
                northern = x.northern_,
                southern = x.southern,
                eastern = x.eastern,
                lebanon = x.Lebanon,
                commission = x.commission1,
                month = x.month,
                year = x.year
            }).SingleOrDefault();

            return Json(co, JsonRequestBehavior.AllowGet);
        }
    }
}