
namespace Echecs
{
    partial class FormPartie
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
            this.labMessage = new System.Windows.Forms.Label();
            this.btnAbandon = new System.Windows.Forms.Button();
            this.btnNulle = new System.Windows.Forms.Button();
            this.pnlEchiquier = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMessage.Location = new System.Drawing.Point(78, 41);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(160, 31);
            this.labMessage.TabIndex = 1;
            this.labMessage.Text = "labMessage";
            // 
            // btnAbandon
            // 
            this.btnAbandon.Location = new System.Drawing.Point(163, 668);
            this.btnAbandon.Name = "btnAbandon";
            this.btnAbandon.Size = new System.Drawing.Size(116, 34);
            this.btnAbandon.TabIndex = 4;
            this.btnAbandon.Text = "Abandon";
            this.btnAbandon.UseVisualStyleBackColor = true;
            this.btnAbandon.Click += new System.EventHandler(this.btnAbandon_Click);
            // 
            // btnNulle
            // 
            this.btnNulle.Location = new System.Drawing.Point(396, 668);
            this.btnNulle.Name = "btnNulle";
            this.btnNulle.Size = new System.Drawing.Size(116, 34);
            this.btnNulle.TabIndex = 5;
            this.btnNulle.Text = "Nulle";
            this.btnNulle.UseVisualStyleBackColor = true;
            this.btnNulle.Click += new System.EventHandler(this.btnNulle_Click);
            // 
            // pnlEchiquier
            // 
            this.pnlEchiquier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlEchiquier.Location = new System.Drawing.Point(84, 122);
            this.pnlEchiquier.Name = "pnlEchiquier";
            this.pnlEchiquier.Size = new System.Drawing.Size(496, 496);
            this.pnlEchiquier.TabIndex = 6;
            this.pnlEchiquier.Click += new System.EventHandler(this.pnlEchiquier_Click);
            this.pnlEchiquier.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEchiquier_Paint);
            // 
            // FormPartie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 767);
            this.Controls.Add(this.btnNulle);
            this.Controls.Add(this.btnAbandon);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.pnlEchiquier);
            this.Name = "FormPartie";
            this.Text = "Partie d\'échec";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Button btnAbandon;
        private System.Windows.Forms.Button btnNulle;
        private System.Windows.Forms.Panel pnlEchiquier;
    }
}