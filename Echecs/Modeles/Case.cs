using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    /// <summary>
    /// Case du plateau du jeu pouvant détenir une pièce.
    /// </summary>
    public class Case
    {
        private Piece _piece;
        private bool _estVide;

        /// <summary>
        /// Créer la pièce sur la case selon son identifiant
        /// </summary>
        /// <param name="piece">L'identifiant de la pièce, soit son premier caractère</param>
        /// <param name="plateau">Le plateau où se trouve la case</param>
        public Case(char piece, Plateau plateau) 
        {
           
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

        /// <summary>
        /// Instancie une case vide
        /// </summary>
        /// <param name="estVide">La confirmation que la case devra être vide</param>
        public Case(bool estVide)
        {
            _estVide = estVide;    
        }

        /// <summary>
        /// Retourne la donnée membre pièce sur la case
        /// </summary>
        public Piece Piece 
        { 
            get { return _piece; }
            set { _piece = value; }
        }

        /// <summary>
        /// Retourne vrai si la case est vide
        /// </summary>
        public bool EstVide
        {
            get { return _estVide; }
            set { _estVide = value; }
        }

        /// <summary>
        /// La couleur de la pièce sur la case
        /// </summary>
        /// <returns>Retourne la couleur blanc ou noir</returns>
        public Couleur couleurPiece()
        {
            return _piece.Couleur;
        }

        /// <summary>
        /// Vérifie si les règles de la pièce sont respectés durant le coup
        /// </summary>
        /// <param name="indexInitiale">La case initiale de la pièce</param>
        /// <param name="indexDesti">La case destination de la pièce</param>
        /// <returns>Retourne le type de mouvement de la pièce selon ses règles</returns>
        public Mouvement regles(int indexInitiale, int indexDesti)
        {
            return _piece.regles(indexInitiale, indexDesti);
        }
        
        /// <summary>
        /// Renvoie le charactère représentant la pièce sur la case
        /// </summary>
        /// <returns>Le caractère de la pièce</returns>
        public override string ToString()
        {
            return _piece.ToString();

        }

        /// <summary>
        /// Vérifie si la pièce peut être promu
        /// </summary>
        /// <returns> Retourne vrai si la pièce peut être promu</returns>
        public bool peutEtrePromu()
        {
            return _piece.peutEtrePromu();
        }

        /// <summary>
        /// Vérifie si la pièce peut roquer
        /// </summary>
        /// <returns>Retourne vrai si la pièce sur la case peut roquer</returns>
        public bool peutRoquer()
        {
            return _piece.peutRoquer();
        }

        /// <summary>
        /// Fais en sorte que la pièce ne puisse plus charger
        /// </summary>
        public void nePeutPlusCharger() 
        {
            _piece.nePeutPlusCharger();
        }

        /// <summary>
        /// Dit à la pièce qu'elle a bougé
        /// </summary>
        public void vientDeBouger()
        {
            _piece.vientDeBouger();
        }

    }
}
