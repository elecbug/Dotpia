
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
            this.PbxR = new System.Windows.Forms.RichTextBox();
            this.PbxG = new System.Windows.Forms.RichTextBox();
            this.PbxB = new System.Windows.Forms.RichTextBox();
            this.PbxA = new System.Windows.Forms.RichTextBox();
            this.BtnChoice = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SfdSave = new System.Windows.Forms.SaveFileDialog();
            this.CldColor = new System.Windows.Forms.ColorDialog();
            this.BtnSmart = new System.Windows.Forms.Button();
            this.BtnBorder = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.RtbExport = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).BeginInit();
            this.SuspendLayout();
            // 
            // PbxColor
            // 
            this.PbxColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxColor.Location = new System.Drawing.Point(299, 19);
            this.PbxColor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PbxColor.Name = "PbxColor";
            this.PbxColor.Size = new System.Drawing.Size(154, 154);
            this.PbxColor.TabIndex = 0;
            this.PbxColor.TabStop = false;
            // 
            // PbxR
            // 
            this.PbxR.Location = new System.Drawing.Point(459, 19);
            this.PbxR.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PbxR.Name = "PbxR";
            this.PbxR.Size = new System.Drawing.Size(154, 31);
            this.PbxR.TabIndex = 1;
            this.PbxR.Text = "255";
            this.PbxR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // PbxG
            // 
            this.PbxG.Location = new System.Drawing.Point(459, 60);
            this.PbxG.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PbxG.Name = "PbxG";
            this.PbxG.Size = new System.Drawing.Size(154, 31);
            this.PbxG.TabIndex = 1;
            this.PbxG.Text = "255";
            this.PbxG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // PbxB
            // 
            this.PbxB.Location = new System.Drawing.Point(459, 101);
            this.PbxB.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PbxB.Name = "PbxB";
            this.PbxB.Size = new System.Drawing.Size(154, 31);
            this.PbxB.TabIndex = 1;
            this.PbxB.Text = "255";
            this.PbxB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // PbxA
            // 
            this.PbxA.Location = new System.Drawing.Point(459, 142);
            this.PbxA.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PbxA.Name = "PbxA";
            this.PbxA.Size = new System.Drawing.Size(154, 31);
            this.PbxA.TabIndex = 1;
            this.PbxA.Text = "255";
            this.PbxA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
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
            // BtnSmart
            // 
            this.BtnSmart.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSmart.Location = new System.Drawing.Point(298, 236);
            this.BtnSmart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnSmart.Name = "BtnSmart";
            this.BtnSmart.Size = new System.Drawing.Size(314, 43);
            this.BtnSmart.TabIndex = 2;
            this.BtnSmart.Text = "Smart Set";
            this.BtnSmart.UseVisualStyleBackColor = true;
            this.BtnSmart.Click += new System.EventHandler(this.BtnSmart_Click);
            // 
            // BtnBorder
            // 
            this.BtnBorder.Location = new System.Drawing.Point(12, 12);
            this.BtnBorder.Name = "BtnBorder";
            this.BtnBorder.Size = new System.Drawing.Size(120, 42);
            this.BtnBorder.TabIndex = 3;
            this.BtnBorder.Text = "Border";
            this.BtnBorder.UseVisualStyleBackColor = true;
            this.BtnBorder.Click += new System.EventHandler(this.BtnBorder_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(492, 313);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 42);
            this.BtnExport.TabIndex = 3;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // RtbExport
            // 
            this.RtbExport.Location = new System.Drawing.Point(392, 313);
            this.RtbExport.Name = "RtbExport";
            this.RtbExport.Size = new System.Drawing.Size(100, 41);
            this.RtbExport.TabIndex = 4;
            this.RtbExport.Text = "";
            this.RtbExport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // Pencil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(627, 412);
            this.Controls.Add(this.RtbExport);
            this.Controls.Add(this.BtnBorder);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnSmart);
            this.Controls.Add(this.BtnChoice);
            this.Controls.Add(this.PbxA);
            this.Controls.Add(this.PbxB);
            this.Controls.Add(this.PbxG);
            this.Controls.Add(this.PbxR);
            this.Controls.Add(this.PbxColor);
            this.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "Pencil";
            this.Text = "Pencil Case";
            this.Load += new System.EventHandler(this.Pencil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxColor;
        private System.Windows.Forms.RichTextBox PbxR;
        private System.Windows.Forms.RichTextBox PbxG;
        private System.Windows.Forms.RichTextBox PbxB;
        private System.Windows.Forms.RichTextBox PbxA;
        private System.Windows.Forms.Button BtnChoice;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.SaveFileDialog SfdSave;
        private System.Windows.Forms.ColorDialog CldColor;
        private System.Windows.Forms.Button BtnSmart;
        private System.Windows.Forms.Button BtnBorder;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.RichTextBox RtbExport;
    }
}