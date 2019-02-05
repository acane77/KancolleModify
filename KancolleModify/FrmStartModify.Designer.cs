namespace KancolleModify
{
    partial class FrmStartModify
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
            this.lstFileList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelDetail = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModType = new System.Windows.Forms.TextBox();
            this.lblOriginalFile = new System.Windows.Forms.Label();
            this.txtOriginalFile = new System.Windows.Forms.TextBox();
            this.btnOpenOriginalFile = new System.Windows.Forms.Button();
            this.lblDstFile = new System.Windows.Forms.Label();
            this.txtDstFile = new System.Windows.Forms.TextBox();
            this.OpenDstFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblReplaceAs = new System.Windows.Forms.Label();
            this.txtReplaceAs = new System.Windows.Forms.TextBox();
            this.btnOpenReplaceAs = new System.Windows.Forms.Button();
            this.panelDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFileList
            // 
            this.lstFileList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstFileList.FormattingEnabled = true;
            this.lstFileList.Location = new System.Drawing.Point(15, 35);
            this.lstFileList.Name = "lstFileList";
            this.lstFileList.Size = new System.Drawing.Size(314, 292);
            this.lstFileList.TabIndex = 0;
            this.lstFileList.SelectedIndexChanged += new System.EventHandler(this.lstFileList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "待修改的文件列表";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(418, 333);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(137, 30);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "开始魔改!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.btnOpenReplaceAs);
            this.panelDetail.Controls.Add(this.txtReplaceAs);
            this.panelDetail.Controls.Add(this.lblReplaceAs);
            this.panelDetail.Controls.Add(this.lblWarning);
            this.panelDetail.Controls.Add(this.txtFileName);
            this.panelDetail.Controls.Add(this.label5);
            this.panelDetail.Controls.Add(this.OpenDstFile);
            this.panelDetail.Controls.Add(this.txtDstFile);
            this.panelDetail.Controls.Add(this.lblDstFile);
            this.panelDetail.Controls.Add(this.btnOpenOriginalFile);
            this.panelDetail.Controls.Add(this.txtOriginalFile);
            this.panelDetail.Controls.Add(this.lblOriginalFile);
            this.panelDetail.Controls.Add(this.txtModType);
            this.panelDetail.Controls.Add(this.label2);
            this.panelDetail.Enabled = false;
            this.panelDetail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelDetail.Location = new System.Drawing.Point(338, 35);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(227, 291);
            this.panelDetail.TabIndex = 16;
            this.panelDetail.TabStop = false;
            this.panelDetail.Text = "详细信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "魔改类型";
            // 
            // txtModType
            // 
            this.txtModType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModType.Location = new System.Drawing.Point(80, 32);
            this.txtModType.Name = "txtModType";
            this.txtModType.ReadOnly = true;
            this.txtModType.Size = new System.Drawing.Size(130, 16);
            this.txtModType.TabIndex = 1;
            // 
            // lblOriginalFile
            // 
            this.lblOriginalFile.AutoSize = true;
            this.lblOriginalFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOriginalFile.Location = new System.Drawing.Point(18, 82);
            this.lblOriginalFile.Name = "lblOriginalFile";
            this.lblOriginalFile.Size = new System.Drawing.Size(56, 17);
            this.lblOriginalFile.TabIndex = 2;
            this.lblOriginalFile.Text = "原始文件";
            // 
            // txtOriginalFile
            // 
            this.txtOriginalFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOriginalFile.Location = new System.Drawing.Point(21, 105);
            this.txtOriginalFile.Name = "txtOriginalFile";
            this.txtOriginalFile.ReadOnly = true;
            this.txtOriginalFile.Size = new System.Drawing.Size(130, 16);
            this.txtOriginalFile.TabIndex = 3;
            // 
            // btnOpenOriginalFile
            // 
            this.btnOpenOriginalFile.Location = new System.Drawing.Point(157, 102);
            this.btnOpenOriginalFile.Name = "btnOpenOriginalFile";
            this.btnOpenOriginalFile.Size = new System.Drawing.Size(64, 23);
            this.btnOpenOriginalFile.TabIndex = 4;
            this.btnOpenOriginalFile.Text = "Open";
            this.btnOpenOriginalFile.UseVisualStyleBackColor = true;
            this.btnOpenOriginalFile.Click += new System.EventHandler(this.btnOpenOriginalFile_Click);
            // 
            // lblDstFile
            // 
            this.lblDstFile.AutoSize = true;
            this.lblDstFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDstFile.Location = new System.Drawing.Point(18, 133);
            this.lblDstFile.Name = "lblDstFile";
            this.lblDstFile.Size = new System.Drawing.Size(56, 17);
            this.lblDstFile.TabIndex = 5;
            this.lblDstFile.Text = "目标文件";
            // 
            // txtDstFile
            // 
            this.txtDstFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDstFile.Location = new System.Drawing.Point(21, 156);
            this.txtDstFile.Name = "txtDstFile";
            this.txtDstFile.ReadOnly = true;
            this.txtDstFile.Size = new System.Drawing.Size(130, 16);
            this.txtDstFile.TabIndex = 6;
            // 
            // OpenDstFile
            // 
            this.OpenDstFile.Location = new System.Drawing.Point(157, 153);
            this.OpenDstFile.Name = "OpenDstFile";
            this.OpenDstFile.Size = new System.Drawing.Size(64, 23);
            this.OpenDstFile.TabIndex = 7;
            this.OpenDstFile.Text = "Open";
            this.OpenDstFile.UseVisualStyleBackColor = true;
            this.OpenDstFile.Click += new System.EventHandler(this.OpenDstFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(18, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "文件名";
            // 
            // txtFileName
            // 
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileName.Location = new System.Drawing.Point(80, 57);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(130, 16);
            this.txtFileName.TabIndex = 9;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectAll.Location = new System.Drawing.Point(15, 333);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(101, 28);
            this.btnSelectAll.TabIndex = 10;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnselectAll.Location = new System.Drawing.Point(122, 333);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(101, 28);
            this.btnUnselectAll.TabIndex = 17;
            this.btnUnselectAll.Text = "全不选";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(18, 242);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(200, 34);
            this.lblWarning.TabIndex = 10;
            this.lblWarning.Text = "原始文件尺寸不同于将其替换的文件\r\n的尺寸。";
            this.lblWarning.Visible = false;
            // 
            // lblReplaceAs
            // 
            this.lblReplaceAs.AutoSize = true;
            this.lblReplaceAs.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReplaceAs.Location = new System.Drawing.Point(18, 184);
            this.lblReplaceAs.Name = "lblReplaceAs";
            this.lblReplaceAs.Size = new System.Drawing.Size(44, 17);
            this.lblReplaceAs.TabIndex = 11;
            this.lblReplaceAs.Text = "替换为";
            // 
            // txtReplaceAs
            // 
            this.txtReplaceAs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReplaceAs.Location = new System.Drawing.Point(21, 209);
            this.txtReplaceAs.Name = "txtReplaceAs";
            this.txtReplaceAs.ReadOnly = true;
            this.txtReplaceAs.Size = new System.Drawing.Size(130, 16);
            this.txtReplaceAs.TabIndex = 12;
            // 
            // btnOpenReplaceAs
            // 
            this.btnOpenReplaceAs.Location = new System.Drawing.Point(157, 206);
            this.btnOpenReplaceAs.Name = "btnOpenReplaceAs";
            this.btnOpenReplaceAs.Size = new System.Drawing.Size(64, 23);
            this.btnOpenReplaceAs.TabIndex = 13;
            this.btnOpenReplaceAs.Text = "Open";
            this.btnOpenReplaceAs.UseVisualStyleBackColor = true;
            this.btnOpenReplaceAs.Click += new System.EventHandler(this.btnOpenReplaceAs_Click);
            // 
            // FrmStartModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 373);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstFileList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStartModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "待修改的文件列表";
            this.Load += new System.EventHandler(this.FrmStartModify_Load);
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstFileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox panelDetail;
        private System.Windows.Forms.TextBox txtDstFile;
        private System.Windows.Forms.Label lblDstFile;
        private System.Windows.Forms.Button btnOpenOriginalFile;
        private System.Windows.Forms.TextBox txtOriginalFile;
        private System.Windows.Forms.Label lblOriginalFile;
        private System.Windows.Forms.TextBox txtModType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OpenDstFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnOpenReplaceAs;
        private System.Windows.Forms.TextBox txtReplaceAs;
        private System.Windows.Forms.Label lblReplaceAs;
        private System.Windows.Forms.Label lblWarning;
    }
}