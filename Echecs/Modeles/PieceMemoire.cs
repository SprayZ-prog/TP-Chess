using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public abstract class PieceMemoire : Piece
    {
        protected bool _aBougé;
        public PieceMemoire(Couleur couleur) : base(couleur)
        {
            _aBougé = false;
        }

    }
}
