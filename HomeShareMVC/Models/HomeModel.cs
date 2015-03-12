using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShare.DAL;

namespace HomeShare.Models
{
    public class HomeModel
    {
        

        public List<BienEchange> listeBiens
        {
            get;
            set;
        }

        public List<Membre> listeMembres
        {
            get;
            set;
        }

        public List<Pays> listePays
        {
            get;
            set;
        }

        public List<AvisMembreBien> listeAvis
        {
            get;
            set;
        }
    }
}