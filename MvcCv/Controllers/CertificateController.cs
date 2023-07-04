using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        GenericRepository<TblCertificate> repo=new GenericRepository<TblCertificate>();
        // GET: Certificate
        public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult CertificateGet(int id) 
        { 
            var values=repo.Find(x=>x.ID==id);
            return View(values);
        }
        [HttpPost]
        public ActionResult CertificateGet(TblCertificate t)
        {
            var values = repo.Find(x => x.ID ==t.ID);
            values.Description = t.Description;
            values.Date=t.Date;
            repo.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}