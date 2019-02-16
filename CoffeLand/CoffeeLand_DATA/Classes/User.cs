using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
	public class User
	{
		public int ID { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }

		public virtual BaristaComment BaristaCommentOfUser { get; set; }
		public virtual CoffeeComment CoffeeCommentOfUser { get; set; }
		public virtual Authorization AuthorizationOfUser { get; set; }

		public virtual List<Order> Orders { get; set; }
	}
}
