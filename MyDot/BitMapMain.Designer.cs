
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BitMapMain));
            this.Pnl = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Pnl
            // 
            this.Pnl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Pnl.Location = new System.Drawing.Point(12, 12);
            this.Pnl.Name = "Pnl";
            this.Pnl.Size = new System.Drawing.Size(800, 600);
            this.Pnl.TabIndex = 0;
            this.Pnl.Click += new System.EventHandler(this.BtnClick);
            this.Pnl.DoubleClick += new System.EventHandler(this.MouseDClick);
            this.Pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pnl_MouseDown);
            this.Pnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pnl_MouseMove);
            this.Pnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pnl_MouseUp);
            // 
            // Timer
            // 
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // BitMapMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(824, 624);
            this.Controls.Add(this.Pnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BitMapMain";
            this.Text = "Dotpia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BitMapMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BitMapMain_FormClosed);
            this.Load += new System.EventHandler(this.BitMapMain_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BitMapMain_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Pnl;
        private System.Windows.Forms.Timer Timer;
    }
}