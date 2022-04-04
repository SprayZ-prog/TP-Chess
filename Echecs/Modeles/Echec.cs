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
            _listeJoueur = new List<Joueur>();
            _formMenu = new FormMenu(this);
            Application.Run(_formMenu);
        }
        public void ouvrirClassement()
        {
            _formClassement = new FormClassement(this);
            _formClassement.Show();
        }
        public void nouvellePartie()
        {
            //_unePartie = new Partie(this);
            _formPartie = new FormPartie(this);
            _formPartie.Show();
        }

        public Tuple<int, int> jouerCoup(int x1, int y1, int x2, int y2)
        {
            Tuple<int, int> indexMovement = _unePartie.determinerCase(x1, y1, x2, y2);
            _unePartie.verifDeplacement(indexMovement.Item1, indexMovement.Item2);

            return indexMovement;
        }
        public void ajouterJoueur(string nom, int gagné, int perdu, int nulle)
        {
            _listeJoueur.Add(new Joueur(nom, gagné, perdu, nulle));
        }
        public List<Joueur> ListeJoueur
        {
            get { return _listeJoueur; }
        }


    }
}
