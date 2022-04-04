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
    }
}
