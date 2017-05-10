using System;
using System.Collections.Generic;
namespace PulsarTales.Models.ViewModels.Home
{
    public class AnnounsmentDetailsViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateAnnounced { get; set; }
        public string AnnouncedFrom { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
