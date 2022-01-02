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
    public partial class PartnerAndCustomerProfile : Form
    {
        string UserName;
        int check;
        SqlConnection connection;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string str = @"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True";

        public PartnerAndCustomerProfile(int _check,string _UserName )
        {
            InitializeComponent();
            UserName = _UserName;
            check = _check;
            connection = new SqlConnection(str);
            connection.Open();
        }

        public void LoadProfile()
        {
            SqlCommand cmd = new SqlCommand("select * from NhanVien where UserName=@UserName", connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            nameTb.Text = dt.Rows[0]["HoTen"].ToString();
            phoneNumTb.Text = dt.Rows[0]["SoDienThoai"].ToString();
            addressTb.Text = dt.Rows[0]["DiaChi"].ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            nameTb.ReadOnly = false;
            addressTb.ReadOnly = false;
            phoneNumTb.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update KhachHang set TenKH = @HoTen, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi where ", connection);
            cmd.Parameters.AddWithValue("@HoTen", nameTb.Text);
            cmd.Parameters.AddWithValue("@SoDienThoai", phoneNumTb.Text);
            cmd.Parameters.AddWithValue("@Diachi", addressTb.Text);
            DialogResult confirm = MessageBox.Show("Xác nhận thay đổi thông tin?", "Chỉnh Sửa Thông Tin Cá Nhân", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Chỉnh sửa thông tin thành công.");
                    nameTb.ReadOnly = true;
                    addressTb.ReadOnly = true;
                    phoneNumTb.ReadOnly = true;
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối.");
                }
            }
        }

        private void autoLoadData()
        {
            SqlCommand cmd = new SqlCommand("select * from KhachHang where UserName = @UserName", connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            nameTb.Text = dt.Rows[0]["TenKH"].ToString();
            phoneNumTb.Text = dt.Rows[0]["Sdt"].ToString();
            addressTb.Text = dt.Rows[0]["DiaChi"].ToString();
        }
        private void StaffAndCustomerProfile_Load(object sender, EventArgs e)
        {
            autoLoadData();
        }
    }
}
