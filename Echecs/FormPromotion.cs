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

        public FormPromotion(Echec leControlleur)
        {
            InitializeComponent();
            _controlleur = leControlleur;
        }

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

        private void pnl1_Click(object sender, EventArgs e)
        {
            if (_controlleur.tour(this) != 0)
            {
                _controlleur.changerPion("r");
            }
            else
            {
                _controlleur.changerPion("R");
            }
        }
    }
}
