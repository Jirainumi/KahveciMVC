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

        public byte? Point { get; set; }

		public DateTime BaristaCommentDate { get; set; }


		public int BaristaID { get; set; }
        public virtual Barista BaristaOfBaristaComment { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer CustomerOfBaristaComment { get; set; }
    }
}
