using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PulsarTales.Models.Entities;
using PulsarTales.Models.ViewModels.Home;

namespace PulsarTales.Services
{
    public class HomeService:Service
    {
        public List<TaleViewModel> GetTranslatedTales()
        {
            var dbNovels = this.DbContext.Novels
                       .Where(n => n.IsTranslatedTale)
                       .Select(t => new TaleViewModel()
                        {
                            Id = t.Id,
                            Title = t.TitleEnglish,
                            Url = t.Url
                        })
                        .OrderBy(n => n.Title)
                        .ToList();
            dbNovels.ForEach(n =>
            {
                if (string.IsNullOrEmpty(n.Url))
                {
                    n.Url = GetNovelUrl(n.Title);
                }
            });

            return dbNovels;
        }
        public List<TaleViewModel> GetOriginalTales()
        {
            var dbNovels = this.DbContext.Novels
                       .Where(n => n.IsOriginalTale)
                       .Select(t => new TaleViewModel()
                       {
                           Id = t.Id,
                           Title = t.TitleEnglish,
                           Url = t.Url
                       })
                       .OrderBy(n => n.Title)
                       .ToList();
            dbNovels.ForEach(n =>
            {
                if (string.IsNullOrEmpty(n.Url))
                {
                    n.Url = GetNovelUrl(n.Title);
                }
            });

            return dbNovels;
        }
        public List<TaleViewModel> GetOtherTales()
        {
            var dbNovels = this.DbContext.Novels
                       .Where(n => n.IsOtherTale)
                       .Select(t => new TaleViewModel()
                       {
                           Id = t.Id,
                           Title = t.TitleEnglish,
                           Url = t.Url
                       })
                       .OrderBy(n => n.Title)
                       .ToList();
            dbNovels.ForEach(n =>
            {
                if (string.IsNullOrEmpty(n.Url))
                {
                    n.Url = GetNovelUrl(n.Title);
                }
            });

            return dbNovels;
        }

        public IEnumerable<LatestAnnounsmentsViewModel> GetLatestAnnounsments()
        {
            var announcements = this.DbContext.Announsments
                .Where(a => !a.IsDeleted)
                .OrderByDescending(a => a.DateAnnounced)
                .Take(5);
            return Mapper.Instance.Map<IEnumerable<LatestAnnounsmentsViewModel>>(announcements);
        }

        private string GetNovelUrl(string novelTitle)
        {
            string escapedTitle = novelTitle.Replace("!", "").Replace(" ", "-").Replace("'", "").Replace(".", "");

            return escapedTitle;
        }


        public IEnumerable<LatestChapterUpdateViewModel> GetLatesChapterUpdates()
        {
            var latestChapters = this.DbContext.Chapters
                .Where(ch => !ch.IsDeleted)
                .OrderByDescending(ch => ch.DateAdded)
                .Take(15);
            return Mapper.Instance.Map<IEnumerable<LatestChapterUpdateViewModel>>(latestChapters);
        }
    }
}
