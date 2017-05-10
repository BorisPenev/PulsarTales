using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PulsarTales.Models.Entities
{
    public class Novel
    {
        public Novel()
        {
            this.DateAdded = DateTime.Now;
            this.Chapters = new HashSet<Chapter>();
            this.Genres = new HashSet<Genre>();
            this.Translators = new HashSet<ApplicationUser>();
            this.Editors = new HashSet<ApplicationUser>();
            this.TranslationCheckers = new HashSet<ApplicationUser>();
            this.Writers = new HashSet<ApplicationUser>();
        }
        public int Id { get; set; }
        [Required]
        public string TitleEnglish { get; set; }      
        public string TitleInOriginalLanguage { get; set; }
        [Required]
        public string AuthorEnglishName { get; set; }
        public string AuthorNameInOriginalLanguage { get; set; }
        public DateTime? DateAdded { get; set; }
        [Required]
        [DisplayName("Synopsis")]
        public string Description { get; set; }
        [Required]
        public bool IsOngoing { get; set; }
        [Required]
        public bool IsTranslatedTale { get; set; }
        [Required]
        public bool IsOriginalTale { get; set; }
        [Required]
        public bool IsOtherTale { get; set; }

        public string CoverImageUrl { get; set; }
        public string Url { get; set; } 
        public bool IsDeleted { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        [InverseProperty("TranslatedNovels")]
        public virtual ICollection<ApplicationUser> Translators { get; set; }
        [InverseProperty("EditedNovels")]
        public virtual ICollection<ApplicationUser> Editors { get; set; }
        [InverseProperty("CheckedTranslatedNovels")]
        public virtual ICollection<ApplicationUser> TranslationCheckers { get; set; }
        [InverseProperty("WrittenNovels")]
        public virtual ICollection<ApplicationUser> Writers { get; set; }

        
    }
}
