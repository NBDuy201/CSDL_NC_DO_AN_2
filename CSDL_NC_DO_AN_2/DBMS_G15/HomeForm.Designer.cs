
namespace DBMS_G15
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.userAvatar = new System.Windows.Forms.PictureBox();
            this.greetingLabel = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnMoney = new System.Windows.Forms.Button();
            this.btnPartner = new System.Windows.Forms.Button();
            this.btnDriver = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.navMenu = new System.Windows.Forms.Panel();
            this.childFormPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.childFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(15)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Controls.Add(this.userAvatar);
            this.panel1.Controls.Add(this.greetingLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1582, 105);
            this.panel1.TabIndex = 1;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.logoLabel);
            this.panelLogo.Controls.Add(this.logoPic);
            this.panelLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(370, 105);
            this.panelLogo.TabIndex = 2;
            this.panelLogo.Click += new System.EventHandler(this.panelLogo_Click);
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.BackColor = System.Drawing.Color.Transparent;
            this.logoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.logoLabel.Location = new System.Drawing.Point(174, 31);
            this.logoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(157, 40);
            this.logoLabel.TabIndex = 4;
            this.logoLabel.Text = "ADB1_7";
            this.logoLabel.Click += new System.EventHandler(this.logoLabel_Click);
            // 
            // logoPic
            // 
            this.logoPic.BackColor = System.Drawing.Color.Transparent;
            this.logoPic.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoPic.Image = ((System.Drawing.Image)(resources.GetObject("logoPic.Image")));
            this.logoPic.Location = new System.Drawing.Point(0, 0);
            this.logoPic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(142, 105);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.TabIndex = 3;
            this.logoPic.TabStop = false;
            this.logoPic.Click += new System.EventHandler(this.logoPic_Click);
            // 
            // userAvatar
            // 
            this.userAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userAvatar.Image = ((System.Drawing.Image)(resources.GetObject("userAvatar.Image")));
            this.userAvatar.Location = new System.Drawing.Point(1461, 14);
            this.userAvatar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userAvatar.Name = "userAvatar";
            this.userAvatar.Size = new System.Drawing.Size(122, 77);
            this.userAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userAvatar.TabIndex = 3;
            this.userAvatar.TabStop = false;
            // 
            // greetingLabel
            // 
            this.greetingLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.greetingLabel.AutoSize = true;
            this.greetingLabel.BackColor = System.Drawing.Color.Transparent;
            this.greetingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greetingLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.greetingLabel.Location = new System.Drawing.Point(904, 31);
            this.greetingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(355, 40);
            this.greetingLabel.TabIndex = 1;
            this.greetingLabel.Text = "Xin chào, username";
            this.greetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuPanel
            // 
            this.menuPanel.AutoScroll = true;
            this.menuPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.btnMoney);
            this.menuPanel.Controls.Add(this.btnPartner);
            this.menuPanel.Controls.Add(this.btnDriver);
            this.menuPanel.Controls.Add(this.btnStaff);
            this.menuPanel.Controls.Add(this.btnCustomer);
            this.menuPanel.Controls.Add(this.btnOrder);
            this.menuPanel.Controls.Add(this.btnProduct);
            this.menuPanel.Controls.Add(this.btnProfile);
            this.menuPanel.Controls.Add(this.btnLogout);
            this.menuPanel.Controls.Add(this.navMenu);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 105);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(396, 897);
            this.menuPanel.TabIndex = 2;
            // 
            // btnMoney
            // 
            this.btnMoney.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnMoney.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoney.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMoney.FlatAppearance.BorderSize = 0;
            this.btnMoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoney.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMoney.Image = ((System.Drawing.Image)(resources.GetObject("btnMoney.Image")));
            this.btnMoney.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMoney.Location = new System.Drawing.Point(0, 756);
            this.btnMoney.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMoney.Name = "btnMoney";
            this.btnMoney.Size = new System.Drawing.Size(368, 108);
            this.btnMoney.TabIndex = 19;
            this.btnMoney.Text = "  Thống Kê";
            this.btnMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoney.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMoney.UseVisualStyleBackColor = false;
            this.btnMoney.Click += new System.EventHandler(this.btnMoney_Click);
            // 
            // btnPartner
            // 
            this.btnPartner.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPartner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPartner.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPartner.FlatAppearance.BorderSize = 0;
            this.btnPartner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartner.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartner.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPartner.Image = ((System.Drawing.Image)(resources.GetObject("btnPartner.Image")));
            this.btnPartner.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPartner.Location = new System.Drawing.Point(0, 648);
            this.btnPartner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPartner.Name = "btnPartner";
            this.btnPartner.Size = new System.Drawing.Size(368, 108);
            this.btnPartner.TabIndex = 17;
            this.btnPartner.Text = "  Cung Cấp";
            this.btnPartner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPartner.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPartner.UseVisualStyleBackColor = false;
            this.btnPartner.Click += new System.EventHandler(this.btnPartner_Click);
            // 
            // btnDriver
            // 
            this.btnDriver.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnDriver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDriver.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDriver.FlatAppearance.BorderSize = 0;
            this.btnDriver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDriver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDriver.Image = ((System.Drawing.Image)(resources.GetObject("btnDriver.Image")));
            this.btnDriver.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDriver.Location = new System.Drawing.Point(0, 540);
            this.btnDriver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDriver.Name = "btnDriver";
            this.btnDriver.Size = new System.Drawing.Size(368, 108);
            this.btnDriver.TabIndex = 16;
            this.btnDriver.Text = "  Nhận Đơn";
            this.btnDriver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDriver.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDriver.UseVisualStyleBackColor = false;
            this.btnDriver.Click += new System.EventHandler(this.btnDriver_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStaff.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStaff.Image = ((System.Drawing.Image)(resources.GetObject("btnStaff.Image")));
            this.btnStaff.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStaff.Location = new System.Drawing.Point(0, 432);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(368, 108);
            this.btnStaff.TabIndex = 15;
            this.btnStaff.Text = "  Nhân Viên";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCustomer.Location = new System.Drawing.Point(0, 324);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(368, 108);
            this.btnCustomer.TabIndex = 14;
            this.btnCustomer.Text = "  Khách Hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOrder.Location = new System.Drawing.Point(0, 216);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(368, 108);
            this.btnOrder.TabIndex = 13;
            this.btnOrder.Text = "  Đơn Hàng";
            this.btnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProduct.Location = new System.Drawing.Point(0, 108);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(368, 108);
            this.btnProduct.TabIndex = 12;
            this.btnProduct.Text = "  Sản Phẩm";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnProfile.Image")));
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfile.Location = new System.Drawing.Point(0, 0);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(368, 108);
            this.btnProfile.TabIndex = 11;
            this.btnProfile.Text = "  Hồ Sơ";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Orange;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 864);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(368, 108);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "  Đăng Xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // navMenu
            // 
            this.navMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.navMenu.Location = new System.Drawing.Point(0, 0);
            this.navMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navMenu.Name = "navMenu";
            this.navMenu.Size = new System.Drawing.Size(15, 108);
            this.navMenu.TabIndex = 10;
            // 
            // childFormPanel
            // 
            this.childFormPanel.Controls.Add(this.label10);
            this.childFormPanel.Controls.Add(this.label9);
            this.childFormPanel.Controls.Add(this.label8);
            this.childFormPanel.Controls.Add(this.label7);
            this.childFormPanel.Controls.Add(this.label6);
            this.childFormPanel.Controls.Add(this.label5);
            this.childFormPanel.Controls.Add(this.label4);
            this.childFormPanel.Controls.Add(this.label3);
            this.childFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childFormPanel.Location = new System.Drawing.Point(396, 105);
            this.childFormPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.childFormPanel.Name = "childFormPanel";
            this.childFormPanel.Size = new System.Drawing.Size(1186, 897);
            this.childFormPanel.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(484, 461);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(321, 40);
            this.label10.TabIndex = 7;
            this.label10.Text = "Trương Minh Nhựt";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(484, 534);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 40);
            this.label9.TabIndex = 6;
            this.label9.Text = "Nguyễn Bảo Duy";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(484, 382);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(290, 40);
            this.label8.TabIndex = 5;
            this.label8.Text = "Phạm Anh Tuấn";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(287, 461);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 40);
            this.label7.TabIndex = 4;
            this.label7.Text = "19127237";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(291, 534);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 40);
            this.label6.TabIndex = 3;
            this.label6.Text = "19127498";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(287, 382);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 40);
            this.label5.TabIndex = 2;
            this.label5.Text = "19127084";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(484, 294);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 40);
            this.label4.TabIndex = 1;
            this.label4.Text = "Họ và Tên";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 294);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "MSSV";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1582, 1002);
            this.Controls.Add(this.childFormPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1596, 1006);
            this.Name = "HomeForm";
            this.Text = "ConCung";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAvatar)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.childFormPanel.ResumeLayout(false);
            this.childFormPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.PictureBox userAvatar;
        private System.Windows.Forms.Panel childFormPanel;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel navMenu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPartner;
        private System.Windows.Forms.Button btnDriver;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnMoney;
    }
}