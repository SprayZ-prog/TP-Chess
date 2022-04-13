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
        FormSelection _formSelection;
        FormClassement _formClassement;
        FormPromotion _formPromotion;
        Partie _unePartie;
        List<Joueur> _listeJoueur;
        List<Partie> _listePartie;
        List<FormPartie> _listeFormPartie;

        [STAThread]
        static void Main()
        {
            Echec echec = new Echec();
        }
        public Echec()
        {
            _listeJoueur = new List<Joueur>();
            _listePartie = new List<Partie>();
            _listeFormPartie = new List<FormPartie>();
            _formMenu = new FormMenu(this);
            read();
            Application.Run(_formMenu);
        }
        /// <summary>
        /// Ouvre le formulaire du classement
        /// 
        /// </summary>
        public void ouvrirClassement()
        {
            _formClassement = new FormClassement(this);
            _formClassement.Show();
        }
        public void nouvellePartie()
        {
            
            _formSelection = new FormSelection(this);
            _formSelection.Show();
        }

        public void commencerPartie(string joueur1, string joueur2)
        {
            Joueur j1 = null;
            Joueur j2 = null;
            for (int i = 0; i < _listeJoueur.Count; i++)
            {
                if (this._listeJoueur[i].Nom.Equals(joueur1))
                {
                    j1 = this._listeJoueur[i];
                }
                else if (this._listeJoueur[i].Nom.Equals(joueur2))
                {
                    j2 = this._listeJoueur[i];
                }
                
            }
            

            _formSelection.Close();

            _listePartie.Add(new Partie(this, j1, j2));
            _formPartie = new FormPartie(this);
            _listeFormPartie.Add(_formPartie);
            _formPartie.Show();
        }

        public Tuple<bool, int> jouerCoup(FormPartie monForm, int x1, int y1, int x2, int y2)
        {
            int indexOfForm = _listeFormPartie.IndexOf(monForm);
            _unePartie = _listePartie[indexOfForm];
            Tuple<int, int> indexMovement = _unePartie.determinerCase(x1, y1, x2, y2);
            Tuple<bool, int> message = _unePartie.verifDeplacement(indexMovement.Item1, indexMovement.Item2);

            if (message.Item1)
            {
                if(message.Item2 != 12)
                {
                    bool promotion = _unePartie.faireDeplacement(indexMovement.Item1, indexMovement.Item2);

                    if (promotion)
                    {
                        _formPromotion = new FormPromotion(this, indexMovement.Item2);
                        _formPromotion.Show();
                    }
                }
                
                message = _unePartie.verifEchec();
               
                
            }
            return message;
            
        }

        public void changerPion(char piece, int indexPion)
        {
            _unePartie.changerPion(piece, indexPion);
            _formPromotion.Close();
            string echiquier = afficherEchiquier();
            _formPartie.peinturerEchiquier(echiquier);
        }

        public void victoire_Abandon(FormPartie monForm)
        {
            int indexOfForm = _listeFormPartie.IndexOf(monForm);
            _unePartie = _listePartie[indexOfForm];
            _unePartie.victoire_Abandon();
        }

        public void uneNulle(FormPartie monForm)
        {
            int indexOfForm = _listeFormPartie.IndexOf(monForm);
            _unePartie = _listePartie[indexOfForm];
            _unePartie.uneNulle();
        }


        public int tour(FormPartie monForm)
        {
            int indexOfForm = _listeFormPartie.IndexOf(monForm);
            _unePartie = _listePartie[indexOfForm];
            return _unePartie.tour();
        }
        public int tour(FormPromotion monForm)
        {
            return _unePartie.tour();
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
