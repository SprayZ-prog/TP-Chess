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
        private bool _estVide;
        private Plateau _plateau;

        public Case(Piece piece, Plateau plateau) 
        {
            _piece = piece;
            _plateau = plateau;
            _estVide = false;
        }
        public Case(bool estVide, Plateau plateau)
        {
            this._estVide = estVide;    
            this._plateau = plateau;    
        }
        public Piece Piece 
        { 
            get { return _piece; }
            set { _piece = value; }
        }
        public bool EstVide
        {
            get { return _estVide; }
            set { _estVide = value; }
        }
        public Couleur couleurPiece()
        {
            return _piece.Couleur;
        }

       

    }
}
