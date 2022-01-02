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
    public partial class StaffProfile : Form
    {
        string UserName;
        int check;
        SqlConnection connection;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string str = @"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True";
        public StaffProfile(int _check, string _UserName)
        {
            InitializeComponent();
            UserName = _UserName;
            check = _check;
            connection = new SqlConnection(str);
            connection.Open();
        }

        private void autoLoadData()
        {
            SqlCommand cmd = new SqlCommand("select * from NhanVien where UserName = @UserName", connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            nameTb.Text = dt.Rows[0]["TenNV"].ToString();
            RoleTb.Text = dt.Rows[0]["ChucVu"].ToString();
            UserNameTb.Text = dt.Rows[0]["UserName"].ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void StaffProfile_Load(object sender, EventArgs e)
        {
            autoLoadData();
        }
    }
}
