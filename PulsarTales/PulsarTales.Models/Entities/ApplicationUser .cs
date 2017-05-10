using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            this.TranslatedNovels = new HashSet<Novel>();
            this.EditedNovels = new HashSet<Novel>();
            this.WrittenNovels = new HashSet<Novel>();
            this.CheckedTranslatedNovels = new HashSet<Novel>();

            this.TranslatedChapters = new HashSet<Chapter>();
            this.EditedChapters = new HashSet<Chapter>();
            this.WrittenChapters = new HashSet<Chapter>();
            this.CheckedTranslatedChapters = new HashSet<Chapter>();

            this.Comments = new HashSet<Comment>();
        }

        public DateTime? RegistrationDate { get; set; }
        public bool IsMarkedAsDeleted { get; set; }
        public virtual ICollection<Novel> TranslatedNovels { get; set; }
        public virtual ICollection<Novel> EditedNovels { get; set; }
        public virtual ICollection<Novel> WrittenNovels { get; set; }
        public virtual ICollection<Novel> CheckedTranslatedNovels { get; set; }

        public virtual ICollection<Chapter> TranslatedChapters { get; set; }
        public virtual ICollection<Chapter> EditedChapters { get; set; }
        public virtual ICollection<Chapter> WrittenChapters { get; set; }
        public virtual ICollection<Chapter> CheckedTranslatedChapters { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}