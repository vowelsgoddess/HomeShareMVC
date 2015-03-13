using HomeShare.Areas.Membre.Models;
using HomeShare.Helper;
using HomeShare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Areas.Membre.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Member/Home/
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtLog, string txtPass)
        {
            Membre m = Membre.ChargerMembreViaLogin(txtLog, txtPass);

            if (m == null)
            {
                ViewBag.Error = "Essaie encore !!!";
                return View();
            }

            else
            {
                SessionMembre.Login = m.Login;
                SessionMembre.User = m;

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

        }

        [HttpGet]
        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(string txtNom, string txtPrenom, string txtEmail, int idPays, string txtTel, string txtLogin, string txtPassword)
        {
            Membre m = new Membre();
            m.Nom = txtNom;
            m.Prenom = txtPrenom;
            m.Email = txtEmail;
            m.IdPays = (int)idPays;
            m.Telephone = txtTel;
            m.Login = txtLogin;
            m.Password = txtPassword;
            m.Sauvegarder();

            return RedirectToRoute(new { area = "Membre", controller = "Home", action = "Inscription" });
        }


        [HttpGet]
        public ActionResult AjouterBien()
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjouterBien(BienEchange b,
           HttpPostedFileWrapper Fclient, string txtTitre, string txtdescCourt, string txtdescLong, int cap, int codePays,
            string txtVille, string txtRue, int txtNumero, int txtCP, string txtPhoto,
            bool txtAssurance, bool txtDispo, string txtLat, string txtLong, DateTime txtDate)
        {


            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }

            if (Fclient != null)
            {
                b.Titre = txtTitre;
                b.DescCourte = txtdescCourt;
                b.DescLong = txtdescLong;
                b.NombrePerson = cap;
                b.IdPays = codePays;
                b.Ville = txtVille;
                b.Rue = txtRue;
                b.Numero = txtNumero;
                b.CodePostal = txtCP;
                b.Photo = txtPhoto;
                b.AssuranceObligatoire = txtAssurance;
                b.IsEnabled = (bool)txtDispo;
                b.Latitude = txtLat;
                b.Longitude = txtLong;
                b.DateCreation = (DateTime)txtDate;
                b.Photo = Fclient.FileName;
               
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

        [HttpGet]
        public ActionResult ModifierBien(int id)
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            BienEchange be = BienEchange.ChargerUnBien(id);
            return View(be);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifierBien(BienEchange b, HttpPostedFileWrapper Fclient)
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            if (Fclient != null)
            {
                b.Photo = Fclient.FileName;
                Fclient.SaveAs(@"C:\Users\e.haultecoeur\Documents\visual studio 2013\Projects\HomeShare\HomeShare\Content\images\" + Fclient.FileName);
            }
            else
            {
                b.Photo = BienEchange.ChargerUnBien(b.IdBien).Photo;
            }

            b.Sauvegarder();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SupprimerBien(int id)
        {
            if (SessionMembre.Login == null)
            {
                return RedirectToAction("Login");
            }
            BienEchange be = BienEchange.ChargerUnBien(id);
            be.Supprimer();
            return RedirectToAction("ListeBiens");
        }


        public ActionResult LogOut()
        {
            SessionMembre.Login = null;
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}