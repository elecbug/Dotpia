﻿
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
            this.BtnPaint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbxColor
            // 
            this.PbxColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbxColor.Location = new System.Drawing.Point(6, 27);
            this.PbxColor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PbxColor.Name = "PbxColor";
            this.PbxColor.Size = new System.Drawing.Size(154, 154);
            this.PbxColor.TabIndex = 0;
            this.PbxColor.TabStop = false;
            // 
            // RtbR
            // 
            this.RtbR.Location = new System.Drawing.Point(166, 27);
            this.RtbR.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RtbR.Name = "RtbR";
            this.RtbR.Size = new System.Drawing.Size(154, 31);
            this.RtbR.TabIndex = 1;
            this.RtbR.Text = "255";
            this.RtbR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbG
            // 
            this.RtbG.Location = new System.Drawing.Point(166, 68);
            this.RtbG.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RtbG.Name = "RtbG";
            this.RtbG.Size = new System.Drawing.Size(154, 31);
            this.RtbG.TabIndex = 1;
            this.RtbG.Text = "255";
            this.RtbG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbB
            // 
            this.RtbB.Location = new System.Drawing.Point(166, 109);
            this.RtbB.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.RtbB.Name = "RtbB";
            this.RtbB.Size = new System.Drawing.Size(154, 31);
            this.RtbB.TabIndex = 1;
            this.RtbB.Text = "255";
            this.RtbB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbA
            // 
            this.RtbA.Location = new System.Drawing.Point(166, 150);
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
            this.BtnChoice.Location = new System.Drawing.Point(6, 191);
            this.BtnChoice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnChoice.Name = "BtnChoice";
            this.BtnChoice.Size = new System.Drawing.Size(117, 43);
            this.BtnChoice.TabIndex = 2;
            this.BtnChoice.Text = "Set";
            this.BtnChoice.UseVisualStyleBackColor = true;
            this.BtnChoice.Click += new System.EventHandler(this.BtnChoice_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(98, 121);
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
            this.BtnSmart.Location = new System.Drawing.Point(129, 191);
            this.BtnSmart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnSmart.Name = "BtnSmart";
            this.BtnSmart.Size = new System.Drawing.Size(190, 43);
            this.BtnSmart.TabIndex = 2;
            this.BtnSmart.Text = "Smart Set";
            this.BtnSmart.UseVisualStyleBackColor = true;
            this.BtnSmart.Click += new System.EventHandler(this.BtnSmart_Click);
            // 
            // BtnBorder
            // 
            this.BtnBorder.BackColor = System.Drawing.SystemColors.Control;
            this.BtnBorder.Location = new System.Drawing.Point(6, 25);
            this.BtnBorder.Name = "BtnBorder";
            this.BtnBorder.Size = new System.Drawing.Size(70, 42);
            this.BtnBorder.TabIndex = 3;
            this.BtnBorder.Text = "Border";
            this.BtnBorder.UseVisualStyleBackColor = false;
            this.BtnBorder.Click += new System.EventHandler(this.BtnBorder_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(98, 73);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 42);
            this.BtnExport.TabIndex = 3;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // RtbExport
            // 
            this.RtbExport.Location = new System.Drawing.Point(6, 73);
            this.RtbExport.Name = "RtbExport";
            this.RtbExport.Size = new System.Drawing.Size(86, 41);
            this.RtbExport.TabIndex = 4;
            this.RtbExport.Text = "";
            this.RtbExport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // BtnCombine
            // 
            this.BtnCombine.Location = new System.Drawing.Point(98, 25);
            this.BtnCombine.Name = "BtnCombine";
            this.BtnCombine.Size = new System.Drawing.Size(120, 42);
            this.BtnCombine.TabIndex = 3;
            this.BtnCombine.Text = "Combine";
            this.BtnCombine.UseVisualStyleBackColor = true;
            this.BtnCombine.Click += new System.EventHandler(this.BtnCombine_Click);
            // 
            // RtbCWidth
            // 
            this.RtbCWidth.Location = new System.Drawing.Point(6, 25);
            this.RtbCWidth.Name = "RtbCWidth";
            this.RtbCWidth.Size = new System.Drawing.Size(40, 41);
            this.RtbCWidth.TabIndex = 4;
            this.RtbCWidth.Text = "";
            this.RtbCWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbCHeight
            // 
            this.RtbCHeight.Location = new System.Drawing.Point(52, 25);
            this.RtbCHeight.Name = "RtbCHeight";
            this.RtbCHeight.Size = new System.Drawing.Size(40, 41);
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
            this.BtnExtraction.BackColor = System.Drawing.SystemColors.Control;
            this.BtnExtraction.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnExtraction.Location = new System.Drawing.Point(82, 27);
            this.BtnExtraction.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnExtraction.Name = "BtnExtraction";
            this.BtnExtraction.Size = new System.Drawing.Size(90, 42);
            this.BtnExtraction.TabIndex = 2;
            this.BtnExtraction.Text = "Extraction";
            this.BtnExtraction.UseVisualStyleBackColor = false;
            this.BtnExtraction.Click += new System.EventHandler(this.BtnExtraction_Click);
            // 
            // BtnPaint
            // 
            this.BtnPaint.BackColor = System.Drawing.SystemColors.Control;
            this.BtnPaint.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnPaint.Location = new System.Drawing.Point(178, 27);
            this.BtnPaint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnPaint.Name = "BtnPaint";
            this.BtnPaint.Size = new System.Drawing.Size(87, 42);
            this.BtnPaint.TabIndex = 2;
            this.BtnPaint.Text = "Paint";
            this.BtnPaint.UseVisualStyleBackColor = false;
            this.BtnPaint.Click += new System.EventHandler(this.BtnPaint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RtbCWidth);
            this.groupBox1.Controls.Add(this.RtbCHeight);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.BtnExport);
            this.groupBox1.Controls.Add(this.RtbExport);
            this.groupBox1.Controls.Add(this.BtnCombine);
            this.groupBox1.Location = new System.Drawing.Point(12, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 169);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PbxColor);
            this.groupBox2.Controls.Add(this.RtbR);
            this.groupBox2.Controls.Add(this.RtbG);
            this.groupBox2.Controls.Add(this.RtbB);
            this.groupBox2.Controls.Add(this.RtbA);
            this.groupBox2.Controls.Add(this.BtnSmart);
            this.groupBox2.Controls.Add(this.BtnChoice);
            this.groupBox2.Location = new System.Drawing.Point(289, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 242);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnBorder);
            this.groupBox3.Controls.Add(this.BtnExtraction);
            this.groupBox3.Controls.Add(this.BtnPaint);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 213);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tool";
            // 
            // Pencil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(627, 412);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "Pencil";
            this.Text = "Pencil Case";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pencil_FormClosed);
            this.Load += new System.EventHandler(this.Pencil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.Button BtnPaint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}