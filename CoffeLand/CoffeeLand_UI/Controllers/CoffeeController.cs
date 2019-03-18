using CoffeeLand_BLL.Repository.Concrete;
using CoffeeLand_DATA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeLand_UI.Controllers
{
	public class CoffeeController : Controller
	{
		CoffeeConcrete _coffeeConcrete;
		CoffeeCommentConcrete _coffeeCommentConcrete;
		BaristaConcrete _baristaConcrete;
		public CoffeeController()
		{
			_baristaConcrete = new BaristaConcrete();
			_coffeeConcrete = new CoffeeConcrete();
			_coffeeCommentConcrete = new CoffeeCommentConcrete();
		}
		public ActionResult Coffees()
		{
			return View(_coffeeConcrete._coffeeRepository.GetAll().ToList());
		}

		public ActionResult HighPrice()
		{
			return View(_coffeeConcrete._coffeeRepository.GetAll().OrderByDescending(x => x.Price).Take(20).ToList());
		}
		public ActionResult LowPrice()
		{
			return View(_coffeeConcrete._coffeeRepository.GetAll().OrderBy(x => x.Price).Take(20).ToList());
		}
		public ActionResult HighPoint()
		{
			return View(_coffeeConcrete._coffeeRepository.GetAll().OrderByDescending(x => x.AVGPoint).Take(20).ToList());

		}
		public ActionResult NumberOfComment()
		{
			return View(_coffeeConcrete._coffeeRepository.GetAll().OrderByDescending(x => x.CoffeeComments.Count).Take(20).ToList());
		}

		public ActionResult Coffee(int id)
		{
			return View(_coffeeConcrete._coffeeRepository.GetAll().Where(x => x.CategoryID == id).ToList());
		}

		public ActionResult CoffeeDetail(int id)
		{

			ViewBag.Baristas = _baristaConcrete._baristaRepository.GetAll().ToList();

			ViewData["Comments"] = _coffeeCommentConcrete._coffeeCommentRepository.GetAll().Where(x => x.CoffeeID == id).ToList();

			return View(_coffeeConcrete._coffeeRepository.GetById(id));
		}

		[HttpPost]
		public ActionResult AddReview(int id, FormCollection frm)
		{
			CoffeeComment coffeeComment = new CoffeeComment()
			{
				CoffeeID = id,
				Comment = frm["review"],
				CustomerID = (Session["OnlineKullanici"] as Customer).ID,
				CoffeeCommentDate=DateTime.Now				
			};
			_coffeeCommentConcrete._coffeeCommentRepository.Insert(coffeeComment);

			_coffeeCommentConcrete._coffeeCommentUnitOfWork.SaveChanges();
			_coffeeCommentConcrete._coffeeCommentUnitOfWork.Dispose();

			return Redirect(Request.UrlReferrer.ToString());
		}
	}
}