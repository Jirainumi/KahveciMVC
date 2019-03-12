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
        [ForeignKey("ApplicationUser")]
        public string ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


        public virtual ApplicationUser ApplicationUser{ get; set; }
        public virtual List<Order> OrdersOfUser { get; set; }
        public virtual List<CoffeeComment> CoffeeCommentsOfUser { get; set; }
        public virtual List<BaristaComment> BaristaCommentsOfUser { get; set; }
        public virtual List<WishList> WishLists { get; set; }
    }
}
