using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    /// <summary>
    /// La pièce du pion
    /// </summary>
    class Pion : PieceMemoire
    {

        /// <summary>
        /// Instancie le nom du pion
        /// </summary>
        /// <param name="_couleur">La couleur du pion</param>
        public Pion(Couleur _couleur) : base(_couleur)
        {

            if(_couleur == Couleur.Blanc)
            {
                _nom = 'P';
            }
            else
            {
                _nom = 'p';
            }
        }
        /// <summary>
        /// Vérifie si le pion peut être promu
        /// </summary>
        /// <returns>Retourne vrai s'il peut être promu</returns>
        public override bool peutEtrePromu()
        {
            return true;
        }

        /// <summary>
        /// Vérifie si le pion peut charger
        /// </summary>
        /// <returns>Retourne vrai s'il n'a toujours pas bougé pour le permettre de charger</returns>
        public override bool peutCharger()
        {
            return !_aBougé;
        }

        /// <summary>
        /// Fais en sorte que le pion ne puisse plus charger
        /// </summary>
        public override void nePeutPlusCharger()
        {
            ABougé = true;
        }

        /// <summary>
        /// Vérifie la validité du mouvement selon les règles du pion
        /// </summary>
        /// <param name="indexInitiale">L'index de la case initiale de la pièce</param>
        /// <param name="indexDestination">L'index de la case destination de la pièce</param>
        /// <returns>Retourne le type de mouvement de du pion</returns>
        public override Mouvement regles(int indexInitiale, int indexDestination)
        {
           if (_nom == 'P')
           {
                if (peutCharger() && (indexDestination == indexInitiale - 8 || indexDestination == indexInitiale - 16))
                {
                    return Mouvement.peutCharger;
                }
                else if (indexDestination == indexInitiale - 8)
                {
                    return Mouvement.peutBougerSansCollision;
                }
                
           }
           else
           {
                if (peutCharger() && (indexDestination == indexInitiale + 16 || indexDestination == indexInitiale + 8))
                {
                    return Mouvement.peutCharger;
                }
                else if (indexDestination == indexInitiale + 8)
                {
                    return Mouvement.peutBougerSansCollision;
                }
   
           }
            return Mouvement.peutPasBouger;
        }
    }
}
