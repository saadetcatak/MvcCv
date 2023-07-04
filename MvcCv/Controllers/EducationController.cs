using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<TblEducation> repo=new GenericRepository<TblEducation>();
        // GET: Education
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult EducationGet()
        { 
            return View(); 
        }

        [HttpPost]
        public ActionResult EducationGet(TblEducation p)
        {
            if(!ModelState.IsValid)
            {
                return View("EducationGet");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EducationDelete(int id)
        {
            var values = repo.Find(x=>x.ID==id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
         public ActionResult EducationUpdate(int id) 
        {
            var values=repo.Find(x=>x.ID==id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EducationUpdate(TblEducation t)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationUpdate");
            }
            var values=repo.Find(x=> x.ID==t.ID);
            values.Title= t.Title;
            values.Subtitle1 = t.Subtitle1;
            values.Subtitle2 = t.Subtitle2;
            values.Note= t.Note;
            values.Date= t.Date;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}