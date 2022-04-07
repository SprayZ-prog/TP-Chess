
namespace Echecs
{
    partial class FormClassement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labClassement = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNulle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(707, 572);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(237, 46);
            this.btnAjouter.TabIndex = 1;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(213, 718);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(237, 46);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(30, 65);
            this.listView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listView1.MaximumSize = new System.Drawing.Size(596, 625);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(596, 625);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(830, 175);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 37);
            this.txtName.TabIndex = 3;
            // 
            // labClassement
            // 
            this.labClassement.AutoSize = true;
            this.labClassement.Location = new System.Drawing.Point(163, 32);
            this.labClassement.Name = "labClassement";
            this.labClassement.Size = new System.Drawing.Size(310, 29);
            this.labClassement.TabIndex = 4;
            this.labClassement.Text = "Classement des joueurs:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(634, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Parties gagnées";
            // 
            // txtWin
            // 
            this.txtWin.Location = new System.Drawing.Point(830, 245);
            this.txtWin.Name = "txtWin";
            this.txtWin.Size = new System.Drawing.Size(238, 37);
            this.txtWin.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(634, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Parties perdues";
            // 
            // txtLose
            // 
            this.txtLose.Location = new System.Drawing.Point(830, 329);
            this.txtLose.Name = "txtLose";
            this.txtLose.Size = new System.Drawing.Size(238, 37);
            this.txtLose.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(634, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nulle";
            // 
            // txtNulle
            // 
            this.txtNulle.Location = new System.Drawing.Point(830, 407);
            this.txtNulle.Name = "txtNulle";
            this.txtNulle.Size = new System.Drawing.Size(238, 37);
            this.txtNulle.TabIndex = 11;
            // 
            // FormClassement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1080, 883);
            this.Controls.Add(this.txtNulle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labClassement);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormClassement";
            this.Text = "Classement";
            this.Load += new System.EventHandler(this.FormClassement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labClassement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNulle;
    }
}