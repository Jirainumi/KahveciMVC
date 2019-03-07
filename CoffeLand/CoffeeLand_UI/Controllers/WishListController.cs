using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeLand_UI.Controllers
{
    public class WishListController : Controller
    {
        /*
         İstek listesini sepetten farklı olarak bilerek yazdım daha ayrı clean bi şekilde kodlarız İsteğe bağlı tek Controller a atabiliriz
             Database e hem WishList Hemde Cart tabloları eklenicek
             Şuan içinde örnek 2 tane öylesine orjinal templatedeki ürün var
             */
        public ActionResult WishList()
        {
            return View();
        }
    }
}