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
		BaristaCommentConrete _baristaCommentConcrete;
		CoffeeCommentConcrete _coffeeCommentConcrete;

		public AccountController()
		{
			_orderConcrete = new OrderConcrete();
			_customerConcrete = new CustomerConcrete();
			_orderDetailConcrete = new OrderDetailConcrete();
			_baristaConcrete = new BaristaConcrete();
			_coffeeConcrete = new CoffeeConcrete();
			_coffeeCommentConcrete = new CoffeeCommentConcrete();
			_baristaCommentConcrete = new BaristaCommentConrete();

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
				Session["OnlineKullanici"] = customer;
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
                //Şİfre kontrolü yap

                if(frm["newpassword"]== frm["confirmnewpassword"])
                {
                    customer.Password = frm["newpassword"];

                    _customerConcrete._customerRepository.Update(customer);
                    _customerConcrete._customerUnitOfWork.SaveChanges();
                    _customerConcrete._customerUnitOfWork.Dispose();
                   
                    return Redirect(Request.UrlReferrer.ToString());
                }

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
            if (Session["OnlineKullanici"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

			OrderDetail orderDetail = _orderDetailConcrete._orderDetailRepository.GetById(id);
			int baristaId = orderDetail.BaristaID;
			int coffeeId = orderDetail.CoffeeID;

			BaristaComment baristaComment = new BaristaComment()
			{
				BaristaID = baristaId,
				CustomerID = (Session["OnlineKullanici"] as Customer).ID,
				Point = Convert.ToByte(frm["brating"]),
                BaristaCommentDate = DateTime.Now
			};
			_baristaCommentConcrete._baristaCommentRepository.Insert(baristaComment);
			_baristaCommentConcrete._baristaCommentUnitOfWork.SaveChanges();

			CoffeeComment coffeeComment = new CoffeeComment()
			{
				CustomerID = (Session["OnlineKullanici"] as Customer).ID,
				CoffeeID = coffeeId,
				Point = Convert.ToByte(frm["crating"]),
                CoffeeCommentDate = DateTime.Now
            };

			_coffeeCommentConcrete._coffeeCommentRepository.Insert(coffeeComment);
			_coffeeCommentConcrete._coffeeCommentUnitOfWork.SaveChanges();

			Barista barista = _baristaConcrete._baristaRepository.GetById(baristaId);
			Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(coffeeId);

			barista.AVGPoint = _baristaCommentConcrete.CalculateBaristaAVGPoint();
			coffee.AVGPoint = _coffeeCommentConcrete.CalculateCoffeeAVGPoint();

			_coffeeConcrete._coffeeUnitOfWork.SaveChanges();
			_baristaConcrete._baristaUnitOfWork.SaveChanges();

			orderDetail.IsRated = true;
			_orderDetailConcrete._orderDetailUnitOfWork.SaveChanges();

			_baristaConcrete._baristaUnitOfWork.Dispose();

			return Redirect(Request.UrlReferrer.ToString());
		}
	}
}