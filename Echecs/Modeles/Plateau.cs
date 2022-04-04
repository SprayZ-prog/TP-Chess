using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    public class Plateau
    {
        private List<Case> _echiquier;
        private Partie _partie;

        public Plateau(Partie partie)
        {
            _partie = partie;
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
