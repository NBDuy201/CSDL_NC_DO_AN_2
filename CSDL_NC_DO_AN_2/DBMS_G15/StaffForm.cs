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
    public partial class StaffForm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableStaff = new DataTable();
        string str = @"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True";
        private int offset;
        const int maxRowsPerPage = 15;
        public StaffForm()
        {
            InitializeComponent();
            offset = 0;
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            autoLoadStaffData();
            btnPrevious.Enabled = false;
        }

        private void autoLoadStaffData()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "Select MaNV,TenNV,ChucVu,Luong from NhanVien order by MaNV offset @offset rows fetch next @rows rows only";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@offset", offset);
                command.Parameters.AddWithValue("@rows", maxRowsPerPage);
                adapter.SelectCommand = command;
                tableStaff.Clear();
                adapter.Fill(tableStaff);
                StaffDGV.DataSource = tableStaff;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.");
            }
        }

        private void StaffDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = StaffDGV.CurrentCell.RowIndex;
            tbID.Text = StaffDGV.Rows[rowIndex].Cells[0].Value.ToString();
            tbName.Text = StaffDGV.Rows[rowIndex].Cells[1].Value.ToString();
            tbPhone.Text = StaffDGV.Rows[rowIndex].Cells[2].Value.ToString();
            tbAddress.Text = StaffDGV.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            offset += 10;
            try
            {
                autoLoadStaffData();
                btnPrevious.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            offset -= 10;
            if (offset <= 0)
            {
                offset = 0;
                btnPrevious.Enabled = false;
            }
            autoLoadStaffData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbID.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            offset = 0;
            autoLoadStaffData();
        }
    }
}
