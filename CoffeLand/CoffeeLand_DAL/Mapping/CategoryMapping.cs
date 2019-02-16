using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
   public class CategoryMapping:EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.Description).HasColumnType("nvarchar");
            Property(x => x.CategoryName).HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
