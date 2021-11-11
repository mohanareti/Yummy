using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zomato.Models;

namespace Zomato.Controllers
{
    public class HomeController : Controller
    {
       //MenuDbContext db = null;
       // public HomeController()
       // {
       //     db = new MenuDbContext();
       // }

        //Mian home page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            // ViewBag.allmenu = db.Menu.ToList();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}