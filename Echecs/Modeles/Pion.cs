using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Pion : PieceMemoire
    {
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

        public override string ToString()
        {
            return _nom.ToString();
        }
        public override bool peutEtrePromu()
        {
            return true;
        }
        public override bool peutCharger()
        {
            return !_aBougé;
        }
        public override void nePeutPlusCharger()
        {
            ABougé = true;
        }
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
