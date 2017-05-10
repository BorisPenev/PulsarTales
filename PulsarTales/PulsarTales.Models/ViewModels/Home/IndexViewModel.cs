using System.Collections.Generic;

namespace PulsarTales.Models.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<LatestAnnounsmentsViewModel> Announcements { get; set; }
        public IEnumerable<LatestChapterUpdateViewModel> LatestChapterUpdates { get; set; }
    }
}
