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

        public override string ToString()
        {
            return _nom.ToString();
        }
        public override Tuple<Mouvement, string> regles(int indexInitiale, int indexDestination)
        {
            int x1 = indexInitiale % 8;
            int y1 = indexInitiale / 8;
            int x2 = indexDestination % 8;
            int y2 = indexDestination / 8;

            if ((y2 - y1) / (x2 - x1) == 1 || (y2 - y1) / (x2 - x1) == -1 
                || (indexInitiale - indexDestination) % 8 == 0 || (indexInitiale + indexDestination) % 8 == 0
                || indexInitiale / 8 == indexDestination / 8)
                {
                    return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le coup est correcte");
                }
                
            return new Tuple<Mouvement, string>(Mouvement.peutPasBouger, "Le coup est incorrecte");
        }
    }
}

