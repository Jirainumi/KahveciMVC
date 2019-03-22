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
    public class CustomerController : Controller
    {
        CustomerConcrete _customerConcrete;
        AuthorizationConrete _authorizationConrete;

        public CustomerController()
        {
            _customerConcrete = new CustomerConcrete();
            _authorizationConrete = new AuthorizationConrete();
        }

        // GET: Admin/Customer
        public ActionResult Index()
        {
            Customer loggedCustomer = Session["OnlineKullanici"] as Customer;

            if (loggedCustomer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (loggedCustomer.AuthorizationID == 1 || loggedCustomer.AuthorizationID == 2)
            {
                return View(_customerConcrete._customerRepository.GetAll());
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }

        // GET: Admin/Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer loggedCustomer = Session["OnlineKullanici"] as Customer;

            if (loggedCustomer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (loggedCustomer.AuthorizationID == 1 || loggedCustomer.AuthorizationID == 2)
            {
                Customer customer = _customerConcrete._customerRepository.GetById(id);
                return View(customer);
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }

        // GET: Admin/Customer/Create
        public ActionResult Create()
        {
            Customer loggedCustomer = Session["OnlineKullanici"] as Customer;

            if (loggedCustomer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (loggedCustomer.AuthorizationID == 1)
            {
                ViewBag.AuthorizationID = new SelectList(_authorizationConrete._authorizationRepository.GetEntity(), "ID", "AuthorizationName");
                return View();
            }
            else if (loggedCustomer.AuthorizationID == 2)
            {
                ViewBag.AuthorizationID = new SelectList(_authorizationConrete._authorizationRepository.GetEntity().Where(x => x.ID == 3), "ID", "AuthorizationName");
                return View();
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }

        // POST: Admin/Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,BirthDate,UserName,Password,AuthorizationID")] Customer customer)
        {
            Customer loggedCustomer = Session["OnlineKullanici"] as Customer;

            if (loggedCustomer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (loggedCustomer.AuthorizationID == 1)
            {
                if (ModelState.IsValid)
                {
                    _customerConcrete._customerRepository.Insert(customer);
                    _customerConcrete._customerUnitOfWork.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.AuthorizationID = new SelectList(_authorizationConrete._authorizationRepository.GetEntity(), "ID", "AuthorizationName");
                return View(customer);
            }
            else if (loggedCustomer.AuthorizationID == 2)
            {
                if (ModelState.IsValid)
                {
                    _customerConcrete._customerRepository.Insert(customer);
                    _customerConcrete._customerUnitOfWork.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.AuthorizationID = new SelectList(_authorizationConrete._authorizationRepository.GetEntity().Where(x => x.ID == 3), "ID", "AuthorizationName");
                return View(customer);
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }

        // GET: Admin/Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer loggedCustomer = Session["OnlineKullanici"] as Customer;

            if (loggedCustomer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (loggedCustomer.AuthorizationID == 1)
            {
                Customer customer = _customerConcrete._customerRepository.GetById(id);

                ViewBag.AuthorizationID = new SelectList(_authorizationConrete._authorizationRepository.GetEntity(), "ID", "AuthorizationName");
                return View(customer);
            }
            else if (loggedCustomer.AuthorizationID == 2)
            {
                Customer customer = _customerConcrete._customerRepository.GetById(id);

                ViewBag.AuthorizationID = new SelectList(_authorizationConrete._authorizationRepository.GetEntity().Where(x => x.ID == 3), "ID", "AuthorizationName");
                return View(customer);
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }

        // POST: Admin/Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Gender,BirthDate,UserName,Password,AuthorizationID")] Customer customer)
        {
            Customer loggedCustomer = Session["OnlineKullanici"] as Customer;

            if (loggedCustomer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (loggedCustomer.AuthorizationID == 1)
            {
                if (ModelState.IsValid)
                {
                    _customerConcrete._customerRepository.Update(customer);
                    _customerConcrete._customerUnitOfWork.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.AuthorizationID = new SelectList(_authorizationConrete._authorizationRepository.GetEntity(), "ID", "AuthorizationName");
                return View(customer);
            }
            else if (loggedCustomer.AuthorizationID == 2)
            {
                if (ModelState.IsValid)
                {
                    _customerConcrete._customerRepository.Update(customer);
                    _customerConcrete._customerUnitOfWork.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.AuthorizationID = new SelectList(_authorizationConrete._authorizationRepository.GetEntity().Where(x => x.ID == 3), "ID", "AuthorizationName");
                return View(customer);
            }
            else
            {
                return Redirect("/Coffee/Coffees");
            }
        }

        // GET: Admin/Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = _customerConcrete._customerRepository.GetById(id);
            return View(customer);
        }

        // POST: Admin/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer loggedCustomer = Session["OnlineKullanici"] as Customer;

            if (loggedCustomer == null)
            {
                return Redirect("/Login/Login");
            }
            else if (loggedCustomer.AuthorizationID == 1 || loggedCustomer.AuthorizationID == 2)
            {
                Customer customer = _customerConcrete._customerRepository.GetById(id);
                _customerConcrete._customerRepository.Delete(customer);
                _customerConcrete._customerUnitOfWork.SaveChanges();
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
                _customerConcrete._customerUnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
