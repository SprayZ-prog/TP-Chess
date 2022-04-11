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
        protected bool _peutEtrePromu;

        public Piece(Couleur couleur)
        {
            _aBouge = false;
            _couleur = couleur;
            _peutEtrePromu = false;
        }

        public Couleur Couleur
        {
            get { return _couleur; }
            set { _couleur = Couleur; }
            
        }
        public bool PeutEtrePromu
        {
            get { return _peutEtrePromu; }
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
