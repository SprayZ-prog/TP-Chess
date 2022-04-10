using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Tour : Piece
    {
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

        public override string ToString()
        {
            return _nom.ToString();
        }
        public override Tuple<Mouvement, string> regles(int indexInitiale, int indexDestination)
        {
            if ((indexInitiale - indexDestination) % 8 == 0 || (indexInitiale + indexDestination) % 8 == 0)
            {
                return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le coup est correcte");
            }
            else if (indexInitiale / 8 == indexDestination / 8)
            {
                return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le coup est correcte");
            }
            return new Tuple<Mouvement, string>(Mouvement.peutPasBouger, "Le coup est incorrecte");
        }
    }
}
