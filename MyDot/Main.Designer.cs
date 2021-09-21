
namespace Dotpia
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.RtbWidth = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RtbHeight = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OfdOpen = new System.Windows.Forms.OpenFileDialog();
            this.BtnHelp = new System.Windows.Forms.Button();
            this.BtnNewLoad = new System.Windows.Forms.Button();
            this.OfdNewOpen = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(13, 394);
            this.BtnNew.Margin = new System.Windows.Forms.Padding(4);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(358, 46);
            this.BtnNew.TabIndex = 3;
            this.BtnNew.Text = "New";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.AllowDrop = true;
            this.BtnLoad.Location = new System.Drawing.Point(12, 448);
            this.BtnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(358, 46);
            this.BtnLoad.TabIndex = 4;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // RtbWidth
            // 
            this.RtbWidth.Location = new System.Drawing.Point(76, 25);
            this.RtbWidth.Name = "RtbWidth";
            this.RtbWidth.Size = new System.Drawing.Size(114, 30);
            this.RtbWidth.TabIndex = 1;
            this.RtbWidth.Text = "";
            this.RtbWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height:";
            // 
            // RtbHeight
            // 
            this.RtbHeight.Location = new System.Drawing.Point(76, 61);
            this.RtbHeight.Name = "RtbHeight";
            this.RtbHeight.Size = new System.Drawing.Size(114, 30);
            this.RtbHeight.TabIndex = 2;
            this.RtbHeight.Text = "";
            this.RtbHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtbKeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RtbWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.RtbHeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(159, 276);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // OfdOpen
            // 
            this.OfdOpen.Filter = "|*.png;*.jpg";
            // 
            // BtnHelp
            // 
            this.BtnHelp.Location = new System.Drawing.Point(12, 12);
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.Size = new System.Drawing.Size(44, 43);
            this.BtnHelp.TabIndex = 6;
            this.BtnHelp.Text = "?";
            this.BtnHelp.UseVisualStyleBackColor = true;
            this.BtnHelp.Click += new System.EventHandler(this.Main_HelpButtonClicked);
            // 
            // BtnNewLoad
            // 
            this.BtnNewLoad.AllowDrop = true;
            this.BtnNewLoad.Location = new System.Drawing.Point(12, 502);
            this.BtnNewLoad.Margin = new System.Windows.Forms.Padding(4);
            this.BtnNewLoad.Name = "BtnNewLoad";
            this.BtnNewLoad.Size = new System.Drawing.Size(358, 46);
            this.BtnNewLoad.TabIndex = 5;
            this.BtnNewLoad.Text = "Load Dotpia";
            this.BtnNewLoad.UseVisualStyleBackColor = true;
            this.BtnNewLoad.Click += new System.EventHandler(this.BtnNewLoad_Click);
            // 
            // OfdNewOpen
            // 
            this.OfdNewOpen.Filter = "|*.dotpia";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.BtnHelp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnNewLoad);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnNew);
            this.Font = new System.Drawing.Font("휴먼편지체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Dotpia";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.RichTextBox RtbWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RtbHeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog OfdOpen;
        private System.Windows.Forms.Button BtnHelp;
        private System.Windows.Forms.Button BtnNewLoad;
        private System.Windows.Forms.OpenFileDialog OfdNewOpen;
    }
}

