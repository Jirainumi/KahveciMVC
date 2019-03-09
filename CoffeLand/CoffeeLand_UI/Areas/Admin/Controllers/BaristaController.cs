using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeLand_BLL.Repository.Abstract;
using CoffeeLand_BLL.Repository.Concrete;
using CoffeeLand_DAL;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_UI.Areas.Admin.Controllers
{
    public class BaristaController : Controller
    {
        BaristaConcrete _baristaConcrete;

        public BaristaController()
        {
            _baristaConcrete = new BaristaConcrete();
        }

        // GET: Admin/Baristas
        public ActionResult Index()
        {
            return View(_baristaConcrete._baristaRepository.GetAll());
        }

        // GET: Admin/Baristas/Details/5
        public ActionResult Details(int id)
        {
            Barista barista = _baristaConcrete._baristaRepository.GetById(id);
            return View(barista);
        }

        // GET: Admin/Baristas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Baristas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Firstname,Lastname,Gender,BirthDate,HiredDate,AVGPoint")] Barista barista)
        {
            if (ModelState.IsValid)
            {
                _baristaConcrete._baristaRepository.Insert(barista);
                _baristaConcrete._baristaUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barista);
        }

        // GET: Admin/Baristas/Edit/5
        public ActionResult Edit(int id)
        {
            Barista barista = _baristaConcrete._baristaRepository.GetById(id);
            return View(barista);
        }

        // POST: Admin/Baristas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Firstname,Lastname,Gender,BirthDate,HiredDate,AVGPoint")] Barista barista)
        {
            if (ModelState.IsValid)
            {
                _baristaConcrete._baristaRepository.Update(barista);
                _baristaConcrete._baristaUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barista);
        }

        // GET: Admin/Baristas/Delete/5
        public ActionResult Delete(int id)
        {
            Barista barista = _baristaConcrete._baristaRepository.GetById(id);
            return View(barista);
        }

        // POST: Admin/Baristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barista barista = _baristaConcrete._baristaRepository.GetById(id);
            _baristaConcrete._baristaRepository.Delete(barista);
            _baristaConcrete._baristaUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _baristaConcrete._baristaUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
