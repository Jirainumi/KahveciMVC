using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.OrderDate).HasColumnType("datetime2");
            Property(x => x.TotalPrice).HasColumnType("money");

            HasRequired(x => x.CustomerOfOrder).WithMany(x => x.OrdersOfCustomer).HasForeignKey(x => x.CustomerID);
        }
    }
}
