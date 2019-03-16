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


                //TODO: login olmuş kullanıcı denetimi yapılacak
                int miktar = 1;
                if (frm["miktar"] != null)
                    miktar = Convert.ToInt32(frm["miktar"]);

                int baristaId = int.Parse(frm["barista"]);

                Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(id);
                Order order = new Order()
                {
                    CustomerID = (Session["OnlineKullanici"] as Customer).ID, //TODO: userıd eklenecek, dinamik hale getirilecek
                    OrderDate = DateTime.Now,
                    TotalPrice = miktar * coffee.Price
                };
                _orderConcrete._orderRepository.Insert(order);
                _orderConcrete._orderUnitOfWork.SaveChanges();

                // TODO: userıd eklenecek, dinamik hale getirilecek
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

        public void ControlCart(int id, int quantity = 1)
        {
            /*TODO:
            CustomerID dinamik olucak
            OrderDate eklenebilir
            Update işlemi için stock kullanılıcak database güncellenicek coffee için
            */
            OrderDetail od = _orderDetailConcrete._orderDetailRepository.GetAll().FirstOrDefault(x => x.OrderOfOrderDetail.CustomerID == (Session["OnlineKullanici"] as Customer).ID && x.IsCompleted == false && x.CoffeeID == id);

            if (od == null)
            {
                od = new OrderDetail();

                od.CoffeeID = id;
                od.OrderOfOrderDetail.CustomerID = (Session["OnlineKullanici"] as Customer).ID;//Dinamik olucak
                od.IsCompleted = false;
                od.UnitPrice = _orderDetailConcrete._orderDetailRepository.GetById(id).CoffeeOfOrderDetail.Price;
                od.UnitPrice = od.Quantity * od.UnitPrice;

                _orderDetailConcrete._orderDetailRepository.Insert(od);
                _orderDetailConcrete._orderDetailUnitOfWork.SaveChanges();

                _orderDetailConcrete._orderDetailUnitOfWork.Dispose();
            }
            else
            {//UPDATE işlemi burası
             //Todo
            }
        }

        public void ControlWishList(int id)
        {
            // TODO: userıd eklenecek, dinamik hale getirilecek
            WishList wl = _wishListConcrete._wishListRepository.GetAll().FirstOrDefault(x => x.CoffeeID == id && x.CustomerID == (Session["OnlineKullanici"] as Customer).ID && x.IsActive == true);

            if (wl == null)
            {
                wl = new WishList()
                {
                    CoffeeID = id,
                    CustomerID = (Session["OnlineKullanici"] as Customer).ID, //TODO: userıd eklenecek, dinamik hale getirilecek
                    IsActive = true
                };
                _wishListConcrete._wishListRepository.Insert(wl);
                _wishListConcrete._wishListUnitOfWork.SaveChanges();

                _wishListConcrete._wishListUnitOfWork.Dispose();
            }
        }
        public ActionResult CartList()
        {
            //TODO: userıd eklenecek, dinamik hale getirilecek
            return View(_orderDetailConcrete._orderDetailRepository.GetAll().Where(x => x.OrderOfOrderDetail.CustomerID == (Session["OnlineKullanici"] as Customer).ID && x.IsCompleted == false).ToList());
        }

        public ActionResult WishList()
        {
            //TODO: userıd eklenecek, dinamik hale getirilecek
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

        public ActionResult AddToCartFromWishList(int id)
        {
            Coffee coffee = _coffeeConcrete._coffeeRepository.GetById(id);
            ControlCart(coffee.ID);

            WishList wishlist = _wishListConcrete._wishListRepository.GetById(id);
            wishlist.IsActive = false;
            _wishListConcrete._wishListUnitOfWork.SaveChanges();
            _wishListConcrete._wishListUnitOfWork.Dispose();
            return RedirectToAction("WishList", "Shopping");
        }

        public ActionResult Orders(string id)
        {
            //Todo:CustomerId içeriye alıp burdan yönlendiricez return ün içini dinamikleştiricez			
            return View(_orderConcrete._orderRepository.GetAll().Where(x => x.CustomerID == (Session["OnlineKullanici"] as Customer).ID).ToList());
        }



    }
}