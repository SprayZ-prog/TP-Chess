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

        /// <summary>
        /// Événement du bouton « Nouvelle partie »
        /// </summary>
        private void btnNouvelle_Click(object sender, EventArgs e)
        {
            _controlleur.nouvellePartie();
        }
        /// <summary>
        /// Événement du bouton « Classement » qui affiche le classement
        /// </summary>
        private void btnClassement_Click(object sender, EventArgs e)
        {
            _controlleur.ouvrirClassement();
        }
        /// <summary>
        /// Événement lors de la fermeture de ce formulaire (Menu principal) qui ferme tout le jeu
        /// </summary>
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _controlleur.fermerJeu();
        }
        /// <summary>
        /// Événement du clic du bouton « Quitter le jeu »
        /// </summary>
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            _controlleur.quitter();
        }
    }
}
