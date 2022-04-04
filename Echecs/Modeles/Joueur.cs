using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public class Joueur
    {
        private string _nom;
        private int _statsVictoire;
        private int _statsDefaite;
        private int _statsNull;


        public Joueur(string nom, int statsVictoire, int statsDefaire, int statsNull)
        {
            _nom = nom; 
            _statsVictoire = statsVictoire;
            _statsDefaite = statsDefaire;
            _statsNull= statsNull;
        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public int StatsVictoire
        {
            get { return _statsVictoire;}
            set { _statsVictoire = value; }
        }
        public int StatsDefaite
        {
            get { return _statsDefaite; }
            set { _statsDefaite = value; }

        }
        public int StatsNull
        {
            get { return _statsNull; }
            set { _statsNull = value; }
        }
        public void ajoutVictoire()
        {
            _statsVictoire++;
        }
        public void ajoutDefaite()
        {
            _statsDefaite++;
        }
        public void ajoutNulle()
        {
            _statsNull++;
        }
    }
}
