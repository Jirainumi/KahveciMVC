using CoffeeLand_DATA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeLand_UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Customer customer = Session["OnlineKullanici"] as Customer;

            if (customer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
            {
                return View();
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }
    }
}