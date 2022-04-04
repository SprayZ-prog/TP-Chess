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
        int _indexInitial;
        int _indexDestination;
        int _nbCoup;
        int _coupDepuisPionBougé;
        Joueur _joueur1;
        Joueur _joueur2;
        string _echiquierActuelle;
        List<string> _listeEchiquier;
    }
}
