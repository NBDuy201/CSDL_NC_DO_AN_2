
namespace DBMS_G15
{
    partial class CustomerSignUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSignUpForm));
            this.btnPanel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.emailTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addressTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.phoneNumTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comfirmPassTb = new System.Windows.Forms.TextBox();
            this.comfirmpassLabel = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.btnPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPanel
            // 
            this.btnPanel.Controls.Add(this.btnCancel);
            this.btnPanel.Controls.Add(this.signUpBtn);
            this.btnPanel.Controls.Add(this.backBtn);
            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPanel.Location = new System.Drawing.Point(0, 402);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(600, 59);
            this.btnPanel.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancel.Location = new System.Drawing.Point(369, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // signUpBtn
            // 
            this.signUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.signUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.signUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpBtn.Location = new System.Drawing.Point(239, 9);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(103, 40);
            this.signUpBtn.TabIndex = 1;
            this.signUpBtn.Text = "Đăng Ký Ngay!";
            this.signUpBtn.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.backBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backBtn.Location = new System.Drawing.Point(112, 9);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(103, 40);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Quay Lại";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 56);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.emailTb);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.addressTb);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.phoneNumTb);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.nameTb);
            this.panel4.Controls.Add(this.nameLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(300, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 346);
            this.panel4.TabIndex = 21;
            // 
            // emailTb
            // 
            this.emailTb.Location = new System.Drawing.Point(128, 216);
            this.emailTb.Name = "emailTb";
            this.emailTb.Size = new System.Drawing.Size(142, 20);
            this.emailTb.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Email";
            // 
            // addressTb
            // 
            this.addressTb.Location = new System.Drawing.Point(128, 178);
            this.addressTb.Name = "addressTb";
            this.addressTb.Size = new System.Drawing.Size(142, 20);
            this.addressTb.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Địa Chỉ";
            // 
            // phoneNumTb
            // 
            this.phoneNumTb.Location = new System.Drawing.Point(128, 137);
            this.phoneNumTb.Name = "phoneNumTb";
            this.phoneNumTb.Size = new System.Drawing.Size(142, 20);
            this.phoneNumTb.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Số Điện Thoại";
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(128, 90);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(142, 20);
            this.nameTb.TabIndex = 9;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(30, 94);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(73, 16);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Họ Và Tên";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comfirmPassTb);
            this.panel3.Controls.Add(this.comfirmpassLabel);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.passwordLabel);
            this.panel3.Controls.Add(this.textBox4);
            this.panel3.Controls.Add(this.usernameLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 346);
            this.panel3.TabIndex = 20;
            // 
            // comfirmPassTb
            // 
            this.comfirmPassTb.Location = new System.Drawing.Point(142, 199);
            this.comfirmPassTb.Name = "comfirmPassTb";
            this.comfirmPassTb.Size = new System.Drawing.Size(142, 20);
            this.comfirmPassTb.TabIndex = 30;
            // 
            // comfirmpassLabel
            // 
            this.comfirmpassLabel.AutoSize = true;
            this.comfirmpassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comfirmpassLabel.Location = new System.Drawing.Point(16, 203);
            this.comfirmpassLabel.Name = "comfirmpassLabel";
            this.comfirmpassLabel.Size = new System.Drawing.Size(120, 16);
            this.comfirmpassLabel.TabIndex = 29;
            this.comfirmpassLabel.Text = "Nhập Lại Mật Khẩu";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(142, 144);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(142, 20);
            this.textBox5.TabIndex = 28;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(16, 145);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(63, 16);
            this.passwordLabel.TabIndex = 27;
            this.passwordLabel.Text = "Mật Khẩu";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(142, 90);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(142, 20);
            this.textBox4.TabIndex = 26;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(16, 94);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(103, 16);
            this.usernameLabel.TabIndex = 25;
            this.usernameLabel.Text = "Tên Đăng Nhập";
            // 
            // CustomerSignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 461);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(616, 500);
            this.MinimumSize = new System.Drawing.Size(616, 500);
            this.Name = "CustomerSignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Tài Khoản";
            this.btnPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btnPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox emailTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addressTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox phoneNumTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox comfirmPassTb;
        private System.Windows.Forms.Label comfirmpassLabel;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label usernameLabel;
    }
}