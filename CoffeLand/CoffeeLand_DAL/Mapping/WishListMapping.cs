using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
   public class WishListMapping:EntityTypeConfiguration<WishList>
    {
        public WishListMapping()
        {
            HasKey(x => x.WishlistID);
            Property(x => x.IsActive).HasColumnType("bit");


            HasRequired(x => x.Coffee).WithMany(x => x.WishLists).HasForeignKey(x => x.CoffeeID);
            HasRequired(x => x.Customer).WithMany(x => x.WishLists).HasForeignKey(x => x.CustomerID);

           
        }

    }
}
