using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
    public class Coffee
    {
        public int ID { get; set; }

        public string CoffeeName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal AVGPoint { get; set; }

		public string ImageUrl { get; set; }

		public string AltText { get; set; }

        public bool IsPrepared { get; set; }

        public int ExtraMaterialsID { get; set; }
        public virtual ExtraMaterial ExtraMaterialOfCoffee { get; set; }

        public int CategoryID { get; set; }
        public virtual Category CategoryOfCoffee { get; set; }

		public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<CoffeeComment> CoffeeComments { get; set; }
        public virtual List<WishList> WishLists { get; set; }

    }
}
