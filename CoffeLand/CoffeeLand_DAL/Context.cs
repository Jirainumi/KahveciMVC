using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeLand_DAL.Mapping;
using CoffeeLand_DATA.Classes;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CoffeeLand_DAL
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context()
        {
            Database.Connection.ConnectionString = "server=.;database=KahveciDb;uid=sa;pwd=123";
        }

        public static Context Create()
        {
            return new Context();
        }

        public DbSet<Barista> Baristas { get; set; }
        public DbSet<BaristaComment> BaristaComments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<CoffeeComment> CoffeeComments { get; set; }
        public DbSet<ExtraMaterial> ExtraMaterials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BaristaMapping());
            modelBuilder.Configurations.Add(new BaristaCommentMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new CoffeesMapping());
            modelBuilder.Configurations.Add(new CoffeeCommentMapping());
            modelBuilder.Configurations.Add(new ExtraMaterialsMapping());
            modelBuilder.Configurations.Add(new OrderDetailMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new CustomerMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
