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
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				return View(_baristaConcrete._baristaRepository.GetAll());
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		
        }

        // GET: Admin/Baristas/Details/5
        public ActionResult Details(int id)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				Barista barista = _baristaConcrete._baristaRepository.GetById(id);
				return View(barista);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
			
        }

        // GET: Admin/Baristas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Baristas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Firstname,Lastname,Gender,BirthDate,HiredDate,AVGPoint")] Barista barista)
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
					_baristaConcrete._baristaRepository.Insert(barista);
					_baristaConcrete._baristaUnitOfWork.SaveChanges();
					return RedirectToAction("Index");
				}

				return View(barista);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}			
        }

        // GET: Admin/Baristas/Edit/5
        public ActionResult Edit(int id)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				Barista barista = _baristaConcrete._baristaRepository.GetById(id);
				return View(barista);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
			
        }

        // POST: Admin/Baristas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Firstname,Lastname,Gender,BirthDate,HiredDate,AVGPoint")] Barista barista)
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
					_baristaConcrete._baristaRepository.Update(barista);
					_baristaConcrete._baristaUnitOfWork.SaveChanges();
					return RedirectToAction("Index");
				}
				return View(barista);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
			
        }

        // GET: Admin/Baristas/Delete/5
        public ActionResult Delete(int id)
        {
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				Barista barista = _baristaConcrete._baristaRepository.GetById(id);
				return View(barista);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
			
        }

        // POST: Admin/Baristas/Delete/5
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
				Barista barista = _baristaConcrete._baristaRepository.GetById(id);
				_baristaConcrete._baristaRepository.Delete(barista);
				_baristaConcrete._baristaUnitOfWork.SaveChanges();
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
                _baristaConcrete._baristaUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
