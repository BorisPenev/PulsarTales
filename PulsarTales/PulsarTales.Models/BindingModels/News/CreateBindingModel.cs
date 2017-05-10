using System;

namespace PulsarTales.Models.BindingModels.News
{
    public class CreateBindingModel
    {
        public CreateBindingModel()
        {
            this.DateAnnounced = DateTime.Now;
        }
        public string Title { get; set; }
        public DateTime? DateAnnounced { get; set; }
        public string Content { get; set; }
    }
}
