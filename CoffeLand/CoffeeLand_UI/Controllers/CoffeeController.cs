using CoffeeLand_BLL.Repository.Concrete;
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
		public CoffeeController()
		{
			_coffeeConcrete = new CoffeeConcrete();
			_coffeeCommentConcrete = new CoffeeCommentConcrete();
		}

		public ActionResult Coffee(int id)
		{	
			return View(_coffeeConcrete._coffeeRepository.GetAll().Where(x => x.CategoryID == id).ToList());
		}

		public ActionResult CoffeeDetail(int id)
		{
			ViewData["Comments"] = _coffeeCommentConcrete._coffeeCommentRepository.GetAll().Where(x => x.CoffeeID == id).ToList();

			return View(_coffeeConcrete._coffeeRepository.GetById(id));
		}

	}
}