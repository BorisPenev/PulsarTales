using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PulsarTales.Models.Entities;
using PulsarTales.Models.ViewModels.Areas.Admin;

namespace PulsarTales.Services.Areas.Admin
{
    public class UserService: Service
    {
        public ApplicationUser GetUser(string id)
        {
            return this.DbContext.Users.Find(id);
        }
        public List<ApplicationUser> GetAllUsers()
        {
            return this.DbContext.Users.ToList();
        }

        public List<string> GetAllRoles()
        {
            // Get all application roles
            return this.DbContext.Roles
                .Select(r =>  r.Name)
                .OrderBy(r => r)
                .ToList();
        }

        public HashSet<string> GetAdminUserNames(List<ApplicationUser> users)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(this.DbContext));

            var admins = new HashSet<string>();

            foreach (var user in users)
            {
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    admins.Add(user.UserName);
                }
            }

            return admins;
        }

        public void MarkUserAsDeleted(string id)
        {
            var user = this.DbContext.Users.Find(id);
            user.IsMarkedAsDeleted = true;
            this.DbContext.SaveChanges();
        }
    }
}
