using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models;

namespace Casgem_Portfolio.Controllers
{
    public class TestimonialsController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        // GET: Testimonials
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonials()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonials(TblTestimonials testimonials)
        {
            if (ModelState.IsValid)
            {
                db.TblTestimonials.Add(testimonials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonials);
        }

        public ActionResult DeleteTestimonials(int id)
        {
            var values = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonials(int id)
        {
            var values = db.TblTestimonials.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTestimonials(TblTestimonials testimonials)
        {
            if (ModelState.IsValid)
            {
                var values = db.TblTestimonials.Find(testimonials.TestimonialsId);
                values.Name = testimonials.Name;
                values.Location = testimonials.Location;
                values.Contents = testimonials.Contents;
                values.ImageUrl = testimonials.ImageUrl;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}