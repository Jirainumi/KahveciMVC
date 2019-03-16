using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
    public class CoffeeCommentMapping : EntityTypeConfiguration<CoffeeComment>
    {
        public CoffeeCommentMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.Comment).HasColumnType("nvarchar");
            Property(x => x.Point).HasColumnType("tinyint");
			Property(x => x.CoffeeCommentDate).HasColumnType("datetime2");

            HasRequired(x => x.CoffeeOfCoffeeComment).WithMany(x => x.CoffeeComments).HasForeignKey(x => x.CoffeeID);
            HasRequired(x => x.CustomerOfCoffeeComment).WithMany(x => x.CoffeeCommentsOfCustomer).HasForeignKey(x => x.CustomerID);
        }
    }
}
