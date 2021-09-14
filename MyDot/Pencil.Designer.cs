
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
            this.CldColor = new System.Windows.Forms.ColorDialog();
            this.BtnSmart = new System.Windows.Forms.Button();
            this.BtnBorder = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.RtbExport = new System.Windows.Forms.RichTextBox();
            this.BtnCombine = new System.Windows.Forms.Button();
            this.RtbCWidth = new System.Windows.Forms.RichTextBox();
            this.RtbCHeight = new System.Windows.Forms.RichTextBox();
            this.OfdOpen = new System.Windows.Forms.OpenFileDialog();
            this.BtnExtraction = new System.Windows.Forms.Button();
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
            this.BtnChoice.Size = new System.Drawing.Size(65, 43);
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
            this.BtnSmart.Location = new System.Drawing.Point(370, 183);
            this.BtnSmart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnSmart.Name = "BtnSmart";
            this.BtnSmart.Size = new System.Drawing.Size(101, 43);
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
            // BtnCombine
            // 
            this.BtnCombine.Location = new System.Drawing.Point(12, 60);
            this.BtnCombine.Name = "BtnCombine";
            this.BtnCombine.Size = new System.Drawing.Size(120, 42);
            this.BtnCombine.TabIndex = 3;
            this.BtnCombine.Text = "Combine";
            this.BtnCombine.UseVisualStyleBackColor = true;
            this.BtnCombine.Click += new System.EventHandler(this.BtnCombine_Click);
            // 
            // RtbCWidth
            // 
            this.RtbCWidth.Location = new System.Drawing.Point(138, 61);
            this.RtbCWidth.Name = "RtbCWidth";
            this.RtbCWidth.Size = new System.Drawing.Size(39, 41);
            this.RtbCWidth.TabIndex = 4;
            this.RtbCWidth.Text = "";
            this.RtbCWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbCHeight
            // 
            this.RtbCHeight.Location = new System.Drawing.Point(183, 60);
            this.RtbCHeight.Name = "RtbCHeight";
            this.RtbCHeight.Size = new System.Drawing.Size(39, 41);
            this.RtbCHeight.TabIndex = 4;
            this.RtbCHeight.Text = "";
            this.RtbCHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // OfdOpen
            // 
            this.OfdOpen.Filter = "|*.png";
            // 
            // BtnExtraction
            // 
            this.BtnExtraction.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnExtraction.Location = new System.Drawing.Point(477, 183);
            this.BtnExtraction.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnExtraction.Name = "BtnExtraction";
            this.BtnExtraction.Size = new System.Drawing.Size(101, 43);
            this.BtnExtraction.TabIndex = 2;
            this.BtnExtraction.Text = "Extraction";
            this.BtnExtraction.UseVisualStyleBackColor = true;
            this.BtnExtraction.Click += new System.EventHandler(this.BtnExtraction_Click);
            // 
            // Pencil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(627, 412);
            this.Controls.Add(this.RtbCHeight);
            this.Controls.Add(this.RtbCWidth);
            this.Controls.Add(this.RtbExport);
            this.Controls.Add(this.BtnCombine);
            this.Controls.Add(this.BtnBorder);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnExtraction);
            this.Controls.Add(this.BtnSmart);
            this.Controls.Add(this.BtnChoice);
            this.Controls.Add(this.RtbA);
            this.Controls.Add(this.RtbB);
            this.Controls.Add(this.RtbG);
            this.Controls.Add(this.RtbR);
            this.Controls.Add(this.PbxColor);
            this.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "Pencil";
            this.Text = "Pencil Case";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pencil_FormClosed);
            this.Load += new System.EventHandler(this.Pencil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnChoice;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.SaveFileDialog SfdSave;
        private System.Windows.Forms.ColorDialog CldColor;
        private System.Windows.Forms.Button BtnSmart;
        private System.Windows.Forms.Button BtnBorder;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.RichTextBox RtbExport;
        private System.Windows.Forms.Button BtnCombine;
        private System.Windows.Forms.RichTextBox RtbCWidth;
        private System.Windows.Forms.RichTextBox RtbCHeight;
        private System.Windows.Forms.OpenFileDialog OfdOpen;
        private System.Windows.Forms.Button BtnExtraction;
        public System.Windows.Forms.PictureBox PbxColor;
        public System.Windows.Forms.RichTextBox RtbR;
        public System.Windows.Forms.RichTextBox RtbG;
        public System.Windows.Forms.RichTextBox RtbB;
        public System.Windows.Forms.RichTextBox RtbA;
    }
}