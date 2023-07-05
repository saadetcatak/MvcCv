using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest

        GenericRepository<TblInterest> repo=new GenericRepository<TblInterest>();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }

        [HttpGet]
         public ActionResult InterestUpdate(int id)
        {
            var values = repo.Find(x=>x.ID==id);
            return View(values); 
        }

        public ActionResult InterestUpdate(TblInterest p)
        {
            var values = repo.Find(x => x.ID ==p.ID);
            values.Description1 = p.Description1;
            values.Description2 = p.Description2;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }

        public ActionResult InterestDelete(int id) 
        { 
            var values=repo.Find(x=>x.ID==id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult InterestAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InterestAdd(TblInterest p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}
