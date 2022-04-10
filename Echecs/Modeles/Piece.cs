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
        protected bool _aBouge;

        public Piece(Couleur couleur)
        {
            _aBouge = false;
            _couleur = couleur;    
        }

        public Couleur Couleur
        {
            get { return _couleur; }
            set { _couleur = Couleur; }
            
        }
        public bool Abouge
        {
            get { return _aBouge; }
            set { _aBouge = value; }
        }
        public virtual Mouvement regles(int indexInitiale, int indexDestination)
        {
            return Mouvement.peutPasBouger;
        }
        
        public virtual bool estEssentiel()
        {
            return false;
        }


    }
}
