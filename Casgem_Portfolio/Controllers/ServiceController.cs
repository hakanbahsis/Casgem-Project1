using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models;

namespace Casgem_Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        //referanslar admin kısmı
        //projelerim admin kısmı
        //mesaj detayı bitirilecek

        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        // GET: Service
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblServices.Find(id);
            db.TblServices.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(TblServices services)
        {
            if (ModelState.IsValid)
            {
                db.TblServices.Add(services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(services);
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.TblServices.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(TblServices services)
        {
            if (ModelState.IsValid)
            {
                var values = db.TblServices.Find(services.ServicesId);
                values.ServiceTitle = services.ServiceTitle;
                values.Icon = services.Icon;
                values.ServiceContent = services.ServiceContent;
                values.ServiceNumber = services.ServiceNumber;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}