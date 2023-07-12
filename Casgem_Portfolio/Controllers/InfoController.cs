using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models;

namespace Casgem_Portfolio.Controllers
{
    public class InfoController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();

        [HttpGet]
        public ActionResult AddInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInfo(TblInfo info)
        {
            if (ModelState.IsValid)
            {
                db.TblInfo.Add(info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(info);
        }

        [HttpGet]
        public ActionResult UpdateInfo(int id)
        {
            var values = db.TblInfo.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateInfo(TblInfo info)
        {
            if (ModelState.IsValid)
            {
                var values = db.TblInfo.Find(info.ContactId);
                values.Phone = info.Phone;
                values.Email = info.Email;
                values.Address = info.Address;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var count = db.TblInfo.Count();
            ViewBag.Count = count;
            var values = db.TblInfo.ToList();
            return View(values);
        }
    }
}