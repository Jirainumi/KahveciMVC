using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
    public class CoffeeComment
    {
        public int ID { get; set; }

        public string Comment { get; set; }

		public DateTime CoffeeCommentDate { get; set; }

		public int CoffeeID { get; set; }
        public virtual Coffee CoffeeOfCoffeeComment { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer CustomerOfCoffeeComment { get; set; }


    }
}
