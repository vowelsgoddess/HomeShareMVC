using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShare.DAL;
using HomeShare.Models;

namespace HomeShare.Controllers
{
    public class HomeController : Controller
    {
        
        
        //
        // GET: /Home Page/
        public ActionResult Index(int Page = 1)
        {
           Double d = (double)(HomeShare.DAL.BienEchange.ChargerTousLesBiens().Count());
            ViewBag.tot = Math.Ceiling(d / 4);
            return View(HomeShare.DAL.BienEchange.ChargerPagination(Page));
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Membres()
        {
            HomeModel HM = new HomeModel()
            {
                listeMembres = Membre.ChargerTousLesMembres()
            };
            return View(HM);
        }
    }
}