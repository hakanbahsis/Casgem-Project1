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
            return PartialView();
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
    }
}