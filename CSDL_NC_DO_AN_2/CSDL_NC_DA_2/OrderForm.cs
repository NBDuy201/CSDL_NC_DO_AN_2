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
        string PhivanChuyen = "25000";
        string DangXuLi = "Đang xử lí";
        string KhongXacDinh = "Không xác định";
        string DaHuy = "Đã hủy";
        string str = @"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True";
        DateTime now = DateTime.Now;

        public OrderForm()
        {
            InitializeComponent();
            connection = new SqlConnection(str);
        }

        private void loadProduct()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
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
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "select MaKH from KHACHHANG";
                    command.CommandType = CommandType.Text;
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cbbIDCustomer.DataSource = dt;
                    cbbIDCustomer.DisplayMember = "MAKH";
                    cbbIDCustomer.ValueMember = "MAKH";
                    cbbIDCustomer.SelectedItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
                }
            }
        }

        private void loadArea()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "select MaKV ,TenKV from KHUVUC";
                    command.CommandType = CommandType.Text;
                    adapter.SelectCommand = command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cbbArea.DataSource = dt;
                    cbbArea.DisplayMember = "TenKV";
                    cbbArea.ValueMember = "MaKV";
                    cbbArea.SelectedItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
                }
            }
        }

        void LoadOrder()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    DataTable tbOrder = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "select MaDH, NgayDat, NgayGiao, TinhTrang, PhiVanChuyen, TongTien, MaKV from DONHANG where MaKH=@MaKH";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@MaKH", cbbIDCustomer.SelectedValue);
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
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand updateCommand = new SqlCommand("Insert into CHITIETDONHANG(MaDH,MaSP,SoLuong) values (@MaDH,@MaSP,@SL)", connection);
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

        private void cbbIDCustomer_Click(object sender, EventArgs e)
        {
            loadIDCus();
        }

        private void cbbProduct_Click(object sender, EventArgs e)
        {
            loadProduct();
        }

        private void cbbArea_Click(object sender, EventArgs e)
        {
            loadArea();
        }

        private void cbbIDCustomer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                btnCancelOrder.Enabled = false;
                cbbProduct.Enabled = false;
                btnAddProduct.Enabled = false;
                btnDeleteProduct.Enabled = false;
                numericUpDown1.Enabled = false;
                try
                {
                    connection.Open();
                    DataTable tbOrder = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "select MaDH, NgayDat, NgayGiao, TinhTrang, PhiVanChuyen, TongTien, MaKV from DONHANG where MaKH=@MaKH";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@MaKH", cbbIDCustomer.SelectedValue);
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

        private void cbbProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (cbbIDCustomer.SelectedValue == null || cbbArea.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đủ thông tin.");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Xác nhận thêm đơn hàng này?", "Thêm đơn hàng", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand updateCommand = new SqlCommand("Insert into DONHANG(MaKH,NgayDat,TinhTrang,PhiVanChuyen,MaKV) values (@MaKH,@NgayDat,@TinhTrang,@PhiVanChuyen,@MaKV)", connection);
                            updateCommand.Parameters.AddWithValue("@MaKH", cbbIDCustomer.SelectedValue);
                            updateCommand.Parameters.AddWithValue("@NgayDat", now);
                            updateCommand.Parameters.AddWithValue("@TinhTrang", DangXuLi);
                            updateCommand.Parameters.AddWithValue("@PhiVanChuyen", PhivanChuyen);
                            updateCommand.Parameters.AddWithValue("@MaKV", cbbArea.SelectedValue);
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
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    DataTable tbDetailOrder = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "select CT.MaDH,SP.MaSP,SP.TenSP,CT.SoLuong,CT.ThanhTien from CHITIETDONHANG CT,SANPHAM SP where CT.MaDH=@MaDH and CT.MaSP=SP.MaSP";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@MaDH", OrderDGV.CurrentRow.Cells[0].Value);
                    adapter.SelectCommand = command;
                    tbDetailOrder.Clear();
                    adapter.Fill(tbDetailOrder);
                    DetailOrderDGV.DataSource = tbDetailOrder;
                    if(DetailOrderDGV.Rows.Count == 0)
                    {
                        btnDeleteProduct.Enabled = false;
                    }
                    else
                    {
                        btnDeleteProduct.Enabled = true;
                    }
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

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                DialogResult confirm = MessageBox.Show("Xác nhận xóa sản phẩm khỏi đơn hàng?", "Xóa Khỏi Đơn Hàng", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        SqlCommand DeleteCommand = new SqlCommand("delete from CHITIETDONHANG WHERE MaDH=@MaDH and MaSP=@MaSP", connection);
                        DeleteCommand.Parameters.AddWithValue("@MaDH", DetailOrderDGV.CurrentRow.Cells[0].Value);
                        DeleteCommand.Parameters.AddWithValue("@MaSP", DetailOrderDGV.CurrentRow.Cells[1].Value);
                        DeleteCommand.ExecuteNonQuery();
                        LoadDetailOrder();
                        LoadOrder();
                        MessageBox.Show("Xóa sản phẩm khỏi đơn hàng thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Xác nhận hủy đơn hàng?", "Hủy Đơn hàng", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand DeleteCommand = new SqlCommand("exec Cancel_Order @MaDH", connection);
                        DeleteCommand.Parameters.AddWithValue("@MaDH", OrderDGV.CurrentRow.Cells[0].Value);
                        DeleteCommand.ExecuteNonQuery();
                        LoadDetailOrder();
                        LoadOrder();
                        MessageBox.Show("Hủy đơn hàng thành công");
                        checkTinhTrang();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        void checkTinhTrang()
        {
            if (OrderDGV.CurrentRow.Cells[3].Value.ToString() != DangXuLi)
            {
                cbbProduct.Enabled = false;
                numericUpDown1.Enabled = false;
                btnAddProduct.Enabled = false;
                btnDeleteProduct.Enabled = false;
                btnCancelOrder.Enabled = false;
            }
            else if (OrderDGV.CurrentRow.Cells[3].Value.ToString() == DangXuLi)
            {
                cbbProduct.Enabled = true;
                numericUpDown1.Enabled = true;
                btnAddProduct.Enabled = true;
                btnDeleteProduct.Enabled = true;
                btnCancelOrder.Enabled = true;
            }
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            btnCancelOrder.Enabled = false;
            cbbProduct.Enabled = false;
            numericUpDown1.Enabled = false;
            btnDeleteProduct.Enabled = false;
            btnAddProduct.Enabled = false;
        }
    }
}