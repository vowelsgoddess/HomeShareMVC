using HomeShare.DAL;
using HomeShare.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Areas.Abonne.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Abonne/Home/
        public ActionResult Index()
        {

            if (SessionMembre.Login != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        //recuperation de la vue Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //recuperation des infos du membre
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            Membre m = Membre.ChargerMembreViaLogin(login, password);
            if (m != null)
            {
                SessionMembre.Login = m.Login;
                return RedirectToAction("Index");
            }

            return View();
        }

        //inscription d'un membre
        [HttpGet]
        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(string txtNom, string txtPrenom, string txtEmail, string txtTel, string txtLogin, string txtPassword)
        {
            Membre m = new Membre();
            m.Sauvegarder();

            return RedirectToRoute(new { area = "Membre", controller = "Home", action = "Inscription" });
        }


        //ajout d'un bien par un membre
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjouterBien(BienEchange b, HttpPostedFileWrapper membre)
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            if (membre != null)
            {
                b.Photo = membre.FileName;
                membre.SaveAs(@"Content\images\Biens\" + membre.FileName);
            }
            else
            {
                b.Photo = "";
            }
            b.Sauvegarder();
            return RedirectToAction("Index");
        }


        public ActionResult ListeBiens()
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            return View(HomeShare.DAL.BienEchange.ChargerTousLesBiens());
        }


        // Modifier un bien
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            BienEchange b = BienEchange.ChargerUnBien(id);
            return View(b);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BienEchange b, HttpPostedFileWrapper membre)
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            if (membre != null)
            {
                b.Photo = membre.FileName;
                membre.SaveAs(@"Content\images\Biens\" + membre.FileName);
            }
            else
            {
                b.Photo = BienEchange.ChargerUnBien(b.IdBien).Photo;
            }
            b.Sauvegarder();
            return RedirectToAction("Index");
        }
        
        //Supprimer un bien
        [HttpGet]
        public ActionResult Supprime(int id)
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            BienEchange b = BienEchange.ChargerUnBien(id);
            b.Supprimer();
            return RedirectToAction("ListeBiens");
        }

        //Fermer la session
        public ActionResult LogOut()
        {
            SessionMembre.Login = null;
            return RedirectToAction("Index");
        }
    }
}