using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public class PieceMemoire : Piece
    {
        public PieceMemoire(Couleur couleur) : base(couleur)
        {
            
        }
        public virtual bool aBougé()
        {
            return false;
        }

    }
}
