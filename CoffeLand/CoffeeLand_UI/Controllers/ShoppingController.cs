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

		public ShoppingController()
		{
			_orderConcrete = new OrderConcrete();
			_coffeeConcrete = new CoffeeConcrete();
			_orderDetailConcrete = new OrderDetailConcrete();
			_wishListConcrete = new WishListConcrete();
		}

		[HttpPost]
		public ActionResult AddToCart(int id, FormCollection frm)
		{
			if (Session["OnlineKullanici"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				int miktar = 1;
				if (frm["miktar"] != null)
					miktar = Convert.ToInt32(frm["miktar"]);

				int baristaId = int.Parse(frm["barista"]);

				Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(id);
				Order order = new Order()
				{
					CustomerID = (Session["OnlineKullanici"] as Customer).ID,
					OrderDate = DateTime.Now,
					TotalPrice = miktar * coffee.Price
				};
				_orderConcrete._orderRepository.Insert(order);
				_orderConcrete._orderUnitOfWork.SaveChanges();

				OrderDetail od = _orderDetailConcrete._orderDetailRepository.GetAll().FirstOrDefault(x => x.CoffeeID == id && x.OrderOfOrderDetail.CustomerID == (Session["OnlineKullanici"] as Customer).ID && x.IsCompleted == false);

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

				_orderDetailConcrete._orderDetailUnitOfWork.SaveChanges();
				_orderDetailConcrete._orderDetailUnitOfWork.Dispose();

				return RedirectToAction("CoffeeDetail", "Coffee", new { id = id });
			}
		}

		public ActionResult AddToWishList(int id)
		{
			if (Session["OnlineKullanici"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				ControlWishList(id);
				return RedirectToAction("CoffeeDetail", "Coffee", new { id = id });
			}
		}

		public void ControlWishList(int id)
		{
			WishList wl = _wishListConcrete._wishListRepository.GetAll().FirstOrDefault(x => x.CoffeeID == id && x.CustomerID == (Session["OnlineKullanici"] as Customer).ID && x.IsActive == true);

			if (wl == null)
			{
				wl = new WishList()
				{
					CoffeeID = id,
					CustomerID = (Session["OnlineKullanici"] as Customer).ID,
					IsActive = true
				};
				_wishListConcrete._wishListRepository.Insert(wl);
				_wishListConcrete._wishListUnitOfWork.SaveChanges();

				_wishListConcrete._wishListUnitOfWork.Dispose();
			}
		}
		public ActionResult CartList()
		{
			return View(_orderDetailConcrete._orderDetailRepository.GetAll().Where(x => x.OrderOfOrderDetail.CustomerID == (Session["OnlineKullanici"] as Customer).ID && x.IsCompleted == false).ToList());
		}

		public ActionResult WishList()
		{
			return View(_wishListConcrete._wishListRepository.GetAll().Where(x => x.CustomerID == (Session["OnlineKullanici"] as Customer).ID && x.IsActive == true).ToList());
		}

		public ActionResult RemoveFromWishList(int id)
		{
			//Status kısmı düzenlenicek viewde 
			WishList wishList = _wishListConcrete._wishListRepository.GetById(id);
			_wishListConcrete._wishListRepository.Delete(wishList);
			_wishListConcrete._wishListUnitOfWork.SaveChanges();
			_wishListConcrete._wishListUnitOfWork.Dispose();

			return RedirectToAction("WishList", "Shopping");
		}
		public ActionResult RemoveFromCart(int id)
		{
			Order order = _orderConcrete._orderRepository.GetById(id);
			int orderID = order.ID;
			OrderDetail orderDetail = _orderDetailConcrete._orderDetailRepository.GetAll().FirstOrDefault(x => x.OrderID == orderID);
			int coffeeID = orderDetail.CoffeeID;


			_orderConcrete._orderRepository.Delete(order);
			_orderDetailConcrete._orderDetailRepository.Delete(orderDetail);
			_orderDetailConcrete._orderDetailUnitOfWork.SaveChanges();
			_orderDetailConcrete._orderDetailUnitOfWork.Dispose();

			return RedirectToAction("CartList", "Shopping");
		}

		public ActionResult AddToCartFromWishList(int id)
		{
			int coffeeID = _wishListConcrete._wishListRepository.GetAll().FirstOrDefault(x => x.WishlistID == id).CoffeeID;
			
			Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(coffeeID);
			Order order = new Order()
			{
				CustomerID = (Session["OnlineKullanici"] as Customer).ID,
				OrderDate = DateTime.Now,
				TotalPrice = 1 * coffee.Price
			};
			_orderConcrete._orderRepository.Insert(order);
			_orderConcrete._orderUnitOfWork.SaveChanges();

			OrderDetail od = _orderDetailConcrete._orderDetailRepository.GetAll().FirstOrDefault(x => x.CoffeeID == coffeeID && x.OrderOfOrderDetail.CustomerID == (Session["OnlineKullanici"] as Customer).ID && x.IsCompleted == false);

			if (od == null) //yeni kayıt yaptırıyoruz
			{
				od = new OrderDetail();
				od.CoffeeID = coffeeID;
				od.IsCompleted = false;
				od.UnitPrice = coffee.Price;
				od.Quantity = 1;
				od.BaristaID = 3; //TODO wishliste baristaıdeklenecek
				od.OrderID = order.ID;

				_orderDetailConcrete._orderDetailRepository.Insert(od);
			}
			else //update işlemi
			{
				od.Quantity += 1;
				order.TotalPrice = 1 * coffee.Price;
			}

			WishList wishlist = _wishListConcrete._wishListRepository.GetById(id);
			wishlist.IsActive = false;

			_wishListConcrete._wishListUnitOfWork.SaveChanges();
			_orderDetailConcrete._orderDetailUnitOfWork.SaveChanges();
			_orderDetailConcrete._orderDetailUnitOfWork.Dispose();


			return RedirectToAction("WishList", "Shopping");
		}

		public ActionResult Orders(string id)
		{
			//Todo:CustomerId içeriye alıp burdan yönlendiricez return ün içini dinamikleştiricez			
			return View(_orderConcrete._orderRepository.GetAll().Where(x => x.CustomerID == (Session["OnlineKullanici"] as Customer).ID).ToList());
		}

		public ActionResult AddToWishListFromCart(int id)
		{
			OrderDetail orderDetail = _orderDetailConcrete._orderDetailRepository.GetAll().FirstOrDefault(x => x.OrderID == id);
			Order order = _orderConcrete._orderRepository.GetById(orderDetail.OrderID);

			int coffeeID = orderDetail.CoffeeID;
			ControlWishList(coffeeID);

			_orderConcrete._orderRepository.Delete(order);
			_orderDetailConcrete._orderDetailRepository.Delete(orderDetail);
			_orderDetailConcrete._orderDetailUnitOfWork.SaveChanges();
			_orderDetailConcrete._orderDetailUnitOfWork.Dispose();

			//return RedirectToAction("WishList", "Shopping");
			return Redirect(Request.UrlReferrer.ToString());
		}

		public ActionResult UpdateQuantity(int id, FormCollection frm)
		{
			Order order = _orderConcrete._orderRepository.GetById(id);
			int orderID = order.ID;
			OrderDetail orderDetail = _orderDetailConcrete._orderDetailRepository.GetAll().FirstOrDefault(x => x.OrderID == orderID);


			orderDetail.Quantity = Convert.ToInt16(frm["quantity"]);
			order.TotalPrice = orderDetail.Quantity * orderDetail.UnitPrice;

			_orderDetailConcrete._orderDetailUnitOfWork.SaveChanges();
			_orderDetailConcrete._orderDetailUnitOfWork.Dispose();

			return Redirect(Request.UrlReferrer.ToString());
		}

	}
}