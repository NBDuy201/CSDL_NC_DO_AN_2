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
    public partial class OrderForm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string UserName;
        string ChuaDongY = "Chưa đồng ý";
        string str = @"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True";
        DateTime date = DateTime.Now.Date;
        public OrderForm(string _UserName)
        {
            InitializeComponent();
            connection = new SqlConnection(str);
            UserName = _UserName;
            loadIDCus();
        }

        private void loadProduct()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "select MaSP,TenSP from SANPHAM";
                    command.CommandType = CommandType.Text;
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cbbProduct.DataSource = dt;
                    cbbProduct.DisplayMember = "TenSP";
                    cbbProduct.ValueMember = "MaSP";
                    cbbProduct.SelectedItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
                }
            }
        }

        private void loadIDCus()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "select MaKH from KhachHang where UserName=@UserName";
                    command.Parameters.AddWithValue("@UserName",UserName);
                    command.CommandType = CommandType.Text;
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MaKHTb.Text = dt.Rows[0]["MaKH"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
                }
            }
        }

        public void LoadcbbKM()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from KhuyenMai";
                command.CommandType = CommandType.Text;
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbbKM.DisplayMember = "MaKM";
                cbbKM.ValueMember = "MaKM";
                cbbKM.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
            }
        }

        public void LoadOrder()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    DataTable tbOrder = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "EXEC KhachHang_XemTatCa_DonHang @MaKH";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@MaKH", MaKHTb.Text);
                    adapter.SelectCommand = command;
                    tbOrder.Clear();
                    adapter.Fill(tbOrder);
                    OrderDGV.DataSource = tbOrder;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void bttADD_CT_Click(object sender, EventArgs e)
        {
            if (cbbProduct.SelectedValue == null || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Vui lòng chọn đủ thông tin.");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Xác nhận thêm sản phẩm này?", "Thêm sản phẩm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand updateCommand = new SqlCommand("Exec KhachHang_ThemSanPham_GioHang @MaSP,@MaDH,@SL", connection);
                            updateCommand.Parameters.AddWithValue("@MaDH", OrderDGV.CurrentRow.Cells[0].Value);
                            updateCommand.Parameters.AddWithValue("@MaSP", cbbProduct.SelectedValue);
                            updateCommand.Parameters.AddWithValue("@SL", numericUpDown1.Value);
                            updateCommand.ExecuteNonQuery();
                            LoadDetailOrder();
                            LoadOrder();
                            OrderDGV.CurrentCell = OrderDGV[0, OrderDGV.Rows.Count - 1];
                            MessageBox.Show("Thêm Sản phẩm vào giỏ hàng thành công");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                cbbProduct.SelectedItem = null;
                numericUpDown1.Value = 0;
            }
        }

        private void cbbProduct_Click(object sender, EventArgs e)
        {
            loadProduct();
        }

        private void cbbProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if ( cbbKM.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đủ thông tin.");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Xác nhận thêm đơn hàng này?", "Thêm đơn hàng", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand updateCommand = new SqlCommand("EXEC KhachHang_Them_GioHang @MaKH,@MaKM", connection);
                            updateCommand.Parameters.AddWithValue("@MaKH", MaKHTb.Text);
                            updateCommand.Parameters.AddWithValue("@MaKM", cbbKM.SelectedValue);
                            updateCommand.ExecuteNonQuery();
                            LoadOrder();
                            OrderDGV.CurrentCell = OrderDGV[0, OrderDGV.Rows.Count - 1];
                            MessageBox.Show("Thêm đơn hàng thành công");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        void LoadDetailOrder()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    DataTable tbDetailOrder = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "select CT.MaDH,SP.MaSP,SP.TenSP,CT.SoLuong,CT.ThanhTien from CT_DONHANG CT,SANPHAM SP where CT.MaDH=@MaDH and CT.MaSP=SP.MaSP";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@MaDH", OrderDGV.CurrentRow.Cells[0].Value);
                    adapter.SelectCommand = command;
                    tbDetailOrder.Clear();
                    adapter.Fill(tbDetailOrder);
                    DetailOrderDGV.DataSource = tbDetailOrder;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OrderDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbProduct.SelectedItem = null;
            numericUpDown1.Value = 0;
            LoadDetailOrder();
            checkTinhTrang(); 
        }
        void checkTinhTrang()
        {
            if (OrderDGV.CurrentRow.Cells[3].Value.ToString() != ChuaDongY)
            {
                cbbProduct.Enabled = false;
                numericUpDown1.Enabled = false;
                btnAddProduct.Enabled = false;
                button2.Enabled = false;
            }
            else if (OrderDGV.CurrentRow.Cells[3].Value.ToString() == ChuaDongY)
            {
                cbbProduct.Enabled = true;
                numericUpDown1.Enabled = true;
                btnAddProduct.Enabled = true;
                button2.Enabled = true;
            }
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            cbbProduct.Enabled = false;
            numericUpDown1.Enabled = false;
            btnAddProduct.Enabled = false;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void cbbKM_Click(object sender, EventArgs e)
        {
            LoadcbbKM();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Xác nhận thanh toán đơn hàng này?", "Thanh toán đơn hàng", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=QLCuaHang;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand updateCommand = new SqlCommand("EXEC KhachHang_XacNhan_DonHang @MaDH,@NgayLapDon", connection);
                        updateCommand.Parameters.AddWithValue("@MaDH", OrderDGV.CurrentRow.Cells[0].Value);
                        updateCommand.Parameters.AddWithValue("@NgayLapDon",date );                        
                        updateCommand.ExecuteNonQuery();
                        LoadOrder();
                        OrderDGV.CurrentCell = OrderDGV[0, OrderDGV.Rows.Count - 1];
                        MessageBox.Show("Xác nhận thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}