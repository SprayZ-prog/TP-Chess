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
        private Echec _controlleur;
        private string selected1;
        private string selected2;
        public FormSelection(Echec controlleur)
        {
            _controlleur = controlleur;
            InitializeComponent();
        }


        private void btnCommencer_Click(object sender, EventArgs e)
        {
            _controlleur.commencerPartie();
        }

        private void FormSelection_Load(object sender, EventArgs e)
        {
            foreach(Joueur joueur in _controlleur.ListeJoueur)
            {
                cmbJoueur1.Items.Add(joueur.ToString().Split('/')[0]);
                cmbJoueur2.Items.Add(joueur.ToString().Split('/')[0]);
            }
            
        }

        private void cmbJoueur1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected2 != null)
            {
                cmbJoueur2.Items.Add(selected2);
            }
            selected1 = cmbJoueur1.SelectedItem.ToString();
            cmbJoueur2.Items.RemoveAt(cmbJoueur1.SelectedIndex);
        }

        private void cmbJoueur2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected1 != null)
            {
                cmbJoueur1.Items.Add(selected1);
            }
            selected2 = cmbJoueur2.SelectedItem.ToString();
            cmbJoueur1.Items.RemoveAt(cmbJoueur1.SelectedIndex);
        }
    }
}
