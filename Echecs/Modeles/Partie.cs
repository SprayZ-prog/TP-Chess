using System;
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


        public Tuple<int, int> determinerCase(int x1, int y1, int x2, int y2)
        {
            int indexInitial = (x1 / 62) + (y1 / 62) * 496 / 62;
            int indexDest = (x2 / 62) + (y2 / 62) * 496 / 62;
            Tuple<int, int> indexMovement = new Tuple<int, int>(indexInitial, indexDest);

            return indexMovement;
        }

        public Tuple<bool, string> verifDeplacement(int indexInitial, int indexDesti)
        {
            return _plateau.verifierSiPiece(indexInitial);
        }
    }
}
