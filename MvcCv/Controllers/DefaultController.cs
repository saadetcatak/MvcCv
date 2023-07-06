using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities db=new DbCvEntities(); 
        public ActionResult Index()
        {
            var values= db.TblAbout.ToList();
            return View(values);
        }
        
        public PartialViewResult _ExperiencePartial()
        {
            var values=db.TblExperience.ToList();
            return PartialView(values);
        }

        public PartialViewResult _SocialMediaPartial()
        {
            var values = db.TblSocialMedia.Where(x=>x.Durum==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult _EducationPartial()
        {
            var values=db.TblEducation.ToList();
            return PartialView(values);
        }

        public PartialViewResult _SkillPartial()
        {
            var values=db.TblSkill.ToList();
            return PartialView(values);
        }

        public PartialViewResult _InterestPartial()
        {
            var values=db.TblInterest.ToList();
            return PartialView(values);
        }

        public PartialViewResult _CertificatePartial()
        {
            var values=db.TblCertificate.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult _ContactPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult _ContactPartial(TblContact c)
        {
            c.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(c);
            db.SaveChanges();
            return PartialView();
        }
    }
}