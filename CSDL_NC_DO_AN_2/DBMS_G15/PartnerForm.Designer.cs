
namespace DBMS_G15
{
    partial class PartnerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartnerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rightSideMenuPanel = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelNavigator = new System.Windows.Forms.Panel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.PartnerDGV = new System.Windows.Forms.DataGridView();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.productTypeLabel = new System.Windows.Forms.Label();
            this.tbProductType = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.districtLabel = new System.Windows.Forms.Label();
            this.tbDistrict = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.maxNumOrderLabel = new System.Windows.Forms.Label();
            this.numOfDepartmentLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.representativeNameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaxOrder = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbChiNhanh = new System.Windows.Forms.TextBox();
            this.tbRepresentative = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.rightSideMenuPanel.SuspendLayout();
            this.panelNavigator.SuspendLayout();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // rightSideMenuPanel
            // 
            this.rightSideMenuPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rightSideMenuPanel.Controls.Add(this.btnDelete);
            this.rightSideMenuPanel.Controls.Add(this.btnSave);
            this.rightSideMenuPanel.Controls.Add(this.btnAdd);
            this.rightSideMenuPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSideMenuPanel.Location = new System.Drawing.Point(736, 0);
            this.rightSideMenuPanel.Name = "rightSideMenuPanel";
            this.rightSideMenuPanel.Size = new System.Drawing.Size(72, 512);
            this.rightSideMenuPanel.TabIndex = 4;
            this.rightSideMenuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.rightSideMenuPanel_Paint);
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
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Lưu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelNavigator
            // 
            this.panelNavigator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(67)))), ((int)(((byte)(138)))));
            this.panelNavigator.Controls.Add(this.searchBtn);
            this.panelNavigator.Controls.Add(this.searchBox);
            this.panelNavigator.Controls.Add(this.btnNext);
            this.panelNavigator.Controls.Add(this.btnPrevious);
            this.panelNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNavigator.Location = new System.Drawing.Point(0, 442);
            this.panelNavigator.Name = "panelNavigator";
            this.panelNavigator.Size = new System.Drawing.Size(736, 70);
            this.panelNavigator.TabIndex = 6;
            this.panelNavigator.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNavigator_Paint);
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.searchBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchBtn.Location = new System.Drawing.Point(331, 44);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 4;
            this.searchBtn.Text = "Tìm";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.searchBox.Location = new System.Drawing.Point(293, 25);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(150, 20);
            this.searchBox.TabIndex = 2;
            this.searchBox.Enter += new System.EventHandler(this.searchBox_Enter);
            this.searchBox.Leave += new System.EventHandler(this.searchBox_Leave);
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
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
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
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.panelDetails.Controls.Add(this.btnReload);
            this.panelDetails.Controls.Add(this.PartnerDGV);
            this.panelDetails.Controls.Add(this.phoneLabel);
            this.panelDetails.Controls.Add(this.tbPhone);
            this.panelDetails.Controls.Add(this.productTypeLabel);
            this.panelDetails.Controls.Add(this.tbProductType);
            this.panelDetails.Controls.Add(this.addressLabel);
            this.panelDetails.Controls.Add(this.tbAddress);
            this.panelDetails.Controls.Add(this.districtLabel);
            this.panelDetails.Controls.Add(this.tbDistrict);
            this.panelDetails.Controls.Add(this.nameLabel);
            this.panelDetails.Controls.Add(this.tbName);
            this.panelDetails.Controls.Add(this.maxNumOrderLabel);
            this.panelDetails.Controls.Add(this.numOfDepartmentLabel);
            this.panelDetails.Controls.Add(this.cityLabel);
            this.panelDetails.Controls.Add(this.representativeNameLabel);
            this.panelDetails.Controls.Add(this.idLabel);
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.tbMaxOrder);
            this.panelDetails.Controls.Add(this.tbCity);
            this.panelDetails.Controls.Add(this.tbChiNhanh);
            this.panelDetails.Controls.Add(this.tbRepresentative);
            this.panelDetails.Controls.Add(this.tbID);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(736, 442);
            this.panelDetails.TabIndex = 8;
            this.panelDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDetails_Paint);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.Image = global::DBMS_G15.Properties.Resources.reload;
            this.btnReload.Location = new System.Drawing.Point(707, 97);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(29, 24);
            this.btnReload.TabIndex = 12;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // PartnerDGV
            // 
            this.PartnerDGV.AllowUserToAddRows = false;
            this.PartnerDGV.AllowUserToDeleteRows = false;
            this.PartnerDGV.AllowUserToResizeColumns = false;
            this.PartnerDGV.AllowUserToResizeRows = false;
            this.PartnerDGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PartnerDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PartnerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartnerDGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PartnerDGV.GridColor = System.Drawing.Color.Gainsboro;
            this.PartnerDGV.Location = new System.Drawing.Point(0, 119);
            this.PartnerDGV.Name = "PartnerDGV";
            this.PartnerDGV.ReadOnly = true;
            this.PartnerDGV.RowHeadersWidth = 62;
            this.PartnerDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PartnerDGV.Size = new System.Drawing.Size(736, 323);
            this.PartnerDGV.TabIndex = 21;
            this.PartnerDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartnerDGV_CellClick);
            // 
            // phoneLabel
            // 
            this.phoneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(522, 142);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(75, 13);
            this.phoneLabel.TabIndex = 20;
            this.phoneLabel.Text = "Số Điện Thoại";
            // 
            // tbPhone
            // 
            this.tbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhone.Location = new System.Drawing.Point(522, 161);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(161, 20);
            this.tbPhone.TabIndex = 19;
            // 
            // productTypeLabel
            // 
            this.productTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.productTypeLabel.AutoSize = true;
            this.productTypeLabel.Location = new System.Drawing.Point(522, 7);
            this.productTypeLabel.Name = "productTypeLabel";
            this.productTypeLabel.Size = new System.Drawing.Size(56, 13);
            this.productTypeLabel.TabIndex = 18;
            this.productTypeLabel.Text = "Loại Hàng";
            // 
            // tbProductType
            // 
            this.tbProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProductType.Location = new System.Drawing.Point(522, 26);
            this.tbProductType.Name = "tbProductType";
            this.tbProductType.Size = new System.Drawing.Size(161, 20);
            this.tbProductType.TabIndex = 17;
            // 
            // addressLabel
            // 
            this.addressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(288, 143);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(100, 13);
            this.addressLabel.TabIndex = 16;
            this.addressLabel.Text = "Địa Chỉ Kinh Doanh";
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tbAddress.Location = new System.Drawing.Point(288, 161);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(161, 20);
            this.tbAddress.TabIndex = 15;
            // 
            // districtLabel
            // 
            this.districtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.districtLabel.AutoSize = true;
            this.districtLabel.Location = new System.Drawing.Point(289, 100);
            this.districtLabel.Name = "districtLabel";
            this.districtLabel.Size = new System.Drawing.Size(33, 13);
            this.districtLabel.TabIndex = 14;
            this.districtLabel.Text = "Quận";
            // 
            // tbDistrict
            // 
            this.tbDistrict.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDistrict.Location = new System.Drawing.Point(288, 118);
            this.tbDistrict.Name = "tbDistrict";
            this.tbDistrict.Size = new System.Drawing.Size(161, 20);
            this.tbDistrict.TabIndex = 13;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(53, 147);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(26, 13);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Tên";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(53, 163);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(161, 20);
            this.tbName.TabIndex = 11;
            // 
            // maxNumOrderLabel
            // 
            this.maxNumOrderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxNumOrderLabel.AutoSize = true;
            this.maxNumOrderLabel.Location = new System.Drawing.Point(522, 97);
            this.maxNumOrderLabel.Name = "maxNumOrderLabel";
            this.maxNumOrderLabel.Size = new System.Drawing.Size(148, 13);
            this.maxNumOrderLabel.TabIndex = 10;
            this.maxNumOrderLabel.Text = "Đơn Hàng Tối Đa Hàng Ngày";
            // 
            // numOfDepartmentLabel
            // 
            this.numOfDepartmentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOfDepartmentLabel.AutoSize = true;
            this.numOfDepartmentLabel.Location = new System.Drawing.Point(522, 52);
            this.numOfDepartmentLabel.Name = "numOfDepartmentLabel";
            this.numOfDepartmentLabel.Size = new System.Drawing.Size(73, 13);
            this.numOfDepartmentLabel.TabIndex = 9;
            this.numOfDepartmentLabel.Text = "Số Chi Nhánh";
            // 
            // cityLabel
            // 
            this.cityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(288, 57);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(60, 13);
            this.cityLabel.TabIndex = 8;
            this.cityLabel.Text = "Thành Phố";
            // 
            // representativeNameLabel
            // 
            this.representativeNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.representativeNameLabel.AutoSize = true;
            this.representativeNameLabel.Location = new System.Drawing.Point(288, 14);
            this.representativeNameLabel.Name = "representativeNameLabel";
            this.representativeNameLabel.Size = new System.Drawing.Size(79, 13);
            this.representativeNameLabel.TabIndex = 7;
            this.representativeNameLabel.Text = "Người Đại Diện";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(53, 102);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(63, 13);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "Mã Đối Tác";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thông Tin\r\nĐối Tác";
            // 
            // tbMaxOrder
            // 
            this.tbMaxOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMaxOrder.Location = new System.Drawing.Point(522, 116);
            this.tbMaxOrder.Name = "tbMaxOrder";
            this.tbMaxOrder.Size = new System.Drawing.Size(161, 20);
            this.tbMaxOrder.TabIndex = 4;
            // 
            // tbCity
            // 
            this.tbCity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbCity.Location = new System.Drawing.Point(288, 75);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(161, 20);
            this.tbCity.TabIndex = 3;
            // 
            // tbChiNhanh
            // 
            this.tbChiNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChiNhanh.Location = new System.Drawing.Point(522, 71);
            this.tbChiNhanh.Name = "tbChiNhanh";
            this.tbChiNhanh.Size = new System.Drawing.Size(161, 20);
            this.tbChiNhanh.TabIndex = 2;
            // 
            // tbRepresentative
            // 
            this.tbRepresentative.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbRepresentative.Location = new System.Drawing.Point(288, 32);
            this.tbRepresentative.Name = "tbRepresentative";
            this.tbRepresentative.Size = new System.Drawing.Size(161, 20);
            this.tbRepresentative.TabIndex = 1;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(53, 118);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(161, 20);
            this.tbID.TabIndex = 0;
            // 
            // PartnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(808, 512);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelNavigator);
            this.Controls.Add(this.rightSideMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PartnerForm";
            this.Text = "Partner";
            this.Load += new System.EventHandler(this.PartnerForm_Load);
            this.rightSideMenuPanel.ResumeLayout(false);
            this.panelNavigator.ResumeLayout(false);
            this.panelNavigator.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartnerDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rightSideMenuPanel;
        private System.Windows.Forms.Panel panelNavigator;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label maxNumOrderLabel;
        private System.Windows.Forms.Label numOfDepartmentLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label representativeNameLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaxOrder;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbChiNhanh;
        private System.Windows.Forms.TextBox tbRepresentative;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label districtLabel;
        private System.Windows.Forms.TextBox tbDistrict;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label productTypeLabel;
        private System.Windows.Forms.TextBox tbProductType;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView PartnerDGV;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button searchBtn;
    }
}