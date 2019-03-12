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
        BaristaConcrete _baristaConcrete;
        CoffeeConcrete _coffeeConcrete;
        OrderConcrete _orderConrete;

        public OrderDetailController()
        {
            _orderDetailConrete = new OrderDetailConcrete();
            _baristaConcrete = new BaristaConcrete();
            _coffeeConcrete = new CoffeeConcrete();
            _orderConrete = new OrderConcrete();
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

        // GET: Admin/OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
            ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
            ViewBag.OrderID = new SelectList(_orderConrete._orderRepository.GetEntity(), "ID", "ID");
            return View();
        }

        // POST: Admin/OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UnitPrice,Quantity,OrderID,CoffeeID,BaristaID")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _orderDetailConrete._orderDetailRepository.Insert(orderDetail);
                _orderDetailConrete._orderDetailUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
            ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
            ViewBag.OrderID = new SelectList(_orderConrete._orderRepository.GetEntity(), "ID", "ID");
            return View(orderDetail);
        }

        // GET: Admin/OrderDetails/Edit/5
        public ActionResult Edit(int id)
        {
            OrderDetail orderDetail = _orderDetailConrete._orderDetailRepository.GetById(id);

            ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
            ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
            ViewBag.OrderID = new SelectList(_orderConrete._orderRepository.GetEntity(), "ID", "ID");
            return View(orderDetail);
        }

        // POST: Admin/OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UnitPrice,Quantity,OrderID,CoffeeID,BaristaID")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _orderDetailConrete._orderDetailRepository.Update(orderDetail);
                _orderDetailConrete._orderDetailUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
            ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
            ViewBag.OrderID = new SelectList(_orderConrete._orderRepository.GetEntity(), "ID", "ID");
            return View(orderDetail);
        }

        // GET: Admin/OrderDetails/Delete/5
        public ActionResult Delete(int id)
        {
            OrderDetail orderDetail = _orderDetailConrete._orderDetailRepository.GetById(id);
            return View(orderDetail);
        }

        // POST: Admin/OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = _orderDetailConrete._orderDetailRepository.GetById(id);
            _orderDetailConrete._orderDetailRepository.Delete(orderDetail);
            _orderDetailConrete._orderDetailUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _orderDetailConrete._orderDetailUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
