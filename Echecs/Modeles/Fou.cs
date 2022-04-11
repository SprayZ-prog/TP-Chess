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

            int x1 = indexInitiale % 8;
            int y1 = indexInitiale / 8;
            int x2 = indexDestination % 8;
            int y2 = indexDestination / 8;

            if ((y2 - y1) / (x2 - x1) == 1 || (y2 - y1) / (x2 - x1) == -1)
            {
                return Mouvement.peutBougerSansCollision;
            }
            return Mouvement.peutPasBouger;
        }
    }
}