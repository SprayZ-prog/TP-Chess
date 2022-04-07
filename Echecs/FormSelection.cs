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
    public partial class FormSelection : Form
    {
        Echec _controlleur;
        public FormSelection(Echec controlleur)
        {
            _controlleur = controlleur;
            InitializeComponent();
        }

        private void FormSelection_Load(object sender, EventArgs e)
        {

        }

        private void btnCommencer_Click(object sender, EventArgs e)
        {
            _controlleur.commencerPartie();
        }
    }
}
