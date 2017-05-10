using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PulsarTales.Models.ViewModels.Home;
using PulsarTales.Services;

namespace PulsarTales.Web.Controllers
{
    [RoutePrefix("novel")]
    public class NovelsController : Controller
    {
        private NovelsService service;

        public NovelsController()
        {
            this.service = new NovelsService();
        }
        // GET: novel/{url}
        [Route("{novelUrl}")]
        public ActionResult Details(string novelUrl)
        {
            if (string.IsNullOrEmpty(novelUrl))
            {
                return HttpNotFound("No such novel!");
            }
            var novel = this.service.GetNovelDetails(novelUrl);
            if (novel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(novel);
        }
        // GET: novel/{url}
        [Route("{novelUrl}/{chapterUrl}")]
        public ActionResult ChapterDetails(string novelUrl, string chapterUrl)
        {
            if (string.IsNullOrEmpty(novelUrl) || string.IsNullOrEmpty(chapterUrl))
            {
                return HttpNotFound("No such novel or chapter!");
            }
            var chapter = this.service.GetChapterDetails(novelUrl, chapterUrl);
            if (chapter == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(chapter);
        }
    }
}