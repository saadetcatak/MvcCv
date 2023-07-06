using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo=new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(TblAdmin t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult AdminDelete(int id)
        {
            TblAdmin tblAdmin= repo.Find(x => x.ID == id);
            repo.TDelete(tblAdmin);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult AdminUpdate(int id)
        {
           TblAdmin tblAdmin= repo.Find(x => x.ID == id);
            return View(tblAdmin);
        }
        [HttpPost]
        public ActionResult AdminUpdate(TblAdmin p)
        { 
            TblAdmin tbl = repo.Find(x => x.ID == p.ID);
            tbl.UserName= p.UserName;
            tbl.Password= p.Password;
            repo.TUpdate(tbl);
            return RedirectToAction("Index");

        }
    }
}