using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    /// <summary>
    /// Partie d’échec ayant les informations de la partie.
    /// </summary>
    public class Partie
    {
        Echec _controlleur;
        Plateau _plateau;
        int _nbCoup;
        int _coupDepuisPionBougé;
        Joueur _joueur1;
        Joueur _joueur2;
        List<string> _listeEchiquier;

        /// <summary>
        /// Instancie le contrôleur Echec et les joueurs dans la partie
        /// </summary>
        /// <param name="_monControlleur">Le contrôleur Echec</param>
        /// <param name="joueur1">Le joueur 1, qui joue les blancs</param>
        /// <param name="joueur2">Le joueur 2, qui joue les noirs</param>
        public Partie(Echec _monControlleur, Joueur joueur1, Joueur joueur2)
        {
            _controlleur = _monControlleur;
            _joueur1 = joueur1;
            _joueur2 = joueur2;
            _plateau = new Plateau(this);
        }
		
        /// <summary>
        /// Met à jour les statistiques des joueurs après l'abandon
        /// </summary>
        public void victoire_Abandon()
        {
            if (tour() == 0)
            {
                _joueur1.ajoutDefaite();
                _joueur2.ajoutVictoire();
            }
            else
            {
                _joueur1.ajoutVictoire();
                _joueur2.ajoutDefaite();
            }
            Console.WriteLine(_joueur1.ToString());
            Console.WriteLine(_joueur2.ToString());
        }
		
        /// <summary>
        /// Met à jour les statistiques des joueurs après la partie nulle
        /// </summary>
        public void uneNulle()
        {
            _joueur1.ajoutNulle();
            _joueur2.ajoutNulle();
            Console.WriteLine(_joueur1.ToString());
            Console.WriteLine(_joueur2.ToString());
        }

        /// <summary>
        /// Tour d'un joueur
        /// </summary>
        /// <returns>Retourne le tour du bon joueur</returns>
        public int tour()
        {
            return _nbCoup % 2;
        }

        /// <summary>
        /// Détermine l'index de la case initiale et de la case de destination du coup
        /// </summary>
        /// <param name="x1">Coordonnée en X de la case initiale</param>
        /// <param name="y1">Coordonnée en Y de la case initiale</param>
        /// <param name="x2">Coordonnée en X de la case destination</param>
        /// <param name="y2">Coordonnée en Y de la case destination</param>
        /// <returns>Retourne les index de la case initiale et destination</returns>
        public Tuple<int, int> determinerCase(int x1, int y1, int x2, int y2)
        {
            int indexInitial = (x1 / 62) + (y1 / 62) * 496 / 62;
            int indexDest = (x2 / 62) + (y2 / 62) * 496 / 62;
            Tuple<int, int> indexMovement = new Tuple<int, int>(indexInitial, indexDest);
            return indexMovement;
        }
		
        /// <summary>
        /// Vérifie la validité du déplacement du joueur
        /// </summary>
        /// <param name="indexInitial">L'index de la case initiale du coup</param>
        /// <param name="indexDesti">L'index de la case destination du coup</param>
        /// <returns>Retourne vrai sans entier d'erreur si le coup est valide</returns>
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
                    message = _plateau.maPiece(indexInitial);
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
								
                                if (message.Item1)
                                {
                                    message = _plateau.verifCouleurDesti(indexInitial, indexDesti);

                                    if (message.Item1)
                                    {
                                        message = _plateau.metEnEchecAllie(indexInitial, indexDesti, _nbCoup);
                                    }
                                }
                                break;
                            case Mouvement.peutCharger:
                                if (_plateau.Echiquier[indexDesti].EstVide)
                                {
                                    int deplacementCharge = _plateau.deplacement(indexInitial, indexDesti);
                                    Tuple<bool, int> message1 = _plateau.estCollision(indexInitial, indexDesti, deplacementCharge);
									
                                    if (message1.Item1)
                                    {
                                        message = _plateau.verifCouleurDesti(indexInitial, indexDesti);

                                        if (message.Item1)
                                        {
                                            message = _plateau.metEnEchecAllie(indexInitial, indexDesti, _nbCoup);
                                        }
                                    }
                                }
                                else
                                {
                                    message = new Tuple<bool, int>(false, 4);
                                }
                                break;
								
                            case Mouvement.peutBougerAvecCollision:

                                message = _plateau.verifCouleurDesti(indexInitial, indexDesti);

                                if (message.Item1)
                                {
                                    message = _plateau.metEnEchecAllie(indexInitial, indexDesti, _nbCoup);
                                }
                                break;
								
                            case Mouvement.peutGrandRoque:
                                if (tour() == 0)
                                {
                                    message = _plateau.metEnEchecAllie(indexInitial, indexDesti, _nbCoup);
                                    if (message.Item1)
                                    {
                                        _plateau.deplacer(indexInitial, indexDesti);
                                        _plateau.deplacer(56, 59);
                                        _nbCoup++;
                                        message = new Tuple<bool, int>(true, 12);
                                    }
                                }
                                else
                                {
                                    _plateau.deplacer(indexInitial, indexDesti);
                                    _plateau.deplacer(0,3);
                                    _nbCoup++;
                                    message = new Tuple<bool, int>(true, 12);
                                }
                                break;
                            case Mouvement.peutPetitRoque:
                                if (tour() == 0)
                                {
                                    _plateau.deplacer(indexInitial, indexDesti);
                                    _plateau.deplacer(63, 61);
                                    _nbCoup++;
                                    message = new Tuple<bool, int>(true, 12);
                                }
                                else
                                {
                                    message = _plateau.metEnEchecAllie(indexInitial, indexDesti, _nbCoup);
                                    if (message.Item1)
                                    {
                                        _plateau.deplacer(indexInitial, indexDesti);
                                        _plateau.deplacer(7, 5);
                                        _nbCoup++;
                                        message = new Tuple<bool, int>(true, 12);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            return message;
        }
		
        /// <summary>
        /// Fais le coup demandé
        /// </summary>
        /// <param name="indexInitial">L'index de la case initiale du coup</param>
        /// <param name="indexDesti">L'index de la case destination du coup</param>
        /// <returns>Retourne vrai si une promotion de pion doit avoir lieu</returns>
        public bool faireDeplacement(int indexInitial, int indexDesti)
        {
            _plateau.nePeutPlusCharger(indexInitial);
            _plateau.deplacer(indexInitial, indexDesti);
            _nbCoup++;

            return _plateau.verifPromoPion(indexDesti);
        }
		
        /// <summary>
        /// Promouvoit le pion en la pièce que le joueur a sélectionné
        /// </summary>
        /// <param name="piece">La pièce que le pion deviendra</param>
        /// <param name="indexPion">L'index de l'emplacement du pion</param>
        public void changerPion(char piece, int indexPion)
        {
            _plateau.changerPion(piece, indexPion);
        }

        /// <summary>
        /// Vérifie si un échec ou un échec et mat a lieu
        /// </summary>
        /// <returns>Retourne vrai avec 0 s'il n'y a pas d'échec ni d'échec et mat</returns>
        public Tuple<bool, int> verifEchec()
        {
            Tuple<int, Couleur> roi = _plateau.trouverRoiEnnemi();
            Tuple<bool, int, int> verifEchec = _plateau.verifEchec(roi.Item1, roi.Item2); 

            if (verifEchec.Item2 == 8)
            {
                return _plateau.verifEchecMat(roi.Item1, verifEchec.Item3);
            }
            return new Tuple<bool, int>(true, 0);
        }
		
        /// <summary>
        /// Affiche la chaine de caractère de l'échiquier avec les caractères des pièces aux bons endroits
        /// </summary>
        /// <returns>Retourne la chaine de caractères de l'échiquier</returns>
        public string afficher()
        {
            return _plateau.afficher();
        }
    }
}
