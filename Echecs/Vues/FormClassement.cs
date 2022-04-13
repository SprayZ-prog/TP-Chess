using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Echecs
{
    public partial class FormClassement : Form
    {
        private Echec _controlleur;
        public FormClassement(Echec controlleur)
        {
            _controlleur = controlleur;
            
            InitializeComponent();
        }
        
        /// <summary>
        /// Événement de l'affichage du formulaire du classement de joueurs
        /// </summary>
        private void FormClassement_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Nom", 150);
            listView1.Columns.Add("Parties gagnés", 150);
            listView1.Columns.Add("Parties perdues", 150);
            listView1.Columns.Add("Nulles", 150);
            foreach (Joueur joueur in _controlleur.ListeJoueur)
            {
                string[] infos = joueur.ToString().Split('/');
                ListViewItem lvi = new ListViewItem(infos);
                listView1.Items.Add(lvi);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            
            if (int.TryParse(txtWin.Text, out int n) && int.TryParse(txtLose.Text, out int m) && int.TryParse(txtNulle.Text, out int i))
            {
                String[] row = { txtName.Text, txtWin.Text, txtLose.Text, txtNulle.Text };
                ListViewItem lvi = new ListViewItem(row);
                listView1.Items.Add(lvi);
                _controlleur.ajouterJoueur(txtName.Text, Int32.Parse(txtWin.Text), Int32.Parse(txtLose.Text), Int32.Parse(txtNulle.Text));
                
                
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show("Entrez le bon type dans les bons champs", "Attention", buttons);
                
            }
            txtName.Text = "";
            txtWin.Text = "";
            txtLose.Text = "";
            txtNulle.Text = "";

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.FocusedItem.Index);

                _controlleur.enleverJoueur(listView1.FocusedItem.Index);
            }
            
            
        }
    }
}
