using Microsoft.AspNet.Identity;
using NotWikiHow_.Models;
using NotWikiHow_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotWikiHow_.MVC.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private CommentService ServiceCreate()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var serv = new CommentService(userId);
            return serv;
        }
        // GET: Comment
        public ActionResult Index()
        {
            var serv = ServiceCreate();
            var model = serv.GetMyComments();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var serv = ServiceCreate();

            if (serv.CreateComment(model))
            {

                TempData["SaveResult"] = "Comment added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to post comment.");

            return View(model);

        }
        public ActionResult Details(int id)
        {
            var serv = ServiceCreate();
            var model = serv.GetById(id);

            return View(model);
        }
    }
}