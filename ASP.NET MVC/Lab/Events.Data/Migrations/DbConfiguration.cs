namespace Events.Data.Migrations
{
    using Events.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class DbConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com", FullName = "Administrator" };

                userManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 1,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireNonLetterOrDigit = false,
                    RequireUppercase = false
                };

                var userCreateResult = userManager.Create(user, "adminadmin");

                if (!context.Roles.Any(r => r.Name == "Administrator"))
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    var roleCreateResult = roleManager.Create(new IdentityRole("Administrator"));

                    var adminRoleRoleResult = userManager.AddToRole(user.Id, "Administrator");
                }
            }

            if (!context.Events.Any())
            {
                context.Events.Add(new Event()
                {
                    Title = "Party at softuni",
                    StartDateTime = DateTime.Now.Date.AddDays(5).AddHours(21).AddMinutes(30),
                    Author = context.Users.First()
                });

                context.Events.Add(new Event()
                {
                    Title = "Passed anonymous event",
                    StartDateTime = DateTime.Now.Date.AddDays(-2).AddHours(10).AddMinutes(50),
                    Duration = TimeSpan.FromHours(1.5),
                    Comments = new HashSet<Comment>()
                    {
                        new Comment() { Text = "Anonymous comment" },
                        new Comment() { Text = "User comment", Author = context.Users.First() }
                    }
                });
            }

            base.Seed(context);
        }
    }
}
