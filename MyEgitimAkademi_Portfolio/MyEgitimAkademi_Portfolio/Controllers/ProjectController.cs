using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project

        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
		[Authorize]
		public ActionResult Index()
        {
            var values = db.Project.ToList();
            return View(values);
        }

		public ActionResult DeleteSkill(int id)
		{
			var values = db.Project.Find(id);
			db.Project.Remove(values);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult AddProject()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddProject(Project project)
		{
			db.Project.Add(project);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult UpdateProject(int id)
		{
			var values = db.Project.Find(id);
			return View(values);
		}
		[HttpPost]
		public ActionResult UpdateProject(Project project)
		{
			var values = db.Project.Find(project.ProjectID);
			values.Title = project.Title;
			values.Description = project.Description;
			values.ProjectCategory = project.ProjectCategory;
			values.CompleteDay = project.CompleteDay;	
			values.Price = project.Price;	
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}