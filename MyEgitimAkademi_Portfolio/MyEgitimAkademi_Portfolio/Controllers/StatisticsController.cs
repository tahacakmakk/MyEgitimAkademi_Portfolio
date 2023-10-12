using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolio.Models;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class StatisticsController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        [Authorize]
		public ActionResult Index()
        {
            ViewBag.totalProjectCount = db.Project.Count();
            ViewBag.totalTestimonialCount = db.Testimonial.Count();
            ViewBag.sumWorkDay = db.Project.Sum(x => x.CompleteDay );
            ViewBag.avgWorkDay = db.Project.Average(x => x.CompleteDay);
            ViewBag.avgPrice = db.Project.Average(x => x.Price );
            ViewBag.avgPriceFormatted = string.Format("{0:N2}", ViewBag.avgPrice);

            //Select * from project where price = (Select Max(Price) from project)
            var value = db.Project.Max(x => x.Price);
            ViewBag.maxPriceProject = db.Project.Where(x => x.Price == value).FirstOrDefault().Title;
            //
            var value2 = db.Category.Where(x => x.CategoryName == ".Net").Select( y=> y.CategoryID).FirstOrDefault();
            ViewBag.categoryCountName = db.Project.Where(x => x.ProjectCategory == value2).Count();
            return View();
        }
    }
}