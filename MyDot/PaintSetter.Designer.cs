
namespace Dotpia
{
    partial class PaintSetter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaintSetter));
            this.label1 = new System.Windows.Forms.Label();
            this.TrbR = new System.Windows.Forms.TrackBar();
            this.TrbG = new System.Windows.Forms.TrackBar();
            this.TrbB = new System.Windows.Forms.TrackBar();
            this.TrbA = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.TrbR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbA)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "R\r\nG\r\nB\r\nA";
            // 
            // TrbR
            // 
            this.TrbR.Location = new System.Drawing.Point(36, 9);
            this.TrbR.Maximum = 255;
            this.TrbR.Name = "TrbR";
            this.TrbR.Size = new System.Drawing.Size(104, 45);
            this.TrbR.TabIndex = 1;
            this.TrbR.Scroll += new System.EventHandler(this.TrbR_Scroll);
            // 
            // TrbG
            // 
            this.TrbG.Location = new System.Drawing.Point(36, 28);
            this.TrbG.Maximum = 255;
            this.TrbG.Name = "TrbG";
            this.TrbG.Size = new System.Drawing.Size(104, 45);
            this.TrbG.TabIndex = 1;
            this.TrbG.Scroll += new System.EventHandler(this.TrbG_Scroll);
            // 
            // TrbB
            // 
            this.TrbB.Location = new System.Drawing.Point(36, 49);
            this.TrbB.Maximum = 255;
            this.TrbB.Name = "TrbB";
            this.TrbB.Size = new System.Drawing.Size(104, 45);
            this.TrbB.TabIndex = 1;
            this.TrbB.Scroll += new System.EventHandler(this.TrbB_Scroll);
            // 
            // TrbA
            // 
            this.TrbA.Location = new System.Drawing.Point(36, 69);
            this.TrbA.Maximum = 255;
            this.TrbA.Name = "TrbA";
            this.TrbA.Size = new System.Drawing.Size(104, 45);
            this.TrbA.TabIndex = 1;
            this.TrbA.Scroll += new System.EventHandler(this.TrbA_Scroll);
            // 
            // PaintSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(146, 107);
            this.Controls.Add(this.TrbA);
            this.Controls.Add(this.TrbB);
            this.Controls.Add(this.TrbG);
            this.Controls.Add(this.TrbR);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "PaintSetter";
            this.Text = "Paint Setter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PaintSetter_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TrbR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar TrbR;
        private System.Windows.Forms.TrackBar TrbG;
        private System.Windows.Forms.TrackBar TrbB;
        private System.Windows.Forms.TrackBar TrbA;
    }
}