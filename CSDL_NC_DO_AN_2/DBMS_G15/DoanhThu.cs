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
        public DoanhThu()
        {
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
        }
    }
}
