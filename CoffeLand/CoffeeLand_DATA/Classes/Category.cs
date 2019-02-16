using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
	public class Category
	{
		public int ID { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }

		public virtual List<Coffee> Coffees { get; set; }
	}
}
