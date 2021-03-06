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
    public partial class CustomerProfile : Form
    {
        string UserName;
        int check;
        SqlConnection connection;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string str = @"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True";

        public CustomerProfile(int _check,string _UserName )
        {
            InitializeComponent();
            UserName = _UserName;
            check = _check;
            connection = new SqlConnection(str);
            connection.Open();
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
