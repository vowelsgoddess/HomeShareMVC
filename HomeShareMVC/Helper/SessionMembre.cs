using HomeShare.Areas.Panier.Models;
using HomeShare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShare.Helper
{
    public static class SessionMembre
    {
        public static string Login
        {
            get
            {
                if (HttpContext.Current.Session["Login"] != null) return HttpContext.Current.Session["Login"].ToString();
                else return null;
            }

            set { HttpContext.Current.Session["Login"] = value; }
        }

        public static Panier Panier
        {
            get
            {


                if (HttpContext.Current.Session["Panier"] == null)
                {
                    HttpContext.Current.Session["Panier"] = new Panier();


                }
                return (Panier)HttpContext.Current.Session["Panier"];

            }


            set

            { HttpContext.Current.Session["Panier"] = value; }

        }



    }
}