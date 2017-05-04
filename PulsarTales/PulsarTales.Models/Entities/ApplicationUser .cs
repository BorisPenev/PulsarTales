using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PulsarTales.Models.Entities
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.RegistrationDate = DateTime.Now;
            this.Novels = new HashSet<Novel>();
            this.Comments = new HashSet<Comment>();
            this.Bookmarks = new HashSet<Chapter>();
        }

        public DateTime? RegistrationDate { get; set; }
        public bool IsMarkedAsDeleted { get; set; }
        public virtual ICollection<Novel> Novels { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Chapter> Bookmarks { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}