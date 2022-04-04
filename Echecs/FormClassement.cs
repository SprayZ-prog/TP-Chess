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
        public void read()
        {
            string file = @"../../test.txt";
            string[] lines = File.ReadAllLines(file);

            foreach(string line in lines)
            {
                string[] infos = line.Split('/');
                _controlleur.ajouterJoueur(infos[0], Int32.Parse(infos[1]), Int32.Parse(infos[2]), Int32.Parse(infos[3]));
                ListViewItem lvi = new ListViewItem(infos);
                listView1.Items.Add(lvi);
            }
        }
        public void save()
        {
            string file = @"../../test.txt";

        
            
            using (StreamWriter sw = new StreamWriter(file))
            {

                foreach (Joueur joueur in _controlleur.ListeJoueur)
                {
                    sw.WriteLine(joueur.ToString());

                }
                sw.Close();
            }

        }

        private void FormClassement_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Nom", 150);
            listView1.Columns.Add("Parties gagnés", 150);
            listView1.Columns.Add("Parties perdues", 150);
            listView1.Columns.Add("Nulles", 150);
            read();
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
            save();

        }
    }
}
