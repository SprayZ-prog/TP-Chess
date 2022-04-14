using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Roi: PieceMemoire
    {
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


        public override bool peutRoquer()
        {
            return !_aBougé;
        }

        public override void vientDeBouger()
        {
            ABougé = true;
        }

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