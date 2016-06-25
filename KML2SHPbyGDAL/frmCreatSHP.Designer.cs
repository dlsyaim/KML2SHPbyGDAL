namespace KML2SHPbyGDAL
{
    partial class frmCreatSHP
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreatSHP));
            this.btn_createshp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ShpPath = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_SHPOutput = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_createshp
            // 
            this.btn_createshp.Location = new System.Drawing.Point(299, 142);
            this.btn_createshp.Name = "btn_createshp";
            this.btn_createshp.Size = new System.Drawing.Size(121, 23);
            this.btn_createshp.TabIndex = 0;
            this.btn_createshp.Text = "创建SHP测试";
            this.btn_createshp.UseVisualStyleBackColor = true;
            this.btn_createshp.Click += new System.EventHandler(this.btn_createshp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输出路径：";
            // 
            // txt_ShpPath
            // 
            this.txt_ShpPath.Location = new System.Drawing.Point(101, 78);
            this.txt_ShpPath.Name = "txt_ShpPath";
            this.txt_ShpPath.Size = new System.Drawing.Size(424, 21);
            this.txt_ShpPath.TabIndex = 2;
            // 
            // btn_SHPOutput
            // 
            this.btn_SHPOutput.Image = ((System.Drawing.Image)(resources.GetObject("btn_SHPOutput.Image")));
            this.btn_SHPOutput.Location = new System.Drawing.Point(531, 75);
            this.btn_SHPOutput.Name = "btn_SHPOutput";
            this.btn_SHPOutput.Size = new System.Drawing.Size(26, 24);
            this.btn_SHPOutput.TabIndex = 5;
            this.btn_SHPOutput.UseVisualStyleBackColor = true;
            this.btn_SHPOutput.Click += new System.EventHandler(this.btn_SHPOutput_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 78);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 14);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // frmCreatSHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 262);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_SHPOutput);
            this.Controls.Add(this.txt_ShpPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_createshp);
            this.Name = "frmCreatSHP";
            this.Text = "创建SHP文件";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_createshp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ShpPath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_SHPOutput;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

