using CoffeeLand_BLL.Repository.Concrete;
using CoffeeLand_DATA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CoffeeLand_UI.Controllers
{
	public class ShoppingController : Controller
	{
		OrderConcrete _orderConcrete;
		CoffeeConcrete _coffeeConcrete;
		OrderDetailConcrete _orderDetailConcrete;
		WishListConcrete _wishListConcrete;

		[HttpPost]
		public ActionResult AddToCart(int id, FormCollection frm)
		{
			//TODO: login olmuş kullanıcı denetimi yapılacak
			int miktar = 1;
			if (frm["miktar"] != null)
				miktar = Convert.ToInt32(frm["miktar"]);

			int baristaId = int.Parse(frm["barista"]);

			ControlCart(id, baristaId, miktar);

			return RedirectToAction("CoffeeDetail", "Coffee", new { id = id });
		}

		private void ControlCart(int id, int baristaId, int miktar = 1)
		{
			_orderConcrete = new OrderConcrete();
			_coffeeConcrete = new CoffeeConcrete();
			_orderDetailConcrete = new OrderDetailConcrete();

			Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(id);
			Order order = new Order()
			{
				CustomerID = "1", //TODO: userıd eklenecek, dinamik hale getirilecek
				OrderDate = DateTime.Now,
				TotalPrice = miktar * coffee.Price
			};
			_orderConcrete._orderRepository.Insert(order);

			// TODO: userıd eklenecek, dinamik hale getirilecek
			OrderDetail od = _orderDetailConcrete._orderDetailRepository.GetAll().FirstOrDefault(x => x.CoffeeID == id && x.OrderOfOrderDetail.CustomerID == "1" && x.IsCompleted == false);

			if (od == null) //yeni kayıt yaptırıyoruz
			{
				od = new OrderDetail();
				od.CoffeeID = id;
				od.IsCompleted = false;
				od.UnitPrice = coffee.Price;
				od.Quantity = Convert.ToInt16(miktar);
				od.BaristaID = baristaId;
				od.OrderID = order.ID;


				_orderDetailConcrete._orderDetailRepository.Insert(od);
			}
			else //update işlemi
			{
				od.Quantity += Convert.ToInt16(miktar);
				order.TotalPrice = miktar * coffee.Price;
			}
			_orderConcrete._orderUnitOfWork.SaveChanges();
			_orderConcrete._orderUnitOfWork.Dispose();
		}

		public ActionResult AddToWishList(int id)
		{
			//TODO: login olmuş kullanıcı denetimi yapılacak

			ControlWishList(id);

			return RedirectToAction("CoffeeDetail", "Coffee", new { id = id });
		}

		public void ControlWishList(int id)
		{
			_wishListConcrete = new WishListConcrete();

			// TODO: userıd eklenecek, dinamik hale getirilecek
			WishList wl = _wishListConcrete._wishListRepository.GetAll().FirstOrDefault(x => x.CoffeeID == id && x.CustomerID == "1" && x.IsActive == true);

			if (wl == null)
			{
				wl = new WishList()
				{
					CoffeeID = id,
					CustomerID = "1", //TODO: userıd eklenecek, dinamik hale getirilecek
					IsActive = true
				};
				_wishListConcrete._wishListRepository.Insert(wl);
				_wishListConcrete._wishListUnitOfWork.SaveChanges();

				_wishListConcrete._wishListUnitOfWork.Dispose();
			}
		}
		public ActionResult CartList()
		{
			_orderDetailConcrete = new OrderDetailConcrete();

			//TODO: userıd eklenecek, dinamik hale getirilecek
			return View(_orderDetailConcrete._orderDetailRepository.GetAll().Where(x => x.OrderOfOrderDetail.CustomerID == "1" && x.IsCompleted == false).ToList());
		}

		public ActionResult WishList()
		{
			_wishListConcrete = new WishListConcrete();

			//TODO: userıd eklenecek, dinamik hale getirilecek
			return View(_wishListConcrete._wishListRepository.GetAll().Where(x => x.CustomerID == "1" && x.IsActive == true).ToList());
		}
	}
}