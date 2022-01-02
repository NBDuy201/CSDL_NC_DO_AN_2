using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMS_G15
{
    public partial class PartnerForm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tablePartner = new DataTable();
        string str = @"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True";
        string placeholder = "Nhập tên đối tác...";

        private int offset;
        const int maxRowsPerPage = 15;
        public PartnerForm()
        {
            InitializeComponent();
        }

        

        private void autoLoadPartnerData()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "exec ViewPartnerListWith_n_Rows @offset, @rows";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@offset", offset);
                command.Parameters.AddWithValue("@rows", maxRowsPerPage);
                adapter.SelectCommand = command;
                tablePartner.Clear();
                adapter.Fill(tablePartner);
                PartnerDGV.DataSource = tablePartner;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.");
            }
        }

        private void panelDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    if (tbID.Text.Trim() == "")
                    {
                        MessageBox.Show("Hãy chọn đối tác để xóa.");
                    }
                    else
                    {
                        SqlCommand checkPartnerExisted = new SqlCommand("select * from DOITAC where MaDT=@MaDT", connection);
                        checkPartnerExisted.Parameters.AddWithValue("@MaDT", tbID.Text);
                        SqlDataReader reader = checkPartnerExisted.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Close();
                            DialogResult confirm = MessageBox.Show("Xác nhận xóa đối tác này?", "Xóa Đối tác", MessageBoxButtons.YesNo);
                            if (confirm == DialogResult.Yes)
                            {
                                SqlCommand deleteCommand = new SqlCommand("exec deleteDT @MaDT", connection);
                                deleteCommand.Parameters.AddWithValue("@MaDT", tbID.Text);
                                deleteCommand.ExecuteNonQuery();
                                tbID.Text = "";
                                tbName.Text = "";
                                tbCity.Text = "";
                                tbDistrict.Text = "";
                                tbAddress.Text = "";
                                tbPhone.Text = "";
                                tbRepresentative.Text = "";
                                tbMaxOrder.Text = "";
                                tbProductType.Text = "";
                                tbChiNhanh.Text = "";
                                offset = 0;
                                autoLoadPartnerData();
                                MessageBox.Show("Xóa Đối tác thành công.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đối tác không tồn tại.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            //{
            //    try
            //    {
            //        connection.Open();
            //        SqlCommand checkProductExisted = new SqlCommand("select * from DOITAC where MaDT=@MaDT", connection);
            //        checkProductExisted.Parameters.AddWithValue("@MaSP", tbID.Text);
            //        SqlDataReader reader = checkProductExisted.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            reader.Close();
            //            DialogResult confirm = MessageBox.Show("Xác nhận cập nhật thông tin đối tác này?", "Cập Nhật Đối Tác", MessageBoxButtons.YesNo);
            //            if (confirm == DialogResult.Yes)
            //            {
            //                SqlCommand updateCommand = new SqlCommand("exec updateSP @MaSP, @TenSP, @Gia, @MoTa", connection);
            //                updateCommand.Parameters.AddWithValue("@MaSP", tbID.Text);
            //                updateCommand.Parameters.AddWithValue("@TenSP", tbName.Text);
            //                updateCommand.Parameters.AddWithValue("@Gia", tbPrice.Text);
            //                updateCommand.Parameters.AddWithValue("@MoTa", tbDescription.Text);
            //                updateCommand.ExecuteNonQuery();
            //                autoLoadPartnerData();
            //                MessageBox.Show("Cập nhật sản phẩm thành công");
            //                //loadAfterSave();
            //            }
            //        }
            //        else
            //        {
            //            reader.Close();
            //            MessageBox.Show("Đối tác không tồn tại.");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void rightSideMenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelNavigator_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbAddress.Text == "" || tbRepresentative.Text == "" || tbCity.Text == "" || tbDistrict.Text == "" || tbProductType.Text == "" || tbChiNhanh.Text == "" || tbMaxOrder.Text == "" || tbPhone.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Xác nhận thêm đối tác này?", "Thêm đối tác", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand AddDT = new SqlCommand("exec addDT @TenDT,@NguoiDaiDien,@ThanhPho,@Quan,@SoChiNhanh,@SLDonHang,@LoaiHang,@DiaChiKD,@SDT");
                        AddDT.Parameters.AddWithValue("@TenDT", tbName.Text);
                        AddDT.Parameters.AddWithValue("@NguoiDaiDien", tbRepresentative.Text);
                        AddDT.Parameters.AddWithValue("@ThanhPho", tbCity.Text);
                        AddDT.Parameters.AddWithValue("@Quan", tbDistrict.Text);
                        AddDT.Parameters.AddWithValue("@SoChiNhanh", tbChiNhanh.Text);
                        AddDT.Parameters.AddWithValue("@SLDonHang", tbMaxOrder.Text);
                        AddDT.Parameters.AddWithValue("@LoaiHang", tbProductType.Text);
                        AddDT.Parameters.AddWithValue("@DiaChiKD", tbAddress.Text);
                        AddDT.Parameters.AddWithValue("@SDT", tbPhone.Text);
                        AddDT.ExecuteNonQuery();
                        autoLoadPartnerData();
                        MessageBox.Show("Thêm Đối Tác thành công");
                        //loadAfterAdd();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void loadAfterAdd()
        {
            DataTable tb = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from DOITAC where TenDT = @TenDT";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@TenDT", tbName.Text);
            adapter.SelectCommand = command;
            tb.Clear();
            adapter.Fill(tb);
            tbID.Text = tb.Rows[0]["MaDT"].ToString();
            tbName.Text = tb.Rows[0]["TenDT"].ToString();
            tbRepresentative.Text = tb.Rows[0]["NguoiDaiDien"].ToString();
            tbCity.Text = tb.Rows[0]["ThanhPho"].ToString();
            tbDistrict.Text = tb.Rows[0]["Quan"].ToString();
            tbChiNhanh.Text = tb.Rows[0]["SoChiNhanh"].ToString();
            tbMaxOrder.Text = tb.Rows[0]["SLDonHang"].ToString();
            tbProductType.Text = tb.Rows[0]["LoaiHang"].ToString();
            tbAddress.Text = tb.Rows[0]["DiaChiKinhDoanh"].ToString();
            tbPhone.Text = tb.Rows[0]["SoDienThoai"].ToString();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbID.Text = "";
            tbName.Text = "";
            tbCity.Text = "";
            tbDistrict.Text = "";
            tbAddress.Text= "";
            tbPhone.Text = "";
            tbRepresentative.Text = "";
            tbMaxOrder.Text = "";
            tbProductType.Text = "";
            tbChiNhanh.Text = "";
            offset = 0;
            autoLoadPartnerData();
        }

        private void PartnerForm_Load(object sender, EventArgs e)
        {
                connection = new SqlConnection(str);
                connection.Open();
                autoLoadPartnerData();
                btnPrevious.Enabled = false;
                searchBox.Text = placeholder;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            offset += maxRowsPerPage;
            try
            {
                autoLoadPartnerData();
                btnPrevious.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            offset -= maxRowsPerPage;
            if (offset <= 0)
            {
                offset = 0;
                btnPrevious.Enabled = false;
            }
            autoLoadPartnerData();
        }

        private void PartnerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = PartnerDGV.CurrentCell.RowIndex;
            tbID.Text = PartnerDGV.Rows[rowIndex].Cells[0].Value.ToString(); ;
            tbName.Text = PartnerDGV.Rows[rowIndex].Cells[1].Value.ToString();
            tbRepresentative.Text = PartnerDGV.Rows[rowIndex].Cells[2].Value.ToString();
            tbCity.Text = PartnerDGV.Rows[rowIndex].Cells[3].Value.ToString();;
            tbDistrict.Text = PartnerDGV.Rows[rowIndex].Cells[4].Value.ToString();
            tbChiNhanh.Text = PartnerDGV.Rows[rowIndex].Cells[5].Value.ToString();
            tbMaxOrder.Text = PartnerDGV.Rows[rowIndex].Cells[6].Value.ToString();
            tbProductType.Text = PartnerDGV.Rows[rowIndex].Cells[7].Value.ToString();
            tbAddress.Text = PartnerDGV.Rows[rowIndex].Cells[8].Value.ToString();
            tbPhone.Text = PartnerDGV.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == placeholder)
                searchBox.Text = "";
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
                searchBox.Text = placeholder;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searchBox.Text != placeholder && searchBox.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from DOITAC where TenDT like '%' + @TenDT + '%'";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@TenDT", searchBox.Text);
                adapter.SelectCommand = command;
                tablePartner.Clear();
                adapter.Fill(tablePartner);
                PartnerDGV.DataSource = tablePartner;
                searchBox.Text = placeholder;
            }
            else
            {
                MessageBox.Show("Hãy nhập tên sản phẩm.");
            }
        }
    }
}
