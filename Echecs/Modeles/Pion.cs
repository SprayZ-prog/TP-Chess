﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Pion : Piece
    {
        bool aBougé;
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
        public override Mouvement regles(int indexInitiale, int indexDestination)
        {
           if (_nom == 'P')
           {
                if (indexDestination == indexInitiale - 8 || indexDestination == indexInitiale - 9 || indexDestination == indexInitiale - 7)
                {
                    return Mouvement.peutBougerSansCollision;
                }
                
           }
           else
           {
                if (indexDestination == indexInitiale + 8 || (indexDestination == indexInitiale + 9 || indexDestination == indexInitiale + 7))
                {
                    return Mouvement.peutBougerSansCollision;
                }
   
           }
            return Mouvement.peutPasBouger;
        }
    }
}
