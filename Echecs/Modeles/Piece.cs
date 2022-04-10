using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public abstract class Piece
    {
        protected char _nom;
        protected Couleur _couleur;

        public Piece(Couleur couleur)
        {
            _couleur = couleur;    
        }

        public Couleur Couleur
        {
            get { return _couleur; }
            set { _couleur = Couleur; }
            
        }
        public virtual Tuple<Mouvement, string> regles(int indexInitiale, int indexDestination)
        {
            return new Tuple<Mouvement, string>(Mouvement.peutPasBouger, "t beau babe");
        }

        public virtual bool estEssentiel()
        {
            return false;
        }


    }
}
