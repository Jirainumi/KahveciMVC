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
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				return View(_extraMaterialsConcrete._extraMaterialRepository.GetAll());
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
        }

        // GET: Admin/ExtraMaterial/Details/5
        public ActionResult Details(int id)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				ExtraMaterial extraMaterial = _extraMaterialsConcrete._extraMaterialRepository.GetById(id);
				return View(extraMaterial);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
        }

        // GET: Admin/ExtraMaterial/Create
        public ActionResult Create()
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				return View();
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
        }

        // POST: Admin/ExtraMaterial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,UnitPrice,Quantity")] ExtraMaterial extraMaterial)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				if (ModelState.IsValid)
				{
					_extraMaterialsConcrete._extraMaterialRepository.Insert(extraMaterial);
					_extraMaterialsConcrete._extraMaterialUnitOfWork.SaveChanges();
					return RedirectToAction("Index");
				}

				return View(extraMaterial);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
        }

        // GET: Admin/ExtraMaterial/Edit/5
        public ActionResult Edit(int id)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				ExtraMaterial extraMaterial = _extraMaterialsConcrete._extraMaterialRepository.GetById(id);
				return View(extraMaterial);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
        }

        // POST: Admin/ExtraMaterial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,UnitPrice,Quantity")] ExtraMaterial extraMaterial)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				if (ModelState.IsValid)
				{
					_extraMaterialsConcrete._extraMaterialRepository.Update(extraMaterial);
					_extraMaterialsConcrete._extraMaterialUnitOfWork.SaveChanges();
					return RedirectToAction("Index");
				}
				return View(extraMaterial);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
        }

        // GET: Admin/ExtraMaterial/Delete/5
        public ActionResult Delete(int id)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				ExtraMaterial extraMaterial = _extraMaterialsConcrete._extraMaterialRepository.GetById(id);
				return View(extraMaterial);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
        }

        // POST: Admin/ExtraMaterial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				ExtraMaterial extraMaterial = _extraMaterialsConcrete._extraMaterialRepository.GetById(id);
				_extraMaterialsConcrete._extraMaterialRepository.Delete(extraMaterial);
				_extraMaterialsConcrete._extraMaterialUnitOfWork.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
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
