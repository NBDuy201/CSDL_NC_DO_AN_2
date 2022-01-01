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
    public partial class StaffAndCustomerProfile : Form
    {
        string role;
        int ID;
        SqlConnection connection;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string str = @"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True";

        public StaffAndCustomerProfile(string _role, int _ID)
        {
            InitializeComponent();
            role = _role;
            ID = _ID;
            connection = new SqlConnection(str);
            connection.Open();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            nameTb.ReadOnly = false;
            addressTb.ReadOnly = false;
            phoneNumTb.ReadOnly = false;
            emailTb.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update THONGTINCANHAN set HoTen = @HoTen, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email where ID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@HoTen", nameTb.Text);
            cmd.Parameters.AddWithValue("@SoDienThoai", phoneNumTb.Text);
            cmd.Parameters.AddWithValue("@Diachi", addressTb.Text);
            cmd.Parameters.AddWithValue("@Email", emailTb.Text);
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
                    emailTb.ReadOnly = true;
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối.");
                }
            }
        }

        private void autoLoadData()
        {
            SqlCommand cmd = new SqlCommand("select * from THONGTINCANHAN where ID = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            nameTb.Text = dt.Rows[0]["HoTen"].ToString();
            phoneNumTb.Text = dt.Rows[0]["SoDienThoai"].ToString();
            addressTb.Text = dt.Rows[0]["DiaChi"].ToString();
            emailTb.Text = dt.Rows[0]["Email"].ToString();
        }
        private void StaffAndCustomerProfile_Load(object sender, EventArgs e)
        {
            if(role == "customer")
            {
                label1.Text = "THÔNG TIN KHÁCH HÀNG";
            }    
            autoLoadData();
        }
    }
}
