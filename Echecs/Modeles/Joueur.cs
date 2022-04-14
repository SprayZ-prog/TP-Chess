using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    /// <summary>
    /// Les joueurs étant inscrits dans le classement du jeu d’échec avec leurs statistiques.
    /// </summary>
    public class Joueur
    {
        private string _nom;
        private int _statsVictoire;
        private int _statsDefaite;
        private int _statsNull;

        /// <summary>
        /// Instancie les informations du joueur
        /// </summary>
        /// <param name="nom">Le nom du joueur</param>
        /// <param name="statsVictoire">Le nombre de victoire du joueur</param>
        /// <param name="statsDefaire">Le nombre de défaite du joueur</param>
        /// <param name="statsNull">Le nombre de partie nulle du joueur</param>
        public Joueur(string nom, int statsVictoire, int statsDefaire, int statsNull)
        {
            _nom = nom; 
            _statsVictoire = statsVictoire;
            _statsDefaite = statsDefaire;
            _statsNull= statsNull;
        }

        /// <summary>
        /// Retourne la donnée membre du nom du joueur
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        /// <summary>
        /// Retourne la donnée membre des statistiques de victoire du joueur
        /// </summary>
        public int StatsVictoire
        {
            get { return _statsVictoire;}
            set { _statsVictoire = value; }
        }

        /// <summary>
        /// Retourne la donnée membre des statistiques de défaite du joueur
        /// </summary>
        public int StatsDefaite
        {
            get { return _statsDefaite; }
            set { _statsDefaite = value; }

        }

        /// <summary>
        /// Retourne la donnée membre des statistiques de nulle du joueur
        /// </summary>
        public int StatsNull
        {
            get { return _statsNull; }
            set { _statsNull = value; }
        }

        /// <summary>
        /// Ajoute un victoire au joueur
        /// </summary>
        public void ajoutVictoire()
        {
            _statsVictoire++;
        }
        /// <summary>
        /// Ajoute une défaite au joueur
        /// </summary>
        public void ajoutDefaite()
        {
            _statsDefaite++;
        }
        /// <summary>
        /// Ajoute une nulle au joueur
        /// </summary>
        public void ajoutNulle()
        {
            _statsNull++;
        }
        /// <summary>
        /// Met en format lisible le joueur avec ses statistiques
        /// </summary>
        /// <returns>Retourne la chaine de caractères des informations du joueur</returns>
        public override string ToString()
        {
            return _nom + "/" + _statsVictoire + "/" + _statsDefaite + "/" + _statsNull; 
        }
    }
}
