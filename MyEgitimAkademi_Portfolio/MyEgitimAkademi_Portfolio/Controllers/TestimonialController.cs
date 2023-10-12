using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
		[Authorize]
		public ActionResult Index()
        {
            var values = db.Testimonial.ToList();   
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial )
        {
            db.Testimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.Testimonial.Find(id);
            db.Testimonial.Remove(values);
            db.SaveChanges();
			return RedirectToAction("Index");

		}
        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            var values = db.Testimonial.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditTestimonial(Testimonial testimonial)
        {
            Testimonial t = db.Testimonial.Find(testimonial.TestimonialID);
            t.NameSurname = testimonial.NameSurname;
            t.Title = testimonial.Title;
            t.ImageUrl = testimonial.ImageUrl;  
            t.Comment = testimonial.Comment;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
	}
}