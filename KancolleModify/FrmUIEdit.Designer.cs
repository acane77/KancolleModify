namespace KancolleModify
{
    partial class FrmUIEdit
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
            this.label25 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbIniPosEditContent = new System.Windows.Forms.ComboBox();
            this.btnIniText = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbVDStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAxis = new System.Windows.Forms.GroupBox();
            this.numPosTop = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numPosLeft = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentEdit = new System.Windows.Forms.TextBox();
            this.panelEdit = new KancolleModify.PanelEx();
            this.panel2.SuspendLayout();
            this.panelAxis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(11, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 17);
            this.label25.TabIndex = 1;
            this.label25.Text = "当前编辑";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbIniPosEditContent);
            this.panel2.Controls.Add(this.btnIniText);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.cbVDStatus);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panelAxis);
            this.panel2.Controls.Add(this.txtCurrentEdit);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(802, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 480);
            this.panel2.TabIndex = 2;
            // 
            // cbIniPosEditContent
            // 
            this.cbIniPosEditContent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIniPosEditContent.FormattingEnabled = true;
            this.cbIniPosEditContent.Items.AddRange(new object[] {
            "母港立绘",
            "战斗立绘",
            "海域地图（出击中）立绘",
            "演习立绘",
            "近代化改修立绘",
            "改造界面立绘"});
            this.cbIniPosEditContent.Location = new System.Drawing.Point(73, 9);
            this.cbIniPosEditContent.Name = "cbIniPosEditContent";
            this.cbIniPosEditContent.Size = new System.Drawing.Size(94, 25);
            this.cbIniPosEditContent.TabIndex = 18;
            this.cbIniPosEditContent.SelectedIndexChanged += new System.EventHandler(this.cbIniPosEditContent_SelectedIndexChanged);
            // 
            // btnIniText
            // 
            this.btnIniText.Location = new System.Drawing.Point(26, 375);
            this.btnIniText.Name = "btnIniText";
            this.btnIniText.Size = new System.Drawing.Size(130, 27);
            this.btnIniText.TabIndex = 17;
            this.btnIniText.Text = "IniText";
            this.btnIniText.UseVisualStyleBackColor = true;
            this.btnIniText.Click += new System.EventHandler(this.btnIniText_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(26, 408);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(26, 441);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 27);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbVDStatus
            // 
            this.cbVDStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVDStatus.FormattingEnabled = true;
            this.cbVDStatus.Items.AddRange(new object[] {
            "通常",
            "中破/大破"});
            this.cbVDStatus.Location = new System.Drawing.Point(73, 40);
            this.cbVDStatus.Name = "cbVDStatus";
            this.cbVDStatus.Size = new System.Drawing.Size(94, 25);
            this.cbVDStatus.TabIndex = 5;
            this.cbVDStatus.SelectedIndexChanged += new System.EventHandler(this.cbVDStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "立绘";
            // 
            // panelAxis
            // 
            this.panelAxis.Controls.Add(this.numPosTop);
            this.panelAxis.Controls.Add(this.label5);
            this.panelAxis.Controls.Add(this.numPosLeft);
            this.panelAxis.Controls.Add(this.label4);
            this.panelAxis.Controls.Add(this.btnReset);
            this.panelAxis.Controls.Add(this.btnRestore);
            this.panelAxis.Controls.Add(this.label3);
            this.panelAxis.Controls.Add(this.label2);
            this.panelAxis.Enabled = false;
            this.panelAxis.Location = new System.Drawing.Point(11, 76);
            this.panelAxis.Name = "panelAxis";
            this.panelAxis.Size = new System.Drawing.Size(155, 167);
            this.panelAxis.TabIndex = 3;
            this.panelAxis.TabStop = false;
            this.panelAxis.Text = "坐标(偏移量)";
            // 
            // numPosTop
            // 
            this.numPosTop.Location = new System.Drawing.Point(62, 60);
            this.numPosTop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosTop.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosTop.Name = "numPosTop";
            this.numPosTop.Size = new System.Drawing.Size(61, 23);
            this.numPosTop.TabIndex = 13;
            this.numPosTop.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "px";
            // 
            // numPosLeft
            // 
            this.numPosLeft.Location = new System.Drawing.Point(62, 29);
            this.numPosLeft.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPosLeft.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numPosLeft.Name = "numPosLeft";
            this.numPosLeft.Size = new System.Drawing.Size(61, 23);
            this.numPosLeft.TabIndex = 11;
            this.numPosLeft.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "px";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(19, 129);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 27);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(19, 96);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(121, 27);
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Top";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Left";
            // 
            // txtCurrentEdit
            // 
            this.txtCurrentEdit.Location = new System.Drawing.Point(73, 9);
            this.txtCurrentEdit.Name = "txtCurrentEdit";
            this.txtCurrentEdit.ReadOnly = true;
            this.txtCurrentEdit.Size = new System.Drawing.Size(94, 23);
            this.txtCurrentEdit.TabIndex = 2;
            this.txtCurrentEdit.Visible = false;
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.Color.Black;
            this.panelEdit.Location = new System.Drawing.Point(0, 0);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(800, 480);
            this.panelEdit.TabIndex = 0;
            this.panelEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEdit_Paint);
            // 
            // FrmUIEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmUIEdit";
            this.ShowIcon = false;
            this.Text = "编辑坐标位置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUIEdit_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUIEdit_FormClosed);
            this.Load += new System.EventHandler(this.FrmUIEdit_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelAxis.ResumeLayout(false);
            this.panelAxis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelEx panelEdit;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox panelAxis;
        private System.Windows.Forms.TextBox txtCurrentEdit;
        private System.Windows.Forms.ComboBox cbVDStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniText;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numPosTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPosLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbIniPosEditContent;
    }
}