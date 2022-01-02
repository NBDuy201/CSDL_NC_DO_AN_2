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
        string str = @"Data Source = (local); Initial Catalog = QLCuaHang; Integrated Security = True";
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
                command.CommandText = "select kh.MaKH, kh.TenKH, kh.Sdt, kh.DiaChi,kh.UserName from KHACHHANG kh order by MaKH offset @offset rows fetch next @rows rows only";
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
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select kh.MaKH, kh.TenKH, kh.Sdt, kh.DiaChi,kh.UserName from KHACHHANG kh where  kh.Sdt = @Sdt";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@Sdt", searchBox.Text);
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            customerDGV.DataSource = table;
            searchBox.Text = placeholder;
            tbID.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbID.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            offset = 0;
            autoLoadData();
        }
    }
}

