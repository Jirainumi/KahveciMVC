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
        CustomerConcrete _customerConcrete;

        public AccountController()
        {
            _customerConcrete = new CustomerConcrete();
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
    }
}