using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Cavalier : Piece
    {
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

        public override string ToString()
        {
            return _nom.ToString();
        }
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