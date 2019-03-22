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
		CustomerConcrete _customerConcrete;
		BaristaConcrete _baristaConcrete;

		public BaristaCommentController()
		{
			_baristaCommentConrete = new BaristaCommentConrete();
			_customerConcrete = new CustomerConcrete();
			_baristaConcrete = new BaristaConcrete();
		}

		// GET: Admin/BaristaComment
		public ActionResult Index()
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				return View(_baristaCommentConrete._baristaCommentRepository.GetAll());
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// GET: Admin/BaristaComment/Details/5
		public ActionResult Details(int id)
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				BaristaComment baristaComment = _baristaCommentConrete._baristaCommentRepository.GetById(id);
				return View(baristaComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// GET: Admin/BaristaComment/Create
		public ActionResult Create()
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
				ViewBag.CustomerID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "FirstName");
				return View();
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// POST: Admin/BaristaComment/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "ID,Comment,Point,BaristaCommentDate,BaristaID,CustomerID")] BaristaComment baristaComment)
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
					_baristaCommentConrete._baristaCommentRepository.Insert(baristaComment);
					_baristaCommentConrete._baristaCommentUnitOfWork.SaveChanges();
					return RedirectToAction("Index");
				}

				ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname");
				ViewBag.CustomerID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "FirstName");
				return View(baristaComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// GET: Admin/BaristaComment/Edit/5
		public ActionResult Edit(int id)
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				BaristaComment baristaComment = _baristaCommentConrete._baristaCommentRepository.GetById(id);

				ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname", baristaComment.BaristaID);
				ViewBag.CustomerID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "FirstName", baristaComment.CustomerID);
				return View(baristaComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// POST: Admin/BaristaComment/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "ID,Comment,Point,BaristaCommentDate,BaristaID,CustomerID")] BaristaComment baristaComment)
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
					_baristaCommentConrete._baristaCommentRepository.Update(baristaComment);
					_baristaCommentConrete._baristaCommentUnitOfWork.SaveChanges();
					return RedirectToAction("Index");
				}
				ViewBag.BaristaID = new SelectList(_baristaConcrete._baristaRepository.GetEntity(), "ID", "Firstname", baristaComment.BaristaID);
				ViewBag.CustomerID = new SelectList(_customerConcrete._customerRepository.GetEntity(), "ID", "FirstName", baristaComment.CustomerID);
				return View(baristaComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// GET: Admin/BaristaComment/Delete/5
		public ActionResult Delete(int id)
		{
			Customer customer = Session["OnlineKullanici"] as Customer;

			if (customer == null)
			{
				return Redirect("/Login/Login");
			}
			else if (customer.AuthorizationID == 1 || customer.AuthorizationID == 2)
			{
				BaristaComment baristaComment = _baristaCommentConrete._baristaCommentRepository.GetById(id);
				return View(baristaComment);
			}
			else
			{
				return Redirect("/Coffee/Coffees");
			}
		}

		// POST: Admin/BaristaComment/Delete/5
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
				BaristaComment baristaComment = _baristaCommentConrete._baristaCommentRepository.GetById(id);
				_baristaCommentConrete._baristaCommentRepository.Delete(baristaComment);
				_baristaCommentConrete._baristaCommentUnitOfWork.SaveChanges();
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
				_baristaCommentConrete._baristaCommentUnitOfWork.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
