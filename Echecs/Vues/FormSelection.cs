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
            if(selected1 != null && selected2 != null)
            {
                _controlleur.commencerPartie(selected1, selected2);
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show("Veuiller selectionner 2 joueurs!", "Attention", buttons);
            }
            
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
            if(selected1 == null)
            {
                selected1 = cmbJoueur1.SelectedItem.ToString();
                int index = cmbJoueur2.FindString(selected1);
                cmbJoueur2.Items.RemoveAt(index);
            }
            else if (!selected1.Equals(cmbJoueur1.SelectedItem.ToString()))
            {
                cmbJoueur2.Items.Add(selected1);
                selected1 = cmbJoueur1.SelectedItem.ToString();
                int index = cmbJoueur2.FindString(selected1);
                cmbJoueur2.Items.RemoveAt(index);

                
            }
        }

        private void cmbJoueur2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected2 == null)
            {
                selected2 = cmbJoueur2.SelectedItem.ToString();
                int index = cmbJoueur1.FindString(selected2);
                cmbJoueur1.Items.RemoveAt(index);
            }
            else if (!selected2.Equals(cmbJoueur2.SelectedItem.ToString()))
            {
                cmbJoueur1.Items.Add(selected2);
                selected2 = cmbJoueur2.SelectedItem.ToString();
                int index = cmbJoueur1.FindString(selected2);
                cmbJoueur1.Items.RemoveAt(index);
            }
           
            
        }

    }
}
