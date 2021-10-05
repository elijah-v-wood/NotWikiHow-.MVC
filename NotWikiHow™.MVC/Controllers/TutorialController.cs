using NotWikiHow_.Models;
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
            var model = new TutorialListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TutorialCreateModel tutorial)
        {
            if (ModelState.IsValid) { }

            return View();
        }
    }
}