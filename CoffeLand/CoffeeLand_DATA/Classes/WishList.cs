using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
   public class WishList
    {
        [Key]
        public int WishlistID { get; set; }
        public bool IsActive { get; set; }



        public string CustomerID { get; set; }
        public virtual Customer User { get; set; }


        public int CoffeeID { get; set; }
        public virtual Coffee Coffee { get; set; }
    }
}
