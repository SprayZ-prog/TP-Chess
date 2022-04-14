using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    /// <summary>
    /// La pièce de la tour
    /// </summary>
    class Tour : PieceMemoire
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_couleur"></param>
        public Tour(Couleur _couleur) : base(_couleur)
        {
            if (_couleur == Couleur.Blanc)
            {
                _nom = 'T';
            }
            else
            {
                _nom = 't';
            }

        }

        /// <summary>
        /// Vérifie si la tour peut roquer
        /// </summary>
        /// <returns>Retourne vrai si la tour peut roquer</returns>
        public override bool peutRoquer()
        {
            return !_aBougé;
        }

        /// <summary>
        /// Dit que la tour a bougé
        /// </summary>
        public override void vientDeBouger()
        {
            ABougé = true;
        }
        /// <summary>
        /// Vérifie la validité du mouvement selon les règles de la tour
        /// </summary>
        /// <param name="indexInitiale">L'index de la case initiale de la pièce</param>
        /// <param name="indexDestination">L'index de la case destination de la pièce</param>
        /// <returns>Retourne le type de mouvement de la tour</returns>
        public override Mouvement regles(int indexInitiale, int indexDestination)
        {
            if ((indexInitiale - indexDestination) % 8 == 0 || (indexInitiale + indexDestination) % 8 == 0 || indexInitiale / 8 == indexDestination / 8)
            {
                return Mouvement.peutBougerSansCollision;
            }
            return Mouvement.peutPasBouger;
        }
    }
}
