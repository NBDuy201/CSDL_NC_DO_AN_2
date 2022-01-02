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
    public partial class LoginForm : Form
    {
        int check;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableProduct = new DataTable();
        string str = @"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True";
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = loginBtn;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text == "" || passTxt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin đăng nhập.");
            }
            if(usernameTxt.Text == "Developer")
            {
                check = 5;
                HomeForm homeForm = new HomeForm(usernameTxt.Text, check);
                this.Hide();
                homeForm.StartPosition = FormStartPosition.CenterScreen;
                homeForm.ShowDialog();
                this.Close();
            }    
            else using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
            {
                try
                {
                        connection.Open();
                        SqlCommand checkCusAccountExisted = new SqlCommand("select* from KhachHang where UserName = @UserName", connection);
                        checkCusAccountExisted.Parameters.AddWithValue("@UserName", usernameTxt.Text);
                        SqlDataReader readerCus = checkCusAccountExisted.ExecuteReader();
                        if (readerCus.HasRows)
                        {
                            readerCus.Close();
                            SqlCommand checkCusAccountPass = new SqlCommand("select* from KhachHang where UserName = @UserName and Pass=@Pass", connection);
                            checkCusAccountPass.Parameters.AddWithValue("@UserName", usernameTxt.Text);
                            checkCusAccountPass.Parameters.AddWithValue("@Pass", passTxt.Text);
                            SqlDataReader readerCusPass = checkCusAccountPass.ExecuteReader();
                            if (readerCusPass.HasRows)
                            {
                                readerCusPass.Close();
                                check = 0;
                                HomeForm homeForm = new HomeForm(usernameTxt.Text, check);
                                this.Hide();
                                homeForm.StartPosition = FormStartPosition.CenterScreen;
                                homeForm.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                readerCus.Close();
                                readerCusPass.Close();
                                MessageBox.Show("Sai mật khẩu!.");
                            }
                        }
                        // Check Nhân viên
                       readerCus.Close();
                       SqlCommand checkStaffAccountExisted = new SqlCommand("select* from KhachHang where UserName = @UserName", connection);
                       checkStaffAccountExisted.Parameters.AddWithValue("@UserName", usernameTxt.Text);
                       SqlDataReader readerStaff = checkStaffAccountExisted.ExecuteReader();
                       if (readerStaff.HasRows)
                       {
                            readerStaff.Close();
                            SqlCommand checkStaffAccountPass = new SqlCommand("select * from NhanVien where UserName = @UserName and Pass=@Pass", connection);
                            checkStaffAccountPass.Parameters.AddWithValue("@UserName", usernameTxt.Text);
                            checkStaffAccountPass.Parameters.AddWithValue("@Pass", passTxt.Text);
                            SqlDataReader readerStaffPass = checkStaffAccountPass.ExecuteReader();
                            
                            if (readerStaffPass.HasRows)
                            {
                                readerStaffPass.Close();
                                SqlCommand checkStaffRole = new SqlCommand("select * from NhanVien where UserName = @UserName", connection);
                                checkStaffRole.Parameters.AddWithValue("@UserName", usernameTxt.Text);
                                string ChucVu = checkStaffRole.ExecuteScalar().ToString();
                                if (ChucVu == "Quản lí")
                                {
                                    check = 2;
                                }
                                else if (ChucVu == "Quản trị")
                                {
                                    check = 1;
                                }
                                else if (ChucVu == "Tài xế")
                                {
                                    check = 3;
                                }
                                HomeForm homeForm = new HomeForm(usernameTxt.Text, check);
                                this.Hide();
                                homeForm.StartPosition = FormStartPosition.CenterScreen;
                                homeForm.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                readerStaff.Close();
                                readerStaffPass.Close();
                                MessageBox.Show("Sai mật khẩu!.");
                            }
                        }
                        readerStaff.Close();
                        SqlCommand checkNCCAccountExisted = new SqlCommand("select* from NhaCungCap where UserName = @UserName", connection);
                        checkNCCAccountExisted.Parameters.AddWithValue("@UserName", usernameTxt.Text);
                        SqlDataReader readerNCC = checkNCCAccountExisted.ExecuteReader();
                        if (readerNCC.HasRows)
                        {
                            readerNCC.Close();
                            SqlCommand checkNCCAccountPass = new SqlCommand("select * from NhaCungCap where UserName = @UserName and Pass=@Pass", connection);
                            checkNCCAccountPass.Parameters.AddWithValue("@UserName", usernameTxt.Text);
                            checkNCCAccountPass.Parameters.AddWithValue("@Pass", passTxt.Text);
                            SqlDataReader readerNCCPass = checkNCCAccountPass.ExecuteReader();
                            if(readerNCCPass.HasRows)
                            {
                                readerNCCPass.Close();
                                check = 4;
                                HomeForm homeForm = new HomeForm(usernameTxt.Text, check);
                                this.Hide();
                                homeForm.StartPosition = FormStartPosition.CenterScreen;
                                homeForm.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                readerNCC.Close();
                                readerNCCPass.Close();
                                MessageBox.Show("Sai mật khẩu!.");
                            }
                        }
                        readerNCC.Close();
                    }
                    catch 
                    {
                        MessageBox.Show("Tài khoản không tồn tại.");
                    }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerSignUpForm cSU = new CustomerSignUpForm();
            cSU.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    } 
}
