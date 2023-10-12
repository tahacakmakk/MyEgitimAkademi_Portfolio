using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(Contact contact)
		{
			db.Contact.Add(contact);
			db.SaveChanges();
			return RedirectToAction("Index", "Default");
		}
		public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialQuickContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialFuture()
        {
            var values = db.About.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = db.Service.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.Skill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAward()
        {
            return PartialView();
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = db.Testimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialClient()
        {
            return PartialView();
        }
        public PartialViewResult PartialContact()
        {
             var values = db.Address.ToList();
            return PartialView(values);
        }
          
    }
}