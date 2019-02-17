using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
   public class AuthorizationMapping:EntityTypeConfiguration<Authorization>
    {
        public AuthorizationMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.AuthorizationType).HasColumnType("nvarchar").HasMaxLength(30);
        }
    }
}
