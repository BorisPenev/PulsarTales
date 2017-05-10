using System.Data.Entity;
using System.Linq;
using AutoMapper;
using PulsarTales.Models.ViewModels.Novels;

namespace PulsarTales.Services
{
    public class NovelsService:Service
    {
        public NovelDetailsViewModel GetNovelDetails(string novelUrl)
        {
            var novel = this.DbContext.Novels.Include(n => n.Genres).FirstOrDefault(n => n.Url.Equals(novelUrl));
            return Mapper.Instance.Map<NovelDetailsViewModel>(novel);
        }

        public NovelDetailsChapterViewModel GetChapterDetails(string novelUrl, string chapterUrl)
        {
            var chapter = this.DbContext.Chapters.FirstOrDefault(n => n.UrlSuffix.Equals(chapterUrl) && n.Novel.Url.Equals(novelUrl));
            return Mapper.Instance.Map<NovelDetailsChapterViewModel>(chapter);
        }
    }
}
