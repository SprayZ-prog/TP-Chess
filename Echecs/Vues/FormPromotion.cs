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
    public partial class FormPromotion : Form
    {
        Echec _controlleur;
        int _indexPion;

        public FormPromotion(Echec leControlleur, int index)
        {
            InitializeComponent();
            _controlleur = leControlleur;
            _indexPion = index;
        }
        /// <summary>
        /// Dessine l'image de la reine dans le formulaire
        /// </summary>
        private void pnl1_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraph = pnl1.CreateGraphics();
            
            if (_controlleur.tour(this) != 0)
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

            if (_controlleur.tour(this) != 0)
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

            if (_controlleur.tour(this) != 0)
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

            if (_controlleur.tour(this) != 0)
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
            if (_controlleur.tour(this) != 0)
            {
                _controlleur.changerPion('R', _indexPion);
            }
            else
            {
                _controlleur.changerPion('r', _indexPion);
            }
        }
        /// <summary>
        /// Événement du clic sur le fou, ce qui promouvoit le pion en fou
        /// </summary>
        private void pnl2_Click(object sender, EventArgs e)
        {
            if (_controlleur.tour(this) != 0)
            {
                _controlleur.changerPion('F', _indexPion);
            }
            else
            {
                _controlleur.changerPion('f', _indexPion);
            }
        }
        /// <summary>
        /// Événement du clic sur le cavalier, ce qui promouvoit le pion en cavalier
        /// </summary>
        private void pnl3_Click(object sender, EventArgs e)
        {
            if (_controlleur.tour(this) != 0)
            {
                _controlleur.changerPion('C', _indexPion);
            }
            else
            {
                _controlleur.changerPion('c', _indexPion);
            }
        }
        /// <summary>
        /// Événement du clic sur la tour, ce qui promouvoit le pion en tour
        /// </summary>
        private void pnl4_Click(object sender, EventArgs e)
        {
            if (_controlleur.tour(this) != 0)
            {
                _controlleur.changerPion('T', _indexPion);
            }
            else
            {
                _controlleur.changerPion('t', _indexPion);
            }
        }
    }
}
