
namespace Dotpia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pencil));
            this.PbxColor = new System.Windows.Forms.PictureBox();
            this.RtbR = new System.Windows.Forms.RichTextBox();
            this.RtbG = new System.Windows.Forms.RichTextBox();
            this.RtbB = new System.Windows.Forms.RichTextBox();
            this.RtbA = new System.Windows.Forms.RichTextBox();
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
            this.BtnNewSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn7 = new System.Windows.Forms.Button();
            this.Btn6 = new System.Windows.Forms.Button();
            this.Btn5 = new System.Windows.Forms.Button();
            this.Btn4 = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Btn1 = new System.Windows.Forms.Button();
            this.Pbx7 = new System.Windows.Forms.PictureBox();
            this.Pbx6 = new System.Windows.Forms.PictureBox();
            this.Pbx5 = new System.Windows.Forms.PictureBox();
            this.Pbx4 = new System.Windows.Forms.PictureBox();
            this.Pbx3 = new System.Windows.Forms.PictureBox();
            this.Pbx2 = new System.Windows.Forms.PictureBox();
            this.Pbx1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RtbResizeH = new System.Windows.Forms.RichTextBox();
            this.RtbResizeW = new System.Windows.Forms.RichTextBox();
            this.BtnResize = new System.Windows.Forms.Button();
            this.BtnCut = new System.Windows.Forms.Button();
            this.BtnV = new System.Windows.Forms.Button();
            this.BtnZ = new System.Windows.Forms.Button();
            this.BtnZoom = new System.Windows.Forms.Button();
            this.BtnMIrror = new System.Windows.Forms.Button();
            this.RtbMirror = new System.Windows.Forms.RichTextBox();
            this.SfdNewSave = new System.Windows.Forms.SaveFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LblPx = new System.Windows.Forms.Label();
            this.LblMouse = new System.Windows.Forms.Label();
            this.LblHeight = new System.Windows.Forms.Label();
            this.LblWidth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.RtbR.TextChanged += new System.EventHandler(this.RtbColor_TextChanged);
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
            this.RtbG.TextChanged += new System.EventHandler(this.RtbColor_TextChanged);
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
            this.RtbB.TextChanged += new System.EventHandler(this.RtbColor_TextChanged);
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
            this.RtbA.TextChanged += new System.EventHandler(this.RtbColor_TextChanged);
            this.RtbA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSave.Location = new System.Drawing.Point(7, 121);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(85, 42);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // SfdSave
            // 
            this.SfdSave.Filter = "|*.png;*.jpg";
            // 
            // BtnSmart
            // 
            this.BtnSmart.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSmart.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSmart.Location = new System.Drawing.Point(6, 249);
            this.BtnSmart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BtnSmart.Name = "BtnSmart";
            this.BtnSmart.Size = new System.Drawing.Size(314, 43);
            this.BtnSmart.TabIndex = 2;
            this.BtnSmart.Text = "Smart Set";
            this.BtnSmart.UseVisualStyleBackColor = false;
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
            this.BtnExport.BackColor = System.Drawing.SystemColors.Control;
            this.BtnExport.Location = new System.Drawing.Point(98, 73);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 42);
            this.BtnExport.TabIndex = 3;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = false;
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
            this.BtnCombine.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCombine.Location = new System.Drawing.Point(98, 25);
            this.BtnCombine.Name = "BtnCombine";
            this.BtnCombine.Size = new System.Drawing.Size(120, 42);
            this.BtnCombine.TabIndex = 3;
            this.BtnCombine.Text = "Combine";
            this.BtnCombine.UseVisualStyleBackColor = false;
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
            this.OfdOpen.Filter = "|*.png;*.jpg";
            // 
            // BtnExtraction
            // 
            this.BtnExtraction.BackColor = System.Drawing.SystemColors.Control;
            this.BtnExtraction.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnExtraction.Location = new System.Drawing.Point(82, 25);
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
            this.BtnPaint.Location = new System.Drawing.Point(178, 25);
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
            this.groupBox1.Controls.Add(this.BtnNewSave);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.BtnExport);
            this.groupBox1.Controls.Add(this.RtbExport);
            this.groupBox1.Controls.Add(this.BtnCombine);
            this.groupBox1.Location = new System.Drawing.Point(12, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 169);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // BtnNewSave
            // 
            this.BtnNewSave.BackColor = System.Drawing.SystemColors.Control;
            this.BtnNewSave.Location = new System.Drawing.Point(98, 121);
            this.BtnNewSave.Name = "BtnNewSave";
            this.BtnNewSave.Size = new System.Drawing.Size(120, 42);
            this.BtnNewSave.TabIndex = 3;
            this.BtnNewSave.Text = "Save Dotpia";
            this.BtnNewSave.UseVisualStyleBackColor = false;
            this.BtnNewSave.Click += new System.EventHandler(this.BtnNewSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn7);
            this.groupBox2.Controls.Add(this.Btn6);
            this.groupBox2.Controls.Add(this.Btn5);
            this.groupBox2.Controls.Add(this.Btn4);
            this.groupBox2.Controls.Add(this.Btn3);
            this.groupBox2.Controls.Add(this.Btn2);
            this.groupBox2.Controls.Add(this.Btn1);
            this.groupBox2.Controls.Add(this.Pbx7);
            this.groupBox2.Controls.Add(this.Pbx6);
            this.groupBox2.Controls.Add(this.Pbx5);
            this.groupBox2.Controls.Add(this.Pbx4);
            this.groupBox2.Controls.Add(this.Pbx3);
            this.groupBox2.Controls.Add(this.Pbx2);
            this.groupBox2.Controls.Add(this.Pbx1);
            this.groupBox2.Controls.Add(this.PbxColor);
            this.groupBox2.Controls.Add(this.RtbR);
            this.groupBox2.Controls.Add(this.RtbG);
            this.groupBox2.Controls.Add(this.RtbB);
            this.groupBox2.Controls.Add(this.RtbA);
            this.groupBox2.Controls.Add(this.BtnSmart);
            this.groupBox2.Location = new System.Drawing.Point(289, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 300);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color";
            // 
            // Btn7
            // 
            this.Btn7.Location = new System.Drawing.Point(284, 232);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(36, 10);
            this.Btn7.TabIndex = 4;
            this.Btn7.UseVisualStyleBackColor = true;
            this.Btn7.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn6
            // 
            this.Btn6.Location = new System.Drawing.Point(242, 232);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(36, 10);
            this.Btn6.TabIndex = 4;
            this.Btn6.UseVisualStyleBackColor = true;
            this.Btn6.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn5
            // 
            this.Btn5.Location = new System.Drawing.Point(188, 232);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(36, 10);
            this.Btn5.TabIndex = 4;
            this.Btn5.UseVisualStyleBackColor = true;
            this.Btn5.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn4
            // 
            this.Btn4.Location = new System.Drawing.Point(146, 232);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(36, 10);
            this.Btn4.TabIndex = 4;
            this.Btn4.UseVisualStyleBackColor = true;
            this.Btn4.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn3
            // 
            this.Btn3.Location = new System.Drawing.Point(104, 232);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(36, 10);
            this.Btn3.TabIndex = 4;
            this.Btn3.UseVisualStyleBackColor = true;
            this.Btn3.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn2
            // 
            this.Btn2.Location = new System.Drawing.Point(48, 232);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(36, 10);
            this.Btn2.TabIndex = 4;
            this.Btn2.UseVisualStyleBackColor = true;
            this.Btn2.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Btn1
            // 
            this.Btn1.Location = new System.Drawing.Point(6, 232);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(36, 10);
            this.Btn1.TabIndex = 4;
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.Click += new System.EventHandler(this.Btn_Click);
            // 
            // Pbx7
            // 
            this.Pbx7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pbx7.Location = new System.Drawing.Point(284, 191);
            this.Pbx7.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Pbx7.Name = "Pbx7";
            this.Pbx7.Size = new System.Drawing.Size(36, 36);
            this.Pbx7.TabIndex = 3;
            this.Pbx7.TabStop = false;
            this.Pbx7.Click += new System.EventHandler(this.Pbx_Click);
            // 
            // Pbx6
            // 
            this.Pbx6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pbx6.Location = new System.Drawing.Point(242, 191);
            this.Pbx6.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Pbx6.Name = "Pbx6";
            this.Pbx6.Size = new System.Drawing.Size(36, 36);
            this.Pbx6.TabIndex = 3;
            this.Pbx6.TabStop = false;
            this.Pbx6.Click += new System.EventHandler(this.Pbx_Click);
            // 
            // Pbx5
            // 
            this.Pbx5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pbx5.Location = new System.Drawing.Point(188, 191);
            this.Pbx5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Pbx5.Name = "Pbx5";
            this.Pbx5.Size = new System.Drawing.Size(36, 36);
            this.Pbx5.TabIndex = 3;
            this.Pbx5.TabStop = false;
            this.Pbx5.Click += new System.EventHandler(this.Pbx_Click);
            // 
            // Pbx4
            // 
            this.Pbx4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pbx4.Location = new System.Drawing.Point(146, 191);
            this.Pbx4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Pbx4.Name = "Pbx4";
            this.Pbx4.Size = new System.Drawing.Size(36, 36);
            this.Pbx4.TabIndex = 3;
            this.Pbx4.TabStop = false;
            this.Pbx4.Click += new System.EventHandler(this.Pbx_Click);
            // 
            // Pbx3
            // 
            this.Pbx3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pbx3.Location = new System.Drawing.Point(104, 191);
            this.Pbx3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Pbx3.Name = "Pbx3";
            this.Pbx3.Size = new System.Drawing.Size(36, 36);
            this.Pbx3.TabIndex = 3;
            this.Pbx3.TabStop = false;
            this.Pbx3.Click += new System.EventHandler(this.Pbx_Click);
            // 
            // Pbx2
            // 
            this.Pbx2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pbx2.Location = new System.Drawing.Point(48, 191);
            this.Pbx2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Pbx2.Name = "Pbx2";
            this.Pbx2.Size = new System.Drawing.Size(36, 36);
            this.Pbx2.TabIndex = 3;
            this.Pbx2.TabStop = false;
            this.Pbx2.Click += new System.EventHandler(this.Pbx_Click);
            // 
            // Pbx1
            // 
            this.Pbx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pbx1.Location = new System.Drawing.Point(6, 191);
            this.Pbx1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Pbx1.Name = "Pbx1";
            this.Pbx1.Size = new System.Drawing.Size(36, 36);
            this.Pbx1.TabIndex = 3;
            this.Pbx1.TabStop = false;
            this.Pbx1.Click += new System.EventHandler(this.Pbx_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RtbResizeH);
            this.groupBox3.Controls.Add(this.RtbResizeW);
            this.groupBox3.Controls.Add(this.BtnResize);
            this.groupBox3.Controls.Add(this.BtnCut);
            this.groupBox3.Controls.Add(this.BtnV);
            this.groupBox3.Controls.Add(this.BtnZ);
            this.groupBox3.Controls.Add(this.BtnZoom);
            this.groupBox3.Controls.Add(this.BtnMIrror);
            this.groupBox3.Controls.Add(this.BtnBorder);
            this.groupBox3.Controls.Add(this.RtbMirror);
            this.groupBox3.Controls.Add(this.BtnExtraction);
            this.groupBox3.Controls.Add(this.BtnPaint);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 223);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tool";
            // 
            // RtbResizeH
            // 
            this.RtbResizeH.Location = new System.Drawing.Point(52, 170);
            this.RtbResizeH.Name = "RtbResizeH";
            this.RtbResizeH.Size = new System.Drawing.Size(40, 41);
            this.RtbResizeH.TabIndex = 4;
            this.RtbResizeH.Text = "";
            this.RtbResizeH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // RtbResizeW
            // 
            this.RtbResizeW.Location = new System.Drawing.Point(6, 170);
            this.RtbResizeW.Name = "RtbResizeW";
            this.RtbResizeW.Size = new System.Drawing.Size(40, 41);
            this.RtbResizeW.TabIndex = 4;
            this.RtbResizeW.Text = "";
            this.RtbResizeW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // BtnResize
            // 
            this.BtnResize.BackColor = System.Drawing.SystemColors.Control;
            this.BtnResize.Location = new System.Drawing.Point(98, 169);
            this.BtnResize.Name = "BtnResize";
            this.BtnResize.Size = new System.Drawing.Size(85, 42);
            this.BtnResize.TabIndex = 3;
            this.BtnResize.Text = "Resize";
            this.BtnResize.UseVisualStyleBackColor = false;
            this.BtnResize.Click += new System.EventHandler(this.BtnResize_Click);
            // 
            // BtnCut
            // 
            this.BtnCut.BackColor = System.Drawing.SystemColors.Control;
            this.BtnCut.Location = new System.Drawing.Point(180, 121);
            this.BtnCut.Name = "BtnCut";
            this.BtnCut.Size = new System.Drawing.Size(85, 42);
            this.BtnCut.TabIndex = 3;
            this.BtnCut.Text = "Cut";
            this.BtnCut.UseVisualStyleBackColor = false;
            this.BtnCut.Click += new System.EventHandler(this.BtnCut_Click);
            // 
            // BtnV
            // 
            this.BtnV.BackColor = System.Drawing.SystemColors.Control;
            this.BtnV.Location = new System.Drawing.Point(93, 121);
            this.BtnV.Name = "BtnV";
            this.BtnV.Size = new System.Drawing.Size(81, 42);
            this.BtnV.TabIndex = 3;
            this.BtnV.Text = "Ctrl+V";
            this.BtnV.UseVisualStyleBackColor = false;
            this.BtnV.Click += new System.EventHandler(this.BtnV_Click);
            // 
            // BtnZ
            // 
            this.BtnZ.BackColor = System.Drawing.SystemColors.Control;
            this.BtnZ.Location = new System.Drawing.Point(6, 121);
            this.BtnZ.Name = "BtnZ";
            this.BtnZ.Size = new System.Drawing.Size(81, 42);
            this.BtnZ.TabIndex = 3;
            this.BtnZ.Text = "Ctrl+Z";
            this.BtnZ.UseVisualStyleBackColor = false;
            this.BtnZ.Click += new System.EventHandler(this.BtnZ_Click);
            // 
            // BtnZoom
            // 
            this.BtnZoom.BackColor = System.Drawing.SystemColors.Control;
            this.BtnZoom.Location = new System.Drawing.Point(139, 73);
            this.BtnZoom.Name = "BtnZoom";
            this.BtnZoom.Size = new System.Drawing.Size(126, 42);
            this.BtnZoom.TabIndex = 3;
            this.BtnZoom.Text = "Zoom Reset";
            this.BtnZoom.UseVisualStyleBackColor = false;
            this.BtnZoom.Click += new System.EventHandler(this.BtnZoom_Click);
            // 
            // BtnMIrror
            // 
            this.BtnMIrror.BackColor = System.Drawing.SystemColors.Control;
            this.BtnMIrror.Location = new System.Drawing.Point(63, 73);
            this.BtnMIrror.Name = "BtnMIrror";
            this.BtnMIrror.Size = new System.Drawing.Size(70, 42);
            this.BtnMIrror.TabIndex = 3;
            this.BtnMIrror.Text = "Mirror";
            this.BtnMIrror.UseVisualStyleBackColor = false;
            this.BtnMIrror.Click += new System.EventHandler(this.BtnMIrror_Click);
            // 
            // RtbMirror
            // 
            this.RtbMirror.Location = new System.Drawing.Point(6, 73);
            this.RtbMirror.Name = "RtbMirror";
            this.RtbMirror.Size = new System.Drawing.Size(51, 41);
            this.RtbMirror.TabIndex = 4;
            this.RtbMirror.Text = "";
            this.RtbMirror.TextChanged += new System.EventHandler(this.RtbMirror_TextChanged);
            this.RtbMirror.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // SfdNewSave
            // 
            this.SfdNewSave.Filter = "|*.dotpia";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LblPx);
            this.groupBox4.Controls.Add(this.LblMouse);
            this.groupBox4.Controls.Add(this.LblHeight);
            this.groupBox4.Controls.Add(this.LblWidth);
            this.groupBox4.Location = new System.Drawing.Point(289, 318);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 82);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Data";
            // 
            // LblPx
            // 
            this.LblPx.AutoSize = true;
            this.LblPx.Location = new System.Drawing.Point(100, 46);
            this.LblPx.Name = "LblPx";
            this.LblPx.Size = new System.Drawing.Size(42, 19);
            this.LblPx.TabIndex = 1;
            this.LblPx.Text = "Px: 1";
            // 
            // LblMouse
            // 
            this.LblMouse.AutoSize = true;
            this.LblMouse.Location = new System.Drawing.Point(100, 22);
            this.LblMouse.Name = "LblMouse";
            this.LblMouse.Size = new System.Drawing.Size(0, 19);
            this.LblMouse.TabIndex = 1;
            // 
            // LblHeight
            // 
            this.LblHeight.AutoSize = true;
            this.LblHeight.Location = new System.Drawing.Point(6, 46);
            this.LblHeight.Name = "LblHeight";
            this.LblHeight.Size = new System.Drawing.Size(0, 19);
            this.LblHeight.TabIndex = 0;
            // 
            // LblWidth
            // 
            this.LblWidth.AutoSize = true;
            this.LblWidth.Location = new System.Drawing.Point(6, 22);
            this.LblWidth.Name = "LblWidth";
            this.LblWidth.Size = new System.Drawing.Size(0, 19);
            this.LblWidth.TabIndex = 0;
            // 
            // Pencil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(627, 422);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "Pencil";
            this.Text = "Pencil Case";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pencil_FormClosed);
            this.Load += new System.EventHandler(this.Pencil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pbx7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pbx1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.SaveFileDialog SfdSave;
        private System.Windows.Forms.ColorDialog CldColor;
        private System.Windows.Forms.Button BtnSmart;
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
        private System.Windows.Forms.Button BtnMIrror;
        private System.Windows.Forms.RichTextBox RtbMirror;
        public System.Windows.Forms.PictureBox Pbx7;
        public System.Windows.Forms.PictureBox Pbx6;
        public System.Windows.Forms.PictureBox Pbx5;
        public System.Windows.Forms.PictureBox Pbx4;
        public System.Windows.Forms.PictureBox Pbx3;
        public System.Windows.Forms.PictureBox Pbx2;
        public System.Windows.Forms.PictureBox Pbx1;
        private System.Windows.Forms.Button Btn7;
        private System.Windows.Forms.Button Btn6;
        private System.Windows.Forms.Button Btn5;
        private System.Windows.Forms.Button Btn4;
        private System.Windows.Forms.Button Btn3;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Button BtnZoom;
        private System.Windows.Forms.Button BtnNewSave;
        private System.Windows.Forms.SaveFileDialog SfdNewSave;
        public System.Windows.Forms.Button BtnBorder;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label LblWidth;
        public System.Windows.Forms.Label LblMouse;
        public System.Windows.Forms.Label LblHeight;
        private System.Windows.Forms.Button BtnZ;
        public System.Windows.Forms.Label LblPx;
        private System.Windows.Forms.Button BtnV;
        private System.Windows.Forms.Button BtnCut;
        private System.Windows.Forms.RichTextBox RtbResizeH;
        private System.Windows.Forms.RichTextBox RtbResizeW;
        private System.Windows.Forms.Button BtnResize;
    }
}