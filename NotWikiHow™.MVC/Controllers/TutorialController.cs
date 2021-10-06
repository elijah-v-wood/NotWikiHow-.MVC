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
    public class TutorialController : Controller
    {
        // GET: Tutorial
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var serv = new TutorialService(userId);
            var model = serv.GetMyTutorials();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TutorialCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var serv = new TutorialService(userId);

            if (serv.CreateTutorial(model))
            {
                TempData["SaveResult"] = "Tutorial Created Successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Tutorial could not be created.");

            return View(model);
        }
    }
}