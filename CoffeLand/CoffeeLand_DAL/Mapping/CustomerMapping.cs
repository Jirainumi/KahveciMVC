using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.UserName).HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.Password).HasColumnType("nvarchar").HasMaxLength(30);
        }
    }
}
