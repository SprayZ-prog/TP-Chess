using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Echecs
{
    public partial class FormPartie : Form
    {
        Echec _controlleur;
        int clique1 = 0;
        Point clickInitial;
        Point clickDest;

        public FormPartie(Echec leControlleur)
        {
            InitializeComponent();
            _controlleur = leControlleur;
        }

        /// <summary>
        /// Événement du clique du bouton « abandonner » pour terminer la partie
        /// </summary>
        private void btnAbandon_Click(object sender, EventArgs e)
        {
            finPartie(1);
        }

        /// <summary>
        /// Événement du clique du bouton « Nulle » pour terminer la partie
        /// </summary>
        private void btnNulle_Click(object sender, EventArgs e)
        {
            finPartie(2);
        }

        /// <summary>
        /// Affiche l'échiquier et les messages pour rappeler à qui est le tour
        /// </summary>
        private void pnlEchiquier_Paint(object sender, PaintEventArgs e)
        {
            if (_controlleur.tour(this) == 0)
            {
                labMessage.Text = "Tour des blancs";
            }
            else
            {
                labMessage.Text = "Tour des noirs";
            }
            string echiquier = _controlleur.afficherEchiquier();
            peinturerEchiquier(echiquier);
        }

        /// <summary>
        /// Évenement des cliques sur l'échiquier. Joue le coup et affiche les messages si possible.
        /// </summary>
        private void pnlEchiquier_Click(object sender, EventArgs e)
        {

            Point point1 = pnlEchiquier.PointToClient(Cursor.Position);

            if (clique1 % 2 == 0)
            {
                clickInitial = point1;
            }
            else
            {
                clickDest = point1;
                Tuple<bool, int> mouvement = _controlleur.jouerCoup(this, clickInitial.X, clickInitial.Y, clickDest.X, clickDest.Y);

                if (mouvement.Item1)
                {
                    string echiquier = _controlleur.afficherEchiquier();
                    peinturerEchiquier(echiquier);
                }

                int tour = _controlleur.tour(this);

                switch (mouvement.Item2)
                {
                    case 0:
                        if(tour == 0){
                            labMessage.Text = "Tour des blancs";
                        }
                        else
                        {
                            labMessage.Text = "Tour des noirs";
                        }
                        break;
                    case 1:

                        labMessage.Text = "Invalide: Sélectionner une pièce";
                        break;

                    case 2:

                        labMessage.Text = "Invalide: Mauvaise couleur de pièce";
                        break;

                    case 3:

                        labMessage.Text = "Invalide: Sélection de la même case 2 fois";
                        break;
                    case 4:

                        labMessage.Text = "Invalide: Cette pièce ne peut pas faire ce mouvement";
                        break;

                    case 5:

                        labMessage.Text = "Invalide: Une pièce est dans la trajectoire";
                        break;

                    case 6:

                        labMessage.Text = "Invalide: Vous ne pouvez pas attaquer votre propre pièce";
                        break;

                    case 7:
                        labMessage.Text = "Invalide: Vous mettez votre roi en échec";
                        break;
                    case 8:
                        if (tour == 0)
                        {
                            labMessage.Text = "Échec des blancs";
                        }
                        else
                        {
                            labMessage.Text = "Échec des noirs";
                        }
                        break;
                    case 9:
                        if (tour == 0)
                        {
                            labMessage.Text = "Échec et mat des blancs";
                        }
                        else
                        {
                            labMessage.Text = "Échec et mat des noirs";
                        }
                        finPartie(mouvement.Item2);
                        break;
                    case 10:
                        labMessage.Text = "Partie nulle";
                        finPartie(mouvement.Item2);
                        break;
                }    
            }
            clique1++;

        }
        /// <summary>
        /// Affiche les pièces sur l'échiquier sur leurs bons emplacements
        /// </summary>
        /// <param name="echiquier">La chaine de caractères ayant la position de chacune des pièces</param>
        public void peinturerEchiquier(string echiquier)
        {

            char[] tabEchiquier = null;

            if (tabEchiquier == null)
            {
                tabEchiquier = echiquier.ToCharArray();
            }

            Bitmap imgPiece = null;
            Graphics myGraph = pnlEchiquier.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Chocolate);
            myGraph.DrawImage(Properties.Resources.board2, 0, 0);


            // Dessine les pièces...
            for (int c = 0; c < 8; c++)
                for (int r = 0; r < 8; r++)
                {
                    if (true)
                    {
                        //Thread.Sleep(100);
                        switch (tabEchiquier[c * 8 + r])
                        {
                            case 'P':
                                imgPiece = new Bitmap(Properties.Resources.pawnWhite);
                                break;
                            case 'p':
                                imgPiece = new Bitmap(Properties.Resources.pawnBlack);
                                break;
                            case 'T':
                                imgPiece = new Bitmap(Properties.Resources.rookWhite);
                                break;
                            case 't':
                                imgPiece = new Bitmap(Properties.Resources.rookBlack);
                                break;
                            case 'C':
                                imgPiece = new Bitmap(Properties.Resources.knightWhite);
                                break;
                            case 'c':
                                imgPiece = new Bitmap(Properties.Resources.knightBlack);
                                break;
                            case 'F':
                                imgPiece = new Bitmap(Properties.Resources.bishopWhite);
                                break;
                            case 'f':
                                imgPiece = new Bitmap(Properties.Resources.bishopBlack);
                                break;
                            case 'R':
                                imgPiece = new Bitmap(Properties.Resources.queenWhite);
                                break;
                            case 'r':
                                imgPiece = new Bitmap(Properties.Resources.queenBlack);
                                break;
                            case 'K':
                                imgPiece = new Bitmap(Properties.Resources.kingWhite);
                                break;
                            case 'k':
                                imgPiece = new Bitmap(Properties.Resources.kingBlack);
                                break;
                            case '0':
                                imgPiece = null;
                                break;
                        }
                        if (imgPiece != null)
                        {
                            imgPiece.MakeTransparent(imgPiece.GetPixel(1, 1));
                            myGraph.DrawImage(imgPiece, r * 62, c * 62);
                        }
                    }
                }
        }

        /// <summary>
        /// Termine la partie
        /// </summary>
        /// <param name="raison">La raison de la fin de la partie</param>
        public void finPartie(int raison)
        {
            string message = "";
            string title = "";
            MessageBoxButtons buttons;
            DialogResult result;
            buttons = MessageBoxButtons.YesNo;
            switch (raison)
            {
                case 1:
                    message = "Voulez-vous vraiment abandonner?";
                    title = "Abandonner";
                    result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        _controlleur.victoire_Abandon(this);
                        this.Close();
                    }

                    break;
                case 2:
                    message = "Acceptez-vous une partie nulle?";
                    title = "Partie nulle";
                    result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        _controlleur.uneNulle(this);
                        this.Close();
                    }
                    break;
                case 9:
                    if (_controlleur.tour(this) == 0)
                        message = "Victoire des noirs!!!";
                    else
                        message = "Victoire des blancs!!!";

                    title = "Victoire";
                    result = MessageBox.Show(message, title, buttons);
                    _controlleur.victoire_Abandon(this);
                    
                    
                    this.Close();
                    
                    break;
                case 10:
                    message = "C'est une partie nulle!";
                    title = "Partie nulle!!";
                    result = MessageBox.Show(message, title, buttons);
                    _controlleur.uneNulle(this);
                    
                    this.Close();
                    
                    break;
            }
        }

    }
}

