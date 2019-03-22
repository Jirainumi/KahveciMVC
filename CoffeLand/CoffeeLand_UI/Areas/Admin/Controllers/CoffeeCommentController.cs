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
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				return View(_coffeeCommentConcrete._coffeeCommentRepository.GetAll());
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// GET: Admin/CoffeeComments/Details/5
		public ActionResult Details(int id)
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				CoffeeComment coffeeComment = _coffeeCommentConcrete._coffeeCommentRepository.GetById(id);
				return View(coffeeComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// GET: Admin/CoffeeComments/Create
		public ActionResult Create()
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
				ViewBag.UserID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "UserName");
				return View();
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// POST: Admin/CoffeeComments/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,Comment,Point,CoffeeCommentDate,CoffeeID,UserID")] CoffeeComment coffeeComment)
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
					_coffeeCommentConcrete._coffeeCommentRepository.Insert(coffeeComment);
					_coffeeCommentConcrete._coffeeCommentUnitOfWork.SaveChanges();
					return RedirectToAction("Index");
				}

				ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName");
				ViewBag.UserID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "UserName");
				return View(coffeeComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// GET: Admin/CoffeeComments/Edit/5
		public ActionResult Edit(int id)
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				CoffeeComment coffeeComment = _coffeeCommentConcrete._coffeeCommentRepository.GetById(id);

				ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName", coffeeComment.CoffeeID);
				ViewBag.UserID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "UserName", coffeeComment.CustomerID);
				return View(coffeeComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// POST: Admin/CoffeeComments/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Comment,Point,CoffeeCommentDate,CoffeeID,UserID")] CoffeeComment coffeeComment)
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
					_coffeeCommentConcrete._coffeeCommentRepository.Update(coffeeComment);
					_coffeeCommentConcrete._coffeeCommentUnitOfWork.SaveChanges();
					return RedirectToAction("Index");
				}
				ViewBag.CoffeeID = new SelectList(_coffeeConcrete._coffeeRepository.GetEntity(), "ID", "CoffeeName", coffeeComment.CoffeeID);
				ViewBag.UserID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "UserName", coffeeComment.CustomerID);
				return View(coffeeComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// GET: Admin/CoffeeComments/Delete/5
		public ActionResult Delete(int id)
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				CoffeeComment coffeeComment = _coffeeCommentConcrete._coffeeCommentRepository.GetById(id);
				return View(coffeeComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// POST: Admin/CoffeeComments/Delete/5
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
				CoffeeComment coffeeComment = _coffeeCommentConcrete._coffeeCommentRepository.GetById(id);
				_coffeeCommentConcrete._coffeeCommentRepository.Delete(coffeeComment);
				_coffeeCommentConcrete._coffeeCommentUnitOfWork.SaveChanges();
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
				_coffeeCommentConcrete._coffeeCommentUnitOfWork.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
