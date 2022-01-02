
namespace DBMS_G15
{
    partial class DoanhThu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderDGV = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panelNavigator = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.ThongKe = new System.Windows.Forms.Button();
            this.Ngày = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.YearTb = new System.Windows.Forms.TextBox();
            this.MonthTb = new System.Windows.Forms.TextBox();
            this.DoanhThuDGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDGV)).BeginInit();
            this.panel5.SuspendLayout();
            this.panelNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DoanhThuDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 116);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.OrderDGV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 627);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.MonthTb);
            this.panel3.Controls.Add(this.YearTb);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.Ngày);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 743);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(579, 154);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DoanhThuDGV);
            this.panel4.Controls.Add(this.ThongKe);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(579, 743);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(607, 154);
            this.panel4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(390, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH HÓA ĐƠN";
            // 
            // OrderDGV
            // 
            this.OrderDGV.AllowUserToAddRows = false;
            this.OrderDGV.AllowUserToDeleteRows = false;
            this.OrderDGV.AllowUserToOrderColumns = true;
            this.OrderDGV.AllowUserToResizeColumns = false;
            this.OrderDGV.AllowUserToResizeRows = false;
            this.OrderDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.OrderDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderDGV.Location = new System.Drawing.Point(0, 0);
            this.OrderDGV.Name = "OrderDGV";
            this.OrderDGV.ReadOnly = true;
            this.OrderDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.OrderDGV.RowTemplate.Height = 28;
            this.OrderDGV.Size = new System.Drawing.Size(1186, 627);
            this.OrderDGV.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panelNavigator);
            this.panel5.Controls.Add(this.btnNext);
            this.panel5.Controls.Add(this.btnPrevious);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 512);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1186, 115);
            this.panel5.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(835, 20);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(150, 77);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(201, 18);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(150, 77);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            // 
            // panelNavigator
            // 
            this.panelNavigator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(67)))), ((int)(((byte)(138)))));
            this.panelNavigator.Controls.Add(this.button1);
            this.panelNavigator.Controls.Add(this.button2);
            this.panelNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNavigator.Location = new System.Drawing.Point(0, 0);
            this.panelNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelNavigator.Name = "panelNavigator";
            this.panelNavigator.Size = new System.Drawing.Size(1186, 115);
            this.panelNavigator.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(865, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 77);
            this.button1.TabIndex = 1;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(171, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 77);
            this.button2.TabIndex = 0;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnReload.Image = global::DBMS_G15.Properties.Resources.reload;
            this.btnReload.Location = new System.Drawing.Point(1142, 79);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(44, 37);
            this.btnReload.TabIndex = 13;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // ThongKe
            // 
            this.ThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThongKe.Location = new System.Drawing.Point(86, 40);
            this.ThongKe.Name = "ThongKe";
            this.ThongKe.Size = new System.Drawing.Size(164, 81);
            this.ThongKe.TabIndex = 1;
            this.ThongKe.Text = "Thống Kê";
            this.ThongKe.UseVisualStyleBackColor = true;
            this.ThongKe.Click += new System.EventHandler(this.ThongKe_Click);
            // 
            // Ngày
            // 
            this.Ngày.AutoSize = true;
            this.Ngày.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ngày.Location = new System.Drawing.Point(320, 48);
            this.Ngày.Name = "Ngày";
            this.Ngày.Size = new System.Drawing.Size(181, 32);
            this.Ngày.TabIndex = 0;
            this.Ngày.Text = "Chọn Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn Năm";
            // 
            // YearTb
            // 
            this.YearTb.Location = new System.Drawing.Point(83, 81);
            this.YearTb.Name = "YearTb";
            this.YearTb.Size = new System.Drawing.Size(117, 26);
            this.YearTb.TabIndex = 2;
            // 
            // MonthTb
            // 
            this.MonthTb.Location = new System.Drawing.Point(326, 81);
            this.MonthTb.Name = "MonthTb";
            this.MonthTb.Size = new System.Drawing.Size(122, 26);
            this.MonthTb.TabIndex = 3;
            // 
            // DoanhThuDGV
            // 
            this.DoanhThuDGV.AllowUserToAddRows = false;
            this.DoanhThuDGV.AllowUserToDeleteRows = false;
            this.DoanhThuDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DoanhThuDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DoanhThuDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DoanhThuDGV.Location = new System.Drawing.Point(301, 8);
            this.DoanhThuDGV.Name = "DoanhThuDGV";
            this.DoanhThuDGV.ReadOnly = true;
            this.DoanhThuDGV.RowHeadersWidth = 62;
            this.DoanhThuDGV.RowTemplate.Height = 28;
            this.DoanhThuDGV.Size = new System.Drawing.Size(267, 137);
            this.DoanhThuDGV.TabIndex = 2;
            // 
            // DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 897);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1186, 897);
            this.Name = "DoanhThu";
            this.Load += new System.EventHandler(this.DoanhThu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDGV)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panelNavigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DoanhThuDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView OrderDGV;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Panel panelNavigator;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox MonthTb;
        private System.Windows.Forms.TextBox YearTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Ngày;
        private System.Windows.Forms.Button ThongKe;
        private System.Windows.Forms.DataGridView DoanhThuDGV;
    }
}