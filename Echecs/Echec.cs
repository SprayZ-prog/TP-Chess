using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echecs
{
    public class Echec
    {
        FormMenu _leMenu;
        FormPartie _formPartie;
        FormClassement formClassement;
        Partie _unePartie;
        List<Joueur> _listeJoueur;

        [STAThread]
        static void Main()
        {
            Echec echec = new Echec();
        }
        public Echec()
        {
            /*_leMenu = new FormMenu(this);
            Application.Run(_leMenu);*/
            _formPartie = new FormPartie(this);
            Application.Run(_formPartie);
        }
        public void ouvrirClassement()
        {
            formClassement = new FormClassement();
            formClassement.Show();
        }

    }
}
