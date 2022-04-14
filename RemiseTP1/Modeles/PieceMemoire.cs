using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    /// <summary>
    /// Pièce se souvenant qu'elle a bougé
    /// </summary>
    public abstract class PieceMemoire : Piece
    {
        protected bool _aBougé;

        /// <summary>
        /// Instancie la pièce avec sa couleur
        /// </summary>
        /// <param name="couleur">La couleur de la pièce</param>
        public PieceMemoire(Couleur couleur) : base(couleur)
        {
            _aBougé = false;
        }

        /// <summary>
        /// Gère la propriété qui montre si la pièce a déjà bougé
        /// </summary>
        public bool ABougé
        {
            get { return _aBougé; }
            set { _aBougé = value; }
        }


    }
}
