﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DATA.Classes;

namespace CoffeeLand_DAL.Mapping
{
    public class BaristaCommentMapping : EntityTypeConfiguration<BaristaComment>
    {
        public BaristaCommentMapping()
        {
            HasKey(x => x.ID);
            Property(x => x.Comment).HasColumnType("nvarchar");
            Property(x => x.Point).HasColumnType("tinyint");
            Property(x => x.BaristaCommentDate).HasColumnType("datetime2");


            HasRequired(x => x.BaristaOfBaristaComment).WithMany(x => x.BaristaComments).HasForeignKey(x => x.BaristaID);

            HasRequired(x => x.CustomerOfBaristaComment).WithMany(x => x.BaristaCommentsOfCustomer).HasForeignKey(x => x.CustomerID);
        }
    }
}
