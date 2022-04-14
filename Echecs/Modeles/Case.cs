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
        Couleur _couleur;
        /// <summary>
        /// Créer la pièce sur la case selon son identifiant
        /// </summary>
        /// <param name="piece">L'identifiant de la pièce, soit son premier caractère</param>
        /// <param name="plateau">Le plateau où se tro-</param>
        public Case(char piece, Plateau plateau) 
        {
            _plateau = plateau;
            _estVide = false;

            switch (piece)
            {
                case 'P':
                    _piece = new Pion(Couleur.Blanc);
                    break;
                case 'p':
                    _piece = new Pion(Couleur.Noir);
                    break;
                case 'T':
                    _piece = new Tour(Couleur.Blanc);
                    break;
                case 't':
                    _piece = new Tour(Couleur.Noir);
                    break;
                case 'C':
                    _piece = new Cavalier(Couleur.Blanc);
                    break;
                case 'c':
                    _piece = new Cavalier(Couleur.Noir);
                    break;
                case 'F':
                    _piece = new Fou(Couleur.Blanc);
                    break;
                case 'f':
                    _piece = new Fou(Couleur.Noir);
                    break;
                case 'R':
                    _piece = new Reine(Couleur.Blanc);
                    break;
                case 'r':
                    _piece = new Reine(Couleur.Noir);
                    break;
                case 'K':
                    _piece = new Roi(Couleur.Blanc);
                    break;
                case 'k':
                    _piece = new Roi(Couleur.Noir);
                    break;
            }
        }
        public Case(bool estVide, Plateau plateau)
        {
            _estVide = estVide;    
            _plateau = plateau;    
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

        public Couleur setcouleurPiece()
        {

            return _piece.Couleur;
        }
        public Mouvement regles(int indexInitiale, int indexDesti)


        {
            return _piece.regles(indexInitiale, indexDesti);
        }
        

        public override string ToString()
        {
            return _piece.ToString();

        }

        public bool peutEtrePromu()
        {
            return _piece.peutEtrePromu();
        }

        public bool peutRoquer()
        {
            return _piece.peutRoquer();
        }

        public void nePeutPlusCharger() 
        {
            _piece.nePeutPlusCharger();
        }

        public void vientDeBouger()
        {
            _piece.vientDeBouger();
        }

    }
}
