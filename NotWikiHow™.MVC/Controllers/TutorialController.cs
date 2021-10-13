using Microsoft.AspNet.Identity;
using NotWikiHow_.Data;
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
        private TutorialService ServiceCreate()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var serv = new TutorialService(userId);
            return serv;
        }
        // GET: Tutorial
        public ActionResult Index()
        {
            var serv = ServiceCreate();
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

            var serv = ServiceCreate();

            if (serv.CreateTutorial(model))
            {
                TempData["SaveResult"] = "Tutorial Created Successfully.";
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
            var mdl = new TutorialEdit
            {
                TutorId = dtl.TutorId,
                Title = dtl.Title,
                Description = dtl.Description,
                Instructions = dtl.Instructions,
                Published = dtl.Published
            };
            return View(mdl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,TutorialEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.TutorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var svc = ServiceCreate();

            if (svc.UpdateTutorial(model))
            {
                TempData["Save Result"] = "Your Tutorial was Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your tutorial could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var serv = ServiceCreate();
            var model = serv.GetById(id);

            return View(model);
        }
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTutorial(int id)
        {
            return RedirectToAction("Index");
        }
        public ActionResult AddInstruction()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInstruction(int id, Instruction model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var svc = ServiceCreate();

            if (svc.AddInstruction(model, id))
            {
                TempData["SaveResult"] = "Instruction Added.";
                return RedirectToAction($"Edit/{id}");
            }
            ModelState.AddModelError("", "Failed to add instruction");
            return View(model);
        }
    }
}