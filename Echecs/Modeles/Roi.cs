using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    /// <summary>
    /// La pièce du roi
    /// </summary>
    class Roi: PieceMemoire
    {
		
        /// <summary>
        /// Instancie le nom de la pièce
        /// </summary>
        /// <param name="_couleur">La couleur du roi</param>
        public Roi(Couleur _couleur) : base(_couleur)
        {
            if(_couleur == Couleur.Blanc)
            {
                _nom = 'K';
            }
            else
            {
                _nom = 'k';
            }
        }

        /// <summary>
        /// Vérifie si le roi peut roquer
        /// </summary>
        /// <returns>Retourne vrai si le roi peut roquer</returns>
        public override bool peutRoquer()
        {
            return !_aBougé;
        }

        /// <summary>
        /// Dit que le roi a bougé
        /// </summary>
        public override void vientDeBouger()
        {
            ABougé = true;
        }

        /// <summary>
        /// Vérifie la validité du mouvement selon les règles du roi
        /// </summary>
        /// <param name="indexInitiale">L'index de la case initiale de la pièce</param>
        /// <param name="indexDestination">L'index de la case destination de la pièce</param>
        /// <returns>Retourne le type de mouvement du roi</returns>
        public override Mouvement regles(int indexInitiale, int indexDestination)
        {
            if (indexDestination == indexInitiale + 1 || indexDestination == indexInitiale - 1
                || indexDestination == indexInitiale - 8 || indexDestination == indexInitiale + 8
                || indexDestination == indexInitiale - 9 || indexDestination == indexInitiale - 7
                || indexDestination == indexInitiale + 9 || indexDestination == indexInitiale + 7)
            {
                return Mouvement.peutBougerSansCollision;
            }
            return Mouvement.peutPasBouger;
        }
    }
}