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
    }
}
