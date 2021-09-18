
namespace Dotpia
{
    partial class Helper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Helper));
            this.Rtb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Rtb
            // 
            this.Rtb.Location = new System.Drawing.Point(12, 12);
            this.Rtb.Name = "Rtb";
            this.Rtb.ReadOnly = true;
            this.Rtb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Rtb.Size = new System.Drawing.Size(290, 440);
            this.Rtb.TabIndex = 0;
            this.Rtb.Text = "";
            // 
            // Helper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(314, 464);
            this.Controls.Add(this.Rtb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Helper";
            this.Text = "Helper";
            this.Load += new System.EventHandler(this.Helper_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Rtb;
    }
}