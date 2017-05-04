using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PulsarTales.Models.Entities;

namespace PulsarTales.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PulsarTales.Data.PulsarTalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PulsarTales.Data.PulsarTalesContext";
        }

        protected override void Seed(PulsarTalesContext context)
        {
            if (!context.Roles.Any())
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "Moderator");
                this.CreateRole(context, "User");
                this.CreateRole(context, "Translator");
                this.CreateRole(context, "Editor");
                this.CreateRole(context, "Writer");
                this.CreateRole(context, "TranslationChecker");
            }

            if (!context.Users.Any())
            {
                this.CreateUser(context, "admin@admin.com", "SuperAdmin", "admin123");
                this.SetRoleToUser(context, "admin@admin.com", "Admin");
            }
            if (!context.Genres.Any())
            {
                var list = new string[]
                {
                    "Action", "Adventure","Fantasy","Harem","MartialArts","Mature","Romance","Xianxia","Chinese",
                    "Supernatural","Wuxia","Xianxia","Korean","Psychological","Horror","SciFi","Drama","SliceOfLife",
                    "Tragedy","Reincarnation","VirtualReality","Comedy","Sports","Manhua","Historical","Original",
                    "English"
                };
                CreateGenre(context, list);
            }
        }

        private void CreateGenre(PulsarTalesContext context, string[] genres)
        {
            var listOfGenres = genres.Select(genreName => new Genre()
            {
                Name = genreName,
                DateAdded = DateTime.Now,
                User = context.Users.FirstOrDefault()
            });
            context.Genres.AddRange(listOfGenres);
            context.SaveChanges();
        }

        private void SetRoleToUser(PulsarTalesContext context, string email, string role)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = context.Users
                .FirstOrDefault(u => u.Email.Equals(email));

            var result = userManager.AddToRole(user.Id, role);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateRole(PulsarTalesContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            var result = roleManager.Create(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(PulsarTalesContext context, string email, string fullName, string password)
        {
            // Create user manager
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            // Set user manager password validator
            userManager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6,
                RequireDigit = false,
                RequireLowercase = true,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };

            // Create user object
            var admin = new ApplicationUser()
            {
                UserName = email,
                Email = email,
                Comments = new HashSet<Comment>(),
                Bookmarks = new HashSet<Chapter>(),
                Novels = new HashSet<Novel>(),
                RegistrationDate = DateTime.Now,
                EmailConfirmed = true,
            };
            // Create user
            var result = userManager.Create(admin, password);
            // Validate result
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }

        }
    }
}