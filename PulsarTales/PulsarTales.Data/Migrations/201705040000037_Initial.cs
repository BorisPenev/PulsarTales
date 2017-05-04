namespace PulsarTales.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Novel_Id = c.Int(),
                        Novel_Id1 = c.Int(),
                        Novel_Id2 = c.Int(),
                        Novel_Id3 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Novels", t => t.Novel_Id)
                .ForeignKey("dbo.Novels", t => t.Novel_Id1)
                .ForeignKey("dbo.Novels", t => t.Novel_Id2)
                .ForeignKey("dbo.Novels", t => t.Novel_Id3)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Novel_Id)
                .Index(t => t.Novel_Id1)
                .Index(t => t.Novel_Id2)
                .Index(t => t.Novel_Id3);
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        DateAdded = c.DateTime(),
                        NovelId = c.Int(nullable: false),
                        TranslatorId = c.String(maxLength: 128),
                        EditorId = c.String(maxLength: 128),
                        WriterId = c.String(maxLength: 128),
                        TranslatorCheckerId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EditorId)
                .ForeignKey("dbo.Novels", t => t.NovelId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TranslatorId)
                .ForeignKey("dbo.AspNetUsers", t => t.TranslatorCheckerId)
                .ForeignKey("dbo.AspNetUsers", t => t.WriterId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.NovelId)
                .Index(t => t.TranslatorId)
                .Index(t => t.EditorId)
                .Index(t => t.WriterId)
                .Index(t => t.TranslatorCheckerId)
                .Index(t => t.ApplicationUser_Id);
            
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
                        Genre_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateAdded = c.DateTime(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
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
                .ForeignKey("dbo.Chapters", t => t.ChapterId, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.ChapterId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.NovelGenres",
                c => new
                    {
                        NovelId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NovelId, t.GenreId })
                .ForeignKey("dbo.Novels", t => t.NovelId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.NovelId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.AnnounsmentComments",
                c => new
                    {
                        AnnounsmentId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnnounsmentId, t.CommentId })
                .ForeignKey("dbo.Announsments", t => t.AnnounsmentId, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
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
            DropForeignKey("dbo.Novels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "WriterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "TranslatorCheckerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "TranslatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chapters", "NovelId", "dbo.Novels");
            DropForeignKey("dbo.AspNetUsers", "Novel_Id3", "dbo.Novels");
            DropForeignKey("dbo.AspNetUsers", "Novel_Id2", "dbo.Novels");
            DropForeignKey("dbo.AspNetUsers", "Novel_Id1", "dbo.Novels");
            DropForeignKey("dbo.NovelGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.NovelGenres", "NovelId", "dbo.Novels");
            DropForeignKey("dbo.Genres", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Novels", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.AspNetUsers", "Novel_Id", "dbo.Novels");
            DropForeignKey("dbo.Chapters", "EditorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChapterComments", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.ChapterComments", "ChapterId", "dbo.Chapters");
            DropIndex("dbo.AnnounsmentComments", new[] { "CommentId" });
            DropIndex("dbo.AnnounsmentComments", new[] { "AnnounsmentId" });
            DropIndex("dbo.NovelGenres", new[] { "GenreId" });
            DropIndex("dbo.NovelGenres", new[] { "NovelId" });
            DropIndex("dbo.ChapterComments", new[] { "CommentId" });
            DropIndex("dbo.ChapterComments", new[] { "ChapterId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FrequentlyAskedQuestions", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Genres", new[] { "UserId" });
            DropIndex("dbo.Novels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Novels", new[] { "Genre_Id" });
            DropIndex("dbo.Chapters", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Chapters", new[] { "TranslatorCheckerId" });
            DropIndex("dbo.Chapters", new[] { "WriterId" });
            DropIndex("dbo.Chapters", new[] { "EditorId" });
            DropIndex("dbo.Chapters", new[] { "TranslatorId" });
            DropIndex("dbo.Chapters", new[] { "NovelId" });
            DropIndex("dbo.AspNetUsers", new[] { "Novel_Id3" });
            DropIndex("dbo.AspNetUsers", new[] { "Novel_Id2" });
            DropIndex("dbo.AspNetUsers", new[] { "Novel_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "Novel_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Announsments", new[] { "UserId" });
            DropTable("dbo.AnnounsmentComments");
            DropTable("dbo.NovelGenres");
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
