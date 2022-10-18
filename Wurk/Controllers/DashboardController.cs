using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wurk.Core.Models.Home;

namespace Wurk.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IEventService _eventService;
        private readonly IBlogPostService _blogPostService;
        // private readonly IContactsService contactsService;

        public DashboardController(ILogger<HomeController> logger, IEventService eventService,
           IBlogPostService blogPostService)
        {
            this.logger = logger;
            this._eventService = eventService;
            this._blogPostService = blogPostService;
            // this.contactsService = contactsService;
        }

        // GET: Dashboard
        [AllowAnonymous]
        public async Task<IActionResult> Index(int eventId, int blogId)
        {
            var upcomingEvents = await _eventService.GetUpcomingByIdAsync<UpcomingEventViewModel>(eventId);
            var latestBlog = await _blogPostService.GetLatestBlogAsync<LatestBlogPostViewModel>(blogId);

            var latestBlogs = latestBlog.Select(x => new LatestBlogPostViewModel()
            {
                Author = x.Author,
                Content = x.Content,
                Title = x.Title,
                UrlImage = x.UrlImage
            }).ToList();

            ViewBag.AllUpcomingEvents = upcomingEvents;
            ViewBag.AllLatestBlogPost = latestBlogs;

            return View();
        }

        // GET: Dashboard/Index2
        public ActionResult Index2()
        {
            return View();
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}