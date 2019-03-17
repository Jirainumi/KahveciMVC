using CoffeeLand_BLL.Repository.Concrete;
using CoffeeLand_DATA.Classes;
using CoffeeLand_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeLand_UI.Controllers
{
	public class AccountController : Controller
	{
		OrderConcrete _orderConcrete;
		CustomerConcrete _customerConcrete;
		OrderDetailConcrete _orderDetailConcrete;
		BaristaConcrete _baristaConcrete;
		CoffeeConcrete _coffeeConcrete;

		public AccountController()
		{
			_orderConcrete = new OrderConcrete();
			_customerConcrete = new CustomerConcrete();
			_orderDetailConcrete = new OrderDetailConcrete();
			_baristaConcrete = new BaristaConcrete();
			_coffeeConcrete = new CoffeeConcrete();
		}

		public ActionResult Account(string username)
		{
			if (Session["OnlineKullanici"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				Customer customer;
				if ((Session["OnlineKullanici"] as Customer).UserName != username)
				{
					return RedirectToAction("Login", "Login");
				}
				else
				{
					customer = (Session["OnlineKullanici"] as Customer);
				}
				return View(customer);
			}
		}

		[HttpPost]
		public ActionResult ProfileUpdate(FormCollection frm)
		{
			if (Session["OnlineKullanici"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				Customer customer = _customerConcrete._customerRepository.GetById((Session["OnlineKullanici"] as Customer).ID);
				customer.FirstName = frm["firstname"];
				customer.LastName = frm["lastname"];
				customer.BirthDate = DateTime.Parse(frm["birthdate"]);

				_customerConcrete._customerRepository.Update(customer);
				_customerConcrete._customerUnitOfWork.SaveChanges();
				_customerConcrete._customerUnitOfWork.Dispose();

				return Redirect(Request.UrlReferrer.ToString());
			}
		}

		[HttpPost]
		public ActionResult ChangePassword(FormCollection frm)
		{
			if (Session["OnlineKullanici"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				Customer customer = _customerConcrete._customerRepository.GetById((Session["OnlineKullanici"] as Customer).ID);
				customer.Password = frm["newpassword"];

				_customerConcrete._customerRepository.Update(customer);
				_customerConcrete._customerUnitOfWork.SaveChanges();
				_customerConcrete._customerUnitOfWork.Dispose();

				return Redirect(Request.UrlReferrer.ToString());
			}
		}


		public ActionResult MyOrders(string username)
		{
				Customer customer = _customerConcrete._customerRepository.GetAll().FirstOrDefault(x => x.UserName == username);

				List<OrderDetail> orders = _orderDetailConcrete._orderDetailRepository.GetAll().Where(x => x.OrderOfOrderDetail.CustomerID == customer.ID && x.IsCompleted == true).ToList();

				ViewBag.MyOrders = orders;

				return View(customer.ID);
			
		}

		[HttpPost]
		public ActionResult GiveRate(int id, FormCollection frm)
		{
			OrderDetail orderDetail = _orderDetailConcrete._orderDetailRepository.GetById(id);
			int baristaId = orderDetail.BaristaID;
			int coffeeId = orderDetail.CoffeeID;

			Barista barista = _baristaConcrete._baristaRepository.GetById(baristaId);
			Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(coffeeId);

			barista.AVGPoint += Convert.ToDecimal(frm["barista_rate"]);
			coffee.AVGPoint += Convert.ToDecimal(frm["coffe_rate"]);

			_coffeeConcrete._coffeeUnitOfWork.SaveChanges();
			_baristaConcrete._baristaUnitOfWork.SaveChanges();

			_baristaConcrete._baristaUnitOfWork.Dispose();

			return Redirect(Request.UrlReferrer.ToString());
		}
	}
}