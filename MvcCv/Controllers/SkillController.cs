using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;
using Newtonsoft.Json.Linq;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        GenericRepository<TblSkill> repo = new GenericRepository<TblSkill>();
        public ActionResult Index()

        {
            var values=repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult SkillAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SkillAdd(TblSkill p)
        {
            repo.TAdd(p);
           return RedirectToAction("Index");
        }

        public ActionResult SkillDelete(int id)
        {
            var values=repo.Find(x=>x.ID==id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SkillUpdate(int id)
        {
            var values = repo.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult SkillUpdate(TblSkill t)
        {
            var values = repo.Find(x => x.ID ==t.ID);
            values.Skill = t.Skill;
            values.Ratio= t.Ratio;
            repo.TUpdate(values);
            return RedirectToAction("Index");

        }
    }
}