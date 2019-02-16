using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
   public class ExtraMaterialsMapping:EntityTypeConfiguration<ExtraMaterial>
    {
        public ExtraMaterialsMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Quantity).HasColumnType("smallint");
            Property(x => x.UnitPrice).HasColumnType("money");

        }
    }
}
