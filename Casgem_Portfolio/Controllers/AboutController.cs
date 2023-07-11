using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models;
namespace Casgem_Portfolio.Controllers
{
    public class AboutController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        // GET: About
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAbout about)
        {
            if (ModelState.IsValid)
            {
                db.TblAbout.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }

        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            db.TblAbout.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout about)
        {
            if (ModelState.IsValid)
            {
                var values = db.TblAbout.Find(about.WhoAmIId);
                values.Title = about.Title;
                values.Title1 = about.Title1;
                values.Description = about.Description;
                values.ImageUrl = about.ImageUrl;
                values.CvUrl = about.CvUrl;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}