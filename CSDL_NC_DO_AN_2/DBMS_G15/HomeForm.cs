using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_G15
{
    public partial class HomeForm : Form
    {
        int _check;
        string UserName;
        private Form currentChildForm;
        public HomeForm()
        {
            InitializeComponent();            
        }
        public HomeForm(string _username,int check)
        {
            // 0:Khach hang, 1:Quan Tri, 2:Quan Li, 3:Taixe, 4:NhaCCap
            InitializeComponent();
            _check = check;
            UserName = _username;
            greetingLabel.Text = "Xin chào, " + _username.Trim();
            if(check == 0)
            {
                btnPartner.Hide();
                btnProduct.Hide();
                btnMoney.Hide();
                btnDriver.Hide();
                btnStaff.Hide();
                btnCustomer.Hide();
            }
            else if(check == 1)
            {
                btnProfile.Hide();
                btnPartner.Hide();
                btnProduct.Hide();
                btnMoney.Hide();
                btnDriver.Hide();
                btnCustomer.Hide();
            }
            else if(check == 2)
            {
                btnProduct.Hide();
                btnPartner.Hide();
                btnDriver.Hide();
                btnCustomer.Hide();
                btnOrder.Hide();
            }
            else if(check == 3)
            {
                btnCustomer.Hide();
                btnDriver.Hide();
                btnPartner.Hide();
                btnStaff.Hide();
                btnProduct.Hide();
            }
            else if(check==4)
            {
                btnOrder.Hide();
                btnProduct.Hide();
                btnMoney.Hide();
                btnDriver.Hide();
                btnStaff.Hide();
                btnCustomer.Hide();
            }    
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(childForm);
            childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            navMenu.Height = btnProduct.Height;
            navMenu.Top = btnProduct.Top;
            navMenu.BringToFront();
            OpenChildForm(new productForm(UserName));
        }

        private void btnOrder_Click(object sender, EventArgs e)
        { 
            navMenu.Height = btnOrder.Height;
            navMenu.Top = btnOrder.Top;
            navMenu.BringToFront();
            OpenChildForm(new OrderForm(UserName));
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            navMenu.Height = btnCustomer.Height;
            navMenu.Top = btnCustomer.Top;
            navMenu.BringToFront();
            OpenChildForm(new CustomerForm());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            navMenu.Height = btnStaff.Height;
            navMenu.Top = btnStaff.Top;
            navMenu.BringToFront();
            OpenChildForm(new StaffForm());
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            navMenu.Height = btnDriver.Height;
            navMenu.Top = btnDriver.Top;
            navMenu.BringToFront();
            OpenChildForm(new DriverForm());
        }

        private void btnPartner_Click(object sender, EventArgs e)
        {
            navMenu.Height = btnPartner.Height;
            navMenu.Top = btnPartner.Top;
            navMenu.BringToFront();
            //OpenChildForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenLoginForm));
            t.Start();
            this.Close();
        }
        private void panelLogo_Click(object sender, EventArgs e)
        {
            navMenu.SendToBack();
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }
        public static void OpenLoginForm()
        {
            Application.Run(new LoginForm());
        }

        private void logoPic_Click(object sender, EventArgs e)
        {
            navMenu.SendToBack();
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void logoLabel_Click(object sender, EventArgs e)
        {
            navMenu.SendToBack();
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {
            navMenu.Height = btnMoney.Height;
            navMenu.Top = btnMoney.Top;
            navMenu.BringToFront();
            OpenChildForm(new DoanhThu(UserName));
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (_check == 0)
            {
                navMenu.Height = btnProfile.Height;
                navMenu.Top = btnProfile.Top;
                navMenu.BringToFront();
                OpenChildForm(new CustomerProfile(_check, UserName));
            }
            else
            {
                navMenu.Height = btnProfile.Height;
                navMenu.Top = btnProfile.Top;
                navMenu.BringToFront();
                OpenChildForm(new StaffProfile(_check, UserName));
            }    
        }
    }
}
