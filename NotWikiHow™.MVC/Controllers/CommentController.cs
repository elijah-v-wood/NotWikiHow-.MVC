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
    public class CommentController : Controller
    {
        private CommentService ServiceCreate()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var serv = new CommentService(userId);
            return serv;
        }
        
        // GET: Comment
        public ActionResult Index(int id)
        {
            var svc = ServiceCreate();
            var mdl = svc.GetAllComments(id);
            return View(mdl);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var serv = ServiceCreate();

            if (serv.CreateComment(model))
            {
                TempData["SaveResult"] = "Comment added Successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Tutorial could not be created.");

            return View(model);

        }
        public ActionResult Details(int id)
        {
            var serv = ServiceCreate();
            var model = serv.GetById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var svc = ServiceCreate();
            var dtl = svc.GetById(id);
            var mdl = new CommentEdit
            {
                CommentId=dtl.CommentId,
                Question=dtl.Question
            };
            return View(mdl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.CommentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var svc = ServiceCreate();

            if(svc.UpdateComment(model))
            {
                TempData["Save Result"] = "Your Comment has been Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Comment could not be updated.");
            return View(model);
        }

    }
}