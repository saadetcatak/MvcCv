using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<TblContact> repo=new GenericRepository<TblContact>();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var values = repo.Find(x => x.ID == id);
            repo.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}