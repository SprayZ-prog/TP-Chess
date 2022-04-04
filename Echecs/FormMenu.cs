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
   
    public partial class FormMenu : Form
    {
        Echec _controlleur;
        public FormMenu(Echec controlleur)
        {
            _controlleur = controlleur;
            InitializeComponent();
        }
        public void nouvellePartie()
        {
            _controlleur.nouvellePartie();
        }

        private void classementOuvrir(object sender, EventArgs e)
        {
            _controlleur.ouvrirClassement();

        }
    }
}
