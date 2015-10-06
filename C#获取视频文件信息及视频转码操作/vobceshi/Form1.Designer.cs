namespace vobceshi
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.rtbmessage = new System.Windows.Forms.RichTextBox();
            this.txttime1 = new System.Windows.Forms.TextBox();
            this.txttime2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnjiequ = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txttime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblstep = new System.Windows.Forms.Label();
            this.pnstep = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnstep.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "转码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbmessage
            // 
            this.rtbmessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbmessage.Location = new System.Drawing.Point(0, 153);
            this.rtbmessage.Name = "rtbmessage";
            this.rtbmessage.Size = new System.Drawing.Size(746, 428);
            this.rtbmessage.TabIndex = 1;
            this.rtbmessage.Text = "";
            // 
            // txttime1
            // 
            this.txttime1.Location = new System.Drawing.Point(83, 82);
            this.txttime1.Name = "txttime1";
            this.txttime1.Size = new System.Drawing.Size(100, 21);
            this.txttime1.TabIndex = 2;
            // 
            // txttime2
            // 
            this.txttime2.Location = new System.Drawing.Point(206, 82);
            this.txttime2.Name = "txttime2";
            this.txttime2.Size = new System.Drawing.Size(96, 21);
            this.txttime2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "时间段截取";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnstep);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnjiequ);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txttime);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.txtpath);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txttime1);
            this.panel1.Controls.Add(this.txttime2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 147);
            this.panel1.TabIndex = 6;
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Location = new System.Drawing.Point(153, 19);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(11, 12);
            this.lbltime.TabIndex = 16;
            this.lbltime.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "共耗时间：";
            // 
            // btnjiequ
            // 
            this.btnjiequ.Enabled = false;
            this.btnjiequ.Location = new System.Drawing.Point(634, 19);
            this.btnjiequ.Name = "btnjiequ";
            this.btnjiequ.Size = new System.Drawing.Size(59, 23);
            this.btnjiequ.TabIndex = 14;
            this.btnjiequ.Text = "截取";
            this.btnjiequ.UseVisualStyleBackColor = true;
            this.btnjiequ.Click += new System.EventHandler(this.btnjiequ_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "图片截取点：";
            // 
            // txttime
            // 
            this.txttime.Location = new System.Drawing.Point(391, 82);
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(98, 21);
            this.txttime.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "文件输出名：";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(391, 19);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(98, 21);
            this.txtname.TabIndex = 10;
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(83, 19);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(100, 21);
            this.txtpath.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(206, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "选取文件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "选择文件：";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Gainsboro;
            this.progressBar1.ForeColor = System.Drawing.Color.Green;
            this.progressBar1.Location = new System.Drawing.Point(83, 121);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(660, 20);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "秒";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "转换进度：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "完成：";
            // 
            // lblstep
            // 
            this.lblstep.AutoSize = true;
            this.lblstep.Location = new System.Drawing.Point(50, 19);
            this.lblstep.Name = "lblstep";
            this.lblstep.Size = new System.Drawing.Size(11, 12);
            this.lblstep.TabIndex = 20;
            this.lblstep.Text = "0";
            // 
            // pnstep
            // 
            this.pnstep.Controls.Add(this.label9);
            this.pnstep.Controls.Add(this.lblstep);
            this.pnstep.Controls.Add(this.label7);
            this.pnstep.Controls.Add(this.label6);
            this.pnstep.Controls.Add(this.lbltime);
            this.pnstep.Location = new System.Drawing.Point(529, 66);
            this.pnstep.Name = "pnstep";
            this.pnstep.Size = new System.Drawing.Size(200, 49);
            this.pnstep.TabIndex = 21;
            this.pnstep.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 581);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbmessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视频转码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnstep.ResumeLayout(false);
            this.pnstep.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txttime1;
        private System.Windows.Forms.TextBox txttime2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtname;
        public System.Windows.Forms.RichTextBox rtbmessage;
        private System.Windows.Forms.TextBox txttime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnjiequ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblstep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnstep;
    }
}

