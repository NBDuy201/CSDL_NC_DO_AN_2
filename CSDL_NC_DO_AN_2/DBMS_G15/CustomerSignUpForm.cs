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
    public partial class CustomerSignUpForm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableProduct = new DataTable();
        string str = @"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True";
        public CustomerSignUpForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            if (UserNameTb.Text == "" || PassTb.Text == "" || nameTb.Text == "" || phoneNumTb.Text == "" || addressTb.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    SqlCommand updateCommand = new SqlCommand("exec newlogin_KhachHang @TenKH,@Sdt,@DiaChi,@UserName,@Pass", connection);
                    updateCommand.Parameters.AddWithValue("@TenKH", nameTb.Text);
                    updateCommand.Parameters.AddWithValue("@DiaChi", addressTb.Text);
                    updateCommand.Parameters.AddWithValue("@Sdt", phoneNumTb.Text);
                    updateCommand.Parameters.AddWithValue("@UserName", UserNameTb.Text);
                    updateCommand.Parameters.AddWithValue("@Pass", PassTb.Text);
                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký thành công");
                    this.Hide();
                    LoginForm Login = new LoginForm();
                    Login.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
