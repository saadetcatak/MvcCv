using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience

        ExperienceRepository experienceRepository = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = experienceRepository.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult ExperienceAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExperienceAdd(TblExperience tblExperience)
        {
            experienceRepository.TAdd(tblExperience);
            return RedirectToAction("Index");
        }
        public ActionResult ExperienceDelete(int id)
        {
            TblExperience tblExperience = experienceRepository.Find(x => x.ID == id);
            experienceRepository.TDelete(tblExperience);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult ExperienceGet(int id)
        {
            TblExperience tblExperience=experienceRepository.Find(x=>x.ID == id);
            return View(tblExperience);
        }
        [HttpPost]
        public ActionResult ExperienceGet(TblExperience p)
        {
            TblExperience tbl = experienceRepository.Find(x=>x.ID==p.ID);
            tbl.Title1 = p.Title1;
            tbl.Title2 = p.Title2;
            tbl.Date=p.Date;
            tbl.Description=p.Description;
            experienceRepository.TUpdate(tbl);
            return RedirectToAction("Index");
            
        }
    }
}