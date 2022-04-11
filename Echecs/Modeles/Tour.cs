using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Tour : PieceMemoire
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
        public override Mouvement regles(int indexInitiale, int indexDestination)
        {
            if ((indexInitiale - indexDestination) % 8 == 0 || (indexInitiale + indexDestination) % 8 == 0 || indexInitiale / 8 == indexDestination / 8)
            {
                return Mouvement.peutBougerSansCollision;
            }
            return Mouvement.peutPasBouger;
        }
    }
}
