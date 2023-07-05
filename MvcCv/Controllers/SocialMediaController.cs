using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<TblSocialMedia> repo=new GenericRepository<TblSocialMedia>();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult SocialMediaAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SocialMediaAdd(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SocialMediaUpdate(int id)
        {
            var values = repo.Find(x=>x.ID==id);
            return View(values);

        }
        [HttpPost]
        public ActionResult SocialMediaUpdate(TblSocialMedia p)
        {
            var values = repo.Find(x => x.ID ==p.ID);
            values.Name = p.Name;
            values.Durum = true;
            values.Link= p.Link;
            values.Icon= p.Icon;
            repo.TUpdate(values);
            return RedirectToAction("Index");

        }

        public ActionResult SocialMediaDelete(int id) 
        {
            var values=repo.Find(x=>x.ID==id);
            values.Durum = false;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }

    }
}