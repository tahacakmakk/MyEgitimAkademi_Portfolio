using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEgitimAkademi_Portfolio.Models;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        [Authorize]
        public ActionResult Index()
        {
            var values = db.Service.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.Service.Find(id);
            db.Service.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
		public ActionResult AddService()
        {
			return View();
		}

		[HttpPost]
        public ActionResult AddService(Service service)
        {
            db.Service.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ListService(int id)
        {
            Service services = db.Service.Find(id);
            return View(services);
        }

        [HttpPost]
        public ActionResult ListService(Service s)
        {
            Service d1 = db.Service.Find(s.ServiceId);
            d1.ServiceName = s.ServiceName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}