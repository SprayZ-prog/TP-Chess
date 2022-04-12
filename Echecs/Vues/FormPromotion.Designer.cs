
namespace Echecs
{
    partial class FormPromotion
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
            this.pnl1 = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.pnl4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.Location = new System.Drawing.Point(59, 39);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(62, 62);
            this.pnl1.TabIndex = 0;
            this.pnl1.Click += new System.EventHandler(this.pnl1_Click);
            this.pnl1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl1_Paint);
            // 
            // pnl2
            // 
            this.pnl2.Location = new System.Drawing.Point(147, 39);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(62, 62);
            this.pnl2.TabIndex = 1;
            this.pnl2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl2_Paint);
            // 
            // pnl3
            // 
            this.pnl3.Location = new System.Drawing.Point(59, 120);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(62, 62);
            this.pnl3.TabIndex = 2;
            this.pnl3.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl3_Paint);
            // 
            // pnl4
            // 
            this.pnl4.Location = new System.Drawing.Point(147, 120);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(62, 62);
            this.pnl4.TabIndex = 2;
            this.pnl4.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl4_Paint);
            // 
            // FormPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 236);
            this.Controls.Add(this.pnl4);
            this.Controls.Add(this.pnl3);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl1);
            this.Name = "FormPromotion";
            this.Text = "Promotion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.Panel pnl4;
    }
}