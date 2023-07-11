using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMessage message)
        {
            if (ModelState.IsValid)
            {
                db.TblMessage.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index", "Portfolio");
               // return Json(new { success = true });
            }
            return View(message);
            
        }
    }
}