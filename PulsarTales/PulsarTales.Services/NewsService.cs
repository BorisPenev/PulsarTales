using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PulsarTales.Models.BindingModels.News;
using PulsarTales.Models.Entities;
using PulsarTales.Models.ViewModels.Home;

namespace PulsarTales.Services
{
    public class NewsService:Service
    {
        public AnnounsmentDetailsViewModel GetAnnouncement(int id)
        {
            var announcement = this.DbContext.Announsments.Find(id);
            if (announcement != null)
            {
                return Mapper.Instance.Map<Announsment, AnnounsmentDetailsViewModel>(announcement);
            }

            return null;
        }

        public IEnumerable<LatestAnnounsmentsViewModel> GetAllAnnouncements()
        {
            return Mapper.Instance.Map<IEnumerable<LatestAnnounsmentsViewModel>>(this.DbContext.Announsments.Where(a => !a.IsDeleted));
        }


        public void CreateAnnouncement(CreateBindingModel bind, string userId)
        {
            var user = this.DbContext.Users.Find(userId);
            if (user != null)
            {
                this.DbContext.Announsments.Add(new Announsment()
                {
                    Title = bind.Title,
                    Content = bind.Content,
                    DateAnnounced = DateTime.Now,
                    User = user
                });
                this.DbContext.SaveChanges();
            }
        }

        public void DeleteAnnouncement(int id)
        {
            var announcement = this.DbContext.Announsments.Find(id);
            if (announcement != null)
            {
                announcement.IsDeleted = true;
                this.DbContext.SaveChanges();
            }
        }

        public void EditAnnouncement(EditBindingModel bind)
        {
            var announcement = this.DbContext.Announsments.Find(bind.Id);
            if (announcement != null)
            {
                announcement.Title = bind.Title;
                announcement.Content = bind.Content;
                
                this.DbContext.SaveChanges();
            }
        }
    }
}
