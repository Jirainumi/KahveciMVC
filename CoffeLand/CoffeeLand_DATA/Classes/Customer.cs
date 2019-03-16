using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
    public class Customer
    {

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }



        public int AuthorizationID { get; set; }
        public virtual Authorization AuthorizationsOfCustomer { get; set; }

        public virtual List<Order> OrdersOfCustomer { get; set; }
        public virtual List<CoffeeComment> CoffeeCommentsOfCustomer { get; set; }
        public virtual List<BaristaComment> BaristaCommentsOfCustomer { get; set; }
        public virtual List<WishList> WishLists { get; set; }
    }
}
