using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public class Case
    {
        private Piece _piece;
        private Plateau _plateau;

        public Case(Piece piece, Plateau plateau) 
        {
            _piece = piece;
            _plateau = plateau; 
        }
        public Piece Piece 
        { 
            get { return _piece; }
            set { _piece = value; }
        }

    }
}
