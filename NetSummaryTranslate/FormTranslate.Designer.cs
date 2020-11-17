namespace NetCore.zh_hans
{
    partial class FormTranslate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_appId = new System.Windows.Forms.TextBox();
            this.textBox_secretKey = new System.Windows.Forms.TextBox();
            this.button_Import = new System.Windows.Forms.Button();
            this.progressBar_Translate = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMaxTasks = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "百度翻译AppID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(549, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "SecretKey:";
            // 
            // textBox_appId
            // 
            this.textBox_appId.Location = new System.Drawing.Point(230, 30);
            this.textBox_appId.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_appId.Name = "textBox_appId";
            this.textBox_appId.Size = new System.Drawing.Size(171, 30);
            this.textBox_appId.TabIndex = 1;
            // 
            // textBox_secretKey
            // 
            this.textBox_secretKey.Location = new System.Drawing.Point(675, 30);
            this.textBox_secretKey.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_secretKey.Name = "textBox_secretKey";
            this.textBox_secretKey.PasswordChar = '*';
            this.textBox_secretKey.Size = new System.Drawing.Size(171, 30);
            this.textBox_secretKey.TabIndex = 1;
            // 
            // button_Import
            // 
            this.button_Import.Location = new System.Drawing.Point(558, 79);
            this.button_Import.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(288, 46);
            this.button_Import.TabIndex = 2;
            this.button_Import.Text = "批量导入Xml文件 | 开始翻译";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // progressBar_Translate
            // 
            this.progressBar_Translate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_Translate.Location = new System.Drawing.Point(23, 215);
            this.progressBar_Translate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.progressBar_Translate.Name = "progressBar_Translate";
            this.progressBar_Translate.Size = new System.Drawing.Size(1214, 32);
            this.progressBar_Translate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "翻译进度:";
            // 
            // cbMaxTasks
            // 
            this.cbMaxTasks.FormattingEnabled = true;
            this.cbMaxTasks.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbMaxTasks.Location = new System.Drawing.Point(230, 86);
            this.cbMaxTasks.Name = "cbMaxTasks";
            this.cbMaxTasks.Size = new System.Drawing.Size(171, 32);
            this.cbMaxTasks.TabIndex = 5;
            this.cbMaxTasks.Text = "10";
            this.cbMaxTasks.Leave += new System.EventHandler(this.cbMaxTasks_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "同时启动文件翻译线程:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1163, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "说  明";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 261);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "日  志:";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(23, 298);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1214, 269);
            this.txtLog.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox_appId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbMaxTasks);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_secretKey);
            this.groupBox1.Controls.Add(this.button_Import);
            this.groupBox1.Location = new System.Drawing.Point(23, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1214, 147);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数";
            // 
            // FormTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 580);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar_Translate);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 800);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormTranslate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VS.NetCore“注释摘要\"中文翻译 zh-hans";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTranslate_FormClosing);
            this.Load += new System.EventHandler(this.FormTranslate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_appId;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox_secretKey;
        private System.Windows.Forms.Button button_in;
        private System.Windows.Forms.Button button_ImportFile;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.Button button_ImportXML;
        private System.Windows.Forms.ProgressBar progressBar_;
        private System.Windows.Forms.ProgressBar progressBar_t;
        private System.Windows.Forms.ProgressBar progressBar_Translate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMaxTasks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

