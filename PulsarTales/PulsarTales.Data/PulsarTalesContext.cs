using System.Data.Entity.ModelConfiguration.Conventions;

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

        public virtual DbSet<Novel> Novels { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Announsment> Announsments { get; set; }
        public virtual DbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Novel>()
            .HasMany(a => a.Genres)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("NovelId");
                x.MapRightKey("GenreId");
                x.ToTable("NovelGenres");
            });
            modelBuilder.Entity<Novel>()
            .HasMany(n => n.Translators)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("NovelId");
                x.MapRightKey("TranslatorId");
                x.ToTable("NovelTranslators");
            });
            modelBuilder.Entity<Novel>()
            .HasMany(n => n.Editors)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("NovelId");
                x.MapRightKey("EditorId");
                x.ToTable("NovelEditors");
            });
            modelBuilder.Entity<Novel>()
            .HasMany(n => n.Writers)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("NovelId");
                x.MapRightKey("WriterId");
                x.ToTable("NovelWriters");
            });
            modelBuilder.Entity<Novel>()
            .HasMany(a => a.TranslationCheckers)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("NovelId");
                x.MapRightKey("TranslationCheckerId");
                x.ToTable("NovelTranslationCheckers");
            });
            modelBuilder.Entity<Announsment>()
            .HasMany(a => a.Comments)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("AnnounsmentId");
                x.MapRightKey("CommentId");
                x.ToTable("AnnounsmentComments");
            });
            modelBuilder.Entity<Chapter>()
            .HasMany(a => a.Comments)
            .WithMany()
            .Map(x =>
            {
                x.MapLeftKey("ChapterId");
                x.MapRightKey("CommentId");
                x.ToTable("ChapterComments");
            });
            
            base.OnModelCreating(modelBuilder);
        }
        public static PulsarTalesContext Create()
        {
            return new PulsarTalesContext();
        }
    }
    
}