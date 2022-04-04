using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Roi: Piece
    {
        public Roi(Couleur _couleur) : base(_couleur)
        {
            if(_couleur == Couleur.Blanc)
            {
                _nom = 'K';
            }
            else
            {
                _nom = 'k';
            }
            
        }

        public override string ToString()
        {
            return _nom.ToString();
        }
    }
}