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
    public class CategoryController : Controller
    {
        CategoryConcrete _categoryConcrete;

        public CategoryController()
        {
            _categoryConcrete = new CategoryConcrete();
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(_categoryConcrete._categoryRepository.GetAll());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            Category category = _categoryConcrete._categoryRepository.GetById(id);
            return View(category);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryConcrete._categoryRepository.Insert(category);
                _categoryConcrete._categoryUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _categoryConcrete._categoryRepository.GetById(id);
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryConcrete._categoryRepository.Update(category);
                _categoryConcrete._categoryUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = _categoryConcrete._categoryRepository.GetById(id);
            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _categoryConcrete._categoryRepository.GetById(id);
            _categoryConcrete._categoryRepository.Delete(category);
            _categoryConcrete._categoryUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoryConcrete._categoryUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
