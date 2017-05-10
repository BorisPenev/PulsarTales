using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PulsarTales.Models.ViewModels.Home;
using PulsarTales.Services;

namespace PulsarTales.Web.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }
        public ActionResult Index()
        {
            var latestAnnouncementsVM = this.service.GetLatestAnnounsments();
            var latestChapterUpdatesVM = this.service.GetLatesChapterUpdates();

            var model = new IndexViewModel()
            {
                Announcements = latestAnnouncementsVM,
                LatestChapterUpdates = latestChapterUpdatesVM
            };
            return View(model);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(string editor1)
        {
            // todo: save body ...
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FroalaAutoSave(string body, int? postId)
        {
            //todo: save body ...
            return new EmptyResult();
        }

        public ActionResult Menu()
        {
            var model = new MenuViewModel();
            model.TranslatedTales = this.service.GetTranslatedTales();
            model.OriginalTales = this.service.GetOriginalTales();
            model.OtherTales = this.service.GetOtherTales();

            return PartialView("_MenuPartial", model);
        }
    }
}