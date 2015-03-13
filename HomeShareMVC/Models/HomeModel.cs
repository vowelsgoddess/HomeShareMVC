using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShare.DAL;

namespace HomeShare.Models
{
    public class HomeModel
    {

        public List<Membre> listeMembres
        {
            get;
            set;
        }

        public Pays PaysMembre
        {
            get;
            set;
        }
    }
}