using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
	public class BaristaComment
	{
		public int ID { get; set; }
		public string Comment { get; set; }
		public byte Point { get; set; }

		public int BaristaID { get; set; }
		public virtual Barista BaristaOfBaristaComment { get; set; }

		public virtual User UserOfBaristaComment { get; set; }
	}
}
