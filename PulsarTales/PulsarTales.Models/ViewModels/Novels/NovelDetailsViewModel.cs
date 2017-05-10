using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PulsarTales.Models.Entities;

namespace PulsarTales.Models.ViewModels.Novels
{
    public class NovelDetailsViewModel
    {
        public string TitleEnglish { get; set; }
        public string AuthorEnglishName { get; set; }
        public string AuthorNameInOriginalLanguage { get; set; }
        public string TranslatorName { get; set; } // handle
        [DisplayName("Synopsis")]
        public string Description { get; set; }
        public string Status { get; set; } // Handle
        public string Url { get; set; }
        public virtual string Genres { get; set; }
        public string CoverImageUrl { get; set; }
        public IEnumerable<NovelDetailsChapterViewModel> Chapters { get; set; }
    }
}
