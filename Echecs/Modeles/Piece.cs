using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public class Piece
    {
        protected string _nom;
        protected Couleur _couleur;

        public Piece(string nom, Couleur couleur)
        {
            _nom = nom;
            _couleur = couleur; 
        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }   
        }
        public Couleur Couleur
        {
            get { return _couleur; }
            
        }
        public virtual Tuple<bool, string> regles(int indexInitiale, int indexDestination)
        {
            return new Tuple<bool, string>(false, "t beau babe");
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public virtual bool estEssentiel()
        {
            return true;
        }


    }
}
