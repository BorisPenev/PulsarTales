﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PulsarTales.Models.Entities
{
    public class Genre
    {
        public Genre()
        {
            this.DateAdded = DateTime.Now;
            this.Novels = new HashSet<Novel>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime? DateAdded { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("User")]
        public string CreatorId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [InverseProperty("Genres")]
        public virtual ICollection<Novel> Novels { get; set; }
    }
}
