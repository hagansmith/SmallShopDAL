using Microsoft.AspNet.Identity.EntityFramework;
using Small_Shop_API.Models;

namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Small_Shop_API.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Small_Shop_API.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                UserName = "asmith",
                Email = "hagansmith@gmail.com",
            };

            userManager.CreateAsync(user, "qazwsx123").Wait();

        }
    }
}
