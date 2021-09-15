
namespace MyDot
{
    partial class BitMapMain
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
            this.Pnl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Pnl
            // 
            this.Pnl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Pnl.Location = new System.Drawing.Point(0, 0);
            this.Pnl.Name = "Pnl";
            this.Pnl.Size = new System.Drawing.Size(800, 749);
            this.Pnl.TabIndex = 0;
            // 
            // BitMapMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 749);
            this.Controls.Add(this.Pnl);
            this.MaximizeBox = false;
            this.Name = "BitMapMain";
            this.Text = "My Dot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BitMapMain_FormClosed);
            this.Load += new System.EventHandler(this.BitMapMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pnl;
    }
}