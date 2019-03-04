using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
    public class CoffeesMapping : EntityTypeConfiguration<Coffee>
    {
        public CoffeesMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.CoffeeName).HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Description).HasColumnType("nvarchar");
            Property(x => x.Price).HasColumnType("money");
            Property(x => x.AVGPoint).HasColumnType("decimal");
			Property(x => x.ImageUrl).HasColumnType("nvarchar").HasMaxLength(500);
			Property(x => x.AltText).HasColumnType("nvarchar").HasMaxLength(200);

			HasRequired(x => x.ExtraMaterialOfCoffee).WithMany(x => x.Coffees).HasForeignKey(x => x.ExtraMaterialsID);
            HasRequired(x => x.CategoryOfCoffee).WithMany(x => x.Coffees).HasForeignKey(x => x.CategoryID);
        }
    }
}
