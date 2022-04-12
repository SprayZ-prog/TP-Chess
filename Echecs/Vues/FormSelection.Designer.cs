
namespace Echecs
{
    partial class FormSelection
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
            this.btnCommencer = new System.Windows.Forms.Button();
            this.cmbJoueur2 = new System.Windows.Forms.ComboBox();
            this.cmbJoueur1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCommencer
            // 
            this.btnCommencer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCommencer.Location = new System.Drawing.Point(239, 63);
            this.btnCommencer.Margin = new System.Windows.Forms.Padding(2);
            this.btnCommencer.MinimumSize = new System.Drawing.Size(144, 37);
            this.btnCommencer.Name = "btnCommencer";
            this.btnCommencer.Size = new System.Drawing.Size(144, 37);
            this.btnCommencer.TabIndex = 0;
            this.btnCommencer.Text = "Commencer";
            this.btnCommencer.UseVisualStyleBackColor = false;
            this.btnCommencer.Click += new System.EventHandler(this.btnCommencer_Click);
            // 
            // cmbJoueur2
            // 
            this.cmbJoueur2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJoueur2.FormattingEnabled = true;
            this.cmbJoueur2.Location = new System.Drawing.Point(27, 112);
            this.cmbJoueur2.Margin = new System.Windows.Forms.Padding(2);
            this.cmbJoueur2.Name = "cmbJoueur2";
            this.cmbJoueur2.Size = new System.Drawing.Size(135, 21);
            this.cmbJoueur2.TabIndex = 1;
            this.cmbJoueur2.SelectedIndexChanged += new System.EventHandler(this.cmbJoueur2_SelectedIndexChanged);
            // 
            // cmbJoueur1
            // 
            this.cmbJoueur1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJoueur1.FormattingEnabled = true;
            this.cmbJoueur1.Location = new System.Drawing.Point(27, 36);
            this.cmbJoueur1.Margin = new System.Windows.Forms.Padding(2);
            this.cmbJoueur1.Name = "cmbJoueur1";
            this.cmbJoueur1.Size = new System.Drawing.Size(135, 21);
            this.cmbJoueur1.TabIndex = 2;
            this.cmbJoueur1.SelectedIndexChanged += new System.EventHandler(this.cmbJoueur1_SelectedIndexChanged);
            // 
            // FormSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(449, 189);
            this.Controls.Add(this.cmbJoueur1);
            this.Controls.Add(this.cmbJoueur2);
            this.Controls.Add(this.btnCommencer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormSelection";
            this.Text = "Sélection des joueurs";
            this.Load += new System.EventHandler(this.FormSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCommencer;
        private System.Windows.Forms.ComboBox cmbJoueur2;
        private System.Windows.Forms.ComboBox cmbJoueur1;
    }
}