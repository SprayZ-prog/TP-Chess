using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Cavalier : Piece
    {
        /// <summary>
        /// Instancie le nom et la couleur du cavalier
        /// </summary>
        /// <param name="_couleur">La couleur du cavalier</param>
        public Cavalier(Couleur _couleur) : base(_couleur)
        {
            if (_couleur == Couleur.Blanc)
            {
                _nom = 'C';
            }
            else
            {
                _nom = 'c';
            }
        }


        /// <summary>
        /// Vérifie la validité du mouvement selon les règles du cavalier
        /// </summary>
        /// <param name="indexInitiale">L'index de la case initiale de la pièce</param>
        /// <param name="indexDestination">L'index de la case destination de la pièce</param>
        /// <returns>Retourne le type de mouvement du cavalier</returns>
        public override Mouvement regles(int indexInitiale, int indexDestination)
        {
            if (indexDestination == indexInitiale - 6 || indexDestination == indexInitiale + 6
                || indexDestination == indexInitiale - 10 || indexDestination == indexInitiale + 10
                || indexDestination == indexInitiale - 15 || indexDestination == indexInitiale + 15
                || indexDestination == indexInitiale - 17 || indexDestination == indexInitiale + 17)
            {
                return Mouvement.peutBougerAvecCollision;
            }
            else
            {
                return Mouvement.peutPasBouger;
            }
        }
    }
}