
namespace MyDot
{
    partial class Pencil
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
            this.PbxColor = new System.Windows.Forms.PictureBox();
            this.RtbR = new System.Windows.Forms.RichTextBox();
            this.RtbG = new System.Windows.Forms.RichTextBox();
            this.RtbB = new System.Windows.Forms.RichTextBox();
            this.RtbA = new System.Windows.Forms.RichTextBox();
            this.BtnChoice = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SfdSave = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).BeginInit();
            this.SuspendLayout();
            // 
            // PbxColor
            // 
            this.PbxColor.Location = new System.Drawing.Point(299, 19);
            this.PbxColor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PbxColor.Name = "PbxColor";
            this.PbxColor.Size = new System.Drawing.Size(154, 154);
            this.PbxColor.TabIndex = 0;
            this.PbxColor.TabStop = false;
            // 
            // RtbR
            // 
            this.RtbR.Location = new System.Drawing.Point(459, 19);
            this.RtbR.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RtbR.Name = "RtbR";
            this.RtbR.Size = new System.Drawing.Size(154, 31);
            this.RtbR.TabIndex = 1;
            this.RtbR.Text = "255";
            this.RtbR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbG
            // 
            this.RtbG.Location = new System.Drawing.Point(459, 60);
            this.RtbG.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RtbG.Name = "RtbG";
            this.RtbG.Size = new System.Drawing.Size(154, 31);
            this.RtbG.TabIndex = 1;
            this.RtbG.Text = "255";
            this.RtbG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbB
            // 
            this.RtbB.Location = new System.Drawing.Point(459, 101);
            this.RtbB.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RtbB.Name = "RtbB";
            this.RtbB.Size = new System.Drawing.Size(154, 31);
            this.RtbB.TabIndex = 1;
            this.RtbB.Text = "255";
            this.RtbB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbA
            // 
            this.RtbA.Location = new System.Drawing.Point(459, 142);
            this.RtbA.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RtbA.Name = "RtbA";
            this.RtbA.Size = new System.Drawing.Size(154, 31);
            this.RtbA.TabIndex = 1;
            this.RtbA.Text = "255";
            this.RtbA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // BtnChoice
            // 
            this.BtnChoice.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnChoice.Location = new System.Drawing.Point(299, 183);
            this.BtnChoice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnChoice.Name = "BtnChoice";
            this.BtnChoice.Size = new System.Drawing.Size(314, 43);
            this.BtnChoice.TabIndex = 2;
            this.BtnChoice.Text = "Set";
            this.BtnChoice.UseVisualStyleBackColor = true;
            this.BtnChoice.Click += new System.EventHandler(this.BtnChoice_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(492, 361);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 42);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // SfdSave
            // 
            this.SfdSave.Filter = "|*.png";
            // 
            // Pencil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 412);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnChoice);
            this.Controls.Add(this.RtbA);
            this.Controls.Add(this.RtbB);
            this.Controls.Add(this.RtbG);
            this.Controls.Add(this.RtbR);
            this.Controls.Add(this.PbxColor);
            this.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Pencil";
            this.Text = "Pencil";
            this.Load += new System.EventHandler(this.Pencil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxColor;
        private System.Windows.Forms.RichTextBox RtbR;
        private System.Windows.Forms.RichTextBox RtbG;
        private System.Windows.Forms.RichTextBox RtbB;
        private System.Windows.Forms.RichTextBox RtbA;
        private System.Windows.Forms.Button BtnChoice;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.SaveFileDialog SfdSave;
    }
}