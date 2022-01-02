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
    public partial class DriverForm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string str = @"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True";
        string placeholder = "Nhập mã CMND...";
        string oldBank = "";
        string oldNum = "";
        string oldIDNum = "";
        string oldPhone = "";
        private int offset;
        const int maxRowsPerPage = 12;
        public DriverForm()
        {
            InitializeComponent();
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            offset = 0;
            searchBox.Text = placeholder;
            loadComboBoxArea();
            loadComboBoxMoney();
            autoLoadData();
            connection.Open();
        }
        private void autoLoadData()
        {
            try
            {
                DataTable table = new DataTable();
                command = connection.CreateCommand();
                command.CommandText = "select tx.MaTX, tt.HoTen, tt.SoDienThoai, kv.TenKV, tx.CMND, tx.PhiThueChan from THONGTINCANHAN tt, TAIXE tx, KHUVUC kv where tt.ID = tx.ID and kv.MaKV = tx.MaKV order by tx.MaTX offset @offset rows fetch next @rows rows only";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@offset", offset);
                command.Parameters.AddWithValue("@rows", maxRowsPerPage);
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                driverDGV.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
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
            autoLoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            offset += 10;
            try
            {
                autoLoadData();
                btnPrevious.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }
        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == placeholder)
                searchBox.Text = "";
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
                searchBox.Text = placeholder;
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select tx.MaTX, tt.HoTen, tt.SoDienThoai, kv.TenKV, tx.CMND, tx.PhiThueChan from THONGTINCANHAN tt, TAIXE tx, KHUVUC kv where tt.ID = tx.ID and kv.MaKV = tx.MaKV and CMND = @CMND";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@CMND", searchBox.Text);
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            driverDGV.DataSource = table;
            searchBox.Text = placeholder;

            refreshDetail();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            offset = 0;
            refreshDetail();
            autoLoadData();
        }
        private void refreshDetail()
        {
            tbID.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            tbEmail.Text = "";
            tbBank.Text = "";
            tbIDNum.Text = "";
            tbNum.Text = "";
            tbBank.Text = "";
            cbbArea.SelectedIndex = 0;
            cbbMoney.SelectedIndex = 0;
        }
        private bool anyBlankDetail()
        {
            if(tbID.Text == "" || tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbEmail.Text == "" || tbBank.Text == "" || tbIDNum.Text == "" || tbNum.Text == "" || tbBank.Text == "")
            {
                return true;
            }
            return false;
        }
        private bool anyExistedIDNum(string CMND)
        {
            SqlCommand checkDriverIfExisted = new SqlCommand("select tx.MaTX from THONGTINCANHAN tt, TAIXE tx where tt.ID = tx.ID and tx.CMND = @CMND", connection);
            checkDriverIfExisted.Parameters.AddWithValue("@CMND", CMND);
            SqlDataReader reader = checkDriverIfExisted.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }
        private bool anyExistedNum(string num)
        {
            SqlCommand checkDriverIfExisted = new SqlCommand("select tx.MaTX from THONGTINCANHAN tt, TAIXE tx where tt.ID = tx.ID and tx.BienSoXe = @BienSoXe", connection);
            checkDriverIfExisted.Parameters.AddWithValue("@BienSoXe", num);
            SqlDataReader reader = checkDriverIfExisted.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }
        private bool anyExistedBank(string bank)
        {
            SqlCommand checkDriverIfExisted = new SqlCommand("select tx.MaTX from THONGTINCANHAN tt, TAIXE tx where tt.ID = tx.ID and tx.SoTaiKhoan = @SoTaiKhoan", connection);
            checkDriverIfExisted.Parameters.AddWithValue("@SoTaiKhoan", bank);
            SqlDataReader reader = checkDriverIfExisted.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }
        private bool anyExistedPhone(string phone)
        {
            SqlCommand checkDriverIfExisted = new SqlCommand("select tx.MaTX from THONGTINCANHAN tt, TAIXE tx where tt.ID = tx.ID and tt.SoDienThoai = @SoDienThoai", connection);
            checkDriverIfExisted.Parameters.AddWithValue("@SoDienThoai", phone);
            SqlDataReader reader = checkDriverIfExisted.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }
        private bool checkValidDetail()
        {
            if(!anyExistedBank(tbBank.Text) && !anyExistedIDNum(tbIDNum.Text) && !anyExistedNum(tbNum.Text) && !anyExistedPhone(tbPhone.Text))
            {
                return true;
            }
            return false;
        }
        private bool checkNotEditedDetail()
        {
            if(oldPhone != tbPhone.Text || oldNum != tbNum.Text || oldBank != tbBank.Text || oldIDNum != tbIDNum.Text)
            {
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (anyBlankDetail())
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin.");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Xác nhận cập nhật thông tin tài xế này?", "Cập Nhật Thông Tin Tài Xế", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update TAIXE set MaKV = @MaKV, BienSoXe = @BienSoXe, CMND = @CMND, SoTaiKhoan = @SoTaiKhoan, PhiThueChan = @PhiThueChan where MaTX = @MaTX", connection);
                        SqlCommand cmd2 = new SqlCommand("update THONGTINCANHAN set HoTen = @HoTen, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email where ID = (select ID from TAIXE where MaTX = @MaTX)", connection);
                        cmd.Parameters.AddWithValue("@MaKV", cbbArea.SelectedValue);
                        cmd.Parameters.AddWithValue("@BienSoXe", tbNum.Text);
                        cmd.Parameters.AddWithValue("@CMND", tbIDNum.Text);
                        cmd.Parameters.AddWithValue("@SoTaiKhoan", tbBank.Text);
                        cmd.Parameters.AddWithValue("@PhiThueChan", cbbMoney.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@MaTX", tbID.Text);

                        cmd2.Parameters.AddWithValue("@HoTen", tbName.Text);
                        cmd2.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);
                        cmd2.Parameters.AddWithValue("@DiaChi", tbAddress.Text);
                        cmd2.Parameters.AddWithValue("@Email", tbEmail.Text);
                        cmd2.Parameters.AddWithValue("@MaTX", tbID.Text);

                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        autoLoadData();
                        MessageBox.Show("Cập nhật thông tin thành công.");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(anyBlankDetail())
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin.");
            }
            else if(checkValidDetail())
            {
                DialogResult confirm = MessageBox.Show("Xác nhận thêm tài xế này?", "Thêm Tài Xế", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("insert into THONGTINCANHAN (HoTen, SoDienThoai, DiaChi, Email) values (@HoTen, @SoDienThoai, @DiaChi, @Email)", connection);
                        SqlCommand cmd2 = new SqlCommand("insert into TAIXE(ID) select tt.ID from THONGTINCANHAN tt where tt.SoDienThoai = @SoDienThoai", connection);
                        SqlCommand cmd3 = new SqlCommand("update TAIXE set MaKV = @MaKV, BienSoXe = @BienSoXe, CMND = @CMND, SoTaiKhoan = @SoTaiKhoan, PhiThueChan = @PhiThueChan where ID = (select ID from THONGTINCANHAN where SoDienThoai = @SoDienThoai)", connection);

                        cmd.Parameters.AddWithValue("@HoTen", tbName.Text);
                        cmd.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", tbAddress.Text);
                        cmd.Parameters.AddWithValue("@Email", tbEmail.Text);

                        cmd2.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);

                        cmd3.Parameters.AddWithValue("@MaKV", cbbArea.SelectedValue);
                        cmd3.Parameters.AddWithValue("@BienSoXe", tbNum.Text);
                        cmd3.Parameters.AddWithValue("@CMND", tbIDNum.Text);
                        cmd3.Parameters.AddWithValue("@SoTaiKhoan", tbBank.Text);
                        cmd3.Parameters.AddWithValue("@PhiThueChan", cbbMoney.SelectedItem.ToString());
                        cmd3.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);

                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        loadAfterAdd();
                        MessageBox.Show("Thêm tài xế thành công.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi dữ liệu");
                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin bị trùng lắp.");
            }
        }

        private void loadAfterAdd()
        {
            DataTable tb = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select tx.MaKV, tx.MaTX, kv.TenKV, tt.HoTen, tx.BienSoXe, tx.CMND, tt.SoDienThoai, tx.SoTaiKhoan, tx.PhiThueChan, tt.DiaChi, tt.Email from THONGTINCANHAN tt, TAIXE tx, KHUVUC kv where tt.ID = tx.ID and kv.MaKV = tx.MaKV and CMND = @CMND";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@CMND", tbIDNum.Text);
            adapter.SelectCommand = command;
            tb.Clear();
            adapter.Fill(tb);

            tbID.Text = tb.Rows[0]["MaTX"].ToString();
            cbbArea.DisplayMember = tb.Rows[0]["TenKV"].ToString();
            cbbArea.SelectedValue = tb.Rows[0]["MaKV"].ToString();
            if (tb.Rows[0]["PhiThueChan"].ToString() == "0")
            {
                cbbMoney.SelectedIndex = 0;
            }
            else
            {
                cbbMoney.SelectedIndex = 1;
            }
            tbName.Text = tb.Rows[0]["HoTen"].ToString();
            tbNum.Text = tb.Rows[0]["BienSoXe"].ToString();
            tbIDNum.Text = tb.Rows[0]["CMND"].ToString();
            tbPhone.Text = tb.Rows[0]["SoDienThoai"].ToString();
            tbBank.Text = tb.Rows[0]["SoTaiKhoan"].ToString();
            cbbMoney.SelectedItem = tb.Rows[0]["PhiThueChan"].ToString();
            tbAddress.Text = tb.Rows[0]["DiaChi"].ToString();
            tbEmail.Text = tb.Rows[0]["Email"].ToString();
            autoLoadData();
        }
        private void loadComboBoxMoney()
        {
            cbbMoney.Items.Insert(0, 0);
            cbbMoney.Items.Insert(1, 500000);
            cbbMoney.SelectedIndex = 0;
        }
        private void loadComboBoxArea()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from KHUVUC";
                command.CommandType = CommandType.Text;
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                cbbArea.DisplayMember = "TenKV";
                cbbArea.ValueMember = "MaKV";
                cbbArea.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối với cơ sở dữ liệu!");
            }
        }
        private void fillCurrentDriverData()
        {
            int rowIndex = driverDGV.CurrentCell.RowIndex;
            DataTable tb = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select tx.MaKV, tx.MaTX, kv.TenKV, tt.HoTen, tx.BienSoXe, tx.CMND, tt.SoDienThoai, tx.SoTaiKhoan, tx.PhiThueChan, tt.DiaChi, tt.Email from THONGTINCANHAN tt, TAIXE tx, KHUVUC kv where tt.ID = tx.ID and kv.MaKV = tx.MaKV and CMND = @CMND";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@CMND", driverDGV.Rows[rowIndex].Cells[4].Value.ToString());
            adapter.SelectCommand = command;
            tb.Clear();
            adapter.Fill(tb);

            tbID.Text = tb.Rows[0]["MaTX"].ToString();
            cbbArea.DisplayMember = tb.Rows[0]["TenKV"].ToString();
            cbbArea.SelectedValue = tb.Rows[0]["MaKV"].ToString();
            if(tb.Rows[0]["PhiThueChan"].ToString() == "0")
            {
                cbbMoney.SelectedIndex = 0;
            }
            else
            {
                cbbMoney.SelectedIndex = 1;
            }
            tbName.Text = tb.Rows[0]["HoTen"].ToString();
            tbNum.Text = tb.Rows[0]["BienSoXe"].ToString();
            tbIDNum.Text = tb.Rows[0]["CMND"].ToString();
            tbPhone.Text = tb.Rows[0]["SoDienThoai"].ToString();
            tbBank.Text = tb.Rows[0]["SoTaiKhoan"].ToString();
            cbbMoney.SelectedItem = tb.Rows[0]["PhiThueChan"].ToString();
            tbAddress.Text = tb.Rows[0]["DiaChi"].ToString();
            tbEmail.Text = tb.Rows[0]["Email"].ToString();
        }
        private void saveOldDetail()
        {
            oldBank = tbBank.Text;
            oldIDNum = tbIDNum.Text;
            oldNum = tbNum.Text;
            oldPhone = tbPhone.Text;
        }
        private void driverDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillCurrentDriverData();
            saveOldDetail();
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataTable table = new DataTable();
                command = connection.CreateCommand();
                command.CommandText = "select tx.MaTX, tt.HoTen, tt.SoDienThoai, kv.TenKV, tx.CMND, tx.PhiThueChan from THONGTINCANHAN tt, TAIXE tx, KHUVUC kv where tt.ID = tx.ID and kv.MaKV = tx.MaKV and CMND = @CMND";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@CMND", searchBox.Text);
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                driverDGV.DataSource = table;
                searchBox.Text = placeholder;

                refreshDetail();
            }
        }
    }
}
