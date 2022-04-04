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

    }
}
