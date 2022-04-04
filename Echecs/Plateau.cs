using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echecs
{
    class Plateau
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
        public Tuple<bool, string> verifTrajectoire(int indexInitial, int indexDestination)
        {
            Tuple<bool, string> message = new Tuple<bool, string>(false, "test");


            return message;

        }

    }
}
