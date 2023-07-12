using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

using Casgem_Portfolio.Models;
namespace Casgem_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Phone = db.TblInfo.Select(x => x.Phone).FirstOrDefault();
            ViewBag.Mail = db.TblInfo.Select(x => x.Email).FirstOrDefault();
            ViewBag.Address = db.TblInfo.Select(x => x.Address).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMessage message)
        {
            if (ModelState.IsValid)
            {
                db.TblMessage.Add(message);
                db.SaveChanges();
                Thread.Sleep(500);

                return RedirectToAction("Index", "Portfolio");
               // return Json(new { success = true });
            }
            return View(message);
            
        }

       
    }
}