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
        string _board =
              "tcfrkfct" +
              "pppppppp" +
              "00000000" +
              "00000000" +
              "00000000" +
              "00000000" +
              "PPPPPPPP" +
              "TCFRKFCT";

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
                Tuple<bool, string> movement = _controlleur.jouerCoup(clickInitial.X, clickInitial.Y, clickDest.X, clickDest.Y);
                if (movement.Item1)
                {
                    string echiquier = _controlleur.afficherEchiquier();
                    peinturerEchiquier(echiquier);

                    labMessage.Text = "";
                }
                else
                {
                    labMessage.Text = movement.Item2;
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

