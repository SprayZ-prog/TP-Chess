using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Fou : Piece
    {
        public Fou(Couleur _couleur) : base(_couleur)
        {
            if (_couleur == Couleur.Blanc)
            {
                _nom = 'F';
            }
            else
            {
                _nom = 'f';
            }

        }

        public override string ToString()
        {
            return _nom.ToString();
        }
        public override Mouvement regles(int indexInitiale, int indexDestination)
        {

            if ((indexDestination - indexInitiale) % 7 == 0 || (indexDestination - indexInitiale) % 9 == 0)
            {
                return Mouvement.peutBougerSansCollision;
            }
            return Mouvement.peutPasBouger;
        }
    }
}