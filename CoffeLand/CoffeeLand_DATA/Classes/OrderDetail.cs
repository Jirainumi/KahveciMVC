using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
	public class OrderDetail
	{
		public int ID { get; set; }
		public decimal UnitPrice { get; set; }
		public short Quantity { get; set; }

		public int OrderID { get; set; }
		public virtual Order OrderOfOrderDetail { get; set; }

		public int CoffeeID { get; set; }
		public virtual Coffee CoffeeOfOrderDetail { get; set; }

		public int BaristaID { get; set; }
		public virtual Barista BaristaOfOrderDetail { get; set; }
	}
}
