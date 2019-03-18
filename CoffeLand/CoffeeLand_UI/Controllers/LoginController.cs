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
    public class LoginController : Controller
    {
        CustomerConcrete _customerConcrete;


        public LoginController()
        {
            _customerConcrete = new CustomerConcrete();
        }

        public ActionResult Register()
        {
            Tools.ReturnUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection frm)
        {
            string kullaniciAdi = frm["username"];

            Customer customer = _customerConcrete.GetCustomerByUsername(kullaniciAdi);

            if (customer != null)
            {
                return View();
            }
            else
            {
                string isim = frm["firstname"];
                string soyisim = frm["lastname"];
                string sifre = frm["password"];
                bool cinsiyet = frm["gender"] == "on" ? true : false;
                DateTime dogumTarihi = DateTime.Parse(frm["birthdate"]);

                customer = new Customer();

                customer.FirstName = isim;
                customer.LastName = soyisim;
                customer.UserName = kullaniciAdi;
                customer.Password = sifre;
                customer.BirthDate = dogumTarihi;
                customer.AuthorizationID = 3;

                _customerConcrete._customerRepository.Insert(customer);
                _customerConcrete._customerUnitOfWork.SaveChanges();

                Session["OnlineKullanici"] = customer;

                _customerConcrete._customerUnitOfWork.Dispose();

                return Redirect(Tools.ReturnUrl);
            }
        }

        public ActionResult Login()
        {
            Tools.ReturnUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string kullaniciAdi = frm["username"];
            string sifre = frm["password"];
            Customer customer = _customerConcrete.LoginControl(kullaniciAdi, sifre);

            if (customer != null)
            {
                Session["OnlineKullanici"] = customer;

                if (Tools.ReturnUrl == "http://localhost:50714/Login/Register")
                {
                    return RedirectToAction("Coffees", "Shopping");
                }
                else
                {
                    return Redirect(Tools.ReturnUrl);
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            Session["OnlineKullanici"] = null;

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}