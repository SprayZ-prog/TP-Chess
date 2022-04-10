using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Roi: Piece
    {
        public Roi(Couleur _couleur) : base(_couleur)
        {
            if(_couleur == Couleur.Blanc)
            {
                _nom = 'K';
            }
            else
            {
                _nom = 'k';
            }
            
        }

        public override string ToString()
        {
            return _nom.ToString();
        }
        public override Tuple<Mouvement, string> regles(int indexInitiale, int indexDestination)
        {
            if (indexDestination == indexInitiale + 1 || indexDestination == indexInitiale - 1
                || indexDestination == indexInitiale - 8 || indexDestination == indexInitiale + 8
                || indexDestination == indexInitiale - 9 || indexDestination == indexInitiale - 7
                || indexDestination == indexInitiale + 9 || indexDestination == indexInitiale + 7)
            {
                return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le mouvement est correct");
            }
            return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le mouvement est incorrect");
        }
    }
}