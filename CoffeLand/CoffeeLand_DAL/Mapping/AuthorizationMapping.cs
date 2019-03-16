using CoffeeLand_DATA.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLand_DAL.Mapping
{
    public class AuthorizationMapping : EntityTypeConfiguration<Authorization>
    {
        public AuthorizationMapping()
        {
            HasKey(x => x.ID);
        }
    }
}
