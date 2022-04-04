using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echecs
{
    public class Echec
    {
        FormMenu _formMenu;
        FormPartie _formPartie;
        FormClassement _formClassement;
        Partie _unePartie;
        List<Joueur> _listeJoueur;

        [STAThread]
        static void Main()
        {
            Echec echec = new Echec();
        }
        public Echec()
        {
            /*_formMenu = new FormMenu(this);
            Application.Run(_formMenu);*/
            _formPartie = new FormPartie(this);
            Application.Run(_formPartie);
        }
        public void ouvrirClassement()
        {
            _formClassement = new FormClassement();
            _formClassement.Show();
        }
        public void nouvellePartie()
        {
            _formPartie = new FormPartie(this);
            _formPartie.Show();
        }

        public Tuple<int, int> jouerCoup(int x1, int y1, int x2, int y2)
        {
            Tuple<int, int> indexMovement = _unePartie.determinerCase(x1, y1, x2, y2);
            _unePartie.verifDeplacement(indexMovement.Item1, indexMovement.Item2);

            return indexMovement;
        }


    }
}
