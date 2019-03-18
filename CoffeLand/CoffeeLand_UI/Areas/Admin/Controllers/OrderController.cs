using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeLand_BLL.Repository.Concrete;
using CoffeeLand_DAL;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_UI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OrderConcrete _orderConrete;

        public OrderController()
        {
            _orderConrete = new OrderConcrete();
        }

        // GET: Admin/Orders
        public ActionResult Index()
        {
            Customer customer = Session["OnlineKullanici"] as Customer;

            if (customer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
            {
                return View(_orderConrete._orderRepository.GetAll());
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = Session["OnlineKullanici"] as Customer;

            if (customer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
            {
                Order order = _orderConrete._orderRepository.GetById(id);
                return View(order);
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }
    }
}
