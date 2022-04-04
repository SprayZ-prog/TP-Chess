using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Pion : Piece
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
    }
}
