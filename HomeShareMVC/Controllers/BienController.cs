using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShare.DAL;
using HomeShare.Models;

namespace HomeShareMVC.Controllers.Bien
{
    public class BienController : Controller
    {
      
        
        // GET: /Details Bien/
        public ActionResult Details(int id)
        {
            //return View();
            DetailsModel DM = new DetailsModel()
            {
                BienCourant = BienEchange.ChargerUnBien(id),
                ListeValeursOptions = OptionsBien.ChargerValeursOptionsBien(id),
                listeLibelleOptions = Options.ChargerLibelleOptionsBien(id),
                Proprio = Membre.ChargerMembreViaBien(id),
                PaysMembre = Pays.ChargerPaysMembreViaBien(id),
                PaysBien = Pays.ChargerPaysBien(id),
                ListeAvis = AvisMembreBien.ChargerAvisBien(id),
                
            };

            return View(DM);
        }
	}
}