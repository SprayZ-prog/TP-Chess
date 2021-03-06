
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
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labMessage.Location = new System.Drawing.Point(77, 53);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(160, 31);
            this.labMessage.TabIndex = 1;
            this.labMessage.Text = "labMessage";
            this.labMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAbandon
            // 
            this.btnAbandon.Location = new System.Drawing.Point(235, 670);
            this.btnAbandon.Name = "btnAbandon";
            this.btnAbandon.Size = new System.Drawing.Size(116, 34);
            this.btnAbandon.TabIndex = 4;
            this.btnAbandon.Text = "Abandon";
            this.btnAbandon.UseVisualStyleBackColor = true;
            this.btnAbandon.Click += new System.EventHandler(this.btnAbandon_Click);
            // 
            // btnNulle
            // 
            this.btnNulle.Location = new System.Drawing.Point(468, 670);
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
            this.pnlEchiquier.Location = new System.Drawing.Point(156, 124);
            this.pnlEchiquier.Name = "pnlEchiquier";
            this.pnlEchiquier.Size = new System.Drawing.Size(496, 496);
            this.pnlEchiquier.TabIndex = 6;
            this.pnlEchiquier.Click += new System.EventHandler(this.pnlEchiquier_Click);
            this.pnlEchiquier.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEchiquier_Paint);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(622, 53);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(59, 23);
            this.btnUndo.TabIndex = 7;
            this.btnUndo.Text = "<< undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(703, 53);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(59, 23);
            this.btnRedo.TabIndex = 8;
            this.btnRedo.Text = "redo >>";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // FormPartie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 767);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
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
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
    }
}