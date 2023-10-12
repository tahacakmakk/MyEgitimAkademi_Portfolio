using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class LoginController : Controller
    {
         MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = db.Admin.FirstOrDefault(x=> x.UserName == p.UserName && x.Password ==p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, true);
                Session["username"] = values.UserName.ToString();
                return RedirectToAction("Index", "Service");
            }
            return View();
        }
    }
}