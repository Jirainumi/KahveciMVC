using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public string CustomerID { get; set; }
        public virtual Customer UserOfOrder { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
