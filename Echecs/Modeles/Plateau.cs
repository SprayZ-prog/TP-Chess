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

        string _board =
              "tcfrkfct" +
              "pppppppp" +
              "00000000" +
              "00000000" +
              "00000000" +
              "00000000" +
              "PPPPPPPP" +
              "TCFRKFCT";



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
        public Case[] Echiquier
        {
            get { return _echiquier; }
        }
        public void deplacer(int indexInitial, int indexDesti)
        {
            _echiquier[indexInitial].aBougé();   
            _echiquier[indexDesti] = _echiquier[indexInitial];
            _echiquier[indexInitial] = new Case(true, this);
        }

        public string afficher()
        {
            string echiquierActuel = "";
            for (int i = 0; i < 64; i++)
            {
                if (!_echiquier[i].EstVide)
                {
                    echiquierActuel += _echiquier[i].Piece.ToString();
                }
                else
                {
                    echiquierActuel += "0";
                }

            }
            Console.WriteLine(echiquierActuel);
            return echiquierActuel;
        }


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

        public Tuple<bool, int> maPiece(int indexInitial, int nbCoup)
        {
            Tuple<bool, int> message;
            if ((nbCoup % 2 == 0 && _echiquier[indexInitial].Piece.Couleur == Couleur.Blanc) || (nbCoup % 2 == 1 && _echiquier[indexInitial].Piece.Couleur == Couleur.Noir))
            {
                message = new Tuple<bool, int>(true, 0);
            }
            else
            {
                message = new Tuple<bool, int>(false, 2);
            }

            return message;

        }
        public Mouvement verifTrajectoire(int indexInitial, int indexDestination)
        {

            return _echiquier[indexInitial].regles(indexInitial, indexDestination);

        }
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
                    
                    if ((nbCoup % 2 == 0 && echiquierTest[i].ToString() == "K")
                    || (nbCoup % 2 == 1 && echiquierTest[i].ToString() == "k"))
                    {
                        
                        indexDestination = i;
                        break;
                    }
                }
                
            }
            for (int i = 0; i < 64; i++)
            {
                if (!echiquierTest[i].EstVide)
                {

                    if (nbCoup % 2 == 0 && echiquierTest[i].couleurPiece() == Couleur.Noir)
                    {
                        Mouvement mouvement = verifTrajectoire(i, indexDestination);

                        switch (mouvement)
                        {
                            case Mouvement.peutPasBouger:


                                break;

                            case Mouvement.peutBougerSansCollision:

                                int deplacement = this.deplacement(i, indexDestination);
                                if (echiquierTest[i].estPion())
                                {
                                    if (!(indexDestination == i + 7 || indexDestination == i + 9))
                                    {
                                        return new Tuple<bool, int>(false, 7);
                                    }
                                }
                                

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
                    else if (nbCoup % 2 == 1 && echiquierTest[i].couleurPiece() == Couleur.Blanc)
                    {
                        Mouvement mouvement = verifTrajectoire(i, indexDestination);

                        switch (mouvement)
                        {
                            case Mouvement.peutPasBouger:


                                break;

                            case Mouvement.peutBougerSansCollision:

                                int deplacement = this.deplacement(i, indexDestination);
                                if (echiquierTest[i].estPion())
                                {
                                    if (!(indexDestination == i - 7 || indexDestination == i - 9))
                                    {
                                        return new Tuple<bool, int>(false, 7);
                                    }
                                }


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
        public Tuple<bool, string> verifPromoPion(int indexDestination)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
        public Tuple<bool, string> verifEchec(int indexInitial, int indexDestination, int nbCoup)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
        public Tuple<bool, string> verifEchecMat()
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
        public Tuple<bool, string> verifPat(int nbCoup)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
    }
}
