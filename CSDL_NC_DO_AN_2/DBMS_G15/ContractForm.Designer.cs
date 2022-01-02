
namespace DBMS_G15
{
    partial class ContractForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelNavigator = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.expirationDateLabel = new System.Windows.Forms.Label();
            this.beginDateLabel = new System.Windows.Forms.Label();
            this.departmentIDLabel = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDepartmentID = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.partnerIDLabel = new System.Windows.Forms.Label();
            this.tbPartnerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRepresentativeName = new System.Windows.Forms.TextBox();
            this.beginDate = new System.Windows.Forms.DateTimePicker();
            this.expirationDate = new System.Windows.Forms.DateTimePicker();
            this.commissionLabel = new System.Windows.Forms.Label();
            this.tbCommission = new System.Windows.Forms.TextBox();
            this.activationComboBox = new System.Windows.Forms.ComboBox();
            this.activationLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panelNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(736, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 583);
            this.panel2.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(0, 380);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 190);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(0, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 190);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 190);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // panelNavigator
            // 
            this.panelNavigator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(67)))), ((int)(((byte)(138)))));
            this.panelNavigator.Controls.Add(this.searchBox);
            this.panelNavigator.Controls.Add(this.btnNext);
            this.panelNavigator.Controls.Add(this.btnPrevious);
            this.panelNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNavigator.Location = new System.Drawing.Point(0, 513);
            this.panelNavigator.Name = "panelNavigator";
            this.panelNavigator.Size = new System.Drawing.Size(736, 70);
            this.panelNavigator.TabIndex = 9;
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.searchBox.Location = new System.Drawing.Point(293, 25);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(150, 20);
            this.searchBox.TabIndex = 2;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(522, 11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 50);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(114, 10);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 50);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(0, 190);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(736, 323);
            this.dataGridView1.TabIndex = 10;
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.panelDetails.Controls.Add(this.activationLabel);
            this.panelDetails.Controls.Add(this.activationComboBox);
            this.panelDetails.Controls.Add(this.commissionLabel);
            this.panelDetails.Controls.Add(this.tbCommission);
            this.panelDetails.Controls.Add(this.expirationDate);
            this.panelDetails.Controls.Add(this.beginDate);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.tbRepresentativeName);
            this.panelDetails.Controls.Add(this.partnerIDLabel);
            this.panelDetails.Controls.Add(this.tbPartnerID);
            this.panelDetails.Controls.Add(this.expirationDateLabel);
            this.panelDetails.Controls.Add(this.beginDateLabel);
            this.panelDetails.Controls.Add(this.departmentIDLabel);
            this.panelDetails.Controls.Add(this.productNameLabel);
            this.panelDetails.Controls.Add(this.idLabel);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.tbDepartmentID);
            this.panelDetails.Controls.Add(this.tbName);
            this.panelDetails.Controls.Add(this.tbID);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(736, 190);
            this.panelDetails.TabIndex = 11;
            // 
            // expirationDateLabel
            // 
            this.expirationDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expirationDateLabel.AutoSize = true;
            this.expirationDateLabel.Location = new System.Drawing.Point(621, 47);
            this.expirationDateLabel.Name = "expirationDateLabel";
            this.expirationDateLabel.Size = new System.Drawing.Size(79, 13);
            this.expirationDateLabel.TabIndex = 10;
            this.expirationDateLabel.Text = "Ngày Kết Thúc";
            // 
            // beginDateLabel
            // 
            this.beginDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.beginDateLabel.AutoSize = true;
            this.beginDateLabel.Location = new System.Drawing.Point(493, 47);
            this.beginDateLabel.Name = "beginDateLabel";
            this.beginDateLabel.Size = new System.Drawing.Size(74, 13);
            this.beginDateLabel.TabIndex = 9;
            this.beginDateLabel.Text = "Ngày Bắt Đầu";
            // 
            // departmentIDLabel
            // 
            this.departmentIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.departmentIDLabel.AutoSize = true;
            this.departmentIDLabel.Location = new System.Drawing.Point(285, 47);
            this.departmentIDLabel.Name = "departmentIDLabel";
            this.departmentIDLabel.Size = new System.Drawing.Size(75, 13);
            this.departmentIDLabel.TabIndex = 8;
            this.departmentIDLabel.Text = "Mã Chi Nhánh";
            // 
            // productNameLabel
            // 
            this.productNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(285, 92);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(66, 13);
            this.productNameLabel.TabIndex = 7;
            this.productNameLabel.Text = "Mã Số Thuế";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(53, 100);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(74, 13);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "Mã Hợp Đồng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thông Tin\r\nHợp Đồng";
            // 
            // tbDepartmentID
            // 
            this.tbDepartmentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tbDepartmentID.Location = new System.Drawing.Point(282, 111);
            this.tbDepartmentID.Name = "tbDepartmentID";
            this.tbDepartmentID.Size = new System.Drawing.Size(161, 20);
            this.tbDepartmentID.TabIndex = 3;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tbName.Location = new System.Drawing.Point(282, 63);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(161, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(53, 119);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(161, 20);
            this.tbID.TabIndex = 0;
            // 
            // partnerIDLabel
            // 
            this.partnerIDLabel.AutoSize = true;
            this.partnerIDLabel.Location = new System.Drawing.Point(53, 145);
            this.partnerIDLabel.Name = "partnerIDLabel";
            this.partnerIDLabel.Size = new System.Drawing.Size(63, 13);
            this.partnerIDLabel.TabIndex = 12;
            this.partnerIDLabel.Text = "Mã Đối Tác";
            // 
            // tbPartnerID
            // 
            this.tbPartnerID.Location = new System.Drawing.Point(53, 164);
            this.tbPartnerID.Name = "tbPartnerID";
            this.tbPartnerID.Size = new System.Drawing.Size(161, 20);
            this.tbPartnerID.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Người Đại Diện";
            // 
            // tbRepresentativeName
            // 
            this.tbRepresentativeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tbRepresentativeName.Location = new System.Drawing.Point(282, 164);
            this.tbRepresentativeName.Name = "tbRepresentativeName";
            this.tbRepresentativeName.Size = new System.Drawing.Size(161, 20);
            this.tbRepresentativeName.TabIndex = 13;
            // 
            // beginDate
            // 
            this.beginDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.beginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.beginDate.Location = new System.Drawing.Point(496, 63);
            this.beginDate.Name = "beginDate";
            this.beginDate.Size = new System.Drawing.Size(100, 20);
            this.beginDate.TabIndex = 15;
            // 
            // expirationDate
            // 
            this.expirationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expirationDate.Location = new System.Drawing.Point(624, 63);
            this.expirationDate.Name = "expirationDate";
            this.expirationDate.Size = new System.Drawing.Size(100, 20);
            this.expirationDate.TabIndex = 16;
            // 
            // commissionLabel
            // 
            this.commissionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.commissionLabel.AutoSize = true;
            this.commissionLabel.Location = new System.Drawing.Point(493, 95);
            this.commissionLabel.Name = "commissionLabel";
            this.commissionLabel.Size = new System.Drawing.Size(80, 13);
            this.commissionLabel.TabIndex = 18;
            this.commissionLabel.Text = "Tiền Hoa Hồng";
            // 
            // tbCommission
            // 
            this.tbCommission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommission.Location = new System.Drawing.Point(496, 111);
            this.tbCommission.Name = "tbCommission";
            this.tbCommission.Size = new System.Drawing.Size(161, 20);
            this.tbCommission.TabIndex = 17;
            // 
            // activationComboBox
            // 
            this.activationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.activationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.activationComboBox.FormattingEnabled = true;
            this.activationComboBox.Items.AddRange(new object[] {
            "Vô Hiệu",
            "Có Hiệu Lực"});
            this.activationComboBox.Location = new System.Drawing.Point(496, 164);
            this.activationComboBox.Name = "activationComboBox";
            this.activationComboBox.Size = new System.Drawing.Size(161, 21);
            this.activationComboBox.TabIndex = 19;
            // 
            // activationLabel
            // 
            this.activationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.activationLabel.AutoSize = true;
            this.activationLabel.Location = new System.Drawing.Point(493, 148);
            this.activationLabel.Name = "activationLabel";
            this.activationLabel.Size = new System.Drawing.Size(50, 13);
            this.activationLabel.TabIndex = 20;
            this.activationLabel.Text = "Hiệu Lực";
            // 
            // ContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(808, 583);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelNavigator);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContractForm";
            this.Text = "ContractForm";
            this.panel2.ResumeLayout(false);
            this.panelNavigator.ResumeLayout(false);
            this.panelNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelNavigator;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label expirationDateLabel;
        private System.Windows.Forms.Label beginDateLabel;
        private System.Windows.Forms.Label departmentIDLabel;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDepartmentID;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label partnerIDLabel;
        private System.Windows.Forms.TextBox tbPartnerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRepresentativeName;
        private System.Windows.Forms.DateTimePicker expirationDate;
        private System.Windows.Forms.DateTimePicker beginDate;
        private System.Windows.Forms.Label commissionLabel;
        private System.Windows.Forms.TextBox tbCommission;
        private System.Windows.Forms.ComboBox activationComboBox;
        private System.Windows.Forms.Label activationLabel;
    }
}