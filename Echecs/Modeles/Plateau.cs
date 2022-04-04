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

            for (int i = 0; i < 63; i++)
            {
                if (tabEchiquier[i] != '0')
                {
                    _echiquier[i] = new Case(tabEchiquier[i], this);
                    Console.WriteLine(_echiquier[i].Piece.ToString());
                    
                }
                else
                {
                    _echiquier[i] = new Case(true, this);
                    Console.WriteLine("0");
                }
                    
            }
            
        }
        

        public string afficher()
        {
            string echiquierActuel = "";
            for (int i = 0; i < 63; i++)
            {
                if (_echiquier[i].EstVide != true)
                {
                    echiquierActuel += _echiquier[i].Piece.ToString();
                }
                else
                {
                    echiquierActuel += "0";
                }

            }
            return echiquierActuel;
        }


        public Tuple<bool, string> verifierSiPiece(int indexInitial)
        {


            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
        public Tuple<bool, string> maPiece(int indexInitial, int indexDestination)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
        public Tuple< Mouvement, List<Case> > verifTrajectoire(int indexInitial, int indexDestination)
        {
            Tuple<Mouvement, List<Case>> message = new Tuple<Mouvement, List<Case>>(Mouvement.peutPasBouger, new List<Case>());


            return message;

        }
        public Tuple<bool, string> estCollision(int indexInitial, int indexDestination)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
        public Tuple<bool, string> verifCouleurDesti(int indexDestination)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }
        public Tuple<bool, string> metEnEchecAllie(int indexInitial, int indexDestination)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

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
