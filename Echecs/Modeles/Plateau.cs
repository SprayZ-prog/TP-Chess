using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public class Plateau
    {
        private Case[] _echiquier;
        private Partie _partie;

        /*string _board =
              "t00fkt00" +
              "pp00cpp0" +
              "000pp00p" +
              "00p00000" +
              "00000000" +
              "0RC00r00" +
              "fP0PPPPc" +
              "T0F0KFCT"; */

        string _board =
              "tcfrkfct" +
              "pppppppp" +
              "00000000" +
              "00000000" +
              "00000000" +
              "00000000" +
              "PPPPPPP0" +
              "TCFRKFCT"; 


        /*string _board =
              "t000k00t" +
              "pcfrpfcp" +
              "00000000" +
              "00000000" +
              "00000000" +
              "00000000" +
              "PCFRPFCP" +
              "T000K00T";*/

       /* string _board =
              "tcfrkfc0" +
              "pppppppP" +
              "00000000" +
              "00000000" +
              "00000000" +
              "00000000" +
              "PPPPPPPp" +
              "TCFRKFC0"; */

        public Plateau(Partie partie)
        {
            _partie = partie;
            _echiquier = new Case[64];
            char[] tabEchiquier = null;

            if (tabEchiquier == null)
            {
                tabEchiquier = _board.ToCharArray();
            }

            for (int i = 0; i < 64; i++)
            {
                if (tabEchiquier[i] != '0')
                {
                    _echiquier[i] = new Case(tabEchiquier[i], this);

                }
                else
                {
                    _echiquier[i] = new Case(true, this);

                }

            }

        }
        /// <summary>
        /// Retourne l'échiquier
        /// </summary>
        public Case[] Echiquier
        {
            get { return _echiquier; }
        }
        /// <summary>
        /// Exécute le coup du joueur en mettant la case initiale sur la case destination, puis rend la case initiale à vide.
        /// </summary>
        /// <param name="indexInitial">L'index de la case initiale du coup</param>
        /// <param name="indexDesti">L'index de la destination du coup</param>
        public void deplacer(int indexInitial, int indexDesti)
        {
            _echiquier[indexDesti] = _echiquier[indexInitial];
            _echiquier[indexInitial] = new Case(true, this);
        }
        /// <summary>
        /// Affiche la chaine de caractère de l'échiquier
        /// </summary>
        /// <returns>Retourne la chaine de caractères de l'échiquier avec les bonnes positions de pièces</returns>
        public string afficher()
        {
            string echiquierActuel = "";
            for (int i = 0; i < 64; i++)
            {
                if (_echiquier[i].EstVide)
                {
                    echiquierActuel += "0";
                }
                else
                {   
                    echiquierActuel += _echiquier[i].Piece.ToString();
                }

            }
            return echiquierActuel;
        }

        /// <summary>
        /// Vérifie si le joueur a cliqué sur une case non vide
        /// </summary>
        /// <param name="indexInitial"></param>
        /// <returns></returns>
        public Tuple<bool, int> verifierSiPiece(int indexInitial)
        {
            Tuple<bool, int> message;
            if (_echiquier[indexInitial].EstVide)
            {
                message = new Tuple<bool, int>(false, 0);
            }
            else
            {
                message = new Tuple<bool, int>(true, 1);
            }


            return message;

        }
        /// <summary>
        /// Vérifie si la case initiale a bel et bien un des pièces du joueur
        /// </summary>
        /// <param name="indexInitial">L'index de la case initiale</param>
        /// <returns>Retourne vrai si la pièce sélectionné est une pièce du joueur devant jouer.</returns>
        public Tuple<bool, int> maPiece(int indexInitial)
        {
            Tuple<bool, int> message;
            if ((_partie.tour() == 0 && _echiquier[indexInitial].couleurPiece() == Couleur.Blanc) || (_partie.tour() == 1 && _echiquier[indexInitial].couleurPiece() == Couleur.Noir))
            {
                message = new Tuple<bool, int>(true, 0);
            }
            else
            {
                message = new Tuple<bool, int>(false, 2);
            }

            return message;

        }
        /// <summary>
        /// Vérifie la trajectoire de la pièce par rapport aux règles de cette dernière.
        /// </summary>
        /// <param name="indexInitial">L'index initial de la pièce</param>
        /// <param name="indexDestination">L'index de la destination de la pièce</param>
        /// <returns>Retourne le tye de mouvement de la pièce</returns>
        public Mouvement verifTrajectoire(int indexInitial, int indexDestination)
        {
            if (_echiquier[indexInitial].peutEtrePromu())
            {
                if (_partie.tour() == 0 && !_echiquier[indexDestination].EstVide && (indexDestination == indexInitial - 7 || indexDestination == indexInitial - 9))
                {
                    return Mouvement.peutBougerAvecCollision;
                }
                else if (_partie.tour() == 1 && !_echiquier[indexDestination].EstVide && (indexDestination == indexInitial + 7 || indexDestination == indexInitial + 9))
                {
                    return Mouvement.peutBougerAvecCollision;
                }
                
            }

            Mouvement roque = verifRoque(indexInitial, indexDestination);
            if (roque == Mouvement.peutGrandRoque || roque == Mouvement.peutPetitRoque)
            {
                return roque;
            }
            else
            {
                return _echiquier[indexInitial].regles(indexInitial, indexDestination);
            }
           
            

        }

        /// <summary>
        /// Vérifie si le joueur a enclenché un roque et vérifie s'il peut le faire
        /// </summary>
        /// <param name="indexInitial">L'index de la case initial</param>
        /// <param name="indexDestination">L'index de la case destination</param>
        /// <returns>Retourne le mouvement du roque s'il le fait</returns>
        public Mouvement verifRoque(int indexInitial, int indexDestination)
        {
            if (_partie.tour() != 0 && indexInitial > 0 && indexInitial < 7 && _echiquier[indexInitial].peutRoquer())
            {
                if (indexDestination == indexInitial - 2 && estCollision(indexInitial, indexDestination, deplacement(indexInitial, indexDestination), _echiquier).Item1 && _echiquier[indexDestination].EstVide)
                {
                    if (_echiquier[0].peutRoquer())
                    {
                        _echiquier[indexInitial].vientDeBouger();
                        _echiquier[0].vientDeBouger();
                        return Mouvement.peutGrandRoque;
                    }
                }
                if (indexDestination == indexInitial + 2 && estCollision(indexInitial, indexDestination, deplacement(indexInitial, indexDestination), _echiquier).Item1 && _echiquier[indexDestination].EstVide)
                {
                    if (_echiquier[7].peutRoquer())
                    {
                        _echiquier[indexInitial].vientDeBouger();
                        _echiquier[7].vientDeBouger();
                        return Mouvement.peutPetitRoque;
                    }
                }
                return Mouvement.peutPasBouger;
            }
            else if (_partie.tour() == 0 && indexInitial > 56 && indexInitial < 63 && _echiquier[indexInitial].peutRoquer())
            {
                if (indexDestination == indexInitial - 2 && estCollision(indexInitial, indexDestination, deplacement(indexInitial, indexDestination), _echiquier).Item1 && _echiquier[indexDestination].EstVide)
                {
                    if (_echiquier[56].peutRoquer())
                    {
                        _echiquier[indexInitial].vientDeBouger();
                        _echiquier[56].vientDeBouger();
                        return Mouvement.peutGrandRoque;
                    }
                }
                if (indexDestination == indexInitial + 2 && estCollision(indexInitial, indexDestination, deplacement(indexInitial, indexDestination), _echiquier).Item1 && _echiquier[indexDestination].EstVide)
                {
                    if (_echiquier[63].peutRoquer())
                    {
                        _echiquier[indexInitial].vientDeBouger();
                        _echiquier[63].vientDeBouger();
                        return Mouvement.peutPetitRoque;
                    }
                }
                return Mouvement.peutPasBouger;
            }
            return Mouvement.peutPasBouger;

        }
        /// <summary>
        /// Vérifie le déplacement que la pièce fera sur chaque pièce
        /// </summary>
        /// <param name="indexInitial">L'index de la case initiale</param>
        /// <param name="indexDesti">L'index de la case destination</param>
        /// <returns>Retourne le nombre de bons de case pour faire chaque mouvement de case en case</returns>
        public int deplacement(int indexInitial, int indexDesti)
        {

            if (indexInitial / 8 == indexDesti / 8)
            {
                if (indexDesti - indexInitial < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if ((indexInitial - indexDesti) % 8 == 0)
            {
                if (indexDesti - indexInitial < 0) {
                    return -8;
                }
                else
                {
                    return 8;
                }
            }
            else if ((indexDesti - indexInitial) % 7 == 0)
            {
                if (indexDesti < indexInitial)
                {
                    return -7;
                }
                else
                {
                    return 7;
                }
            }
            else if ((indexDesti - indexInitial) % 9 == 0)
            {
                if (indexDesti < indexInitial)
                {
                    return -9;
                }
                else
                {
                    return 9;
                }
            }
            return 1;
        }
        /// <summary>
        /// Vérifie s'il y a une collision durant le trajet de la pièce
        /// </summary>
        /// <param name="indexInitial">L'index de la case initiale de la pièce</param>
        /// <param name="indexDestination">L'index de la case destination de la pièce</param>
        /// <param name="deplacement">Le déplacement sur chaque case de la pièce</param>
        /// <param name="echiquier">L'échiquier où le mouvement sera testé</param>
        /// <returns>Retourne vrai avec 0 s'il n'y a pas de collision dans le trajet</returns>
        public Tuple<bool, int> estCollision(int indexInitial, int indexDestination, int deplacement, Case[] echiquier)
        {
            int indexChemin = indexInitial;
            indexChemin += deplacement;
            while (indexChemin != indexDestination)
            {

                if (!echiquier[indexChemin].EstVide)
                {
                    return new Tuple<bool, int>(false, 5);
                }
                indexChemin += deplacement;
            }


            return new Tuple<bool, int>(true, 0);

        }
        /// <summary>
        /// Vérifie la couleur de la pièce de la case destination pour s'assurer que ce n'est pas une pièce allié
        /// </summary>
        /// <param name="indexInitial">L'index de la case initiale de la pièce</param>
        /// <param name="indexDestination">L'index de la case destination de la pièce</param>
        /// <returns>Retourne vrai avec zéro si la couleur de la pièce qui se trouve sur la destination est alliée</returns>
        public Tuple<bool, int> verifCouleurDesti(int indexInitial, int indexDestination)
        {

            if (!_echiquier[indexDestination].EstVide)
            {
                if (_echiquier[indexInitial].couleurPiece() == _echiquier[indexDestination].couleurPiece())
                {
                    return new Tuple<bool, int>(false, 6);
                }
            }


            return new Tuple<bool, int>(true, 0);

        }
        /// <summary>
        /// Vérifie si le coup met en échec le roi allié
        /// </summary>
        /// <param name="indexInitial">L'index de la case initiale de la pièce</param>
        /// <param name="indexDesti">L'index de la case destination de la pièce</param>
        /// <param name="nbCoup">Le nombre de coup joué durant la partie</param>
        /// <returns>Retourne vrai avec le message 0 pour confirmer que le coup ne met pas en échec le roi allié.</returns>
        public Tuple<bool, int> metEnEchecAllie(int indexInitial, int indexDesti, int nbCoup)
        {
            Case[] echiquierTest = (Case[])_echiquier.Clone();

            echiquierTest[indexDesti] = echiquierTest[indexInitial];
            echiquierTest[indexInitial] = new Case(true, this);

            int indexDestination = 0;
            for (int i = 0; i < echiquierTest.Length; i++)
            {
                if (!echiquierTest[i].EstVide)
                {

                    if ((_partie.tour() == 0 && echiquierTest[i].ToString() == "K")
                    || (_partie.tour() == 1 && echiquierTest[i].ToString() == "k"))
                    {

                        indexDestination = i;
                        break;
                    }
                }

            }
            for (int i = 0; i < echiquierTest.Length; i++)
            {
                if (!echiquierTest[i].EstVide)
                {

                    if (_partie.tour() == 0 && echiquierTest[i].couleurPiece() == Couleur.Noir)
                    {
                        Mouvement mouvement = verifTrajectoire(i, indexDestination);

                        switch (mouvement)
                        {

                            case Mouvement.peutBougerSansCollision:

                                int deplacement = this.deplacement(i, indexDestination);

                                Tuple<bool, int> message = this.estCollision(i, indexDestination, deplacement, echiquierTest);
                                if (message.Item1)
                                {
                                    return new Tuple<bool, int>(false, 7);

                                }
                                break;
                            case Mouvement.peutBougerAvecCollision:

                                return new Tuple<bool, int>(false, 7);

                        }
                    }
                    else if (_partie.tour() == 1 && echiquierTest[i].couleurPiece() == Couleur.Blanc)
                    {
                        Mouvement mouvement = verifTrajectoire(i, indexDestination);

                        switch (mouvement)
                        {


                            case Mouvement.peutBougerSansCollision:

                                int deplacement = this.deplacement(i, indexDestination);

                                Tuple<bool, int> message = this.estCollision(i, indexDestination, deplacement, echiquierTest);
                                if (message.Item1)
                                {
                                    return new Tuple<bool, int>(false, 7);

                                }
                                break;

                          
                            case Mouvement.peutBougerAvecCollision:

                                return new Tuple<bool, int>(false, 7);


                        }
                    }
                }


            }
            return new Tuple<bool, int>(true, 0);
        }
        /// <summary>
        /// Enlève le droit à la pièce de pouvoir charger
        /// </summary>
        /// <param name="index">Index où se trouve la pièce</param>
        public void nePeutPlusCharger(int index)
        {
            _echiquier[index].nePeutPlusCharger();
        }
        /// <summary>
        /// Vérifie si une promotion de pion doit avoir lieu
        /// </summary>
        /// <param name="indexDestination">Index de la destination de la pièce</param>
        /// <returns>Retourne vrai si une promotion doit avoir lieu</returns>
        public bool verifPromoPion(int indexDestination)
        {
            if (_echiquier[indexDestination].peutEtrePromu())
            {
                return _echiquier[indexDestination].couleurPiece() == Couleur.Blanc && indexDestination < 8 || _echiquier[indexDestination].couleurPiece() == Couleur.Noir && indexDestination > 55;
            }
            else
                return false;

        }
        /// <summary>
        /// Change le pion en la nouvelle pièce qu'il deviendra
        /// </summary>
        /// <param name="piece">La pièce que le pion deviendra</param>
        /// <param name="indexPion">L'index où se trouve la case du pion</param>
        public void changerPion(char piece, int indexPion)
        {
            _echiquier[indexPion] = new Case(piece, this);
        }

        /// <summary>
        /// Vérifie si le coup met en échec le roi ennemi
        /// </summary>
        /// <param name="indexRoi">L'index de la case où se trouve le roi</param>
        /// <param name="couleur">La couleur des pièces du joueur allié</param>
        /// <returns>Retourne vrai, 0 ainsi que l'index de la pièce qui met en échec l'ennemi</returns>
        public Tuple<bool, int, int> verifEchec(int indexRoi, Couleur couleur)
        {

            for (int i = 0; i < _echiquier.Length; i++)
            {
                if (!_echiquier[i].EstVide)
                {

                    if (_echiquier[i].couleurPiece() == couleur)
                    {
                        Mouvement mouvement = verifTrajectoire(i, indexRoi);

                        switch (mouvement) {

                            case Mouvement.peutBougerSansCollision:

                                int deplacement = this.deplacement(i, indexRoi);

                                Tuple<bool, int> message = this.estCollision(i, indexRoi, deplacement, _echiquier);
                                if (message.Item1)
                                {
                                    return new Tuple<bool, int, int>(true, 8, i);

                                }
                                break;
                            case Mouvement.peutBougerAvecCollision:

                                return new Tuple<bool, int, int>(true, 8, i);

                        }
                    }
                }

            }
            return new Tuple<bool, int, int>(true, 0, 0);

        }
        /// <summary>
        /// Trouve le roi ennemi
        /// </summary>
        /// <returns>Retourne l'index du roi et sa couleur</returns>
        public Tuple<int, Couleur> trouverRoiEnnemi()
        {
            int indexRoi = 0;
            Couleur couleur = Couleur.Blanc;
            for (int i = 0; i < 64; i++)
            {
                if (!_echiquier[i].EstVide)
                {

                    if (_partie.tour() == 0 && _echiquier[i].ToString() == "K") {
                        indexRoi = i;
                        couleur = Couleur.Noir;
                        break;
                    }
                    else if (_partie.tour() == 1 && _echiquier[i].ToString() == "k") {


                        indexRoi = i;
                        couleur = Couleur.Blanc;
                        break;
                    }
                }
           

            }
            return new Tuple<int, Couleur>(indexRoi, couleur);
        }
        /// <summary>
        /// Vérifie s'il y a un échec et mat
        /// </summary>
        /// <param name="indexRoi">Index de la case du roi</param>
        /// <param name="indexAttaquant">Index de l'attaquant</param>
        /// <returns>Retourne vrai et 9 s'il y a un échec et mat</returns>
        public Tuple<bool, int> verifEchecMat(int indexRoi, int indexAttaquant)
        {
            if (!peutBougerRoi(indexRoi))
            {
                int deplacement1 = deplacement(indexAttaquant, indexRoi);
                int indexChemin = indexAttaquant;
                while (indexChemin != indexRoi)
                {
                    for (int i = 0; i < _echiquier.Length; i++)
                    {






                        if (!_echiquier[i].EstVide)
                        {

                            if (_echiquier[i].couleurPiece() == _echiquier[indexRoi].couleurPiece())
                            {
                                if (_partie.verifDeplacement(i, indexChemin).Item1)
                                {
                                    return new Tuple<bool, int>(true, 8);
                                }

                            }
                        }

                    }
                    indexChemin += deplacement1;
                }
                return new Tuple<bool, int>(true, 9);

            }


            return new Tuple<bool, int>(true, 8);

        }
        public Tuple<bool, string> verifPat(int nbCoup)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
        public bool peutBougerRoi(int indexRoi)
        {
            
            if ((indexRoi + 1) % 8 != 0 && _partie.verifDeplacement(indexRoi, indexRoi + 1).Item1
                || (indexRoi - 1) % 8 != 7 && _partie.verifDeplacement(indexRoi, indexRoi - 1).Item1)
            {
                return true;
            }
            else if (indexRoi - 7 > 0 && _partie.verifDeplacement(indexRoi, indexRoi - 7).Item1
                || indexRoi - 8 > 0 && _partie.verifDeplacement(indexRoi, indexRoi - 8).Item1
                || indexRoi - 9 > 0 && _partie.verifDeplacement(indexRoi, indexRoi - 9).Item1)
            {
                return true;
            }
            else if (indexRoi + 7 < 64 && (indexRoi + 7) % 8 != 7 && _partie.verifDeplacement(indexRoi, indexRoi + 7).Item1
                || indexRoi + 8 < 64 && _partie.verifDeplacement(indexRoi, indexRoi + 8).Item1
                || indexRoi + 9 < 64 && (indexRoi + 9) % 8 != 0 && _partie.verifDeplacement(indexRoi, indexRoi + 9).Item1
                || _echiquier[indexRoi].Piece.peutRoquer())
            {
                return true;
            }
            return false;  
        }
    }
}
