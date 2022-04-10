﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public class Partie
    {
        Echec _parent;
        Plateau _plateau;
        int _nbCoup;
        int _coupDepuisPionBougé;
        Joueur _joueur1;
        Joueur _joueur2;
        string _echiquierActuelle;
        List<string> _listeEchiquier;

        public Partie(Echec _monControlleur)
        {
            _parent = _monControlleur;
            _plateau = new Plateau(this);
        }


        public int tour()
        {
            return _nbCoup % 2;
        }


        public Tuple<int, int> determinerCase(int x1, int y1, int x2, int y2)
        {
            int indexInitial = (x1 / 62) + (y1 / 62) * 496 / 62;
            int indexDest = (x2 / 62) + (y2 / 62) * 496 / 62;
            Tuple<int, int> indexMovement = new Tuple<int, int>(indexInitial, indexDest);
            return indexMovement;
        }

        public Tuple<bool, int> verifDeplacement(int indexInitial, int indexDesti)
        {
            Tuple<bool, int> message;
            if (indexInitial == indexDesti)
            {
                message = new Tuple<bool, int>(false, 3);
            }
            else
            {
                message = _plateau.verifierSiPiece(indexInitial);
                if (message.Item1)
                {
                    message = _plateau.maPiece(indexInitial, _nbCoup);
                    if (message.Item1)
                    {
                        Mouvement mouvement = _plateau.verifTrajectoire(indexInitial, indexDesti);

                        switch (mouvement)
                        {
                            case Mouvement.peutPasBouger:

                                message = new Tuple<bool, int>(false, 4);
                                break;

                            case Mouvement.peutBougerSansCollision:
                                int deplacement = _plateau.deplacement(indexInitial, indexDesti);

                                message = _plateau.estCollision(indexInitial, indexDesti, deplacement);
                                Console.WriteLine(message.Item1);
                                if (message.Item1)
                                {
                                    message = _plateau.verifCouleurDesti(indexInitial, indexDesti);


                                }
                                break;

                            case Mouvement.peutBougerAvecCollision:


                                break;


                        }
                    }
                }
            }
            
            return message;
        }

        public void faireDeplacement(int indexInitial, int indexDesti)
        {
            _nbCoup++;
            _plateau.deplacer(indexInitial, indexDesti);
        }

        public string afficher()
        {
            return _plateau.afficher();
        }
    }
}
