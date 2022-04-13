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
        /// </summary>
        public void ouvrirClassement()
        {
            _formClassement = new FormClassement(this);
            _formClassement.Show();
        }
        /// <summary>
        /// Ouvre l formulaire de sélection de joueurs pour la nouvelle partie
        /// </summary>
        public void nouvellePartie()
        {
            
            _formSelection = new FormSelection(this);
            _formSelection.Show();
        }
        /// <summary>
        /// Commence la nouvelle partie et active et garde en mémoire les joueurs qui vont s'affronter
        /// </summary>
        /// <param name="joueur1">Le nom du joueur 1</param>
        /// <param name="joueur2">Le nom du joueur 2</param>
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
        /// <summary>
        /// Vérifie si le coup est valide et fait si possible le déplacement ainsi que la promotion s'il y a lieu
        /// </summary>
        /// <param name="monForm">Formulaire de la partie où se déroule le coup</param>
        /// <param name="x1">Coordonnées en X sur l'échiquier où se trouve la pièce qui fera le mouvement</param>
        /// <param name="y1">Coordonnées en Y sur l'échiquier où se trouve la pièce qui fera le mouvement</param>
        /// <param name="x2">Coordonnées en X sur l'échiquier où se trouve la case destination de la pièce</param>
        /// <param name="y2">Coordonnées en Y sur l'échiquier où se trouve la case destination de la pièce</param>
        /// <returns>Retourne vrai et un entier représentant que le coup est valide si le coup est valide</returns>
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
        /// <summary>
        /// Change le pion qui est promu par la pièce que le joueur aura sélectionné.
        /// </summary>
        /// <param name="piece">La pièce que que deviendra le pion</param>
        /// <param name="indexPion">L'index où se trouve le pion promu</param>
        public void changerPion(char piece, int indexPion)
        {
            _unePartie.changerPion(piece, indexPion);
            _formPromotion.Close();
            string echiquier = afficherEchiquier();
            _formPartie.peinturerEchiquier(echiquier);
        }
        /// <summary>
        /// Abandon de la partie
        /// </summary>
        /// <param name="monForm">Formulaire de la partie où se trouve l'abandon</param>
        public void victoire_Abandon(FormPartie monForm)
        {
            int indexOfForm = _listeFormPartie.IndexOf(monForm);
            _unePartie = _listePartie[indexOfForm];
            _unePartie.victoire_Abandon();
        }
        /// <summary>
        /// Partie nulle
        /// </summary>
        /// <param name="monForm">Formulaire de la partie où se trouv la partie</param>
        public void uneNulle(FormPartie monForm)
        {
            int indexOfForm = _listeFormPartie.IndexOf(monForm);
            _unePartie = _listePartie[indexOfForm];
            _unePartie.uneNulle();
        }

        /// <summary>
        /// Indique le tour du joueur dans la bonne partie
        /// </summary>
        /// 
        /// <param name="monForm">Formulaire de la partie</param>
        /// <returns>Retourne le tour du joueur</returns>
        public int tour(FormPartie monForm)
        {
            int indexOfForm = _listeFormPartie.IndexOf(monForm);
            _unePartie = _listePartie[indexOfForm];
            return _unePartie.tour();
        }
        /// <summary>
        /// Ajoute unn nouveau joueur dans la liste des joueurs du classement
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="gagné">Le nombre de parties gagnées du le joueur</param>
        /// <param name="perdu">Le nombre de parties perdues du le joueur</param>
        /// <param name="nulle">Le nombre de parties nulles du joueur</param>
        public void ajouterJoueur(string nom, int gagné, int perdu, int nulle)
        {
            _listeJoueur.Add(new Joueur(nom, gagné, perdu, nulle));
        }
        /// <summary>
        /// Vide la liste des joueurs
        /// </summary>
        public void nettoyerJoueur()
        {
            _listeJoueur.Clear();
        }
        /// <summary>
        /// Retourne la liste de joueurs du jeu
        /// </summary>
        public List<Joueur> ListeJoueur
        {
            get { return _listeJoueur; }
        }
        /// <summary>
        /// Affiche l'échiquier avec la position de chaque pièce
        /// </summary>
        /// <returns></returns>
        public string afficherEchiquier()
        {
            return _unePartie.afficher();
        }
        /// <summary>
        /// Ferme le jeu d'échec et sauvegarde
        /// </summary>
        public void fermerJeu()
        {
            save();
        }
        /// <summary>
        /// Ferme le jeu d'échec
        /// </summary>
        public void quitter()
        {
            fermerJeu();
            System.Windows.Forms.Application.Exit();
        }
        /// <summary>
        /// Ajoute tous les joueurs du fichier sauvegardé dans la liste des joueurs
        /// </summary>
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
        /// <summary>
        /// Sauvegarde tous les joueurs dans un fichier
        /// </summary>
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
        /// <summary>
        /// Enlève le joueur sélectionné de la liste des joueurs
        /// </summary>
        /// <param name="index">Index où se trouve le joueur</param>
        public void enleverJoueur(int index)
        {
            _listeJoueur.RemoveAt(index);
        }


    }
}
