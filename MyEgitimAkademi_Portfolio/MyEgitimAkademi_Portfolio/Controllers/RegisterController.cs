using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class RegisterController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(Admin admin)
		{
            db.Admin.Add(admin);
            db.SaveChanges();
			return RedirectToAction("Index","Login");
		}
	}
}