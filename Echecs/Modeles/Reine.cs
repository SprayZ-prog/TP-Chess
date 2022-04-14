using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Reine : Piece
    {
        public Reine(Couleur _couleur) : base(_couleur)
        {
            if (_couleur == Couleur.Blanc)
            {
                _nom = 'R';
            }
            else
            {
                _nom = 'r';
            }

        }
        /// <summary>
        /// Vérifie la validité du mouvement selon les règles de la reine
        /// </summary>
        /// <param name="indexInitiale">L'index de la case initiale de la pièce</param>
        /// <param name="indexDestination">L'index de la case destination de la pièce</param>
        /// <returns>Retourne le type de mouvement de la reine</returns>
        public override Mouvement regles(int indexInitiale, int indexDestination)
        {
            int x1 = indexInitiale % 8;
            int y1 = indexInitiale / 8;
            int x2 = indexDestination % 8;
            int y2 = indexDestination / 8;

            if ((indexInitiale - indexDestination) % 8 == 0 || (indexInitiale + indexDestination) % 8 == 0
                || indexInitiale / 8 == indexDestination / 8 
                || (y2 - y1) / (x2 - x1) == 1 || (y2 - y1) / (x2 - x1) == -1)
                {
                    return Mouvement.peutBougerSansCollision;
                }
                
            return Mouvement.peutPasBouger;
        }
    }
}

