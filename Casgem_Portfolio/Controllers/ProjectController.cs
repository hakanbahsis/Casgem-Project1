using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models;

namespace Casgem_Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        CasgemPortfolioEntities1 db = new CasgemPortfolioEntities1();
        // GET: Project
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProjects projects)
        {
            if (ModelState.IsValid)
            {
                db.TblProjects.Add(projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projects);
        }

        public ActionResult DeleteProject(int id)
        {
            var values = db.TblProjects.Find(id);
            db.TblProjects.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var values = db.TblProjects.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProjects projects)
        {
            if (ModelState.IsValid)
            {
                var values = db.TblProjects.Find(projects.ProjectsId);
                values.Title = projects.Title;
                values.Description = projects.Description;
                values.ImageUrl = projects.ImageUrl;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}