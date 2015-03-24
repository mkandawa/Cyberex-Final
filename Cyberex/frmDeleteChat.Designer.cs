namespace ChatRecord
{
    partial class frmDeleteChat
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkChat2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnDeleteby = new System.Windows.Forms.Button();
            this.chkEnableDate = new System.Windows.Forms.CheckBox();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbShareCode = new System.Windows.Forms.ComboBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.ChkChat2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BtnDeleteby);
            this.groupBox1.Controls.Add(this.chkEnableDate);
            this.groupBox1.Controls.Add(this.dpTo);
            this.groupBox1.Controls.Add(this.dpFrom);
            this.groupBox1.Controls.Add(this.cmbShareCode);
            this.groupBox1.Location = new System.Drawing.Point(10, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ChkChat2
            // 
            this.ChkChat2.AutoSize = true;
            this.ChkChat2.Location = new System.Drawing.Point(128, 29);
            this.ChkChat2.Name = "ChkChat2";
            this.ChkChat2.Size = new System.Drawing.Size(57, 17);
            this.ChkChat2.TabIndex = 17;
            this.ChkChat2.Text = "Chat-2";
            this.ChkChat2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "From Date :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "To Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Share Code :";
            // 
            // BtnDeleteby
            // 
            this.BtnDeleteby.Location = new System.Drawing.Point(199, 126);
            this.BtnDeleteby.Name = "BtnDeleteby";
            this.BtnDeleteby.Size = new System.Drawing.Size(75, 23);
            this.BtnDeleteby.TabIndex = 13;
            this.BtnDeleteby.Text = "Delete";
            this.BtnDeleteby.UseVisualStyleBackColor = true;
            this.BtnDeleteby.Click += new System.EventHandler(this.BtnDeleteby_Click);
            // 
            // chkEnableDate
            // 
            this.chkEnableDate.AutoSize = true;
            this.chkEnableDate.Location = new System.Drawing.Point(486, 100);
            this.chkEnableDate.Name = "chkEnableDate";
            this.chkEnableDate.Size = new System.Drawing.Size(132, 17);
            this.chkEnableDate.TabIndex = 12;
            this.chkEnableDate.Text = "Delete by Date Range";
            this.chkEnableDate.UseVisualStyleBackColor = true;
            this.chkEnableDate.CheckedChanged += new System.EventHandler(this.chkEnableDate_CheckedChanged);
            // 
            // dpTo
            // 
            this.dpTo.CustomFormat = "dd/MM/yyyy";
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpTo.Location = new System.Drawing.Point(366, 97);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(91, 20);
            this.dpTo.TabIndex = 11;
            // 
            // dpFrom
            // 
            this.dpFrom.CustomFormat = "dd/MM/yyyy";
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFrom.Location = new System.Drawing.Point(199, 100);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(91, 20);
            this.dpFrom.TabIndex = 10;
            // 
            // cmbShareCode
            // 
            this.cmbShareCode.FormattingEnabled = true;
            this.cmbShareCode.Location = new System.Drawing.Point(200, 70);
            this.cmbShareCode.Name = "cmbShareCode";
            this.cmbShareCode.Size = new System.Drawing.Size(133, 21);
            this.cmbShareCode.TabIndex = 9;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(578, 19);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 18;
            // 
            // frmDeleteChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(713, 252);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeleteChat";
            this.Text = "Delete Chat Record";
            this.Load += new System.EventHandler(this.frmDeleteChat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnDeleteby;
        private System.Windows.Forms.CheckBox chkEnableDate;
        private System.Windows.Forms.DateTimePicker dpTo;
        private System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.ComboBox cmbShareCode;
        private System.Windows.Forms.CheckBox ChkChat2;
        private System.Windows.Forms.TextBox txtPass;
    }
}