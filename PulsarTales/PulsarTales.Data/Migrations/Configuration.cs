using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            if (!context.Novels.Any())
            {
                string dummyTranslatedTaleDescription =
                    "“His parents were the geniuses of the sect. But they were apparently killed while on a mission when he was barely 6. As he apparently did not excel in any of the 5 elements, in fact, all 5 elements are in balance in his body. Thus, our fatty is deemed to be trash and does not deserve the respect his parents had.\r\n\r\nHe is allowed to have one task, to collect garbage of the sect until he reaches the initial test-age where he has to proof to be worthy to stay in the sect.\r\nOur fatty has no choice but to cultivate the only heritage his parents gave him. A mysterious black pearl.\r\n\r\nUnfortunately for him, this pearl seems to be only useful for… collecting garbage…”";
                // Translated Tales
                var translatedTales = new List<Novel>();
                for (int i = 1; i <= 10; i++)
                {
                    translatedTales.Add(new Novel()
                    {
                        TitleEnglish = $"Chaotic Lightning Cultivation {i}",
                        AuthorEnglishName = $"Xie Zi Ban {i}",
                        AuthorNameInOriginalLanguage = $"写字板 {i}",
                        Description = $"{dummyTranslatedTaleDescription} {i}",
                        IsTranslatedTale = true,
                        IsOtherTale = false,
                        IsOriginalTale = false,
                        IsOngoing = false,
                        DateAdded = DateTime.Now,
                        Url = GetNovelUrl($"Chaotic Lightning Cultivation {i}")
                    });
                }
                context.Novels.AddRange(translatedTales);
                context.SaveChanges();

                //if (System.Diagnostics.Debugger.IsAttached == false)
                //    System.Diagnostics.Debugger.Launch();
                var addChaptersToNovels = context.Novels.Take(10);
                var chapters = new List<Chapter>();
                
                foreach (var novel in addChaptersToNovels)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        var chap = new Chapter()
                        {
                            Novel = novel,
                            Title = $"some Title {i}",
                            Content = $"some content {i}",
                            DateAdded = DateTime.Now,
                            Number = i,
                            Translator = context.Users.FirstOrDefault(),
                            Editor = context.Users.FirstOrDefault(),
                            TranslatorChecker = context.Users.FirstOrDefault(),
                            Writer = context.Users.FirstOrDefault(),
                            UrlSuffix = this.GetChapterUrl(i, novel.TitleEnglish)
                        };
                        chapters.Add(chap);
                    }
                }
                context.Chapters.AddRange(chapters);
                context.SaveChanges();
                // Original Tales
                string dummyOriginalTaleDescription =
                    "The world of Ator is ruled by the strong. Through the cultivation of mana and aura heroes emerge and legends are born every day in the battle of civilization against the wilderness. Humans, elves and other humanoid races band together to face the threat of monsters and beasts hiding in dark places.\r\n\r\nIn the forest the child of the strongest monster race is born. Abandoned by its clan and left only with its siblings as family. Taking the seat of a ruler among other monsters was not enough for the beast and it set out to explore the world.";
               var originalTales = new List<Novel>();
                for (int i = 1; i <= 10; i++)
                {
                    originalTales.Add(new Novel()
                    {
                        TitleEnglish = $"A Dragon’s Curiosity {i}",
                        AuthorEnglishName = $"Chunwa {i}",
                        Description = $"{dummyOriginalTaleDescription} {i}",
                        IsTranslatedTale = false,
                        IsOtherTale = false,
                        IsOriginalTale = true,
                        IsOngoing = false,
                        DateAdded = DateTime.Now,
                        Url = GetNovelUrl($"A Dragon’s Curiosity {i}")
                    });
                }
                context.Novels.AddRange(originalTales);
                context.SaveChanges();
                // Other Tales
                string dummyOtherTaleDescription =
                    "What happens when a scientist from a futuristic world reincarnates in a World of Magic and Knights?\r\n\r\nAn awesome MC is what happens!\r\n\r\nA scientist’s goal is to explore the secrets of the universe, and this is exactly what Leylin sets out to do when he is reincarnated. Dark, cold and calculating, he makes use of all his resources as he sets off on his adventures to meet his goal.\r\n\r\nFace? Who needs that… Hmmm… that guy seems too powerful for me to take on now… I better keep a low profile for now.\r\n\r\nYou want me to help you? Sure… but what benefit can I get out of it? Nothing? Bye.\r\n\r\nHmmm… that guy looks like he might cause me problems in the future. Should I let him off for now and let him grow into someone that can threaten me….. Nahhh. *kill*\r\n\r\n- See more at: http://www.readlightnovel.com/warlock-of-the-magus-world#sthash.7E0drGiU.dpuf";

              var otherTales = new List<Novel>();
                for (int i = 1; i <= 10; i++)
                {
                    otherTales.Add(new Novel()
                    {
                        TitleEnglish = $"Warlock of the Magus World {i}",
                        AuthorEnglishName = $"Someone {i}",
                        Description = $"{dummyOtherTaleDescription} {i}",
                        IsTranslatedTale = false,
                        IsOtherTale = true,
                        IsOriginalTale = false,
                        IsOngoing = false,
                        DateAdded = DateTime.Now,
                        Url = GetNovelUrl($"Warlock of the Magus World {i}")
                    });
                }
                context.Novels.AddRange(otherTales);
                context.SaveChanges();

                // Announcements
                var addAnnouncements = new List<Announsment>();
                for (int i = 1; i <= 10; i++)
                {
                    addAnnouncements.Add(new Announsment()
                    {
                        Title = $"My Announcement {i}",
                        Content = $"Some content {i}",
                        User = context.Users.FirstOrDefault(),
                        DateAnnounced = DateTime.Now.AddDays((-1)*i)
                    });
                }
                context.Announsments.AddRange(addAnnouncements);
            }
        }

        private string GetChapterUrl(int chapterNumber, string novelTitle)
        {

            string novelAcronym = string.Empty;
            foreach (var symbol in novelTitle)
            {
                if (char.IsUpper(symbol))
                {
                    novelAcronym += symbol;
                }
            }

            novelAcronym = novelAcronym.ToLower();
            return $"{novelAcronym}-chapter-{chapterNumber}";
        }
        private string GetNovelUrl(string novelTitle)
        {
            string escapedTitle = novelTitle.Replace("!", "").Replace(" ", "-").Replace("'", "").Replace("’","").Replace(".", "");

            return escapedTitle;
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

        private void CreateUser(PulsarTalesContext context, string email, string username, string password)
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
                UserName = username,
                Email = email,
                Comments = new HashSet<Comment>(),
                TranslatedNovels = new HashSet<Novel>(),
                EditedNovels = new HashSet<Novel>(),
                WrittenNovels = new HashSet<Novel>(),
                CheckedTranslatedNovels = new HashSet<Novel>(),

                TranslatedChapters = new HashSet<Chapter>(),
                EditedChapters = new HashSet<Chapter>(),
                WrittenChapters = new HashSet<Chapter>(),
                CheckedTranslatedChapters = new HashSet<Chapter>(),
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