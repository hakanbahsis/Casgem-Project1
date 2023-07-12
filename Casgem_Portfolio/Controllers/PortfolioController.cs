using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models;

namespace Casgem_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        // GET: Portfolio
        public ActionResult Index()
        {
            ViewBag.Title = db.TblFeatures.Select(x => x.FeatureTitle).FirstOrDefault();
            ViewBag.Description = db.TblFeatures.Select(x => x.FeatureDescription).FirstOrDefault();
            ViewBag.ImageUrl = db.TblFeatures.Select(x => x.FeaturesImageUrl).FirstOrDefault();


            ViewBag.Facebook = db.TblSocialMedia.Select(x => x.Facebook).FirstOrDefault();
            ViewBag.Linkedin = db.TblSocialMedia.Select(x => x.LinkedIn).FirstOrDefault();
            ViewBag.Instagram = db.TblSocialMedia.Select(x => x.Instagram).FirstOrDefault();
            ViewBag.Twitter = db.TblSocialMedia.Select(x => x.Twitter).FirstOrDefault();

            List<TblAbout> about = new List<TblAbout>();
            about = db.TblAbout.ToList();
            ViewBag.D1 = about.Select(x => x.Title).FirstOrDefault(); 
            ViewBag.D2 = about.Select(x => x.Title1).FirstOrDefault(); 

            return View();
        }

        [HttpGet]
        public JsonResult Features()
        {
            ViewBag.Title = db.TblFeatures.Select(x => x.FeatureTitle).FirstOrDefault();
            ViewBag.Description = db.TblFeatures.Select(x => x.FeatureDescription).FirstOrDefault();
            ViewBag.ImageUrl = db.TblFeatures.Select(x => x.FeaturesImageUrl).FirstOrDefault();
            var title = ViewBag.Title;
            var desc = ViewBag.Description;
            var arr = new Array[title, desc];
            return Json(arr);
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialBanner()
        {
            ViewBag.FeatureTitle = db.TblFeatures.Select(x => x.FeatureTitle).FirstOrDefault();
            ViewBag.FeatureDescription = db.TblFeatures.Select(x => x.FeatureDescription).FirstOrDefault();
            ViewBag.FeatureImageUrl = db.TblFeatures.Select(x => x.FeaturesImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.Title = db.TblAbout.Select(x => x.Title).FirstOrDefault();
            ViewBag.Title1 = db.TblAbout.Select(x => x.Title1).FirstOrDefault();
            ViewBag.Description = db.TblAbout.Select(x => x.Description).FirstOrDefault();
            ViewBag.ImageUrl = db.TblAbout.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
       

        public FileResult Download(string file)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Templates/" + file + ""));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file);
        }

        public PartialViewResult MyResume()
        {
            var values = db.TblMyResume.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialStatistik()
        {
            ViewBag.TotalService = db.TblServices.Count();
            ViewBag.TotalMessage = db.TblMessage.Count();
            ViewBag.TotalThanksMessage = db.TblMessage.Where(x => x.MessageSubject == "Teşekkür").Count();
            ViewBag.TotalProject = db.TblProjects.Count();
            ViewBag.HappyCustomer = 23;
            return PartialView();
        }

        public PartialViewResult PartialServices()
        {
            var values = db.TblServices.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonials()
        {
            var values = db.TblTestimonials.ToList();
            return PartialView(values);
        }
        
        public PartialViewResult PartialFooter()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }
    }
}