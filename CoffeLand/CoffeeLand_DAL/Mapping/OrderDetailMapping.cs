using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
    public class OrderDetailMapping : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.UnitPrice).HasColumnType("money");
            Property(x => x.Quantity).HasColumnType("smallint");
            Property(x => x.IsCompleted).HasColumnType("bit");

            HasRequired(x => x.OrderOfOrderDetail).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderID);
            HasRequired(x => x.CoffeeOfOrderDetail).WithMany(x => x.OrderDetails).HasForeignKey(x => x.CoffeeID);
            HasRequired(x => x.BaristaOfOrderDetail).WithMany(x => x.OrderDetails).HasForeignKey(x => x.BaristaID);
        }
    }
}
