using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echecs
{
	
    /// <summary>
    /// Le formulaire qui s’affiche lors d’une promotion d’un pion. Affiche un choix de pièce qui pourra remplacer le pion
    /// </summary>
    public partial class FormPromotion : Form
    {
        Echec _controlleur;
        int _indexPion;
        int _indexPartie;

        /// <summary>
        /// Initialise le formulaire de promotion et instancie le controlleur Echec
        /// </summary>
        /// <param name="leControlleur">Le contrôleur Echec</param>
        public FormPromotion(Echec leControlleur, int index, int indexPartie)
        {
            InitializeComponent();
            _controlleur = leControlleur;
            _indexPion = index;
            _indexPartie = indexPartie;
        }

        /// <summary>
        /// Dessine l'image de la reine dans le formulaire
        /// </summary>
        private void pnl1_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraph = pnl1.CreateGraphics();
            
            if (_controlleur.tour(_indexPartie) != 0)
            {
                myGraph.DrawImage(Properties.Resources.queenWhite, 0, 0);
            }
            else
            {
                myGraph.DrawImage(Properties.Resources.queenBlack, 0, 0);
            }
        }

        /// <summary>
        /// Dessine l'image du fou dans le formulaire
        /// </summary>
        private void pnl2_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraph = pnl2.CreateGraphics();

            if (_controlleur.tour(_indexPartie) != 0)
            {
                myGraph.DrawImage(Properties.Resources.bishopWhite, 0, 0);
            }
            else
            {
                myGraph.DrawImage(Properties.Resources.bishopBlack, 0, 0);
            }
        }

        /// <summary>
        /// Dessine l'image du cavalier dans le formulaire
        /// </summary>
        private void pnl3_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraph = pnl3.CreateGraphics();

            if (_controlleur.tour(_indexPartie) != 0)
            {
                myGraph.DrawImage(Properties.Resources.knightWhite, 0, 0);
            }
            else
            {
                myGraph.DrawImage(Properties.Resources.knightBlack, 0, 0);
            }
        }

        /// <summary>
        /// Dessine l'image de la tour dans le formulaire
        /// </summary>
        private void pnl4_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraph = pnl4.CreateGraphics();

            if (_controlleur.tour(_indexPartie) != 0)
            {
                myGraph.DrawImage(Properties.Resources.rookWhite, 0, 0);
            }
            else
            {
                myGraph.DrawImage(Properties.Resources.rookBlack, 0, 0);
            }
        }

        /// <summary>
        /// Événement du clic sur la reine, ce qui promouvoit le pion en reine
        /// </summary>
        private void pnl1_Click(object sender, EventArgs e)
        {
            if (_controlleur.tour(_indexPartie) != 0)
            {
                _controlleur.changerPion('R', _indexPion, _indexPartie);
            }
            else
            {
                _controlleur.changerPion('r', _indexPion, _indexPartie);
            }
        }
		
        /// <summary>
        /// Événement du clic sur le fou, ce qui promouvoit le pion en fou
        /// </summary>
        private void pnl2_Click(object sender, EventArgs e)
        {
            if (_controlleur.tour(_indexPartie) != 0)
            {
                _controlleur.changerPion('F', _indexPion, _indexPartie);
            }
            else
            {
                _controlleur.changerPion('f', _indexPion, _indexPartie);
            }
        }

        /// <summary>
        /// Événement du clic sur le cavalier, ce qui promouvoit le pion en cavalier
        /// </summary>
        private void pnl3_Click(object sender, EventArgs e)
        {
            if (_controlleur.tour(_indexPartie) != 0)
            {
                _controlleur.changerPion('C', _indexPion, _indexPartie);
            }
            else
            {
                _controlleur.changerPion('c', _indexPion, _indexPartie);
            }
        }

        /// <summary>
        /// Événement du clic sur la tour, ce qui promouvoit le pion en tour
        /// </summary>
        private void pnl4_Click(object sender, EventArgs e)
        {
            if (_controlleur.tour(_indexPartie) != 0)
            {
                _controlleur.changerPion('T', _indexPion, _indexPartie);
            }
            else
            {
                _controlleur.changerPion('t', _indexPion, _indexPartie);
            }
        }
    }
}
