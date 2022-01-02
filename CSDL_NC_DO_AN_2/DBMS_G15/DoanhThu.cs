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
    
    public partial class DoanhThu : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableProduct = new DataTable();
        string UserName;
        string str = @"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True";
        private int offset;
        const int maxRowsPerPage = 15;
        string MaNV;
        public DoanhThu(string _UserName)
        {
            UserName = _UserName;
            InitializeComponent();
            offset = 0;
            
        }

        private void autoLoadOrderData()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "Select* from DonHang order by MaDH offset @offset rows fetch next @rows rows only";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@offset", offset);
                command.Parameters.AddWithValue("@rows", maxRowsPerPage);
                adapter.SelectCommand = command;
                tableProduct.Clear();
                adapter.Fill(tableProduct);
                OrderDGV.DataSource = tableProduct;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            offset += maxRowsPerPage;
            try
            {
                autoLoadOrderData();
                btnPrevious.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            offset -= maxRowsPerPage;
            if (offset <= 0)
            {
                offset = 0;
                btnPrevious.Enabled = false;
            }
            autoLoadOrderData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            offset = 0;
            autoLoadOrderData();
        }

        private void DoanhThu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            autoLoadOrderData();
            btnPrevious.Enabled = false;
            getMaNV();
        }

        void getMaNV()
        {
            DataTable tb = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from NhanVien where UserName = @UserName";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@UserName", UserName);
            adapter.SelectCommand = command;
            tb.Clear();
            adapter.Fill(tb);
            MaNV = tb.Rows[0]["MaNV"].ToString();
        }

        private void ThongKe_Click(object sender, EventArgs e)
        {
            if (YearTb.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        DataTable tbDoanhThu = new DataTable();
                        command = connection.CreateCommand();
                        command.CommandText = "Exec NhanVienQuanLy_ThongKeDoanhThuThang @MaNV,@Month,@Year";
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@MaNV", MaNV);
                        command.Parameters.AddWithValue("@Month", MonthTb.Text);
                        command.Parameters.AddWithValue("@Year", YearTb.Text);
                        adapter.SelectCommand = command;
                        tbDoanhThu.Clear();
                        adapter.Fill(tbDoanhThu);
                        DoanhThuDGV.DataSource = tbDoanhThu;
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void DoanhThuTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
