using HomeShare.DAL;
using HomeShare.Models;
using HomeShare.Areas.Panier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShare.Helper;

namespace HomeShare.Areas.Panier.Controllers
{
    public class TransactionController : Controller
    {
        //
        // GET: /Boutique/Transaction/
        public ActionResult Index()
        {
            return View("Transaction", SessionMembre.Panier);
        }
	}
}