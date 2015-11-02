namespace GetVideoTime.UI.WinForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.processBar = new CCWin.SkinControl.ProgressIndicator();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.lbCount = new CCWin.SkinControl.SkinLabel();
            this.lbTotalTime = new CCWin.SkinControl.SkinLabel();
            this.lbTotalSize = new CCWin.SkinControl.SkinLabel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new CCWin.SkinControl.SkinContextMenuStrip();
            this.menuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenPath = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(7, 41);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "路径";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(45, 39);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(471, 21);
            this.txtPath.TabIndex = 0;
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenDir.BackgroundImage")));
            this.btnOpenDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDir.FlatAppearance.BorderSize = 0;
            this.btnOpenDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDir.Location = new System.Drawing.Point(533, 31);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(32, 32);
            this.btnOpenDir.TabIndex = 1;
            this.btnOpenDir.UseVisualStyleBackColor = false;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(582, 31);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(32, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(631, 31);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(32, 32);
            this.btnClear.TabIndex = 3;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // processBar
            // 
            this.processBar.AutoStart = true;
            this.processBar.BackColor = System.Drawing.Color.Transparent;
            this.processBar.CircleColor = System.Drawing.Color.Brown;
            this.processBar.CircleSize = 0.5F;
            this.processBar.Location = new System.Drawing.Point(245, 93);
            this.processBar.Name = "processBar";
            this.processBar.NumberOfCircles = 20;
            this.processBar.Percentage = 0F;
            this.processBar.Size = new System.Drawing.Size(200, 200);
            this.processBar.TabIndex = 4;
            this.processBar.UseWaitCursor = true;
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(368, 345);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(32, 17);
            this.skinLabel2.TabIndex = 5;
            this.skinLabel2.Text = "计数";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(439, 345);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(44, 17);
            this.skinLabel3.TabIndex = 5;
            this.skinLabel3.Text = "总时间";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(579, 345);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(44, 17);
            this.skinLabel4.TabIndex = 5;
            this.skinLabel4.Text = "总大小";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.BackColor = System.Drawing.Color.Transparent;
            this.lbCount.BorderColor = System.Drawing.Color.White;
            this.lbCount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCount.Location = new System.Drawing.Point(402, 345);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(15, 17);
            this.lbCount.TabIndex = 5;
            this.lbCount.Text = "0";
            // 
            // lbTotalTime
            // 
            this.lbTotalTime.AutoSize = true;
            this.lbTotalTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalTime.BorderColor = System.Drawing.Color.White;
            this.lbTotalTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalTime.Location = new System.Drawing.Point(487, 345);
            this.lbTotalTime.Name = "lbTotalTime";
            this.lbTotalTime.Size = new System.Drawing.Size(56, 17);
            this.lbTotalTime.TabIndex = 5;
            this.lbTotalTime.Text = "00:00:00";
            // 
            // lbTotalSize
            // 
            this.lbTotalSize.AutoSize = true;
            this.lbTotalSize.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalSize.BorderColor = System.Drawing.Color.White;
            this.lbTotalSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalSize.Location = new System.Drawing.Point(624, 345);
            this.lbTotalSize.Name = "lbTotalSize";
            this.lbTotalSize.Size = new System.Drawing.Size(44, 17);
            this.lbTotalSize.TabIndex = 5;
            this.lbTotalSize.Text = "0.00M";
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(7, 66);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(696, 276);
            this.dgvResult.TabIndex = 4;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Arrow = System.Drawing.Color.Black;
            this.contextMenuStrip.Back = System.Drawing.Color.White;
            this.contextMenuStrip.BackRadius = 4;
            this.contextMenuStrip.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.contextMenuStrip.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.contextMenuStrip.Fore = System.Drawing.Color.Black;
            this.contextMenuStrip.HoverFore = System.Drawing.Color.White;
            this.contextMenuStrip.ItemAnamorphosis = true;
            this.contextMenuStrip.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuStrip.ItemBorderShow = true;
            this.contextMenuStrip.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuStrip.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuStrip.ItemRadius = 4;
            this.contextMenuStrip.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpenFile,
            this.menuItemOpenPath});
            this.contextMenuStrip.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 48);
            this.contextMenuStrip.SkinAllColor = true;
            this.contextMenuStrip.TitleAnamorphosis = true;
            this.contextMenuStrip.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.contextMenuStrip.TitleRadius = 4;
            this.contextMenuStrip.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // menuItemOpenFile
            // 
            this.menuItemOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("menuItemOpenFile.Image")));
            this.menuItemOpenFile.Name = "menuItemOpenFile";
            this.menuItemOpenFile.Size = new System.Drawing.Size(152, 22);
            this.menuItemOpenFile.Text = "播放该视频";
            this.menuItemOpenFile.Click += new System.EventHandler(this.menuItemOpenFile_Click);
            // 
            // menuItemOpenPath
            // 
            this.menuItemOpenPath.Image = ((System.Drawing.Image)(resources.GetObject("menuItemOpenPath.Image")));
            this.menuItemOpenPath.Name = "menuItemOpenPath";
            this.menuItemOpenPath.Size = new System.Drawing.Size(152, 22);
            this.menuItemOpenPath.Text = "打开此路径";
            this.menuItemOpenPath.Click += new System.EventHandler(this.menuItemOpenPath_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(710, 366);
            this.CloseDownBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseDownBack")));
            this.CloseMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseMouseBack")));
            this.CloseNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.CloseNormlBack")));
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.skinLabel4);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.lbTotalSize);
            this.Controls.Add(this.lbTotalTime);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.processBar);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.skinLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MiniDownBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniDownBack")));
            this.MiniMouseBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniMouseBack")));
            this.MiniNormlBack = ((System.Drawing.Image)(resources.GetObject("$this.MiniNormlBack")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "视频文件时间统计";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClear;
        private CCWin.SkinControl.ProgressIndicator processBar;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel lbCount;
        private CCWin.SkinControl.SkinLabel lbTotalTime;
        private CCWin.SkinControl.SkinLabel lbTotalSize;
        private System.Windows.Forms.DataGridView dgvResult;
        private CCWin.SkinControl.SkinContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenPath;
    }
}