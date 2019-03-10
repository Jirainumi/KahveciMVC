﻿using System;
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
    public class CoffeeController : Controller
    {
        CoffeeConcrete _coffeeConcrete;
        CategoryConcrete _categoryConcrete;
        ExtraMaterialsConcrete _extraMaterialsConcrete;

        public CoffeeController()
        {
            _coffeeConcrete = new CoffeeConcrete();
            _categoryConcrete = new CategoryConcrete();
            _extraMaterialsConcrete = new ExtraMaterialsConcrete();
        }

        // GET: Admin/Coffee
        public ActionResult Index()
        {
            return View(_coffeeConcrete._coffeeRepository.GetAll());
        }

        // GET: Admin/Coffee/Details/5
        public ActionResult Details(int id)
        {
            Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(id);
            return View(coffee);
        }

        // GET: Admin/Coffee/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(_categoryConcrete._categoryRepository.GetEntity(), "ID", "CategoryName");
            ViewBag.ExtraMaterialsID = new SelectList(_extraMaterialsConcrete._extraMaterialRepository.GetEntity(), "ID", "Name");
            return View();
        }

        // POST: Admin/Coffee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CoffeeName,Description,Price,AVGPoint,ExtraMaterialsID,CategoryID,ImageUrl,AltText")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                _coffeeConcrete._coffeeRepository.Insert(coffee);
                _coffeeConcrete._coffeeUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(_categoryConcrete._categoryRepository.GetEntity(), "ID", "CategoryName", coffee.CategoryID);
            ViewBag.ExtraMaterialsID = new SelectList(_extraMaterialsConcrete._extraMaterialRepository.GetEntity(), "ID", "Name", coffee.ExtraMaterialsID);
            return View(coffee);
        }

        // GET: Admin/Coffee/Edit/5
        public ActionResult Edit(int id)
        {
            Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(id);
            ViewBag.CategoryID = new SelectList(_categoryConcrete._categoryRepository.GetEntity(), "ID", "CategoryName", coffee.CategoryID);
            ViewBag.ExtraMaterialsID = new SelectList(_extraMaterialsConcrete._extraMaterialRepository.GetEntity(), "ID", "Name", coffee.ExtraMaterialsID);
            return View(coffee);
        }

        // POST: Admin/Coffee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CoffeeName,Description,Price,AVGPoint,ExtraMaterialsID,CategoryID,ImageUrl,AltText")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                _coffeeConcrete._coffeeRepository.Update(coffee);
                _coffeeConcrete._coffeeUnitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(_categoryConcrete._categoryRepository.GetEntity(), "ID", "CategoryName", coffee.CategoryID);
            ViewBag.ExtraMaterialsID = new SelectList(_extraMaterialsConcrete._extraMaterialRepository.GetEntity(), "ID", "Name", coffee.ExtraMaterialsID);
            return View(coffee);
        }

        // GET: Admin/Coffee/Delete/5
        public ActionResult Delete(int id)
        {
            Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(id);
            return View(coffee);
        }

        // POST: Admin/Coffee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(id);
            _coffeeConcrete._coffeeRepository.Delete(coffee);
            _coffeeConcrete._coffeeUnitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _coffeeConcrete._coffeeUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}