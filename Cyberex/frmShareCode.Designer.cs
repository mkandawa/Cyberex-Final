namespace ChatRecord
{
    partial class frmShareCode
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblShareCodeID = new System.Windows.Forms.Label();
            this.txtShareCompany = new System.Windows.Forms.TextBox();
            this.btnDeleteShare = new System.Windows.Forms.Button();
            this.btnClearShare = new System.Windows.Forms.Button();
            this.btnSaveShare = new System.Windows.Forms.Button();
            this.txtShareCodeTab = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lstShareCode = new EXPARCS.ListViewEx();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.lblShareCodeID);
            this.groupBox1.Controls.Add(this.txtShareCompany);
            this.groupBox1.Controls.Add(this.lstShareCode);
            this.groupBox1.Controls.Add(this.btnDeleteShare);
            this.groupBox1.Controls.Add(this.btnClearShare);
            this.groupBox1.Controls.Add(this.btnSaveShare);
            this.groupBox1.Controls.Add(this.txtShareCodeTab);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 469);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Share Code";
            // 
            // lblShareCodeID
            // 
            this.lblShareCodeID.AutoSize = true;
            this.lblShareCodeID.Location = new System.Drawing.Point(503, 16);
            this.lblShareCodeID.Name = "lblShareCodeID";
            this.lblShareCodeID.Size = new System.Drawing.Size(0, 13);
            this.lblShareCodeID.TabIndex = 15;
            // 
            // txtShareCompany
            // 
            this.txtShareCompany.Location = new System.Drawing.Point(125, 25);
            this.txtShareCompany.MaxLength = 250;
            this.txtShareCompany.Name = "txtShareCompany";
            this.txtShareCompany.Size = new System.Drawing.Size(250, 20);
            this.txtShareCompany.TabIndex = 14;
            this.txtShareCompany.TextChanged += new System.EventHandler(this.txtShareCompany_TextChanged);
            // 
            // btnDeleteShare
            // 
            this.btnDeleteShare.Location = new System.Drawing.Point(97, 51);
            this.btnDeleteShare.Name = "btnDeleteShare";
            this.btnDeleteShare.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteShare.TabIndex = 11;
            this.btnDeleteShare.Text = "Delete";
            this.btnDeleteShare.UseVisualStyleBackColor = true;
            this.btnDeleteShare.Click += new System.EventHandler(this.btnDeleteShare_Click);
            // 
            // btnClearShare
            // 
            this.btnClearShare.Location = new System.Drawing.Point(178, 51);
            this.btnClearShare.Name = "btnClearShare";
            this.btnClearShare.Size = new System.Drawing.Size(75, 23);
            this.btnClearShare.TabIndex = 10;
            this.btnClearShare.Text = "Reset";
            this.btnClearShare.UseVisualStyleBackColor = true;
            this.btnClearShare.Click += new System.EventHandler(this.btnClearShare_Click);
            // 
            // btnSaveShare
            // 
            this.btnSaveShare.Location = new System.Drawing.Point(16, 51);
            this.btnSaveShare.Name = "btnSaveShare";
            this.btnSaveShare.Size = new System.Drawing.Size(75, 23);
            this.btnSaveShare.TabIndex = 9;
            this.btnSaveShare.Text = "Save";
            this.btnSaveShare.UseVisualStyleBackColor = true;
            this.btnSaveShare.Click += new System.EventHandler(this.btnSaveShare_Click);
            // 
            // txtShareCodeTab
            // 
            this.txtShareCodeTab.Location = new System.Drawing.Point(19, 25);
            this.txtShareCodeTab.MaxLength = 4;
            this.txtShareCodeTab.Name = "txtShareCodeTab";
            this.txtShareCodeTab.Size = new System.Drawing.Size(100, 20);
            this.txtShareCodeTab.TabIndex = 8;
            this.txtShareCodeTab.TextChanged += new System.EventHandler(this.txtShareCodeTab_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(436, 12);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(118, 20);
            this.txtPass.TabIndex = 16;
            // 
            // lstShareCode
            // 
            this.lstShareCode.FullRowSelect = true;
            this.lstShareCode.GridLines = true;
            this.lstShareCode.Location = new System.Drawing.Point(16, 84);
            this.lstShareCode.Name = "lstShareCode";
            this.lstShareCode.Size = new System.Drawing.Size(538, 370);
            this.lstShareCode.TabIndex = 12;
            this.lstShareCode.UseCompatibleStateImageBehavior = false;
            this.lstShareCode.View = System.Windows.Forms.View.Details;
            this.lstShareCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstShareCode_MouseDoubleClick);
            // 
            // frmShareCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(593, 486);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShareCode";
            this.Text = "Add/Delete/Edit Share codes";
            this.Load += new System.EventHandler(this.frmShareCode_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtShareCompany;
        private EXPARCS.ListViewEx lstShareCode;
        private System.Windows.Forms.Button btnDeleteShare;
        private System.Windows.Forms.Button btnClearShare;
        private System.Windows.Forms.Button btnSaveShare;
        private System.Windows.Forms.TextBox txtShareCodeTab;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblShareCodeID;
        private System.Windows.Forms.TextBox txtPass;
    }
}