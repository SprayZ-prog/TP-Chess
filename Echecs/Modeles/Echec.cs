using System;
using System.Collections.Generic;
using System.IO;
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
            read();
            Application.Run(_formMenu);
        }
        public void ouvrirClassement()
        {
            _formClassement = new FormClassement(this);
            _formClassement.Show();
        }
        public void nouvellePartie()
        {
            _unePartie = new Partie(this);
            _formPartie = new FormPartie(this);
            _formPartie.Show();
        }

        public Tuple<bool, string, int, int> jouerCoup(int x1, int y1, int x2, int y2)
        {
            Tuple<int, int> indexMovement = _unePartie.determinerCase(x1, y1, x2, y2);
            Tuple<bool, string> test = _unePartie.verifDeplacement(indexMovement.Item1, indexMovement.Item2);
            Tuple<bool, string, int, int> test2 = new Tuple<bool, string, int, int>(test.Item1, test.Item2, indexMovement.Item1, indexMovement.Item2);
            if (test.Item1)
            {
                _unePartie.faireDeplacement(indexMovement.Item1, indexMovement.Item2);
                return test2;
            }
            else
            {
                return test2;
            }
            
        }
        public void ajouterJoueur(string nom, int gagné, int perdu, int nulle)
        {
            _listeJoueur.Add(new Joueur(nom, gagné, perdu, nulle));
        }
        public void nettoyerJoueur()
        {
            _listeJoueur.Clear();
        }
        public List<Joueur> ListeJoueur
        {
            get { return _listeJoueur; }
        }

        public string afficherEchiquier()
        {
            return _unePartie.afficher();
        }
        public void fermerJeu()
        {
            save();
        }

        public void read()
        {
            string file = @"../../test.txt";

            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    string[] infos = line.Split('/');

                    ajouterJoueur(infos[0], Int32.Parse(infos[1]), Int32.Parse(infos[2]), Int32.Parse(infos[3]));

                }

            }

        }
        public void save()
        {
            string file = @"../../test.txt";

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            using (StreamWriter sw = new StreamWriter(file))
            {

                foreach (Joueur joueur in ListeJoueur)
                {
                    sw.WriteLine(joueur.ToString());

                }
                sw.Close();
            }

        }
        public void enleverJoueur(int index)
        {
            _listeJoueur.RemoveAt(index);
        }


    }
}
