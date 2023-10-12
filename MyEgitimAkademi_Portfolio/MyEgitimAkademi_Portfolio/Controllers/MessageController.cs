using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioDbEntities db  = new MyPortfolioDbEntities();    
        [Authorize]
		public ActionResult Index()
        {
            var values = db.Contact.ToList();
            return View(values);
        }
    }
}