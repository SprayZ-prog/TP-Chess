using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Pion : Piece
    {
        public Pion(Couleur _couleur) : base(_couleur)
        {
            if(_couleur == Couleur.Blanc)
            {
                _nom = 'P';
            }
            else
            {
                _nom = 'p';
            }
            
        }

        public override string ToString()
        {
            return _nom.ToString();
        }
        public override Tuple<Mouvement, string> regles(int indexInitiale, int indexDestination)
        {
           if (_nom == 'P')
           {
                if (indexDestination == indexInitiale - 8)
                {
                    return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le coup est correcte");
                }
                else if ((indexDestination == indexInitiale - 9 || indexDestination == indexInitiale - 7))
                {
                    return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le coup est correcte");
                }
                
           }
           else
           {
                if (indexDestination == indexInitiale + 8)
                {
                    return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le coup est correcte");
                }
                else if ((indexDestination == indexInitiale + 9 || indexDestination == indexInitiale + 7))
                {
                    return new Tuple<Mouvement, string>(Mouvement.peutBougerSansCollision, "Le coup est correcte");
                }
           }
            return new Tuple<Mouvement, string>(Mouvement.peutPasBouger, "Le coup est incorrecte");
        }
    }
}
