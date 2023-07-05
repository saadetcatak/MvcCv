using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        GenericRepository<TblAbout> repo=new GenericRepository<TblAbout>();

        [HttpGet]
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }

        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var values = repo.Find(x => x.ID == 1);
            values.Name= p.Name;
            values.Surname= p.Surname;
            values.Adress= p.Adress;
            values.Description= p.Description;
            values.Email= p.Email;
            values.Image= p.Image;
            values.Phone= p.Phone;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}