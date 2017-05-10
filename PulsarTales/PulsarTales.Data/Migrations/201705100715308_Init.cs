namespace PulsarTales.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announsments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateAnnounced = c.DateTime(),
                        Content = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        DateCommented = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RegistrationDate = c.DateTime(),
                        IsMarkedAsDeleted = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        DateAdded = c.DateTime(),
                        UrlSuffix = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        NovelId = c.Int(nullable: false),
                        TranslatorId = c.String(maxLength: 128),
                        EditorId = c.String(maxLength: 128),
                        WriterId = c.String(maxLength: 128),
                        TranslatorCheckerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EditorId)
                .ForeignKey("dbo.Novels", t => t.NovelId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TranslatorId)
                .ForeignKey("dbo.AspNetUsers", t => t.TranslatorCheckerId)
                .ForeignKey("dbo.AspNetUsers", t => t.WriterId)
                .Index(t => t.NovelId)
                .Index(t => t.TranslatorId)
                .Index(t => t.EditorId)
                .Index(t => t.WriterId)
                .Index(t => t.TranslatorCheckerId);
            
            CreateTable(
                "dbo.Novels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleEnglish = c.String(nullable: false),
                        TitleInOriginalLanguage = c.String(),
                        AuthorEnglishName = c.String(nullable: false),
                        AuthorNameInOriginalLanguage = c.String(),
                        DateAdded = c.DateTime(),
                        Description = c.String(nullable: false),
                        IsOngoing = c.Boolean(nullable: false),
                        IsTranslatedTale = c.Boolean(nullable: false),
                        IsOriginalTale = c.Boolean(nullable: false),
                        IsOtherTale = c.Boolean(nullable: false),
                        CoverImageUrl = c.String(),
                        Url = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateAdded = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.FrequentlyAskedQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        DateAsked = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ChapterComments",
                c => new
                    {
                        ChapterId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChapterId, t.CommentId })
                .ForeignKey("dbo.Chapters", t => t.ChapterId)
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .Index(t => t.ChapterId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.NovelEditors",
                c => new
                    {
                        NovelId = c.Int(nullable: false),
                        EditorId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.NovelId, t.EditorId })
                .ForeignKey("dbo.Novels", t => t.NovelId)
                .ForeignKey("dbo.AspNetUsers", t => t.EditorId)
                .Index(t => t.NovelId)
                .Index(t => t.EditorId);
            
            CreateTable(
                "dbo.NovelGenres",
                c => new
                    {
                        NovelId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NovelId, t.GenreId })
                .ForeignKey("dbo.Genres", t => t.NovelId)
                .ForeignKey("dbo.Novels", t => t.GenreId)
                .Index(t => t.NovelId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.NovelTranslationCheckers",
                c => new
                    {
                        NovelId = c.Int(nullable: false),
                        TranslationCheckerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.NovelId, t.TranslationCheckerId })
                .ForeignKey("dbo.Novels", t => t.NovelId)
                .ForeignKey("dbo.AspNetUsers", t => t.TranslationCheckerId)
                .Index(t => t.NovelId)
                .Index(t => t.TranslationCheckerId);
            
            CreateTable(
                "dbo.NovelTranslators",
                c => new
                    {
                        NovelId = c.Int(nullable: false),
                        TranslatorId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.NovelId, t.TranslatorId })
                .ForeignKey("dbo.Novels", t => t.NovelId)
                .ForeignKey("dbo.AspNetUsers", t => t.TranslatorId)
                .Index(t => t.NovelId)
                .Index(t => t.TranslatorId);
            
            CreateTable(
                "dbo.NovelWriters",
                c => new
                    {
                        NovelId = c.Int(nullable: false),
                        WriterId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.NovelId, t.WriterId })
                .ForeignKey("dbo.Novels", t => t.NovelId)
                .ForeignKey("dbo.AspNetUsers", t => t.WriterId)
                .Index(t => t.NovelId)
                .Index(t => t.WriterId);
            
            CreateTable(
                "dbo.AnnounsmentComments",
                c => new
                    {
                        AnnounsmentId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnnounsmentId, t.CommentId })
                .ForeignKey("dbo.Announsments", t => t.AnnounsmentId)
                .ForeignKey("dbo.Comments", t => t.CommentId)
                .Index(t => t.AnnounsmentId)
                .Index(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FrequentlyAskedQuestions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Announsments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AnnounsmentComments", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.AnnounsmentComments", "AnnounsmentId", "dbo.Announsments");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "WriterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "TranslatorCheckerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "TranslatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "NovelId", "dbo.Novels");
            DropForeignKey("dbo.NovelWriters", "WriterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NovelWriters", "NovelId", "dbo.Novels");
            DropForeignKey("dbo.NovelTranslators", "TranslatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NovelTranslators", "NovelId", "dbo.Novels");
            DropForeignKey("dbo.NovelTranslationCheckers", "TranslationCheckerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NovelTranslationCheckers", "NovelId", "dbo.Novels");
            DropForeignKey("dbo.Genres", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NovelGenres", "GenreId", "dbo.Novels");
            DropForeignKey("dbo.NovelGenres", "NovelId", "dbo.Genres");
            DropForeignKey("dbo.NovelEditors", "EditorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.NovelEditors", "NovelId", "dbo.Novels");
            DropForeignKey("dbo.Chapters", "EditorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChapterComments", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.ChapterComments", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.AnnounsmentComments", new[] { "CommentId" });
            DropIndex("dbo.AnnounsmentComments", new[] { "AnnounsmentId" });
            DropIndex("dbo.NovelWriters", new[] { "WriterId" });
            DropIndex("dbo.NovelWriters", new[] { "NovelId" });
            DropIndex("dbo.NovelTranslators", new[] { "TranslatorId" });
            DropIndex("dbo.NovelTranslators", new[] { "NovelId" });
            DropIndex("dbo.NovelTranslationCheckers", new[] { "TranslationCheckerId" });
            DropIndex("dbo.NovelTranslationCheckers", new[] { "NovelId" });
            DropIndex("dbo.NovelGenres", new[] { "GenreId" });
            DropIndex("dbo.NovelGenres", new[] { "NovelId" });
            DropIndex("dbo.NovelEditors", new[] { "EditorId" });
            DropIndex("dbo.NovelEditors", new[] { "NovelId" });
            DropIndex("dbo.ChapterComments", new[] { "CommentId" });
            DropIndex("dbo.ChapterComments", new[] { "ChapterId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FrequentlyAskedQuestions", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Genres", new[] { "CreatorId" });
            DropIndex("dbo.Chapters", new[] { "TranslatorCheckerId" });
            DropIndex("dbo.Chapters", new[] { "WriterId" });
            DropIndex("dbo.Chapters", new[] { "EditorId" });
            DropIndex("dbo.Chapters", new[] { "TranslatorId" });
            DropIndex("dbo.Chapters", new[] { "NovelId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Announsments", new[] { "UserId" });
            DropTable("dbo.AnnounsmentComments");
            DropTable("dbo.NovelWriters");
            DropTable("dbo.NovelTranslators");
            DropTable("dbo.NovelTranslationCheckers");
            DropTable("dbo.NovelGenres");
            DropTable("dbo.NovelEditors");
            DropTable("dbo.ChapterComments");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FrequentlyAskedQuestions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Genres");
            DropTable("dbo.Novels");
            DropTable("dbo.Chapters");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Announsments");
        }
    }
}
