namespace PulsarTales.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PulsarTalesContext :  IdentityDbContext<ApplicationUser>
    {
        public PulsarTalesContext()
            : base("name=PulsarTalesContext", throwIfV1Schema: false)
        {
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public static PulsarTalesContext Create()
        {
            return new PulsarTalesContext();
        }
    }
    
}