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
        OrderConrete _orderConrete;
        UserConcrete _userConcrete;

        public OrderController()
        {
            _orderConrete = new OrderConrete();
            _userConcrete = new UserConcrete();
        }

        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View(_orderConrete._orderRepository.GetAll());
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int id)
        {
            Order order = _orderConrete._orderRepository.GetById(id);
            return View(order);
        }

        // GET: Admin/Orders/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(_userConcrete._userRepository.GetEntity(), "ID", "UserName");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OrderDate,TotalPrice,UserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _orderConrete._orderRepository.Insert(order);
                _orderConrete._orderUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(_userConcrete._userRepository.GetEntity(), "ID", "UserName");
            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = _orderConrete._orderRepository.GetById(id);
            ViewBag.UserID = new SelectList(_userConcrete._userRepository.GetEntity(), "ID", "UserName");
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderDate,TotalPrice,UserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _orderConrete._orderRepository.Update(order);
                _orderConrete._orderUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(_userConcrete._userRepository.GetEntity(), "ID", "UserName", order.UserID);
            return View(order);
        }

        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(int id)
        {
            Order order = _orderConrete._orderRepository.GetById(id);
            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = _orderConrete._orderRepository.GetById(id);
            _orderConrete._orderRepository.Delete(order);
            _orderConrete._orderUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _orderConrete._orderUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
