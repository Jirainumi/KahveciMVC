﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DATA.Classes
{
    public class ExtraMaterial
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public virtual List<Coffee> Coffees { get; set; }
    }
}
