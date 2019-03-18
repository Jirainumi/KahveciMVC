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
    public class OrderDetailController : Controller
    {
        OrderDetailConcrete _orderDetailConrete;

        public OrderDetailController()
        {
            _orderDetailConrete = new OrderDetailConcrete();
        }

        // GET: Admin/OrderDetails
        public ActionResult Index()
        {
            return View(_orderDetailConrete._orderDetailRepository.GetAll());
        }

        // GET: Admin/OrderDetails/Details/5
        public ActionResult Details(int id)
        {
            OrderDetail orderDetail = _orderDetailConrete._orderDetailRepository.GetById(id);
            return View(orderDetail);
        }
    }
}
