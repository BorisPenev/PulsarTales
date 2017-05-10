using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PulsarTales.Models.BindingModels.News;
using PulsarTales.Services;

namespace PulsarTales.Web.Controllers
{
    [RoutePrefix("news")]
    public class NewsController : Controller
    {
        private NewsService service;

        public NewsController()
        {
            this.service = new NewsService();
        }
        // GET: News
        [Route]
        public ActionResult Index()
        {
            var model = this.service.GetAllAnnouncements();
            return View(model);
        }

        // GET: News/5
        [Route("{id:int:min(1)}")]
        public ActionResult Details(int id)
        {
            var announcementDetails = this.service.GetAnnouncement(id);
            return View(announcementDetails);
        }
        
        // GET: News/Create
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        [Route("create")]
        public ActionResult Create(CreateBindingModel bind)
        {
            
            this.service.CreateAnnouncement(bind, this.User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

        // GET: News/Edit/5
        [Route("edit/{id:int:min(1)}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: News/Edit/5
        [HttpPost]
        [Route("edit/{id:int:min(1)}")]
        public ActionResult Edit(int id, EditBindingModel bind)
        {
            if (thi.IsInRole.IsInRole("Admin"))
            {
                this.service.EditAnnouncement(bind);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Account");
        }
       
        // POST: News/Delete/5
        [HttpPost]
        [Route("delete/{id:int:min(1)}")]
        public ActionResult Delete(int id)
        {
            if (this.User.IsInRole("Admin"))
            {
                this.service.DeleteAnnouncement(id);
                return RedirectToAction("Index");

            }

            return RedirectToAction("Login", "Account");
        }
    }
}
