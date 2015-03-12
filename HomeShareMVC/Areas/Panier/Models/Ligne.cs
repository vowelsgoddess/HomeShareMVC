using HomeShare.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShare.Areas.Panier.Models
{
    public class Ligne
    {

        private BienEchange _bienChoisi;
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private bool _assurance = false;
        private int _fraisDossier;
        private int _cout;

        public BienEchange BienChoisi
        {
            get;
            set;
        }
        public DateTime DateDebut
        {
            get;
            set;
        }

        public DateTime DateFin
        {
            get;
            set;
        }

        public bool Assurance
        {
            get;
            set;
        }

        public int FraisDossier
        {
            get { return 5; }
        }

        public int Cout
        {
            get { return FnCout(); }
        }

        private int FnCout()
        {
            return FraisDossier + Cout;
        }


    }
}