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
        int i = 0;
        Point clickInitial;
        Point clickDest;

        public FormPartie(Echec leControlleur)
        {
            InitializeComponent();
            this._controlleur = leControlleur;
        }

        private void btnAbandon_Click(object sender, EventArgs e)
        {
            string message = "Voulez-vous vraiment abandonner?";
            string title = "Abandonner";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                //Appeler methode fin de partie avec qui a abandonner
            }
        }

        private void btnNulle_Click(object sender, EventArgs e)
        {
            string message = "Acceptez-vous une partie nulle?";
            string title = "Partie nulle";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
                //Appeler methode fin de partie avec qui a abandonner
            }
        }

        private void pnlEchiquier_Paint(object sender, PaintEventArgs e)
        {
            if (_controlleur.tour() == 0)
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


        private void pnlEchiquier_Click(object sender, EventArgs e)
        {

            Point point1 = pnlEchiquier.PointToClient(Cursor.Position);

            if (i % 2 == 0)
            {
                clickInitial = point1;
            }
            else
            {
                clickDest = point1;
                Tuple<bool, int> mouvement = _controlleur.jouerCoup(clickInitial.X, clickInitial.Y, clickDest.X, clickDest.Y);

                switch (mouvement.Item2)
                {
                    case 0:
                        if(_controlleur.tour() == 0){
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


                }
                if (mouvement.Item1)
                {
                    string echiquier = _controlleur.afficherEchiquier();
                    peinturerEchiquier(echiquier);
                }
            }
            i++;



            /*Point clickInitial;
            Point clickDest;
            Point point1 = pnlEchiquier.PointToClient(Cursor.Position);


            int indexDest = -1;
            if (i % 2 == 0)
            {
                clickInitial = point1;
                indexInitial = (clickInitial.X / 62) + (clickInitial.Y / 62) * 496 / 62;
                Console.WriteLine(indexInitial);
            }
            else
            {
                clickDest = point1;
                indexDest = (clickDest.X / 62) + (clickDest.Y / 62) * 496 / 62;
                Console.WriteLine(indexDest);
            }
            i++;

            if (indexDest >= 0)
            {
                _controlleur.verifDeplacement(indexInitial, indexDest);
                modifEchiquier(indexInitial, indexDest);
                //Console.WriteLine(indexInitial + ", " + indexDest);
            }*/




        }

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

    }
}

