using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
   public class BaristaMapping:EntityTypeConfiguration<Barista>
    {

        public BaristaMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.Firstname).HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.Lastname).HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.AVGPoint).HasColumnType("decimal");
            Property(x => x.HiredDate).HasColumnType("datetime2");
            Property(x => x.BirthDate).HasColumnType("datetime2");
            Property(x => x.Gender).HasColumnType("bit");


            Ignore(x => x.YearOfExperience);
            Ignore(x => x.Age);

        }

    }
}
