using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using PulsarTales.Models.Entities;
using PulsarTales.Models.ViewModels.Home;
using PulsarTales.Models.BindingModels.News;
using PulsarTales.Models.ViewModels.Novels;
using PulsarTales.Web;
using RedirectToRouteResult = System.Web.Http.Results.RedirectToRouteResult;

namespace PulsarTales
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
        }
        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Announsment, LatestAnnounsmentsViewModel>();
                expression.CreateMap<Announsment, AnnounsmentDetailsViewModel>(); 
                expression.CreateMap<CreateBindingModel, Announsment>();
                expression.CreateMap<Chapter, LatestChapterUpdateViewModel>()
                          .ForMember(dest => dest.NovelTitle, opt => opt.MapFrom(ch => ch.Novel.TitleEnglish))
                          .ForMember(dest => dest.NovelUrl, opt => opt.MapFrom(ch => ch.Novel.Url))
                          .ForMember(dest => dest.ChapterTitle, opt => opt.MapFrom(ch => ch.Title))
                          .ForMember(dest => dest.ChapterUrl, opt => opt.MapFrom(ch => ch.UrlSuffix))
                          .ForMember(dest => dest.ChapterNumber, opt => opt.MapFrom(ch => ch.Number));
                expression.CreateMap<Chapter, NovelDetailsChapterViewModel>();
                expression.CreateMap<Novel, NovelDetailsViewModel>()
                    .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => GetNovelGeneres(src.Genres)))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsOngoing ? "Ongoing" : "Complete"))
                    .ForMember(dest => dest.TranslatorName,
                        opt => opt.MapFrom(src => src.Translators.FirstOrDefault().UserName));
            });
        }

        private string GetNovelGeneres(ICollection<Genre> genres)
        {
            var stringifiesGenres = genres.Select(g => g.Name).ToList();

            return string.Join(", ", stringifiesGenres);
        }
    }
}
