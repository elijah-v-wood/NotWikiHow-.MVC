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
    public class StepController : Controller
    {
        private StepService ServiceCreate()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var serv = new StepService(userId);
            return serv;
        }
        // GET: Instruction
        public ActionResult Index()
        {
            var serv = ServiceCreate();
            var model = serv.GetInstructions();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StepCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var serv = ServiceCreate();

            if (serv.CreateInstruction(model))
            {

                TempData["SaveResult"] = "Instruction added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to add Instruction.");

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
            var mdl = new StepEdit
            {
                InstructId = dtl.InstructId,
                Title = dtl.Title,
                Description = dtl.Description
            };
            return View(mdl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StepEdit model)
        {

            if (!ModelState.IsValid)
                return View(model);

            if (model.InstructId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var svc = ServiceCreate();

            if (svc.UpdateInstruction(model))
            {
                TempData["Save Result"] = "The Instruction was Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The instruction could not be updated.");
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
        public ActionResult DeleteInstruction(int id)
        {
            return RedirectToAction("Index");
        }
    }
}