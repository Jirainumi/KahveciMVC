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
        public byte Point { get; set; }

        public int CoffeeID { get; set; }
        public virtual Coffee CoffeeOfCoffeeComment { get; set; }

        public int UserID { get; set; }
        public virtual User UserOfCoffeeComment { get; set; }
    }
}
