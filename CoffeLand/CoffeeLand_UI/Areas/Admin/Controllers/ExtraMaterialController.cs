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
    public class ExtraMaterialController : Controller
    {
        ExtraMaterialsConcrete _extraMaterialsConcrete;

        public ExtraMaterialController()
        {
            _extraMaterialsConcrete = new ExtraMaterialsConcrete();
        }

        // GET: Admin/ExtraMaterial
        public ActionResult Index()
        {
            return View(_extraMaterialsConcrete._extraMaterialRepository.GetAll());
        }

        // GET: Admin/ExtraMaterial/Details/5
        public ActionResult Details(int id)
        {
            ExtraMaterial extraMaterial = _extraMaterialsConcrete._extraMaterialRepository.GetById(id);
            return View(extraMaterial);
        }

        // GET: Admin/ExtraMaterial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ExtraMaterial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,UnitPrice,Quantity")] ExtraMaterial extraMaterial)
        {
            if (ModelState.IsValid)
            {
                _extraMaterialsConcrete._extraMaterialRepository.Insert(extraMaterial);
                _extraMaterialsConcrete._extraMaterialUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extraMaterial);
        }

        // GET: Admin/ExtraMaterial/Edit/5
        public ActionResult Edit(int id)
        {
            ExtraMaterial extraMaterial = _extraMaterialsConcrete._extraMaterialRepository.GetById(id);
            return View(extraMaterial);
        }

        // POST: Admin/ExtraMaterial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UnitPrice,Quantity")] ExtraMaterial extraMaterial)
        {
            if (ModelState.IsValid)
            {
                _extraMaterialsConcrete._extraMaterialRepository.Update(extraMaterial);
                _extraMaterialsConcrete._extraMaterialUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extraMaterial);
        }

        // GET: Admin/ExtraMaterial/Delete/5
        public ActionResult Delete(int id)
        {
            ExtraMaterial extraMaterial = _extraMaterialsConcrete._extraMaterialRepository.GetById(id);
            return View(extraMaterial);
        }

        // POST: Admin/ExtraMaterial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExtraMaterial extraMaterial = _extraMaterialsConcrete._extraMaterialRepository.GetById(id);
            _extraMaterialsConcrete._extraMaterialRepository.Delete(extraMaterial);
            _extraMaterialsConcrete._extraMaterialUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _extraMaterialsConcrete._extraMaterialUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
