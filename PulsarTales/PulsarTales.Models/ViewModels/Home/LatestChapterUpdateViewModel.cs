using System;

namespace PulsarTales.Models.ViewModels.Home
{
    public class LatestChapterUpdateViewModel
    {
        public string NovelTitle { get; set; }
        public string NovelUrl { get; set; }
        public string ChapterTitle { get; set; }
        public int ChapterNumber { get; set; }
        public string ChapterUrl { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
