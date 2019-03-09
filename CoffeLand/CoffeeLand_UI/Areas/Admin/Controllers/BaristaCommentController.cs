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
    public class BaristaCommentController : Controller
    {
        BaristaCommentConrete _baristaCommentConrete;
        UserConcrete _userConcrete;
        BaristaConcrete _baristaConcrete;

        public BaristaCommentController()
        {
            _baristaCommentConrete = new BaristaCommentConrete();
            _userConcrete = new UserConcrete();
            _baristaConcrete = new BaristaConcrete();
        }

        // GET: Admin/BaristaComments
        public ActionResult Index()
        {
            return View(_baristaCommentConrete._baristaCommentRepository.GetAll());
        }

        // GET: Admin/BaristaComments/Details/5
        public ActionResult Details(int id)
        {
            BaristaComment baristaComment = _baristaCommentConrete._baristaCommentRepository.GetById(id);
            return View(baristaComment);
        }

        // GET: Admin/BaristaComments/Create
        public ActionResult Create()
        {
            ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
            ViewBag.UserID = new SelectList(_userConcrete._userRepository.GetEntity(), "ID", "UserName");
            return View();
        }

        // POST: Admin/BaristaComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Comment,Point,BaristaCommentDate,BaristaID,UserID")] BaristaComment baristaComment)
        {
            if (ModelState.IsValid)
            {
                _baristaCommentConrete._baristaCommentRepository.Insert(baristaComment);
                _baristaCommentConrete._baristaCommentUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
            ViewBag.UserID = new SelectList(_userConcrete._userRepository.GetEntity(), "ID", "UserName");
            return View(baristaComment);
        }

        // GET: Admin/BaristaComments/Edit/5
        public ActionResult Edit(int id)
        {
            BaristaComment baristaComment = _baristaCommentConrete._baristaCommentRepository.GetById(id);
            ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
            ViewBag.UserID = new SelectList(_userConcrete._userRepository.GetEntity(), "ID", "UserName");
            return View(baristaComment);
        }

        // POST: Admin/BaristaComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Comment,Point,BaristaCommentDate,BaristaID,UserID")] BaristaComment baristaComment)
        {
            if (ModelState.IsValid)
            {
                _baristaCommentConrete._baristaCommentRepository.Update(baristaComment);
                _baristaCommentConrete._baristaCommentUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
            ViewBag.UserID = new SelectList(_userConcrete._userRepository.GetEntity(), "ID", "UserName");
            return View(baristaComment);
        }

        // GET: Admin/BaristaComments/Delete/5
        public ActionResult Delete(int id)
        {
            BaristaComment baristaComment = _baristaCommentConrete._baristaCommentRepository.GetById(id);
            return View(baristaComment);
        }

        // POST: Admin/BaristaComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaristaComment baristaComment = _baristaCommentConrete._baristaCommentRepository.GetById(id);
            _baristaCommentConrete._baristaCommentRepository.Delete(baristaComment);
            _baristaCommentConrete._baristaCommentUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _baristaCommentConrete._baristaCommentUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
