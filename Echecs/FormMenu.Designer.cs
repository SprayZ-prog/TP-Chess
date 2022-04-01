
namespace Echecs
{
    partial class FormMenu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Titre = new System.Windows.Forms.Label();
            this.btnNouvelle = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnClassement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Titre
            // 
            this.Titre.AutoSize = true;
            this.Titre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre.Location = new System.Drawing.Point(364, 121);
            this.Titre.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.Titre.Name = "Titre";
            this.Titre.Size = new System.Drawing.Size(316, 29);
            this.Titre.TabIndex = 0;
            this.Titre.Text = "Bienvenue au jeu d\'échec";
            // 
            // btnNouvelle
            // 
            this.btnNouvelle.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnNouvelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouvelle.Location = new System.Drawing.Point(320, 229);
            this.btnNouvelle.Name = "btnNouvelle";
            this.btnNouvelle.Size = new System.Drawing.Size(311, 54);
            this.btnNouvelle.TabIndex = 1;
            this.btnNouvelle.Text = "Nouvelle Partie";
            this.btnNouvelle.UseVisualStyleBackColor = false;
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Location = new System.Drawing.Point(320, 428);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(311, 55);
            this.btnQuitter.TabIndex = 2;
            this.btnQuitter.Text = "Quitter le jeu";
            this.btnQuitter.UseVisualStyleBackColor = false;
            // 
            // btnClassement
            // 
            this.btnClassement.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnClassement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassement.Location = new System.Drawing.Point(320, 331);
            this.btnClassement.Name = "btnClassement";
            this.btnClassement.Size = new System.Drawing.Size(311, 52);
            this.btnClassement.TabIndex = 3;
            this.btnClassement.Text = "Classement";
            this.btnClassement.UseVisualStyleBackColor = false;
            this.btnClassement.Click += new System.EventHandler(this.classementOuvrir);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(978, 544);
            this.Controls.Add(this.btnClassement);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnNouvelle);
            this.Controls.Add(this.Titre);
            this.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "FormMenu";
            this.Text = "Menu du jeu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titre;
        private System.Windows.Forms.Button btnNouvelle;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnClassement;
    }
}

