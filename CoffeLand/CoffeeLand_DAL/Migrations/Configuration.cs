namespace CoffeeLand_DAL.Migrations
{
    using CoffeeLand_DATA.Classes;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoffeeLand_DAL.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CoffeeLand_DAL.Context context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            if (!roleManager.RoleExists("admin"))
                roleManager.Create(new IdentityRole() { Name = "admin" });
            if (!roleManager.RoleExists("standart"))
                roleManager.Create(new IdentityRole() { Name = "standart" });

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var adminUser = userManager.FindByName("admin");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };
                userManager.Create(adminUser, "Ankara1.");
            }
            if (!userManager.IsInRole(adminUser.Id, "admin"))
                userManager.AddToRole(adminUser.Id, "admin");
        }
    }
}
