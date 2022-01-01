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
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = loginBtn;
        }

        //The very first lines of code
        //For testing close login form after login
        //Leave it here until login verification done
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(usernameTxt.Text == "" || passTxt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin đăng nhập.");
            }
            else if(usernameTxt.Text != "customer" && usernameTxt.Text != "developer" && usernameTxt.Text != "partner" && usernameTxt.Text != "staff" && usernameTxt.Text != "driver")
            {
                MessageBox.Show("Sai thông tin đăng nhập.");
            }
            else
            {
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.UserID = usernameTxt.Text;
                    builder.Password = passTxt.Text;
                    builder.DataSource = "local";
                    builder.InitialCatalog = "DBMS_ThucHanh_Nhom15";
                    builder.IntegratedSecurity = false;
                    using(SqlConnection con = new SqlConnection(builder.ConnectionString))
                    {
                        HomeForm homeForm = new HomeForm(usernameTxt.Text);
                        this.Hide();
                        homeForm.StartPosition = FormStartPosition.CenterScreen;
                        homeForm.ShowDialog();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbSignUp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbSignUp.SelectedItem.ToString() == "Tài Xế")
            {
                this.Hide();
                DriverSignUpForm signUpForm = new DriverSignUpForm();
                signUpForm.ShowDialog();
                this.Close();
            }
            else if(cbbSignUp.SelectedItem.ToString() == "Khách Hàng")
            {
                this.Hide();
                CustomerSignUpForm signUpForm = new CustomerSignUpForm();
                signUpForm.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                partnerSignUpForm signUpForm = new partnerSignUpForm();
                signUpForm.ShowDialog();
                this.Close();
            }
            this.Hide();
            this.Close();
        }
    }
}
