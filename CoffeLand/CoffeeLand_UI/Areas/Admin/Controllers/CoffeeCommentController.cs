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
    public class CoffeeCommentController : Controller
    {
        CoffeeCommentConcrete _coffeeCommentConcrete;
        CoffeeConcrete _coffeeConcrete;
        CustomerConcrete _customerConcrete;

        public CoffeeCommentController()
        {
            _coffeeCommentConcrete = new CoffeeCommentConcrete();
            _coffeeConcrete = new CoffeeConcrete();
            _customerConcrete = new CustomerConcrete();
        }

        // GET: Admin/CoffeeComments
        public ActionResult Index()
        {
            return View(_coffeeCommentConcrete._coffeeCommentRepository.GetAll());
        }

        // GET: Admin/CoffeeComments/Details/5
        public ActionResult Details(int id)
        {
            CoffeeComment coffeeComment = _coffeeCommentConcrete._coffeeCommentRepository.GetById(id);
            return View(coffeeComment);
        }

        // GET: Admin/CoffeeComments/Create
        public ActionResult Create()
        {
            ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
            ViewBag.UserID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "UserName");
            return View();
        }

        // POST: Admin/CoffeeComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Comment,Point,CoffeeCommentDate,CoffeeID,UserID")] CoffeeComment coffeeComment)
        {
            if (ModelState.IsValid)
            {
                _coffeeCommentConcrete._coffeeCommentRepository.Insert(coffeeComment);
                _coffeeCommentConcrete._coffeeCommentUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
            ViewBag.UserID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "UserName");
            return View(coffeeComment);
        }

        // GET: Admin/CoffeeComments/Edit/5
        public ActionResult Edit(int id)
        {
            CoffeeComment coffeeComment = _coffeeCommentConcrete._coffeeCommentRepository.GetById(id);

            ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
            ViewBag.UserID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "UserName");
            return View(coffeeComment);
        }

        // POST: Admin/CoffeeComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Comment,Point,CoffeeCommentDate,CoffeeID,UserID")] CoffeeComment coffeeComment)
        {
            if (ModelState.IsValid)
            {
                _coffeeCommentConcrete._coffeeCommentRepository.Update(coffeeComment);
                _coffeeCommentConcrete._coffeeCommentUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
            ViewBag.UserID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "UserName");
            return View(coffeeComment);
        }

        // GET: Admin/CoffeeComments/Delete/5
        public ActionResult Delete(int id)
        {
            CoffeeComment coffeeComment = _coffeeCommentConcrete._coffeeCommentRepository.GetById(id);
            return View(coffeeComment);
        }

        // POST: Admin/CoffeeComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeeComment coffeeComment = _coffeeCommentConcrete._coffeeCommentRepository.GetById(id);
            _coffeeCommentConcrete._coffeeCommentRepository.Delete(coffeeComment);
            _coffeeCommentConcrete._coffeeCommentUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _coffeeCommentConcrete._coffeeCommentUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
