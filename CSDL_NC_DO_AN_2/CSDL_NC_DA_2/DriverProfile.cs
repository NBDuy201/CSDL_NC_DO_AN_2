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
    public partial class DriverProfile : Form
    {
        int ID;
        SqlCommand command;
        SqlConnection connection;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string str = @"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True";

        public DriverProfile(int _ID)
        {
            InitializeComponent();
            ID = _ID;
            connection = new SqlConnection(str);
            connection.Open();
            loadComboBoxArea();
            loadData();
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
        private void loadData()
        {
            DataTable tb = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select tx.MaKV, tx.MaTX, kv.TenKV, tt.HoTen, tx.BienSoXe, tx.CMND, tt.SoDienThoai, tx.SoTaiKhoan, tx.PhiThueChan, tt.DiaChi, tt.Email from THONGTINCANHAN tt, TAIXE tx, KHUVUC kv where tt.ID = tx.ID and kv.MaKV = tx.MaKV and tx.ID = @ID";
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@ID", ID);
            adapter.SelectCommand = command;
            tb.Clear();
            adapter.Fill(tb);

            cbbArea.DisplayMember = tb.Rows[0]["TenKV"].ToString();
            cbbArea.SelectedValue = tb.Rows[0]["MaKV"].ToString();
            if (tb.Rows[0]["PhiThueChan"].ToString() == "0")
            {
                phiThueChan.Text = "Chưa đống phí thuế chân.";
            }
            else
            {
                phiThueChan.Text = "Đã đóng phí thuế chân.";
            }
            nameTb.Text = tb.Rows[0]["HoTen"].ToString();
            tbBSX.Text = tb.Rows[0]["BienSoXe"].ToString();
            tbCMND.Text = tb.Rows[0]["CMND"].ToString();
            phoneNumTb.Text = tb.Rows[0]["SoDienThoai"].ToString();
            tbBank.Text = tb.Rows[0]["SoTaiKhoan"].ToString();
            cbbArea.SelectedItem = tb.Rows[0]["PhiThueChan"].ToString();
            addressTb.Text = tb.Rows[0]["DiaChi"].ToString();
            emailTb.Text = tb.Rows[0]["Email"].ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            nameTb.ReadOnly = false;
            addressTb.ReadOnly = false;
            phoneNumTb.ReadOnly = false;
            emailTb.ReadOnly = false;
            tbBank.ReadOnly = false;
            tbCMND.ReadOnly = false;
            tbBSX.ReadOnly = false;
            cbbArea.Enabled = true;

        }
        private bool anyBlankDetail()
        {
            if (nameTb.Text == "" || phoneNumTb.Text == "" || addressTb.Text == "" || emailTb.Text == "" || tbBank.Text == "" || tbBSX.Text == "" || tbCMND.Text == "" || cbbArea.SelectedItem == null)
            {
                return true;
            }
            return false;
        }
        private void saveData()
        {
            if (anyBlankDetail())
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin.");
            }
            else
            {
                DialogResult confirm = MessageBox.Show("Xác nhận cập nhật thông tin?", "Cập Nhật Thông Tin Cá Nhân", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update TAIXE set MaKV = @MaKV, BienSoXe = @BienSoXe, CMND = @CMND, SoTaiKhoan = @SoTaiKhoan where ID = @ID", connection);
                        SqlCommand cmd2 = new SqlCommand("update THONGTINCANHAN set HoTen = @HoTen, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email where ID = @ID", connection);
                        cmd.Parameters.AddWithValue("@MaKV", cbbArea.SelectedValue);
                        cmd.Parameters.AddWithValue("@BienSoXe", tbBSX.Text);
                        cmd.Parameters.AddWithValue("@CMND", tbCMND.Text);
                        cmd.Parameters.AddWithValue("@SoTaiKhoan", tbBank.Text);
                        cmd.Parameters.AddWithValue("@ID", ID);

                        cmd2.Parameters.AddWithValue("@HoTen", nameTb.Text);
                        cmd2.Parameters.AddWithValue("@SoDienThoai", phoneNumTb.Text);
                        cmd2.Parameters.AddWithValue("@DiaChi", addressTb.Text);
                        cmd2.Parameters.AddWithValue("@Email", emailTb.Text);
                        cmd2.Parameters.AddWithValue("@ID", ID);

                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        nameTb.ReadOnly = true;
                        addressTb.ReadOnly = true;
                        phoneNumTb.ReadOnly = true;
                        emailTb.ReadOnly = true;
                        tbBank.ReadOnly = true;
                        tbCMND.ReadOnly = true;
                        tbBSX.ReadOnly = true;
                        cbbArea.Enabled = false;
                        MessageBox.Show("Cập nhật thông tin thành công.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }
    }
}
