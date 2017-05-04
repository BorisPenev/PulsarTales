using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PulsarTales.Models.Entities
{
    public class FrequentlyAskedQuestion
    {
        public FrequentlyAskedQuestion()
        {
            this.DateAsked = DateTime.Now;
        }
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime? DateAsked { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
