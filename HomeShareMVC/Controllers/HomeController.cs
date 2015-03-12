using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index(int Page = 1)
        {
            Double d = (double)(HomeShare.DAL.BienEchange.ChargerTousLesBiens().Count());
            ViewBag.tot = Math.Ceiling(d / 3);
            return View(HomeShare.DAL.BienEchange.ChargerPagination(Page));
        }
    }
}