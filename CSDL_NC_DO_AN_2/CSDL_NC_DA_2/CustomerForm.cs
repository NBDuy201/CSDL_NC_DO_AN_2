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
    public partial class CustomerForm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        string str = @"Data Source = (local); Initial Catalog = DBMS_ThucHanh_Nhom15; Integrated Security = True";
        string placeholder = "Nhập số điện thoại...";

        private int offset;
        const int maxRowsPerPage = 15;
        public CustomerForm()
        {
            InitializeComponent();
            connection = new SqlConnection(str);
            offset = 0;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                autoLoadData();
                searchBox.Text = placeholder;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
            }
        }
        void autoLoadData()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "select kh.MaKH, tt.HoTen, tt.SoDienThoai, tt.DiaChi, tt.Email from THONGTINCANHAN tt, KHACHHANG kh where tt.ID = kh.ID order by MaKH offset @offset rows fetch next @rows rows only";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@offset", offset);
                command.Parameters.AddWithValue("@rows", maxRowsPerPage);
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                customerDGV.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            offset += 10;
            try
            {
                autoLoadData();
                btnPrevious.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            offset -= 10;
            if (offset <= 0)
            {
                offset = 0;
                btnPrevious.Enabled = false;
            }
            autoLoadData();
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
        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                try
                {
                    if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbEmail.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    }
                    else
                    {
                        DialogResult confirm = MessageBox.Show("Xác nhận sửa khách hàng này?", "Sửa Khách Hàng", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            connection.Open();
                            SqlCommand SaveCommand = new SqlCommand("update THONGTINCANHAN set HoTen = @HoTen, SoDienThoai = @SDT, DiaChi = @DiaChi, Email = @Email where ID = (select ID from KHACHHANG where MaKH = @MaKH)", connection);
                            SaveCommand.Parameters.AddWithValue("@HoTen", tbName.Text);
                            SaveCommand.Parameters.AddWithValue("@SDT", tbPhone.Text);
                            SaveCommand.Parameters.AddWithValue("@DiaChi", tbAddress.Text);
                            SaveCommand.Parameters.AddWithValue("@Email", tbEmail.Text);
                            SaveCommand.Parameters.AddWithValue("@MaKH", tbID.Text);
                            SaveCommand.ExecuteNonQuery();
                            autoLoadData();
                            MessageBox.Show("Chỉnh sửa thông tin thành công.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void customerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = customerDGV.CurrentCell.RowIndex;
            tbID.Text = customerDGV.Rows[rowIndex].Cells[0].Value.ToString();
            tbName.Text = customerDGV.Rows[rowIndex].Cells[1].Value.ToString();
            tbPhone.Text = customerDGV.Rows[rowIndex].Cells[2].Value.ToString();
            tbAddress.Text = customerDGV.Rows[rowIndex].Cells[3].Value.ToString();
            tbEmail.Text = customerDGV.Rows[rowIndex].Cells[4].Value.ToString();
        }
        private void loadAfterAdd()
        {
            DataTable tb = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select kh.MaKH, tt.HoTen, tt.SoDienThoai, tt.DiaChi, tt.Email from THONGTINCANHAN tt, KHACHHANG kh where tt.ID = kh.ID and SoDienThoai = @SoDienThoai";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);
            adapter.SelectCommand = command;
            tb.Clear();
            adapter.Fill(tb);
            tbID.Text = tb.Rows[0]["MaKH"].ToString();
            tbName.Text = tb.Rows[0]["HoTen"].ToString();
            tbAddress.Text = tb.Rows[0]["DiaChi"].ToString();
            tbPhone.Text = tb.Rows[0]["SoDienThoai"].ToString();
            tbEmail.Text = tb.Rows[0]["Email"].ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbEmail.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    SqlCommand checkIfCustomerExisted = new SqlCommand("select SoDienThoai from KHACHHANG kh, THONGTINCANHAN tt where tt.ID = kh.ID and tt.SoDienThoai = @SoDienThoai", con);
                    checkIfCustomerExisted.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);
                    SqlDataReader reader = checkIfCustomerExisted.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        DialogResult confirm = MessageBox.Show("Xác nhận thêm khách hàng này?", "Thêm Khách Hàng", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            //connection.Open();
                            SqlCommand InsertProfileCommand = new SqlCommand("insert into THONGTINCANHAN (HoTen, SoDienThoai, DiaChi, Email) values (@HoTen, @SoDienThoai, @DiaChi, @Email)", con);
                            InsertProfileCommand.Parameters.AddWithValue("@HoTen", tbName.Text);
                            InsertProfileCommand.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);
                            InsertProfileCommand.Parameters.AddWithValue("@DiaChi", tbAddress.Text);
                            InsertProfileCommand.Parameters.AddWithValue("@Email", tbEmail.Text);
                            InsertProfileCommand.ExecuteNonQuery();

                            SqlCommand insertCustomerCommand = new SqlCommand("insert into KHACHHANG(ID) select tt.ID from THONGTINCANHAN tt where tt.SoDienThoai = @SoDienThoai", con);
                            insertCustomerCommand.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);
                            insertCustomerCommand.ExecuteNonQuery();
                            autoLoadData();
                            MessageBox.Show("Khách hàng được thêm thành công.");
                            loadAfterAdd();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Khách hàng đã tồn tại.");
                    }
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                command = connection.CreateCommand();
                command.CommandText = "select kh.MaKH, tt.HoTen, tt.SoDienThoai, tt.DiaChi, tt.Email from KHACHHANG kh, THONGTINCANHAN tt where tt.ID = kh.ID and tt.SoDienThoai = @SoDienThoai";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@SoDienThoai", searchBox.Text);
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                customerDGV.DataSource = table;
                searchBox.Text = placeholder;

                tbID.Text = "";
                tbName.Text = "";
                tbPhone.Text = "";
                tbAddress.Text = "";
                tbEmail.Text = "";
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select kh.MaKH, tt.HoTen, tt.SoDienThoai, tt.DiaChi, tt.Email from KHACHHANG kh, THONGTINCANHAN tt where tt.ID = kh.ID and tt.SoDienThoai = @SoDienThoai";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@SoDienThoai", searchBox.Text);
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            customerDGV.DataSource = table;
            searchBox.Text = placeholder;
            tbID.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            tbEmail.Text = "";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbID.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            tbEmail.Text = "";
            offset = 0;
            autoLoadData();
        }
    }
}

