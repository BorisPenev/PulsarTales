using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulsarTales.Models.Entities
{
    public class Chapter
    {
        public Chapter()
        {
            this.DateAdded = DateTime.Now;
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime? DateAdded { get; set; }
        [ForeignKey("Novel")]
        public int NovelId { get; set; }
        public virtual Novel Novel { get; set; }
        [ForeignKey("Translator")]
        public string TranslatorId { get; set; }
        public virtual ApplicationUser Translator { get; set; }
        [ForeignKey("Editor")]
        public string EditorId { get; set; }
        public virtual ApplicationUser Editor { get; set; }
        [ForeignKey("Writer")]
        public string WriterId { get; set; }
        public virtual ApplicationUser Writer { get; set; }
        [ForeignKey("TranslatorChecker")]
        public string TranslatorCheckerId { get; set; }
        public virtual ApplicationUser TranslatorChecker { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
